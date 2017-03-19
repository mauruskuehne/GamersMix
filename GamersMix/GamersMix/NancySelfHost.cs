using System;
using Nancy.Hosting.Self;

namespace GamersMix
{
    public class NancySelfHost
    {
        private NancyHost _nancyHost;

        public void Start()
        {
            _nancyHost = new NancyHost(new Uri("http://localhost:30000"));
            _nancyHost.Start();
            Console.Write("Nancy started");
        }

        public void Stop()
        {
            _nancyHost.Stop();
            Console.WriteLine("Nancy stopped");
        }
    }
}       
