using BusinessLogic.Models;
using BusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IDealReview
    {
        IEnumerable<DealReviewModel> GetAllReviews(Guid id);
        string InsertDealReview(DealReview dealReview);
    }
}
