using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Net;
namespace WiFiSpeakerServiceLib
{
	[DataContract]
	public class ServiceConfigDataModel
	{
		public string ServerName { get; set; }
		public string Version { get; set; }

		public IEnumerable<Client> Clients { get; set; }
		public IEnumerable<ConfiguredAudioSource> ConfiguredAudioSources { get; set; }
		public IEnumerable<AudioSource> AudioSources { get; set; }
	}

	public enum ConfigResult
	{
		Failed,
		Success,
	}
	
	[DataContract]
	public class Client
	{
		public string ClientName { get; set; }
		public IPEndPoint Endpoint { get; set; }
	}
	
	[DataContract]
	public class ConfiguredAudioSource
	{
		public string ConfiguredName { get; set; }
		public string HardwareName { get; set; }
	}

	[DataContract]
	public class AudioSource
	{
		public string HardwareName { get; set; }
		public string Status { get; set; }
	}
}