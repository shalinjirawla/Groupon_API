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
                if(dealLike != null)
                {
                    var data = _dealLike.InsertDealLike(dealLike);
                    if (data != null)
                    {
                        return Ok(data);
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
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult CheckLike(DealLike model)
        {
            try
            {
                if (model != null)
                {
                    var record = _dealLike.CheckLike(model.DealID, model.UserID);
                    if (record != null)
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
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
