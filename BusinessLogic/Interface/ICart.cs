using BusinessLogic.Models;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ICart
    {
        List<CartModel> GetCartDealList(Guid id);
        bool InsertDeal(Cart cartdeal);
        bool CartPlusMinus(UpdateCartModel Updatecart);
        bool DeleteDealByID(Guid id);
    }
}
