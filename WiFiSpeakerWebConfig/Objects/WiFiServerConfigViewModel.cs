using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
namespace WiFiSpeakerWebConfig.Objects
{
    public class ServerConfigViewModel
    {
        public string ServerName { get; set; }
        public string Version { get; set; }
        public UserModel LoggedInUser { get; set; }

        public IEnumerable<ConfigError> ConfigErrors { get; set; }
        public IEnumerable<ClientViewModel> Clients { get; set; }
        public IEnumerable<ConfiguredAudioSourceViewModel> ConfiguredAudioSources { get; set; }
    }

    public class ConfigError
    {
        public string Description { get; set; }
        public ConfigError(string description)
        {
            this.Description = description;
        }
    }

    public class ClientViewModel
    {
        public string ClientName { get; set; }
        public IPEndPoint Endpoint { get; set; }
    }

    public class ConfiguredAudioSourceViewModel
    {
        public string ConfiguredName { get; set; }
        public string HardwareName { get; set; }
        public string Status { get; set; }
    }
}