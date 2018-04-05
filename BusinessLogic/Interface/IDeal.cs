
using BusinessLogic.Models;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BusinessLogic.Interface
{
    public interface IDeal
    {
        List<AllDeal> GetHotDeal();
        IEnumerable<AllDeal> GetTrendingDeal();
        IEnumerable<AllDeal> GetRecommendedDeal();
        IEnumerable<AllDeal> GetRecentlyDeal();
        AllDeal GetByID(Guid id);
    }
}
