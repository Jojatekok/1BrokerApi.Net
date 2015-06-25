using System;

namespace Jojatekok.OneBrokerAPI.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiToken = null;
            if (args.Length > 0) apiToken = args[0];

            if (string.IsNullOrWhiteSpace(apiToken)) {
                Console.WriteLine("Please input your API token:");
                apiToken = Console.ReadLine();
                Console.WriteLine();
            }

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
