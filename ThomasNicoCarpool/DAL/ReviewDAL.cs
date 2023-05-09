using System.Data;
using System.Data.SqlClient;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL
{
    public class ReviewDAL: IReviewDAL
    {
        private string connectionString;

        public ReviewDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Review> GetReviewsByDriver(User user)
        {
            List<Review> reviews = new List<Review>();
            string query = "SELECT * FROM [Review] " +
                "Join [Carpool] ON [Review].IdCarpool = [Carpool].Id " +
                "Join [User] ON [Carpool].IdDriver = [User].Id " +
                "Where [User].Id = @idUser";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("idUser", user.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Review review = new Review(reader.GetInt32("Id"), reader.GetInt32("Rating"), reader.GetString("Comment"));
                        reviews.Add(review);
                    }
                }
            }
            return reviews;
        }

        public bool SaveReview(Review review)
        {
            bool success = false;
            string query = "INSERT INTO [Review] (Rating, Comment, IdCarpool, IdUser) VALUES(@Rating,@Comment,@IdCarpool,@IdUser)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Rating", review.Rating);
                cmd.Parameters.AddWithValue("Comment", review.Comment);
                cmd.Parameters.AddWithValue("IdCarpool", review.Carpool_.Id);
                cmd.Parameters.AddWithValue("IdUser", review.Passenger.Id);
                connection.Open();
                success = cmd.ExecuteNonQuery() > 0;
                return success;
            }
        }
    }
}
