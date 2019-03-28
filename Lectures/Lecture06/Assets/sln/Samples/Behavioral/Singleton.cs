using System;
using System.Collections.Generic;

namespace Samples.Behavioral
{
    public class Singleton
    {
        public static void Main()
        {
            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();
            var b3 = LoadBalancer.GetLoadBalancer();
            var b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4) Console.WriteLine("Same instance\n");

            // Load balance 15 server requests
            var balancer = LoadBalancer.GetLoadBalancer();
            for (var i = 0; i < 15; i++)
            {
                var server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }
        }
    }

    internal class LoadBalancer
    {
        private static LoadBalancer instance;
        private static readonly object syncLock = new object();

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

        // Random load balancer
        public string Server
        {
            get
            {
                var r = random.Next(servers.Count);
                return servers[r];
            }
        }

        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (instance == null)
                lock (syncLock)
                {
                    if (instance == null) instance = new LoadBalancer();
                }

            return instance;
        }
    }
}