using System;
using ICSharpCode.SharpDevelop.Gui;

namespace Mu.View
{
	public class EditorControlViewContent : AbstractViewContent
	{
		EditorControl content = new EditorControl();
		
		public override void Load(ICSharpCode.SharpDevelop.OpenedFile file, System.IO.Stream stream)
		{
			base.Load(file, stream);
		}
		public override void Save(ICSharpCode.SharpDevelop.OpenedFile file, System.IO.Stream stream)
		{
			base.Save(file, stream);
		}
		
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
