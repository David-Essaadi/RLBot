using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLBotDotNet;

namespace Kebab
{
    class Program
    {
        static void Main()
        {
            // Read the port from port.cfg.
            const string file = "port.cfg";
            string text = File.ReadAllLines(file)[0];
            int port = int.Parse(text);

            // BotManager is a generic which takes in your bot as its T type.
            BotManager<KebabBot> botManager = new BotManager<KebabBot>();
            // Start the server on the port given in the port.cfg file.
            botManager.Start(port);
        }
    }
}
