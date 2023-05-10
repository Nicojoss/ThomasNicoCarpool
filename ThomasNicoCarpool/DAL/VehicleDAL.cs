using System.Data;
using System.Data.SqlClient;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL
{
    public class VehicleDAL: IVehicleDAL
    {
        private string connectionString;

        public VehicleDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Vehicle> GetVehiclesByUser(User u)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string query = "SELECT * FROM [Vehicle] WHERE IdUser = @IdUser";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("IdUser", u.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vehicle v = new Vehicle(reader.GetInt32("Id"), reader.GetString("Type"),
                                                reader.GetInt32("NbrPlace"), reader.GetInt32("StoragePlace"),
                                                Convert.ToDouble(reader.GetDecimal("PriceMultiplier")), u);
                        vehicles.Add(v);
                    }
                }
            }
            return vehicles;
        }
        public bool SaveVehicle(Vehicle vehicle)
        {
            bool success = false;
            string query = "INSERT INTO [Vehicle](Type, NbrPlace, StoragePlace, PriceMultiplier, IdUser)" +
                " VALUES (@Type, @NbrPlace, @StoragePlace, @PriceMultiplier, @IdUser)";

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Type", vehicle.Type);
                cmd.Parameters.AddWithValue("NbrPlace", vehicle.NbrPlace);
                cmd.Parameters.AddWithValue("StoragePlace", vehicle.StoragePlace);
                cmd.Parameters.AddWithValue("PriceMultiplier", vehicle.PriceMultiplier);
                cmd.Parameters.AddWithValue("IdUser", vehicle.Owner.Id);
                connection.Open();
                success = cmd.ExecuteNonQuery() > 0;
                return success;
            }
        }
    }
}
