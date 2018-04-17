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
    public class PaymentDetailController : ApiController
    {
        public IPaymentDetail _paymentDetail;
        public PaymentDetailController()
        {
            _paymentDetail = new PaymentDetailRepository(new AwfirContext());
        }

        [HttpGet]
        public IHttpActionResult GetDealCount(Guid id)
        {
            try
            {
                if(id != null)
                {
                    var data = _paymentDetail.GetDealIDCount(id);
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
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public IHttpActionResult InsertPayment(PaymentDetail detail)
        {
            try
            {
                if(detail != null)
                {
                    var result = _paymentDetail.InsertPayment(detail);
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
