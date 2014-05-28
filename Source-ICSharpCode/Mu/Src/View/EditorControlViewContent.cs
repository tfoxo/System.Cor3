using System;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Workbench;

namespace Mu.View
{
	public class EditorControlViewContent : AbstractViewContent
	{
		EditorControl content = new EditorControl();
		
		
		public override object Control {
			get {
				return content;
			}
		}
		
		public EditorControlViewContent()
		{
			this.TitleName = "MuGenerator Tool";
			this.TabPageText = "Editor Control View (Tab)";
		}
	}
}
