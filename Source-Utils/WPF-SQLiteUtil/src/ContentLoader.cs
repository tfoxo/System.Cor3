/* oio : 03/10/2014 00:34 */
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Windows;
using Microsoft.Win32;
using SQLiteUtil.Views;
namespace SQLiteUtil
{
	/// <summary>
	/// Loads lorem ipsum content regardless the given uri.
	/// </summary>
	public class ContentLoader : DefaultContentLoader
	{
		static ContentLoader()
		{
			DefaultView = new SQLiteView();
		}
//		public GeneratorModel Model;
//		MoxiView moxi;
		static public readonly SQLiteView DefaultView;
		/// <summary>
		/// Loads the content from specified uri.
		/// </summary>
		/// <param name="uri">The content uri</param>
		/// <returns>The loaded content.</returns>
		protected override object LoadContent(Uri uri)
		{
//			if (moxi == null) moxi = new MoxiView();
			switch (uri.OriginalString)
			{
				case "/1": return DefaultView;
			}
//			ModernDialog.ShowMessage("This is a simple Modern UI styled message dialog. Do you like it?", "Message Dialog", MessageBoxButton.OK);
			return base.LoadContent(uri);
		}
	}
}




