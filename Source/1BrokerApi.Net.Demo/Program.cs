using System;
using System.Collections.Generic;

namespace Jojatekok.OneBrokerAPI.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiToken = "8257f01472ad92db5f52c527ad3fcaee";

            // Initialize a new instance of the client
            using (var client = new OneBrokerClient(apiToken)) {
                // Check whether the API token being used is valid
                if (!client.IsApiTokenValid()) {
                    Console.WriteLine("Invalid API token.");
                    ShowExitMessage();
                    return;
                }

                // Greet the user, and show the count of open orders and positions
                Console.WriteLine("Welcome, " + client.Account.GetAccountInfo().Username + "!");
                Console.WriteLine();
                Console.WriteLine("You currently have:");
                Console.WriteLine("   " + client.Orders.GetOpenOrders().Count + " open orders");
                Console.WriteLine("   " + client.Positions.GetOpenPositions().Count + " open positions");

                //============================================

                DateTime from = new DateTime(2016, 6, 20);
                DateTime to = new DateTime(2016, 6, 24);

                IList<JsonObjects.Bar> bars = client.Markets.GetBars("AAPL", Resolution.Daily, from, to);

                foreach(JsonObjects.Bar bar in bars)
                {
                    Console.WriteLine("[" + bar.o + "," + bar.h + "," + bar.l + "," + bar.c);
                }
            }

            ShowExitMessage();
        }

        static void ShowExitMessage() {
            Console.WriteLine();
            Console.WriteLine("Press any key to terminate.");
            Console.Read();
        }
    }
}
