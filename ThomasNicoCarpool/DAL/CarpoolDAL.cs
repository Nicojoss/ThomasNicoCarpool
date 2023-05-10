using System.Data;
using System.Data.SqlClient;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL
{
    public class CarpoolDAL: ICarpoolDAL
    {
        private string connectionString;

        public CarpoolDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Carpool> GetOffers()
        {
            List<Carpool> carpools = new List<Carpool>();
            string query = "SELECT * FROM [Carpool] " +
                "JOIN [User] ON [Carpool].IdDriver = [User].id " +
                "JOIN [Vehicle] ON [Carpool].IdVehicle = [Vehicle].Id " +
                "WHERE Date > @date";

            string query2 = "SELECT * FROM [Registration] " +
                "JOIN [Carpool] ON [Registration].IdCarpool = [Carpool].Id " +
                "JOIN [User] ON [Registration].IdUser = [User].Id " +
                "WHERE [Registration].IdCarpool = @IdCarpool";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("date", DateTime.Now);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User u = new User(reader.GetInt32("IdDriver"), reader.GetString("Firstname"),
                                      reader.GetString("Lastname"), reader.GetString("Nickname"),
                                      reader.GetString("Telephone"), reader.GetString("Email"),
                                      null);
                        Vehicle v = new Vehicle(reader.GetInt32("IdVehicle"),reader.GetString("Type"),
                                                reader.GetInt32("NbrPlace"), reader.GetInt32("StoragePlace"),
                                                Convert.ToDouble(reader.GetDecimal("PriceMultiplier")), u);
                        Carpool c = new Carpool(reader.GetInt32("Id"), reader.GetString("Departure"),
                                       reader.GetString("Arrival"), reader.GetDateTime("Date"),
                                       reader.GetInt32("NbrKm"), Convert.ToBoolean(reader.GetInt32("Smoke")),
                                       Convert.ToBoolean(reader.GetInt32("Stop")), Convert.ToDouble(reader.GetDecimal("Price")), u, v);
                        carpools.Add(c);
                    }
                    reader.Close();
                }
                foreach (var c in carpools)
                {
                    SqlCommand cmd2 = new SqlCommand(query2, connection);
                    cmd2.Parameters.AddWithValue("IdCarpool", c.Id);
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
                                c);
                            c.AddRegistration(reg);
                        }
                    }
                }
            }
            List<Carpool> carpools2 = new List<Carpool>();
            foreach(var c in carpools)
            {
                if(c.CalculateNbrPlaceRemaining() > 0)
                {
                    carpools2.Add(c);
                }
            }
            return carpools2;
        }

        public List<Carpool> GetOffersByDriver(User u)
        {
            List<Carpool> carpools = new List<Carpool>();
            string query = "SELECT * FROM Carpool WHERE IdDriver = @IdDriver AND Date > @date";

            using(SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("IdDriver", u.Id);
                cmd.Parameters.AddWithValue("date", DateTime.Now);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Carpool carpool = new Carpool(reader.GetInt32("Id"), reader.GetString("Departure"),
                                                        reader.GetString("Arrival"), reader.GetDateTime("Date"), reader.GetInt32("NbrKm"),
                                                        Convert.ToBoolean(reader.GetInt32("Smoke")), Convert.ToBoolean(reader.GetInt32("Stop")),
                                                        Convert.ToDouble(reader.GetDecimal("Price")));
                        carpools.Add(carpool);
                    }
                    reader.Close();
                }
            }
            return carpools;
        }

        public bool SaveCarpool(Carpool carpool)
        {
            bool success = false;
            string query = "INSERT INTO [Carpool](Departure, Arrival, Date, NbrKm, Smoke, Stop, Price, IdDriver, IdVehicle)" +
                " VALUES (@Departure, @Arrival, @Date, @NbrKm, @Smoke, @Stop, @Price, @IdDriver, @IdVehicle)";
            if(carpool.Date < DateTime.Now)
            {
                return success;
            }
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Departure", carpool.Departure);
                cmd.Parameters.AddWithValue("Arrival", carpool.Arrival);
                cmd.Parameters.AddWithValue("Date", carpool.Date);
                cmd.Parameters.AddWithValue("NbrKm", carpool.NbrKm);
                cmd.Parameters.AddWithValue("Smoke", carpool.Smoke);
                cmd.Parameters.AddWithValue("Stop", carpool.Pause);
                cmd.Parameters.AddWithValue("Price", carpool.Price);
                cmd.Parameters.AddWithValue("IdDriver", carpool.Driver.Id);
                cmd.Parameters.AddWithValue("IdVehicle", carpool.Vehicle_.Id);
                connection.Open();
                success = cmd.ExecuteNonQuery() > 0;
                return success;
            }
        }
    }
}
