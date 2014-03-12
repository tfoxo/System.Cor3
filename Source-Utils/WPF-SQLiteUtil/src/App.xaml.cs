using System;
using System.Windows;

namespace SQLiteUtil
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// For this instance, if App.xaml designates StartupUri,
		/// we would not need to create our main window OnStartup.
		/// </summary>
		[STAThread()]
		static void Main( params string[] args )
		{
			App app = new App();
			app.InitializeComponent();
//			LoadXshdRes("AS3","VisualEditor.Resources.AS3.xshd");
//			LoadXshdRes("CSS2","VisualEditor.Resources.CSS.xshd");
			AvalonEditorUtils.LoadXshdRes("SQL","SQLiteUtil.src.Styles.Sql.xshd");
//			LoadXshdRes("Inno","VisualEditor.Resources.INNO.xshd");
			app.Run();
			//if ( My.Application.Restart )
			//    Process.Start( Assembly.GetEntryAssembly().CodeBase );
		}
		
		public App()
		{
			
		}
	}
}