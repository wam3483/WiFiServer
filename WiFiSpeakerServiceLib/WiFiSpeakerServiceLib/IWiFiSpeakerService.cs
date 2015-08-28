using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WiFiSpeakerServiceLib
{
	[ServiceContract]
	public interface IWiFiSpeakerService
	{
		[OperationContract]
		ConfigResult SetConfiguration(ServiceConfigDataModel model);

		ServiceConfigDataModel GetConfiguration();
	}
}