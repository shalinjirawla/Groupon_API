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
    public class CategoryController : ApiController
    {

        public ICategory _category;
        public CategoryController()
        {
            _category = new CategoryRepository(new AwfirContext());
        }

        [HttpGet]
        public IHttpActionResult GetListCategory()
        {
            try
            {
                var data = _category.GetAllCategory();
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception E)
            {
                throw E;
            }
        }
    }
}
