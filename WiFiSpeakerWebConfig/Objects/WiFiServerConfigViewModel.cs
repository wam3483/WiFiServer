using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
namespace WiFiSpeakerWebConfig.Objects
{

	public class ServerConfigViewModel
	{
		public WiFiServerConfigViewModel Config { get; set; }
		public UserModel User { get; set; }
	}
	public class WiFiServerConfigViewModel
	{
		public string ServerName { get; set; }
		public string Version { get; set; }

		public IEnumerable<ClientViewModel> Clients { get; set; }
		public IEnumerable<ConfiguredAudioSourceViewModel> ConfiguredAudioSources { get; set; }
		public IEnumerable<AudioSourceViewModel> AudioSources { get; set; }

		public WiFiServerConfigViewModel()
		{
			this.ServerName = "";
			this.Version = "";
			this.Clients = new List<ClientViewModel>();
			this.ConfiguredAudioSources = new List<ConfiguredAudioSourceViewModel>();
			this.AudioSources = new List<AudioSourceViewModel>();
		}
	}

	public class ClientViewModel
	{
		public string ClientName { get; set; }
		public IPEndPoint Endpoint { get; set; }
		public ClientViewModel()
		{
			this.ClientName = "";
		}
	}

	public class ConfiguredAudioSourceViewModel
	{
		public string ConfiguredName { get; set; }
		public string HardwareName { get; set; }
		public ConfiguredAudioSourceViewModel()
		{
			this.ConfiguredName = "";
			this.HardwareName = "";
		}
	}

	public class AudioSourceViewModel
	{
		public string HardwareName { get; set; }
		public AudioSourceStatusCode StatusCode { get; set; }
		public string Status { get; set; }
		public AudioSourceViewModel()
		{
			this.HardwareName = "";
			this.Status = "";
			this.StatusCode = AudioSourceStatusCode.Unavailable;
		}
	}

	public enum AudioSourceStatusCode
	{
		NotFound,
		Available,
		Unavailable,
		Unplugged,
	}
}