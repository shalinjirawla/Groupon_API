using BusinessLogic.Interface;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogic.Repository
{
    public class RegistrationRepository : IRegistration
    {
        private readonly AwfirContext db;

        public RegistrationRepository(AwfirContext context)
        {
            db = context;
        }

        public async Task<List<User>> GetAllUser()
        {
            var list = Task.Run(() => db.Users.ToList());

            List<User> userlist = await list;
            List<User> listUser = new List<User>();

            foreach (var item in userlist)
            {
                User abc = new User();
                abc.ID = item.ID;
                abc.FirstName = item.FirstName;
                abc.LastName = item.LastName;
                abc.EmailID = item.EmailID;
                abc.Gender = item.Gender;
                abc.DOB = item.DOB;
                abc.LocationID = item.LocationID;
                abc.Image = item.Image;
                listUser.Add(abc);
            }
            return listUser;
        }

        public async Task<bool> CreateUser(User model)
        {
            try
            {
                if (model != null)
                {
                    User user = new User();
                    user.EmailID = model.EmailID;
                    user.Password = model.Password;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Gender = model.Gender;
                    user.LocationID = model.LocationID;
                    user.DOB = model.DOB;
                    user.Category = model.Category;
                    user.Image = model.Image;
                    user.RegisteredDate = DateTime.Now;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
