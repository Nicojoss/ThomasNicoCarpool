using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface IUserDAL
    {
        public User Authenticate(string nickName, string password);
        public bool SaveAccount(User user);
    }
}
