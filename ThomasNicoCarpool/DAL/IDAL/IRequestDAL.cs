using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface IRequestDAL
    {
        public bool SaveRequest(Request request);
    }
}
