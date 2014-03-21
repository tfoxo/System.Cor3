/*
 * User: oIo
 * Date: 2/5/2011 – 10:00 PM
 */
#region Using
using System;
using System.Collections.Generic;
#endregion
namespace Generator.Core.Entities.Types
{

	public enum ActionTypes
	{
		// Code-Dom Convertable
		@Class, @Module, @Interface, @Type, @Enum,
		// General Windows.Forms Tactics
		@Method, @Property, @Event, @EventHandler,
		// non-sense
		@RoutedEvent, @RoutedEventHandler
	}
}
