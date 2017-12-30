using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using WcfWebApplication.Models;
using System.ServiceModel;
using System.Text;

namespace WcfWebApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuctionService" in both code and config file together.
    [ServiceContract]
    public interface IAuctionService
    {
        [OperationContract]
        List<AuctionItem> GetAllAuctions();

        [OperationContract]
        AuctionItem GetAuctionByID(int itemNumber);

        [OperationContract]
        string MakeBid(Bid bid);
    }
}
