/* oio * 10/29/2013 * 2:07 AM */
using Autofac;
using Caliburn.Metro.Autofac;
using Caliburn.Micro;

namespace FeedTool.AppManager
{
	public class AppBootstrapper : CaliburnMetroAutofacBootstrapper<AppViewModel>
	{
		protected override void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterType<AppWindowManager>().As<IWindowManager>().SingleInstance();
			var assembly = typeof(AppViewModel).Assembly;
			builder.RegisterAssemblyTypes(assembly).Where(item => item.Name.EndsWith("ViewModel") && item.IsAbstract == false).AsSelf().SingleInstance();
		}
	}
	
}
