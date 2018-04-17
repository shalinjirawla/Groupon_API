using BusinessLogic.Models;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IOffers
    {
        IEnumerable<Offers> DealOffers(Guid id);
        OfferView OfferOrDealByID(OfferIDDealID offerIDDealID);
    }
}
