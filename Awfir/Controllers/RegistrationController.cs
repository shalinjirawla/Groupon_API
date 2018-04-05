using BusinessLogic.Interface;
using BusinessLogic.Models;
using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Awfir.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationController : ApiController
    {
        public IRegistration _registration;
        public RegistrationController()
        {
            _registration = new RegistrationRepository(new AwfirContext());
        }

        [HttpPost]
        public IHttpActionResult CreateUser(User model)
        {
            try
            {
                

                _registration.CreateUser(model);
                return Ok(model);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

       
    }
}
