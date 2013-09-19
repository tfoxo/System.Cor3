/* oOo * 11/28/2007 : 5:29 PM */
using System;
using System.Cor3.Drawing;
using System.Drawing.Utilities.SuperOld;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace System.Drawing
{

	public delegate void AutoIncrEvent(string file, int i);
	public class AutoIncr
	{
		string autopath;
		public string	FilePath { get { return autopath; } set { autopath = value; } }
	
		string	fileName = "file";
		public string FileName { get { return fileName; } set { fileName = value; } }
	
		string	fileExt = ".png";
		public string	FileExt { get { return fileExt; } set { fileExt = CheckExtension(value); } }
	
		public int		AutoIntLen = 3;
		
		public string IntFormat { get { return string.Format("D{0}",AutoIntLen); } }
		public string AutoFormat { get { return "{0}_{1:"+IntFormat+"}{2}"; } }
	
		public string	AutoFile { get { return string.Format(AutoFormat,FileName,ivalue,fileExt); } }
	
		public bool		AutoPathExists { get { return Directory.Exists(autopath); } }
		public bool		AutoFileExists { get { return File.Exists(AutoFile); } }
		public string	FullPath { get { return Path.Combine(FilePath,AutoFile); } }
	
		public void Reset(int NumToReset) { ivalue = NumToReset; }
		public void Reset() { Reset(0); }
	
		int ivalue;
		public int IntValue { get { return ivalue; } }
	
		bool CheckFile(int value) { return File.Exists(string.Format(AutoFormat,FileName,value,fileExt)); }
		string CheckExtension(string ext)
		{
			if (ext[0]!='.') return string.Concat(".",ext);
			return ext;
		}
	
		public int MaximizeIncr() { return MaximizeIncr(0); }
		public int MaximizeIncr(int start)
		{
			do { ivalue++; } while ( CheckFile(start) );
			return ivalue;
		}
		
		public event AutoIncrEvent IncrEvent;
		//
		virtual protected void OnIncrament(string file, int i) { if (IncrEvent != null) IncrEvent(file,i); }
		virtual public int Incrament() { OnIncrament(FullPath, this.ivalue++); return ivalue; }
	
		public AutoIncr(string filen, string file_ext) : this(filen,file_ext,0) {}
		public AutoIncr() : this("file",".png",0) { }
		public AutoIncr(string file_name, string file_ext, int start_a) :
			this(Path.GetDirectoryName(Application.ExecutablePath),file_name,file_ext,start_a) { }
		public AutoIncr(string start_path, string file_name, string file_ext, int start_a)
		{
			FilePath = start_path;
			FileName = file_name;
			FileExt = file_ext;
			ivalue = MaximizeIncr(start_a);
		}
	}
}
