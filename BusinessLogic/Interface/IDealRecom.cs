using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IDealRecom
    {

        DealRecom GetByID(Guid id);
        string InsertUpdateDealRecom(DealRecom dealRecom);
        //DealRecom RemoveLike(DealRecom dealRecom);
    }
}
