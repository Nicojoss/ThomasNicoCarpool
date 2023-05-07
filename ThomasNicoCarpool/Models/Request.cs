using System.Globalization;
using ThomasNicoCarpool.DAL.IDAL;

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
        public Request(string departure, string arrival, DateTime date): base(departure, arrival, date)
        {
            
        }
        // Ne pas oublier changer le return avec une liste
        public static List<Request> GetRequests(IRequestDAL requestDAL) 
        {
            return requestDAL.GetRequests();
        }
        public void SaveRequest()
        {

        }
    }
}
