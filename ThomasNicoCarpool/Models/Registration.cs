using ThomasNicoCarpool.DAL.IDAL;

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
		public int NbrPlaceTaken
		{
			get { return nbrPlaceTaken; }
			set { nbrPlaceTaken = value; }
		}
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
		public static List<Registration> GetRegistrationByUser(User user, IRegistrationDAL registrationDAL)
		{
			return registrationDAL.GetRegistrationByUser(user);
		}
		public void SaveRegistration()
		{

		}
    }
}
