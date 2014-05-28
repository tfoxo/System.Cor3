/* oio : 1/8/2014 10:39 PM */
using System;
using System.Windows.Forms;


namespace System.Windows.Forms
{
	static class DragDropFormsExtension
	{
		static public void ApplyDragDropMethod(this TextBox tInput, DragEventHandler TInputDragEnter, DragEventHandler TInputDragDrop)
		{
			// dragdrop
			tInput.AllowDrop =		  true;
			tInput.DragEnter +=	      TInputDragEnter;
			tInput.DragDrop +=		  TInputDragDrop;
		}
		static public void ApplyDefaultDragDrop(this TextBox tInput)
		{
			tInput.ApplyDragDropMethod(Event_TInputDragEnter,Event_TInputDragDrop);
		}
		internal static void Event_TInputDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}
		internal static void Event_TInputDragDrop(object sender, DragEventArgs e)
		{
			TextBox tInput = sender as TextBox;
			if (tInput==null) throw new Exception("Something went very wrong!");
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] strFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
				tInput.Text = strFiles[0];
				strFiles = null;
			}
		}
	}
}
