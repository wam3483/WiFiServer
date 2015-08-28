using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiFiSpeakerWebConfig.Objects;
namespace WiFiSpeakerWebConfig
{
    public interface IConfigService
    {
        void SetConfiguration(ServerConfigViewModel config);
        ServerConfigViewModel GetConfiguration();
    }
    public class MockConfigService : IConfigService
    {
        private ServerConfigViewModel config;
        public ServerConfigViewModel GetConfiguration()
        {
            return config;
        }

        public void SetConfiguration(ServerConfigViewModel config)
        {
            this.config = config;
        }
    }
}
