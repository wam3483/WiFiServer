using System;
using Nancy.Hosting.Self;
using Topshelf;
namespace WiFiSpeakerWebConfig
{
    public class NancySelfHost
    {
        private NancyHost nancyHost;
        private readonly string path = "http://localhost:8888/wifispeaker/";
        public void Start()
        {
            var config = new HostConfiguration()
            {
                UrlReservations = new UrlReservations()
                {
                    CreateAutomatically = true
                }
            };
            nancyHost = new NancyHost(config,new Uri(path));
            nancyHost.Start();
            Console.WriteLine("Nancy now listening - " + path + " Press ctrl-c to stop");
            System.Diagnostics.Process.Start(path);
        }

        public void Stop()
        {
            nancyHost.Stop();
            Console.WriteLine("Stopped. Good bye!");
        }
    }

    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<NancySelfHost>(s =>
                {
                    s.ConstructUsing(name => new NancySelfHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.UseLog4Net();
                x.RunAsLocalSystem();
                x.SetDescription("WiFiSpeaker Topshelf Host");
                x.SetDisplayName("WiFiSpeaker");
                x.SetServiceName("WiFiSpeaker");
            });
        }
    }
}
