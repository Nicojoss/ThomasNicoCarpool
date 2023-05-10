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
            List<Registration> registrations = new List<Registration>();
            string query = "SELECT * FROM [Registration] " +
                "Join [Carpool] ON [Registration].IdCarpool = [Carpool].Id " +
                "Join [User] ON [Carpool].IdDriver = [User].Id " +
                "Join [Vehicle] ON [Carpool].IdVehicle = [Vehicle].Id " +
                "Where [Registration].IdUser = @idUser";

            string query2 = "SELECT * FROM [Registration] " +
                "Join [Carpool] ON [Carpool].Id = [Registration].IdCarpool " +
                "Join [User] ON [Registration].IdUser = [User].id " +
                "WHERE [Registration].IdCarpool = @IdCarpool";

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
                        
                        registrations.Add(r);
                    }
                }
                foreach (var r in registrations)
                {
                    SqlCommand cmd2 = new SqlCommand(query2, connection);
                    cmd2.Parameters.AddWithValue("IdCarpool", r.Carpool_.Id);
                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            User passenger = new User(reader2.GetInt32("IdUser"), reader2.GetString("Firstname"),
                                  reader2.GetString("Lastname"), reader2.GetString("Nickname"),
                                  reader2.GetString("Telephone"), reader2.GetString("Email"),
                                  null);
                            Registration reg = new Registration(reader2.GetInt32("Id"),
                                reader2.GetInt32("NbrPlace"),
                                reader2.GetInt32("NbrLuggage"),
                                passenger,
                                r.Carpool_);
                            r.Carpool_.AddRegistration(reg);
                        }
                    }
                }
            }
            return registrations;
        }

        public bool SaveRegistration(Registration registration)
        {
            bool success = false;
            string query = "INSERT INTO [Registration] (NbrPlace, NbrLuggage, IdUser, IdCarpool)" +
                " VALUES (@NbrPlace, @NbrLuggage, @IdUser, @IdCarpool)";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("NbrPlace", registration.NbrPlaceTaken);
                cmd.Parameters.AddWithValue("NbrLuggage", registration.NbrLuggage);
                cmd.Parameters.AddWithValue("IdUser", registration.Passenger.Id);
                cmd.Parameters.AddWithValue("IdCarpool", registration.Carpool_.Id);
                connection.Open();
                success = cmd.ExecuteNonQuery() > 0;
                return success;
            }
        }
    }
}
