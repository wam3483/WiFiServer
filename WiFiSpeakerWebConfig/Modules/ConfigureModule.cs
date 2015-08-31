using Nancy;
using Nancy.Security;
using WiFiSpeakerWebConfig.Objects;
using Nancy.ModelBinding;

namespace WiFiSpeakerWebConfig
{
	public class ConfigureModule : NancyModule
	{
		public ConfigureModule(IWiFiSpeakerConfigurationService service)
			: base("/Configure")
		{
			this.RequiresAuthentication();
			Get["/"] = x =>
			{
				
				var user = this.Context.CurrentUser as UserIdentity;
				var userModel = new UserModel(this.Context.CurrentUser.UserName);
				var serviceModel = service.GetConfigurationViewModel();
				var model = new ServerConfigViewModel()
				{
					Config = serviceModel,
					User = userModel,
				};
				return View["Index", model];
			};
			
			Post["/SetConfig"] = x =>
			{
                WiFiServerConfigViewModel model = this.Bind<WiFiServerConfigViewModel>();
				if (model != null)
				{
					service.SetConfigurationViewModel(model);
					var user = this.Context.CurrentUser as UserIdentity;
					var userModel = new UserModel(this.Context.CurrentUser.UserName);
					var serverConfig = new ServerConfigViewModel()
					{
						Config = model,
						User = userModel
					};
					//return View["Index", serverConfig];
				}
                return false;
				//return View["Index", null];
			};
		}
	}
}
