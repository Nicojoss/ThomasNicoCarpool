using System.Data;
using System.Data.SqlClient;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL
{
    public class UserDAL : IUserDAL
    {
        private string connectionString;

        public UserDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User Authenticate(string nickName, string password)
        {
            User u = null;
            string query = "SELECT * FROM [User] where Nickname = @nickname and Password = @password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nickname", nickName);
                cmd.Parameters.AddWithValue("password", password);
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         u = new User(reader.GetInt32("Id"),reader.GetString("Firstname"),
                                      reader.GetString("Lastname"),reader.GetString("Nickname"),
                                      reader.GetString("Telephone"),reader.GetString("Email"),
                                      null);
                    }
                }
            }
            return u;
        }

        public bool SaveAccount(User user)
        {
            throw new NotImplementedException();
        }
    }
}
