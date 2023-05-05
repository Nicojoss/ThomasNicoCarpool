using System.Data;
using System.Data.SqlClient;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL
{
    public class RegistrationDAL: IRegistrationDAL
    {
        private string connectionString;

        public RegistrationDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Registration> GetRegistrationByUser(User user)
        {
            List<Registration> registration = new List<Registration>();
            string query = "SELECT * FROM [Registration] " +
                "Join [Carpool] ON [Registration].IdCarpool = [Carpool].Id " +
                "Join [User] ON [Carpool].IdDriver = [User].Id " +
                "Join [Vehicle] ON [Carpool].IdVehicle = [Vehicle].Id " +
                "Where [Registration].IdUser = @idUser";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("idUser", user.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User driver = new User(reader.GetInt32("IdDriver"), reader.GetString("Firstname"),
                                      reader.GetString("Lastname"), reader.GetString("Nickname"),
                                      reader.GetString("Telephone"), reader.GetString("Email"),
                                      null);

                        Vehicle vehicle = new Vehicle(reader.GetInt32("IdVehicle"), reader.GetString("Type"),
                                                reader.GetInt32("NbrPlace"), reader.GetInt32("StoragePlace"),
                                                Convert.ToDouble(reader.GetDecimal("PriceMultiplier")), driver);
                        Carpool carpool = new Carpool(reader.GetInt32("IdCarpool"), reader.GetString("Departure"),
                                       reader.GetString("Arrival"), reader.GetDateTime("Date"),
                                       reader.GetInt32("NbrKm"), Convert.ToBoolean(reader.GetInt32("Smoke")),
                                       Convert.ToBoolean(reader.GetInt32("Stop")), Convert.ToDouble(reader.GetDecimal("Price")), driver, vehicle);

                        Registration r = new Registration(
                            reader.GetInt32("Id"),
                            reader.GetInt32("NbrPlace"),
                            reader.GetInt32("NbrLuggage"),
                            user,
                            carpool);
                        registration.Add(r);
                    }
                }
            }
            return registration;
        }
    }
}
