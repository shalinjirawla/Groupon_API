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
    public class DealRecomController : ApiController
    {
        public IDealRecom _dealRecom;
        public DealRecomController()
        {
            _dealRecom = new DealRecomRepository(new AwfirContext());
        }
        [HttpPost]
        public IHttpActionResult InsertUpdateDealRecom(DealRecom dealRecom)
        {
            try
            {
                var data = _dealRecom.InsertUpdateDealRecom(dealRecom);
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
