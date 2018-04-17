using BusinessLogic.Interface;
using BusinessLogic.Models;
using BusinessLogic.Repository;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Awfir.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class OffersController : ApiController
    {
        public IOffers _offers;
        public OffersController()
        {
            _offers = new OffersRepository(new AwfirContext());
        }

        [HttpGet]
        public IHttpActionResult DealOffers(Guid id)
        {
            try
            {
                if(id != null)
                {
                    var result = _offers.DealOffers(id);
                    if(result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public IHttpActionResult OfferDealByID(OfferIDDealID offerIDDealID)
        {
            try
            {
                if(offerIDDealID != null)
                {
                    var record = _offers.OfferOrDealByID(offerIDDealID);
                    if(record != null)
                    {
                        return Ok(record);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
