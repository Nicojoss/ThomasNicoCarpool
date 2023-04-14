using ThomasNicoCarpool.DAL.IDAL;

namespace ThomasNicoCarpool.DAL
{
    public class RegistrationDAL: IRegistrationDAL
    {
        private string connectionString;

        public RegistrationDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
