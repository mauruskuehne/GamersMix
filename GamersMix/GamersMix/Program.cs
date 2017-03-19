using System;
using System.Threading;

namespace GamersMix
{
    internal class Program
    {
        private static void Main()
        {
            var selfHost = (NancySelfHost)null;

            try
            {
                selfHost = new NancySelfHost();
                selfHost.Start();

                Console.ReadLine();
            }
            finally
            {
                if (selfHost != null)
                {
                    selfHost.Stop();
                }
            }
        }
    }
}
