using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseService
{
    class Program
    {
        static void Main(string[] args)
        {

            var appServer = new GreenHouseServer();
            var config = new ServerConfig();
            config.Port = 2012;
            config.TextEncoding = "utf-8";
            if (!appServer.Setup(config))
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }

            if (!appServer.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            //Stop the appServer
            appServer.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }
    }
}
