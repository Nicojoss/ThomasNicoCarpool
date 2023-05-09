using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface ICarpoolDAL
    {
        public List<Carpool> GetOffers();
        public bool SaveCarpool(Carpool carpool);
    }
}
