using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WiFiSpeakerWebConfig.Objects
{
    public class AudioSourceTileModel
    {
        public string Id { get; set; }
        public string ConfiguredName { get; set; }
        public string HardwareName { get; set; }
        public AudioSourceType SourceType { get; set; }
        public AudioSourceStatus Status { get; set; }

        public AudioSourceTileModel() : this("", "", AudioSourceType.None, AudioSourceStatus.None) { }

        public AudioSourceTileModel(string configuredName, string hardwareName, AudioSourceType sourceType, AudioSourceStatus status)
        {
            this.Id = Guid.NewGuid().ToString("N");
            this.ConfiguredName = configuredName;
            this.HardwareName = hardwareName;
            this.SourceType = sourceType;
            this.Status = status;
        }

        public string BackgroundImageSrc
        {
            get
            {
                switch (this.SourceType)
                {
                    default:
                        return @"assets/img/mic.png";
                }
            }
        }
    }
    public enum AudioSourceType
    {
        None,
        Mic,
        LineIn,
        Loopback
    }
    public enum AudioSourceStatus
    {
        None,
        Unavailable,
        Unplugged,
        Available,
    }
}
