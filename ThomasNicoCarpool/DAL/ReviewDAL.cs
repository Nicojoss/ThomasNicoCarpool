using ThomasNicoCarpool.DAL.IDAL;

namespace ThomasNicoCarpool.DAL
{
    public class ReviewDAL: IReviewDAL
    {
        private string connectionString;

        public ReviewDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
