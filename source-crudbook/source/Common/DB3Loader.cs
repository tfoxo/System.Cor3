/* oio * 5/29/2014 * Time: 6:42 AM
 */

using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
namespace crudbook
{
	class DB3Loader : INotifyPropertyChanged
	{
		#region IBindCommands implementation
		public class LoadDb3FileCmd : BasicCommand
		{
			public DB3Loader Loader {
				get;
				set;
			}

			// we can always load a new file.
			public override bool CanExecute(object parameter)
			{
				return true;
			}

			public override void Execute(object parameter)
			{
				Console.WriteLine("Load SQL clicked");
				//				var ed = parameter as SQLiteUtil.Controls.Editor;
				//				Loader.Load();
				//				if (Loader.IsLoaded)
				//					ed.Load(Loader.SqlFile);
			}
		}

		static public ICommand LoadDb3FileCommand;

		public class SaveDb3FileCmd : BasicCommand
		{
			public DB3Loader Loader {
				get;
				set;
			}

			// we can always load a new file.
			public override bool CanExecute(object parameter)
			{
				return true;
			}

			public override void Execute(object parameter)
			{
				//				var ed = parameter as SQLiteUtil.Controls.Editor;
				//				Loader.Save(ed.Text);
			}
		}

		static public ICommand SaveDb3FileCommand;

		public class SaveDb3FileAsCmd : BasicCommand
		{
			public DB3Loader Loader {
				get;
				set;
			}

			// we can always load a new file.
			public override bool CanExecute(object parameter)
			{
				return true;
			}

			public override void Execute(object parameter)
			{
				// var ed = parameter as SQLiteUtil.Controls.Editor;
				// Loader.SaveAs(ed.Text);
			}
		}

		static public ICommand SaveDb3FileAsCommand;

		public void UpdateBindings(UserControl control)
		{
			Console.WriteLine("DB3 FileLoader.UpdateBindings");
			LoadDb3FileCommand = new LoadDb3FileCmd {
				Loader = this
			};
			SaveDb3FileCommand = new SaveDb3FileCmd {
				Loader = this
			};
			SaveDb3FileAsCommand = new SaveDb3FileAsCmd {
				Loader = this
			};
			control.CommandBindings.Add(new CommandBinding(LoadDb3FileCommand));
			control.CommandBindings.Add(new CommandBinding(SaveDb3FileCommand));
			control.CommandBindings.Add(new CommandBinding(SaveDb3FileAsCommand));
		}

		#endregion
		public DB3Loader()
		{
		}

		#region FileDialogs
		static public readonly OpenFileDialog OfdDb3 = new OpenFileDialog() {
			Filter = "SQLite Database File (*.db3)|*.db3;*.sqlite|All files|*"
		};

		static public readonly SaveFileDialog SfdDb3 = new SaveFileDialog() {
			Filter = "SQLite Database File (*.db3)|*.db3;*.sqlite|All files|*"
		};

		static public readonly SaveFileDialog SfdDb3As = new SaveFileDialog() {
			Filter = "SQLite Database File (*.db3)|*.db3;*.sqlite|All files|*"
		};

		#endregion
		#region DataFile loader and property
		public string Db3File {
			get {
				return db3File;
			}
			set {
				db3File = value;
				OnProperty("Db3File");
			}
		}

		string db3File;

		public bool IsLoaded {
			get {
				return isLoaded;
			}
			set {
				isLoaded = value;
				OnProperty("IsLoaded");
			}
		}

		bool isLoaded = false;

		public void Load()
		{
			bool? value = OfdDb3.ShowDialog();
			if (!(value.HasValue && value.Value))
				return;
			Load(OfdDb3.FileName);
		}

		public void Load(string file)
		{
			Db3File = file;
			IsLoaded = File.Exists(Db3File);
		}

		public void Save(string text)
		{
			bool? value = false;
			// show file-dialog if no file has previously been loaded
			if (IsLoaded != true) {
				value = SfdDb3.ShowDialog();
				// if loaded file exists, set our SqlFile
				if (File.Exists(SfdDb3.FileName))
					this.Db3File = SfdDb3.FileName;
			}
			// Otherwise, just save the file
			File.WriteAllText(Db3File, text);
		}

		/// <summary>
		/// Here, we are always using a file-dialog to save the file.
		/// </summary>
		/// <param name="text"></param>
		public void SaveAs(string text)
		{
			bool? value = SfdDb3As.ShowDialog();
			// If FileDialog points to file, write text.
			if (value.HasValue && value.Value) {
				Db3File = SfdDb3.FileName;
				IsLoaded = true;
				File.WriteAllText(Db3File, text);
				return;
			}
		}

		#endregion
		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;

		void OnProperty(string prop)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	#endregion
	}
	
}



