using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Linq;
using System.Web;

namespace WcfWebApplication.Models
{
    [DataContract]
    public class AuctionItem
    {
        private static List<int> ItemNumbers = new List<int>();

        [DataMember]
        public int ItemNumber { get; set; }
        [DataMember]
        public string ItemDescription { get; set; }
        [DataMember]
        public int RatingPrice { get; set; }
        [DataMember]
        public int BidPrice { get; set; }
        [DataMember]
        public string BidCustomName { get; set; }
        [DataMember]
        public string BidCustomPhone { get; set; }
        [DataMember]
        public DateTime BidTimeStamp { get; set; }

        public AuctionItem(string itemDescription, int ratingPrice)
        {
            ItemNumber = GenerateUniqueID();
            ItemDescription = itemDescription;
            RatingPrice = ratingPrice;
            BidPrice = 0;
            BidCustomName = "";
            BidCustomPhone = "";

            string bidtime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            BidTimeStamp = DateTime.ParseExact(bidtime, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public int GenerateUniqueID()
        {
            Random random = new Random(Environment.TickCount);
            int result = random.Next(1000, 9999);

            while (true)
            {
                if (ItemNumbers.Contains(result))
                {
                    result = random.Next(1000, 9999);
                }
                else
                {
                    ItemNumbers.Add(result);
                    break;
                }
            }
            return result;
        }
    }
}