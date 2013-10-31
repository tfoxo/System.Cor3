/* oio * 10/29/2013 * 2:07 AM */
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Dynamic;
using System.Windows;

using Caliburn.Micro;

namespace FeedTool.AppManager
{
//	[Export(typeof(AppViewModel))]
	public class AppViewModel : PropertyChangedBase, IHaveDisplayName
	{
        private string _displayName = "FeedTool";

        private readonly IWindowManager _windowManager;
        public AppViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public void OpenWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.Manual;

            _windowManager.ShowWindow(new AppViewModel(_windowManager), null, settings);
        }

        public void OpenSettings()
        {
            IsSettingsFlyoutOpen = true;
        }

        private bool _isSettingsFlyoutOpen;

        public bool IsSettingsFlyoutOpen
        {
            get { return _isSettingsFlyoutOpen; }
            set
            {
                _isSettingsFlyoutOpen = value;
                NotifyOfPropertyChange(() => IsSettingsFlyoutOpen);
            }
        }

	
	}
}
