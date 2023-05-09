using System.Data;
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
        public List<Request> GetRequests()
        {
            List<Request> requests = new List<Request>();
            string query = "SELECT Id, Departure, Arrival, Date FROM [Request]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Request request = new Request(reader.GetInt32("Id"),reader.GetString("Departure"), reader.GetString("Arrival"), reader.GetDateTime("Date"));
                        requests.Add(request);
                    }
                }
            }
            return requests;
        }

        public Request GetRequestById(int id)
        {
            Request request = null;
            string query = "SELECT Id, Departure, Arrival, Date FROM [Request] WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        request = new Request(reader.GetInt32("Id"), reader.GetString("Departure"), reader.GetString("Arrival"), reader.GetDateTime("Date"));
                    }
                }
            }
            return request;
        }
    }
}
