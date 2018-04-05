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
    public class DealLikeController : ApiController
    {
        public IDealLike _dealLike;
        public DealLikeController()
        {
            _dealLike = new DealLikeRepository(new AwfirContext());
        }

        [HttpPost]
        public IHttpActionResult InsertDealLike(DealLike dealLike)
        {
            try
            {
                var data = _dealLike.InsertDealLike(dealLike);
                if(data != null)
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
    }
}
