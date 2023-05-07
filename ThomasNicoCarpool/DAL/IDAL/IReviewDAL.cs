using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface IReviewDAL
    {
        public bool SaveReview(Review review);
    }
}
