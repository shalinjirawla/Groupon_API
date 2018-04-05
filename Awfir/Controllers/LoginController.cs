using BusinessLogic.Interface;
using BusinessLogic.Models;
using BusinessLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Awfir.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        public ILogin _login;

        public LoginController()
        {
            _login = new LoginRepository(new AwfirContext());
        }

        [HttpPost]
        public IHttpActionResult LoginUser(User model)
        {
            try
            {
                if(model != null)
                {
                    var i = _login.LoginUser(model);
                    if (i != null)
                    {
                        return Ok(i);
                    }
                    else
                    {
                        return Ok("fail");
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
