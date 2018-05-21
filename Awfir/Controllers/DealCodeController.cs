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
    public class DealCodeController : ApiController
    {
        public IDealCode _dealcode;
        public DealCodeController()
        {
            _dealcode = new DealCodeRepository(new AwfirContext());
        }

        [HttpPost]
        public IHttpActionResult GetCodeStatus(DealCodeModel deal)
        {
            try
            {
                if(deal != null)
                {
                    var result = _dealcode.GetDiscountByCode(deal);
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
        
    }
}
