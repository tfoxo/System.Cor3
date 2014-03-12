/* oio : 03/10/2014 00:34 */
using System;
using System.Windows.Input;

namespace SQLiteUtil
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
