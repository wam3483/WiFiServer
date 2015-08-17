using Nancy;
using Nancy.Security;
using WiFiSpeakerWebConfig.Objects;

namespace WiFiSpeakerWebConfig
{
    public class ConfigureModule : NancyModule
    {
        public ConfigureModule()
            : base("/Configure")
        {
            this.RequiresAuthentication();
            Get["/"] = x =>
            {
                var user = this.Context.CurrentUser as UserIdentity;
                var userModel = new UserModel(this.Context.CurrentUser.UserName);
                var configModel = new ServerConfigViewModel();
                configModel.LoggedInUser = userModel;
                var model = configModel;
                return View["Index", model];
            };
        }
    }
}
