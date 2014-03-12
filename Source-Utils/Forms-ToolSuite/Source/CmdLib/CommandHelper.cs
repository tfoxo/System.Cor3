#region User/License
// oio * 8/20/2012 * 8:17 AM

// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using XmlWriter=System.Xml.XmlWriter;
using XmlReader=System.Xml.XmlReader;
using XmlReaderSettings=System.Xml.XmlReaderSettings;
using XmlWriterSettings=System.Xml.XmlWriterSettings;
using MemoryStream=System.IO.MemoryStream;
namespace TemplateTool.CmdLib
{
	/// <summary>
	/// The idea would be to populate task parameters with values using
	/// windows-forms or WPF OpenFileDialog/SaveFileDialog for File in/out,
	/// and standard conversion helpers for ui to task value strategy.
	/// </summary>
	public class CommandHelper
	{
		/// <summary>
		/// On error returns -1, otherwise returns the number of parameters for the task.
		/// <para>Note that we send in a string array with a count of 1 (eg: string[1]).</para>
		/// </summary>
		/// <param name="task">Type reccomeded is derived from SimpleGenericCommand.</param>
		/// <returns></returns>
		static public int GetTaskParamCount(Type task)
		{
			ITaskCommandProvider commandtask = TaskFromType(task,new string[1]);
			int count = -1;
			if (commandtask!= null) count = commandtask.InputParamCount;
			commandtask = null;
			GC.Collect();
			return count;
		}

		#region Input File Type Checks
		
		static public bool IsSingleFileInput(ITaskCommandProvider command, string paramId)
		{
			switch (command.ParameterTypes[paramId])
			{
				case ParamType.InputFile:
					case ParamType.OutputFile: return true;
					default: return false;
			}
		}
		static public bool IsMultiFileInput(ITaskCommandProvider command, string paramId)
		{
			switch (command.ParameterTypes[paramId])
			{
				case ParamType.InputFileArray:
					case ParamType.OutputFileArray: return true;
					default: return false;
			}
		}
		#endregion
		
		#region Input String Type Checks
		static public bool IsStringInput(ITaskCommandProvider command, string paramId)
		{
			switch (command.ParameterTypes[paramId])
			{
					case ParamType.String: return true;
					default: return false;
			}
		}
		static public bool IsStringArrayInput(ITaskCommandProvider command, string paramId)
		{
			switch (command.ParameterTypes[paramId])
			{
					case ParamType.StringArray: return true;
					default: return false;
			}
		}

		#endregion
		
		#region DictionaryHelp
		static public KeyValuePair<TKey,TValue> GetIndexedPair<TKey,TValue>(IDictionary<TKey,TValue> dic, int index)
		{
			if (index == -1 || (index) >= (dic.Count)) throw new IndexOutOfRangeException();
			KeyValuePair<TKey,TValue> value = dic.Skip(index).FirstOrDefault();
			Debug.Print("Index: {0}, Key: {1}",index,value.Key);
			return value;
		}
		#endregion
		
		static public object TryGetParameterValue(ITaskCommandProvider command, string paramId)
		{
			string fileFilter = command.ParameterFilters.Keys.Contains(paramId) ?
				command.ParameterFilters[paramId] :
				"All Files (*)|*";
			object returned = command.InputParameters[paramId];
			switch (command.ParameterTypes[paramId])
			{
				case ParamType.InputFile:
					using (OpenFileDialog ofd = new OpenFileDialog()) {
						if (Helper.DialogResultIsOK(ofd,fileFilter))
							returned = ofd.FileName;
					}
					break;
				case ParamType.OutputFile:
					using (SaveFileDialog ofd = new SaveFileDialog()) {
						if (Helper.DialogResultIsOK(ofd,fileFilter))
							returned = ofd.FileName;
					}
					break;
//				case ParamType.String:
//					returned = command.InputParameters[paramId];
//					break;
				default:
					break;
			}
			return returned;
		}
		
		static public void TrySetParameterValue(ITaskCommandProvider command, string paramId, string value)
		{
			command.InputParameters[paramId] = value;
		}

		static public string SerializeCommandXml(ITaskCommandProvider command)
		{
			string output = string.Empty;
			byte[] buffer = new byte[0];
			buffer.Initialize();
			using (MemoryStream ms = new MemoryStream())
				using (XmlWriter writer = XmlWriter.Create(ms,new XmlWriterSettings()))
			{
				writer.WriteStartDocument();
				writer.WriteStartElement("commandset");
				writer.WriteStartElement("command");
				writer.WriteAttributeString("TaskName",command.TaskName);
				writer.WriteAttributeString("Type",command.GetType().Name);
				foreach (string Key in command.InputParamKeys)
				{
					if (!string.IsNullOrEmpty(command.InputParameters[Key]))
					{
						writer.WriteStartElement("parameter");
						writer.WriteAttributeString("Key",Key);
						writer.WriteAttributeString("Value",command.InputParameters[Key]);
						writer.WriteEndElement();
					}
				}
				writer.WriteEndElement();
				writer.WriteEndDocument();
				writer.Flush();
				ms.Position = 0L;
				output = System.Text.Encoding.UTF8.GetString(ms.ToArray());
				writer.Close();
				ms.Close();
				buffer = null;
			}
			GC.Collect();
			return output;
		}
		
		static public void CommandXmlTest(ITaskCommandProvider command, string content)
		{
			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(content);
			using (MemoryStream ms = new MemoryStream(buffer))
				using (XmlReader reader = new System.Xml.XmlTextReader(ms))
			{
				reader.Read();
				Debug.Print("First Element Type: {0}, Name: {1}", reader.NodeType, reader.Name);
				while (reader.Read())
				{
					int i = 0;
					Debug.Print("In Reader Loop");
					switch (reader.Name)
					{
						case "command":
							Debug.Print("command0, Type: {0}, Name: {1}, Attrs: {2}", reader.NodeType, reader.Name, reader.AttributeCount);
							i = reader.AttributeCount;
							for (i=0; i<reader.AttributeCount; i++)
							{
								reader.MoveToAttribute(i);
								Debug.Print("attr, Type: {0}, Name: {1}, Value: {2}", reader.NodeType, reader.Name, reader.Value);
							}
							break;
						case "parameter":
							Debug.Print("parameter, Type: {0}, Name: {1}, Attrs: {2}", reader.NodeType, reader.Name, reader.AttributeCount);
							i = reader.AttributeCount;
							for (i=0; i<reader.AttributeCount; i++)
							{
								reader.MoveToAttribute(i);
								Debug.Print("attr, Type: {0}, Name: {1}, Value: {2}", reader.NodeType, reader.Name, reader.Value);
							}
							break;
						case "commandset":
							Debug.Print("commandset, Type: {0}, Name: {1}", reader.NodeType, reader.Name);
							break;
						default:
							Debug.Print("?, Type: {0}, Name: {1}",reader.NodeType, reader.Name);
							break;
					}
				}
			}
//			return output;
		}
		
		/// <summary>
		/// attempts creation of a task from a Type.
		/// </summary>
		/// <param name="task"></param>
		/// <param name="taskParameters"></param>
		/// <returns></returns>
		static public ITaskCommandProvider TaskFromType(Type task, params string[] taskParameters)
		{
			if (task==null) return null;
			ITaskCommandProvider commandtask = null;
//			try {
			commandtask = (ITaskCommandProvider)Activator.CreateInstance(task,"");
//			}
//			catch (Exception error) { Debug.Print("{0}",error); }
			return commandtask;
		}
	}
}
