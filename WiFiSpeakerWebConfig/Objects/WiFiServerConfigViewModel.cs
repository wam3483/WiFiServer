using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
namespace WiFiSpeakerWebConfig.Objects
{
    public class WiFiServerConfigViewModel
    {
        public string ServerName { get; set; }
        public string Version { get; set; }

        public IEnumerable<ClientViewModel> Clients { get; set; }
        public IEnumerable<ConfiguredAudioSourceViewModel> ConfiguredAudioSources { get; set; }
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