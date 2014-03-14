/* oio : 1/21/2014 9:33 AM */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;
using Generator.Core.Entities;
using Generator.Core.Entities.Types;
using Generator.Core.Markup;
namespace GeneratorTool.Views
{
	
	//http://nerobrain.blogspot.com/2012/01/execute-command-on-combobox-selection.html
	static class SelectionChangedBehaviour
	{
		public static readonly DependencyProperty CommandProperty =
			DependencyProperty.RegisterAttached(
				"Command",
				typeof(ICommand),
				typeof(SelectionChangedBehaviour),
				new PropertyMetadata(PropertyChangedCallback));

		public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
		{
			//System.Diagnostics.Debug.WriteLine("Dependency {0}: {1}", depObj.GetType().Name, depObj);
			if (depObj is TreeView)
			{
				TreeView tv = (TreeView)depObj;
				tv.SelectedItemChanged += SelectionTreeItemChanged;
				return;
			}
			var selector = (Selector)depObj;
			if (selector != null) {
				selector.SelectionChanged += new SelectionChangedEventHandler(SelectionChanged);
			}
		}

		public static ICommand GetCommand(UIElement element)
		{
			return (ICommand)element.GetValue(CommandProperty);
		}

		public static void SetCommand(UIElement element, ICommand command)
		{
			element.SetValue(CommandProperty, command);
		}

		private static void SelectionTreeItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var selector = (TreeView)sender;
			if (selector != null) {
				var command = selector.GetValue(CommandProperty) as ICommand;
				if (command != null) {
					command.Execute(selector.SelectedItem);
				}
			}
		}
		private static void SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (sender is TreeView)
			{
				
				return;
			}
			var selector = (Selector)sender;
			if (selector != null) {
				var command = selector.GetValue(CommandProperty) as ICommand;
				if (command != null) {
					command.Execute(selector.SelectedItem);
				}
			}
		}
	}
}

