using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.Conventions;

namespace WiFiSpeakerWebConfig
{
	public class FormsAuthBootstrapper : DefaultNancyBootstrapper
	{
		TinyIoCContainer iocContainer;

		public FormsAuthBootstrapper()
		{
		}
		private void RegisterForTest(TinyIoCContainer container)
		{
			container.Register<IWiFiSpeakerConfigurationService, MockWiFiSpeakerConfigurationService>().AsSingleton();

			iocContainer.Register<IUserMapper, UserDatabase>().AsSingleton();
		}

		protected override TinyIoCContainer CreateRequestContainer(NancyContext context)
		{
			if (iocContainer == null)
			{
				iocContainer = base.CreateRequestContainer(context);
				RegisterForTest(iocContainer);
			}
			return iocContainer;
		}
		protected override void ConfigureConventions(NancyConventions nancyConventions)
		{
			nancyConventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("/assets")
			);
			base.ConfigureConventions(nancyConventions);
		}
		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			// We don't call "base" here to prevent auto-discovery of
			// types/dependencies
		}

		protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
		{
			// Here we register our user mapper as a per-request singleton.
			// As this is now per-request we could inject a request scoped
			// database "context" or other request scoped services.
			base.ConfigureRequestContainer(container, context);
		}

		protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
		{
			// At request startup we modify the request pipelines to
			// include forms authentication - passing in our now request
			// scoped user name mapper.
			//
			// The pipelines passed in here are specific to this request,
			// so we can add/remove/update items in them as we please.
			var formsAuthConfiguration =
				new FormsAuthenticationConfiguration()
				{
					RedirectUrl = "~/login",
					UserMapper = requestContainer.Resolve<IUserMapper>(),
				};

			FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
		}
	}
}
