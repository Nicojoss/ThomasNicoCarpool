namespace ThomasNicoCarpool.Models
{
    public class Carpool: Journey
    {
		private int nbrKm;
        private bool smoke;
        private bool pause;
        private double price;
        private List<Registration> registrations;
        private User driver;
        private List<Review> reviews;
        private Vehicle vehicle;
        public int NbrKm
		{
			get { return nbrKm; }
			set { nbrKm = value; }
		}
		public bool Smoke
		{
			get { return smoke; }
			set { smoke = value; }
		}
		public bool Pause
		{
			get { return pause; }
			set { pause = value; }
		}
		public double Price
		{
			get { return price; }
			set { price = value; }
		}
		public List<Registration> Registrations
		{
			get { return registrations; }
			set { registrations = value; }
		}
		public User Driver
		{
			get { return driver; }
			set { driver = value; }
		}
		public List<Review> Reviews
		{
			get { return reviews; }
			set { reviews = value; }
		}
		public Vehicle Vehicle_
		{
			get { return vehicle; }
			set { vehicle = value; }
		}

        public Carpool(int id, string departure, string arrival, DateTime date,int nbrKm, bool smoke, bool pause, double price, List<Registration> registrations, User driver, List<Review> reviews, Vehicle vehicle)
			: base(id, departure, arrival, date)
        {
            this.nbrKm = nbrKm;
            this.smoke = smoke;
            this.pause = pause;
            this.price = price;
            this.registrations = registrations;
            this.driver = driver;
            this.reviews = reviews;
            this.vehicle = vehicle;
        }

        public Carpool(string departure, string arrival, DateTime date, int nbrKm, bool smoke, bool pause, double price, User driver, Vehicle vehicle)
			: base(departure, arrival, date)
		{
            this.nbrKm = nbrKm;
            this.smoke = smoke;
            this.pause = pause;
            this.price = price;
            this.driver = driver;
            this.vehicle = vehicle;
			this.registrations = new List<Registration>();
			this.reviews = new List<Review>();
        }
		static List<Carpool> GetOffers()
		{
			return null;
		}
		static List<Carpool> GetOffersByDriver()
		{
			return null;
		}
		public void SaveCarpool()
		{

		}
		public void AddRegistration(Registration registration) => this.registrations.Add(registration);
		public void AddReview(Review review) => this.reviews.Add(review);
    }
}
