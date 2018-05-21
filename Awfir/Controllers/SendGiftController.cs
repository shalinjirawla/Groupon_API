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
    public class SendGiftController : ApiController
    {
        public ISendGift _sendgift;
        public SendGiftController()
        {
            _sendgift = new SendGiftRepository(new AwfirContext());
        }
        [HttpPost]
        public IHttpActionResult InsertSendGift(SendGift SG)
        {
            try
            {
                if(SG != null)
                {
                    var record = _sendgift.sendGift(SG);
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
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
