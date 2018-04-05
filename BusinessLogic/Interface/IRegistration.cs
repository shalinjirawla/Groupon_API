using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IRegistration
    {
        Task<List<User>> GetAllUser();
        //Task<bool> EditByID(Guid id);
        Task<bool> CreateUser(User model);
        //Task<bool> UpdateUser(User model);

    }
}
