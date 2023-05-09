using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface IRegistrationDAL
    {
        public List<Registration> GetRegistrationByUser(User user);
        public bool SaveRegistration(Registration registration);
    }
}
