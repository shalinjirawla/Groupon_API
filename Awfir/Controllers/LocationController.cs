using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Models;
using BusinessLogic.Interface;
using BusinessLogic.Repository;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace Awfir.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LocationController : ApiController
    {
        public ILocation _location;
        public LocationController()
        {
            _location = new LocationRepository(new AwfirContext());
        }
       
        [HttpGet]
        public IHttpActionResult GetListLocation()
        {
            try
            {
                var data = _location.GetAllLocation();
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
 
            }
            catch (Exception E)
            {
                throw E;
            }
        }
    }
}
