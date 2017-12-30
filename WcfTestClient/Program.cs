using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AuctionServiceReference.AuctionServiceClient client = new AuctionServiceReference.AuctionServiceClient();

            Console.WriteLine("Auctions:");
            var auctions = client.GetAllAuctions();

            foreach (var auction in auctions)
            {
                Console.WriteLine(auction.ItemDescription + ", " + auction.RatingPrice + "DKK, " + auction.BidPrice + "DKK, " + "ItemID: " + auction.ItemNumber);
            }

            while (true)
            {
                Console.WriteLine("Enter command:");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "BID":
                        Console.WriteLine("Enter item ID:");
                        input = Console.ReadLine();
                        var item = client.GetAuctionByID(Convert.ToInt32(input));
                        Console.WriteLine("Enter bid:");

                        input = Console.ReadLine();
                        string response = client.MakeBid(new AuctionServiceReference.Bid { ItemNumber = item.ItemNumber, CustomName = "Kristian", CustomPhone = "12345676", Price = Convert.ToInt32(input) });
                        Console.WriteLine(response);
                        break;
                    case "AUCTIONS":
                        auctions = client.GetAllAuctions();
                        foreach (var auction in auctions)
                        {
                            Console.WriteLine(auction.ItemDescription + ", " + auction.RatingPrice + "DKK" + ", ItemID: " + auction.ItemNumber);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }

            }
        }
    }
}
