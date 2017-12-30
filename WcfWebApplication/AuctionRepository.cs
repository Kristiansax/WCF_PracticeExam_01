using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfWebApplication.Models;

namespace WcfWebApplication
{
    public class AuctionRepository
    {
        private static List<AuctionItem> auctionList;
        private static AuctionRepository instance = null;
        private static readonly object padlock = new object();
        private AuctionRepository()
        {
            auctionList = new List<AuctionItem>
            {
                new AuctionItem("Shoes", 100),
                new AuctionItem("Rocks", 55),
                new AuctionItem("Mona Lisa", 5000000),
                new AuctionItem("Stikdows", 1)
            };
        }

        public static AuctionRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new AuctionRepository();
                        }
                    }
                }
                return instance;
            }
        }

        public List<AuctionItem> GetList()
        {
            lock (padlock)
            {
                return auctionList;
            }

        }

        public void UpdateList(AuctionItem auction)
        {
            lock (padlock)
            {
                int index = auctionList.FindIndex(a => a == auction);
                auctionList[index] = auction;
            }
        }
    }
}