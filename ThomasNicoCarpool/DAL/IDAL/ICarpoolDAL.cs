using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface ICarpoolDAL
    {
        public List<Carpool> GetOffers();
        public List<Carpool> GetOffersByDriver(User u);
        public bool SaveCarpool(Carpool carpool);
    }
}
