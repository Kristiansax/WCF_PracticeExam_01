using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfWebApplication.Models;

namespace WcfWebApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuctionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuctionService.svc or AuctionService.svc.cs at the Solution Explorer and start debugging.
    public class AuctionService : IAuctionService
    {
        public List<AuctionItem> GetAllAuctions()
        {
            return AuctionRepository.Instance.GetList();
        }

        public AuctionItem GetAuctionByID(int itemNumber)
        {
            return AuctionRepository.Instance.GetList().Where(x => x.ItemNumber == itemNumber).SingleOrDefault();
        }

        public string MakeBid(Bid bid)
        {
            AuctionItem auction = GetAuctionByID(bid.ItemNumber);
            if(auction != null)
            {
                if(bid.Price > auction.RatingPrice && bid.Price > auction.BidPrice)
                {
                    auction.BidPrice = bid.Price;
                    auction.BidCustomName = bid.CustomName;
                    auction.BidCustomPhone = bid.CustomPhone;
                    auction.BidTimeStamp = DateTime.Now;

                    AuctionRepository.Instance.UpdateList(auction);
                    return "Successfully bid on: " + auction.ItemDescription;
                }
                else
                    return "Bid was too low";
            }
            return "The auction does not exist";
        }
    }
}
