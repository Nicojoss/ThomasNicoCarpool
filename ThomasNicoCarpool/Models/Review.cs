﻿namespace ThomasNicoCarpool.Models
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
		public int Rating
		{
			get { return rating; }
			set { rating = value; }
		}
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
		static List<Review> GetReviewByDriver(User user)
		{
			return null;
		}
		static void SaveReview()
		{

		}
    }
}