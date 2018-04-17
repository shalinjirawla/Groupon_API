using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IDealLike
    {
        string InsertDealLike(DealLike deal);
        
        DealLike CheckLike(Guid DealID, Guid UserID);
    }
}
