using System.ComponentModel.DataAnnotations;

namespace ThomasNicoCarpool.Models
{
    public class Registration
    {
		private int id;
        private int nbrPlaceTaken;
        private int nbrLuggage;
        private User passenger;
        private Carpool carpool;
        public int Id
		{
			get { return id; }
			set { id = value; }
		}
		[Required(ErrorMessage = "Field Invalid!"), Range(0, 10)]
		public int NbrPlaceTaken
		{
			get { return nbrPlaceTaken; }
			set { nbrPlaceTaken = value; }
		}
        [Required(ErrorMessage = "Field Invalid!"), Range(0, 10)]
        public int NbrLuggage
		{
			get { return nbrLuggage; }
			set { nbrLuggage = value; }
		}
		public User Passenger
		{
			get { return passenger; }
			set { passenger = value; }
		}
		public  Carpool Carpool_
		{
			get { return carpool; }
			set { carpool = value; }
		}

        public Registration(int id, int nbrPlaceTaken, int nbrLuggage, User passenger, Carpool carpool)
        {
            this.id = id;
            this.nbrPlaceTaken = nbrPlaceTaken;
            this.nbrLuggage = nbrLuggage;
            this.passenger = passenger;
            this.carpool = carpool;
        }

        public Registration(int nbrPlaceTaken, int nbrLuggage, User passenger, Carpool carpool)
        {
            this.nbrPlaceTaken = nbrPlaceTaken;
            this.nbrLuggage = nbrLuggage;
            this.passenger = passenger;
            this.carpool = carpool;
        }
		static List<Registration> GetRegistrationByUser(User user)
		{
			return null;
		}
		public void SaveRegistration()
		{

		}
    }
}
