using BusinessLogic.Interface;
using BusinessLogic.Models;
using BusinessLogic.Repository;
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
    public class DealController : ApiController
    {
        public IDeal _deal;
        public DealController()
        {
            _deal = new DealRepository(new AwfirContext());
        }
        [HttpGet]
        public IHttpActionResult GetHotDeals()
        {
            try
            {
                var data = _deal.GetHotDeal();
                if(data != null)
                {
                    return Ok(data);
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

        [HttpGet]
        public IHttpActionResult GetTrendingDeal()
        {
            try
            {
                var data = _deal.GetTrendingDeal();
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public IHttpActionResult GetRecommendedDeal()
        {
            try
            {
                var data = _deal.GetRecommendedDeal();
                if(data != null)
                {
                    return Ok(data);
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

        [HttpGet]
        public IHttpActionResult GetRecentlyDeal()
        {
            try
            {
                var data = _deal.GetRecentlyDeal();
                if(data != null)
                {
                    return Ok(data);
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
        [HttpGet]
        public IHttpActionResult GetDealbyID(Guid id)
        {
            try
            {
                var data = _deal.GetByID(id);
                if (data != null)
                {
                    return Ok(data);
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
