using BusinessLogic.Interface;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class LoginRepository : ILogin
    {
        private readonly AwfirContext db;

        public LoginRepository(AwfirContext context)
        {
            db = context;
        }

        public User LoginUser(User model)
        {
            try
            {   
                var data = db.Users.Where(x => x.EmailID == model.EmailID && x.Password == model.Password).FirstOrDefault();
                model = data;
                if (data != null)
                {
                    return model;
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
