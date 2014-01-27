/*
 * User: oio
 * Date: 1/31/2012
 * Time: 6:57 AM
 */
#region Using
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shell;

using Microsoft.Win32;

#endregion
namespace GeneratorTool
{
	public abstract class CommandManager<TContainer> where TContainer:FrameworkElement
	{
		internal TContainer Container { get;set; }
		internal CommandBindingCollection Commands;
		
		protected internal CommandManager(TContainer container)
		{
			this.Container = container;
			this.Commands = new CommandBindingCollection();
			this.InitializeCommands();
			this.AttachCommands();
		}
		
		abstract public void InitializeCommands();
		
		virtual public void AttachCommands()
		{
			foreach (CommandBinding binding in Commands)
			{
				if (!this.Container.CommandBindings.Contains(binding))
					this.Container.CommandBindings.Add(binding);
			}
		}
		virtual public void RemoveCommands()
		{
			foreach (CommandBinding binding in Commands)
			{
				if (this.Container.CommandBindings.Contains(binding))
					this.Container.CommandBindings.Remove(binding);
			}
		}
	}
}
