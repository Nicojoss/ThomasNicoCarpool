using System.Globalization;

namespace ThomasNicoCarpool.Models
{
    public class Request: Journey
    {
        private User passenger;

        public User Passenger
        {
            get { return passenger; }
            set { passenger = value; }
        }

        public Request(User user, int id, string departure, string arrival, DateTime date) : base(id, departure, arrival, date) 
        { 
            this.passenger = user;
        }
        // Ne pas oublier changer le return avec une liste
        static List<Request> GetRequests() 
        {
            return null;
        }
        public void SaveRequest()
        {

        }
    }
}
