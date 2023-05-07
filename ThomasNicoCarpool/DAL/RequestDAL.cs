using System.Data.SqlClient;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL
{
    public class RequestDAL: IRequestDAL
    {
        private string connectionString;

        public RequestDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool SaveRequest(Request request)
        {
            bool success = false;
            string query = "INSERT INTO [Request] (Departure, Arrival, Date, IdUser) VALUES(@Departure,@Arrival,@Date,@IdUser)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Departure", request.Departure);
                cmd.Parameters.AddWithValue("Arrival", request.Arrival);
                cmd.Parameters.AddWithValue("Date", request.Date);
                cmd.Parameters.AddWithValue("IdUser", request.Passenger.Id);
                connection.Open();
                success = cmd.ExecuteNonQuery() > 0;
                return success;
            }
        }
           
        
    }
}
