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

        public List<Request> GetRequests()
        {
            List<Request> requests = new List<Request>();
            string query = "SELECT Departure, Arrival, Date FROM Request";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Request request = new Request(reader.GetString("Departure"), reader.GetString("Departure"), reader.GetDateTime("Date"));
                        requests.Add(request);
                    }
                }
            }
            return requests;
        }
    }
}
