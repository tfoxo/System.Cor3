/* oio * 10/29/2013 * 2:07 AM */
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using Caliburn.Metro;
using Caliburn.Metro.Core;
using Caliburn.Micro;
using FeedTool.ViewMain;
using MahApps.Metro.Controls;

namespace FeedTool.AppManager
{
    public class AppWindowManager : MetroWindowManager
    {
        public override MetroWindow CreateCustomWindow(object view, bool windowIsView)
        {
            if (windowIsView)
            {
                return view as MainWindowContainer;
            }

            return new MainWindowContainer
                       {
                           Content = view
                       };
        }
    }

}
