/*
 * User: oIo
 * Date: 11/15/2010 ? 2:33 AM
 */
using System;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace System.Cor3.Reflection
{
	// Because this class is derived from MarshalByRefObject, a proxy
	// to a MarshalByRefType object can be returned across an AppDomain
	// boundary.
	public class MarshalByRefType : MarshalByRefObject
	{
		//  Call this method via a proxy.
		public void SomeMethod(string callingDomainName)
		{
			// Get this AppDomain's settings and display some of them.
			AppDomainSetup ads = AppDomain.CurrentDomain.SetupInformation;
			Global.statY(
				"AppName={0}, AppBase={1}, ConfigFile={2}",
				ads.ApplicationName,
				ads.ApplicationBase,
				ads.ConfigurationFile
			);
			// Display the name of the calling AppDomain and the name
			// of the second domain.
			// NOTE: The application's thread has transitioned between
			// AppDomains.
			Global.statY(
				"Calling from '{0}' to '{1}'.",
				callingDomainName, System.Threading
				.Thread.GetDomain().FriendlyName
			);
		}
	}
}
