using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface IRequestDAL
    {
        public List<Request> GetRequests();
    }
}
