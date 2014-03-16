using System;
using System.Linq;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using Generator.Core.Entities;
namespace GeneratorTool.Views
{
	public class PasteFieldAboveCmd : BasicCommand
	{
		public MoxiView View {
			get;
			set;
		}

		public override bool CanExecute(object parameter)
		{
			if (View == null || View.Model == null || View.Model.ClipboardItem == null)
				return false;
			return true;
		}

		protected override void OnExecute(object parameter)
		{
			var field = parameter as FieldElement;
			if (field == null) {
				ModernDialog.ShowMessage("no field detected.", "error", MessageBoxButton.OK);
				return;
			}
			//			else ModernDialog.ShowMessage(parameter.ToString(), "Good!", MessageBoxButton.OK);
			var parent = field.Parent;
			int index = parent.Fields.IndexOf(field);
			var elm = FieldElement.Clone(View.Model.ClipboardItem as FieldElement);
			elm.Parent = parent;
			elm.DataName = string.Format("{0} (copy)", elm.DataName);
			parent.Fields.Insert(index, elm);
			parent.Fields = parent.Fields;
		}
	}
}






