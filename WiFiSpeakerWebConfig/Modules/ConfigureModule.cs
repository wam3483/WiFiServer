using Nancy;
using Nancy.Security;
using WiFiSpeakerWebConfig.Objects;

namespace WiFiSpeakerWebConfig
{
    public class ConfigureModule : NancyModule
    {
        public ConfigureModule() : base("/Configure")
        {
            this.RequiresAuthentication();

            Get["/"] = x =>
            {
                var model = new UserModel(this.Context.CurrentUser.UserName);
                return View["Index", model];
            };
        }
    }
}
