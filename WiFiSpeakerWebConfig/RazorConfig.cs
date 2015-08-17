using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.ViewEngines.Razor;

namespace WiFiSpeakerWebConfig
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "WiFiSpeakerWebConfig";
            yield return "Nancy.ViewEngines.Razor";
            //yield return "WiFiSpeakerWebConfig.Website";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "WiFiSpeakerWebConfig";
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}
