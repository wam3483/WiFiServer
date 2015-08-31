using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WiFiSpeakerServiceLib;
using System.ServiceModel;
using WiFiSpeakerWebConfig.Objects;
namespace WiFiSpeakerWebConfig
{
	public interface IWiFiSpeakerConfigurationService
	{
		WiFiServerConfigViewModel GetConfigurationViewModel();
		void SetConfigurationViewModel(WiFiServerConfigViewModel model);
	}

	public class MockWiFiSpeakerConfigurationService : IWiFiSpeakerConfigurationService
	{
		WiFiServerConfigViewModel model;
		public MockWiFiSpeakerConfigurationService()
		{
			model = new WiFiServerConfigViewModel()
			{
				ServerName = "my server",
				Version = "2.0",
                ConfiguredAudioSources = new ConfiguredAudioSourceViewModel[]
                {
                    new ConfiguredAudioSourceViewModel() {ConfiguredName="test1",HardwareName="h1" },
                    new ConfiguredAudioSourceViewModel() {ConfiguredName="test2",HardwareName="h2" },
                    new ConfiguredAudioSourceViewModel() {ConfiguredName="test3",HardwareName="h3" },
                    new ConfiguredAudioSourceViewModel() {ConfiguredName="test4",HardwareName="h4" },
                    new ConfiguredAudioSourceViewModel() {ConfiguredName="test5",HardwareName="h5" },
                }
			};
		}

		public WiFiServerConfigViewModel GetConfigurationViewModel()
		{
			return model;
		}

		public void SetConfigurationViewModel(WiFiServerConfigViewModel model)
		{
			this.model = model;
		}
	}

	public class WiFiSpeakerConfigurationService : IWiFiSpeakerConfigurationService
	{
		const string serviceAddress = "";

		public WiFiSpeakerConfigurationService() { }

		public WiFiServerConfigViewModel GetConfigurationViewModel()
		{
			var service = CreateService();
			if (service != null)
			{
				ServiceConfigDataModel model = service.GetConfiguration();
				var viewModel = new WiFiServerConfigViewModel()
				{
					Version = model.Version,
					ServerName = model.ServerName,
					Clients = model.Clients.Select(s => new ClientViewModel()
					{
						ClientName = s.ClientName,
						Endpoint = s.Endpoint
					}),
					ConfiguredAudioSources = model.ConfiguredAudioSources.Select(s => new ConfiguredAudioSourceViewModel()
					{
						ConfiguredName = s.ConfiguredName,
						HardwareName = s.HardwareName,
					}),
					AudioSources = model.AudioSources.Select(s => new AudioSourceViewModel()
					{
						Status = s.Status,
						HardwareName = s.HardwareName
					})
				};
				return viewModel;
			}
			return null;
		}

		private IWiFiSpeakerService CreateService()
		{
			try
			{
				NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
				EndpointAddress endpoint = new EndpointAddress(serviceAddress);
				var service = ChannelFactory<IWiFiSpeakerService>.CreateChannel(binding, endpoint);
				return service;
			}
			catch
			{
				//TODO what do with error?
			}
			return null;
		}

		public void SetConfigurationViewModel(WiFiServerConfigViewModel model)
		{
			throw new NotImplementedException();
		}
	}
}
