using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface IVehicleDAL
    {
        public List<Vehicle> GetVehiclesByUser(User u);
        public bool SaveVehicle(Vehicle vehicle);
    }
}
