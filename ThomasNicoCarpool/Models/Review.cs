using System.ComponentModel.DataAnnotations;
using ThomasNicoCarpool.DAL.IDAL;

namespace ThomasNicoCarpool.Models
{
    public class Review
    {
		private int id;
        private int rating;
        private string comment;
        private User passenger;
        private Carpool carpool;
        public int Id
		{
			get { return id; }
			set { id = value; }
		}

        [Required(ErrorMessage = "Rating invalid!"), Range(1, 5, ErrorMessage = "Enter a rating between 1 and 5 !")]
        public int Rating
		{
			get { return rating; }
			set { rating = value; }
		}
        [Required(ErrorMessage = "Enter a comment."), StringLength(100, MinimumLength = 1, ErrorMessage = "Enter a comment between 1 and 100 characteres")]
        public string Comment
		{
			get { return comment; }
			set { comment = value; }
		}
		public User Passenger
		{
			get { return passenger; }
			set { passenger = value; }
		}
		public Carpool Carpool_
		{
			get { return carpool; }
			set { carpool = value; }
		}

        public Review(int id, int rating, string comment, User user, Carpool carpool)
        {
            this.id = id;
            this.rating = rating;
            this.comment = comment;
            this.passenger = user;
            this.carpool = carpool;
        }
		// constructeur sans l'id
        public Review(int rating, string comment, User user, Carpool carpool)
        {
            this.rating = rating;
            this.comment = comment;
            this.passenger = user;
            this.carpool = carpool;
        }
        public Review(int id, int rating, string comment)
        {
            this.id = id;
            this.rating = rating;
            this.comment = comment;
        }
        public static List<Review> GetReviewByDriver(IReviewDAL reviewDAL ,User user)
		{
			return reviewDAL.GetReviewsByDriver(user);
		}
		public bool SaveReview(IReviewDAL reviewDAL)
		{
			return reviewDAL.SaveReview(this);
		}
    }
}
