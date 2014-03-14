using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

using FirstFloor.ModernUI.Presentation;

namespace GeneratorTool.Views
{
	public class BasicCommand : ICommand
	{
		// Get list of elements
		public bool CanExecuteCommand {
			get { return canExecuteCommand; }
			set { canExecuteCommand = value; if (CanExecuteChanged!=null) CanExecuteChanged(this,EventArgs.Empty); }
		} bool canExecuteCommand = true;
		
		public event EventHandler CanExecuteChanged;
		
		virtual public bool CanExecute(object parameter) { return canExecuteCommand; }
		
		virtual public void Execute(object parameter)
		{
			throw new NotImplementedException();
		}
	}
}
