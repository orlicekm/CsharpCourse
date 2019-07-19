using System;
using System.Collections.Generic;

namespace Samples.Creational
{
    public class SingletonSample
    {
        public static void Main()
        {
            var b1 = LoadBalancer.Instance;
            var b2 = LoadBalancer.Instance;
            var b3 = LoadBalancer.Instance;
            var b4 = LoadBalancer.Instance;

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            var balancer = LoadBalancer.Instance;
            for (var i = 0; i < 15; i++)
            {
                var server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }
        }
    }

    /// <summary>
    /// https://csharpindepth.com/Articles/Singleton
    /// </summary>
    internal class LoadBalancer
    {
        private readonly Random random = new Random();
        private readonly List<string> servers = new List<string>();

        protected LoadBalancer()
        {
            servers.Add("ServerI");
            servers.Add("ServerII");
            servers.Add("ServerIII");
            servers.Add("ServerIV");
            servers.Add("ServerV");
        }

        public static LoadBalancer Instance { get; } = new LoadBalancer();

        // Random load balancer
        public string Server
        {
            get
            {
                var r = random.Next(servers.Count);
                return servers[r];
            }
        }
    }
}