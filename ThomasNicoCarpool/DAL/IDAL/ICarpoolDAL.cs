using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface ICarpoolDAL
    {
        public List<Carpool> GetOffers();
    }
}
