using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.SharpDevelop.Project;

namespace Mu.View
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class EditorControl : UserControl/*, IViewContent*/
	{
		public EditorControl()
		{
			InitializeComponent();
			
		}
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			
			try {
				this.cbProjectF.SelectedItem = ProjectService.CurrentProject;
				this.cbProjectT.SelectedItem = ProjectService.CurrentProject;
				this.tbRelativePath.Text = ProjectService.CurrentProject.Directory;
			}
			catch {
			}
		}
		
		void Event_DoExecute1(object sender, RoutedEventArgs e)
		{
//			this.editor.Text = ProjectItem_Utility.ExecuteProjectCommand_Orig();
		}
		void Event_DoExecute2(object sender, RoutedEventArgs e)
		{
//			this.editor.Text = ProjectItem_Utility.ExecuteProjectCommand_One();
		}
		/// <summary>
		/// This is the Generation action.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Event_DoExecute3(object sender, RoutedEventArgs e)
		{
//			ProjectService.OpenSolution.Projects.ToArray()[0].Name;
			var selectedproj = cbProjectF.SelectedValue as IProject;
//			tbRelativePath.Text = selectedproj.Location;
			CsProjectItemUtil util = new CsProjectItemUtil(
				new CsProjectItemSettings {
					PreIncludePath = tbIncludeKey.Text,
					Project        = selectedproj,
					IncludeLinks   = false,
					ProjectPath    = selectedproj.Directory
				});
			this.editor.Text = @"    <ItemGroup>@{nodes}
    </ItemGroup>"
				.Replace("@{nodes}",util.SerializeLinks());
			util = null;
		}
		
		void CbProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				var selectedprojfr = cbProjectF.SelectedValue as IProject;
				var selectedprojto = cbProjectT.SelectedValue as IProject;
				if (cbProjectT.SelectedItem != null) tbRelativePath.Text = selectedprojto.Directory;
			}
			catch
			{
				
			}
		}

		#region IHighlighting
		void EditorSyntaxMenuItemClicked(object sender, RoutedEventArgs args)
		{
			MenuItem item = sender as MenuItem;
			PrepareDocumentStrategyFromHighlighting(item.Header.ToString());
		}
		void PrepareDocumentStrategyFromHighlighting(string highlightingDefinition)
		{
			IHighlightingDefinition definition = HighlightingManager.Instance.GetDefinition(highlightingDefinition);
			editor.SyntaxHighlighting = definition;
		}
		#endregion
		
	}

}