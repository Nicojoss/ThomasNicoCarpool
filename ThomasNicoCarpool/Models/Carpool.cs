using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.ViewModels;

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

        [Required(ErrorMessage = "Number of Km Invalid!"), Range(0, 5000, ErrorMessage = "Enter a positive number between 0 and 5000 km.")]
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
		public Carpool() { }
        public Carpool(int id, string departure, string arrival, DateTime date, int nbrKm, bool smoke, bool pause, double price, User driver, Vehicle vehicle)
			: base(id, departure, arrival, date)
        {
            this.nbrKm = nbrKm;
            this.smoke = smoke;
            this.pause = pause;
            this.price = price;
            this.driver = driver;
            this.vehicle = vehicle;
			this.registrations = new List<Registration>();
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
		// Create the carpool with the request attribut in CarpoolController action OfferACarpool(Request) 
        public Carpool(string departure, string arrival, DateTime date, User driver) : base(departure, arrival, date)
        {
			this.Departure = departure;
			this.Arrival = arrival;
			this.Date = date;
			this.driver = driver;
        }
		public Carpool(int id, string departure, string arrival, DateTime date, int nbrKm, bool smoke, bool pause, double price) : base(id,departure, arrival,date)
		{
			this.Id = id;
			this.Departure = departure;
			this.Arrival = arrival;
			this.Date = date;
			this.nbrKm = nbrKm;
			this.smoke = smoke;
			this.pause = pause;
			this.price = price;
		}
        public Carpool(AddAnOffersViewModel cvm)
        {
            this.Departure = cvm.Departure;
			this.Arrival = cvm.Arrival;
			this.Date = cvm.Date;
			this.NbrKm = cvm.NbrKm;
			this.Smoke = cvm.Smoke;
			this.Pause = cvm.Pause;
			this.driver = cvm.Driver;
			/*this.Vehicle_ = cvm.Vehicle;*/
        }
        public static List<Carpool> GetOffers(ICarpoolDAL carpool)
		{
			List<Carpool> carpools = carpool.GetOffers();
			return carpools;
		}
		public static List<Carpool> GetOffersByDriver(ICarpoolDAL carpool, User u)
		{
			List<Carpool> carpools = carpool.GetOffersByDriver(u);

			return carpools;
		}
		public bool SaveCarpool(ICarpoolDAL carpool)
		{
			return carpool.SaveCarpool(this);
		}
		public void AddRegistration(Registration registration) { 
			if(!registrations.Contains(registration))
				registrations.Add(registration);
		}
		public void AddReview(Review review)
		{
			if(reviews == null)
			{
				reviews = new List<Review>();
			}
			this.reviews.Add(review);
		}
		public int CalculateNbrPlaceRemaining() {
			int total = vehicle.NbrPlace;
			foreach(var registration in this.registrations)
			{
				total -= registration.NbrPlaceTaken;
			}
			return total; 
		}
        public int CalculateNbrLuggageRemaining()
        {
            int total = vehicle.StoragePlace;
            foreach (var registration in this.registrations)
            {
                total -= registration.NbrLuggage;
            }
            return total;
        }
		public double CalculatePrice() {
			double totalPassenger = 0;
			foreach (var registration in this.registrations)
			{
				totalPassenger += registration.NbrPlaceTaken;
			}
			if (totalPassenger==0)
			{
				totalPassenger = 1;
			}
			return (price * vehicle.PriceMultiplier) / totalPassenger;
		}
		public double GetPrice() { return this.nbrKm*0.5; }

        public override bool Equals(object? obj)
        {
			return obj.ToString() == this.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string? ToString()
        {
            return $"{Id}, {Departure}, {Arrival}";
        }
    }
}
