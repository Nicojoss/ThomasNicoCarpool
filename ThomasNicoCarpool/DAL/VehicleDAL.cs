using ThomasNicoCarpool.DAL.IDAL;

namespace ThomasNicoCarpool.DAL
{
    public class VehicleDAL: IVehicleDAL
    {
        private string connectionString;

        public VehicleDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
