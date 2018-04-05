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
    public class DealReviewController : ApiController
    {
        public IDealReview _dealReview;

        public DealReviewController()
        {
            _dealReview = new DealReviewRepository(new AwfirContext());
        }

        [HttpGet]
        public IHttpActionResult GetAllReview(Guid id)
        {
            try
            {
                var data = _dealReview.GetAllReviews(id);
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


        [HttpPost]
        public IHttpActionResult InsertDealReview(DealReview dealReview)
        {
            try
            {
                var data = _dealReview.InsertDealReview(dealReview);
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

    }
}
