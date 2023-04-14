using ThomasNicoCarpool.DAL.IDAL;

namespace ThomasNicoCarpool.DAL
{
    public class RequestDAL: IRequestDAL
    {
        private string connectionString;

        public RequestDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
