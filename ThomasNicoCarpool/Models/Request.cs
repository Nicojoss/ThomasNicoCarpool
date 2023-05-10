using System.Globalization;
using ThomasNicoCarpool.DAL.IDAL;

namespace ThomasNicoCarpool.Models
{
    public class Request : Journey
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
        public Request(User user, string departure, string arrival, DateTime date) : base(departure, arrival, date)
        {
            this.passenger = user;
        }
        public Request(int id, string departure, string arrival, DateTime date) :base(id ,departure, arrival, date)
        {
            
        }
        public Request(string departure, string arrival, DateTime date) : base(departure, arrival, date) { }
        // Ne pas oublier changer le return avec une liste
        public static List<Request> GetRequests(IRequestDAL requestDAL)
        {
            return requestDAL.GetRequests();
        }
        public bool SaveRequest(IRequestDAL requestDAL)
        {
            return requestDAL.SaveRequest(this);
        }
        public static Request GetRequestById(int id, IRequestDAL requestDAL)
        {
            return requestDAL.GetRequestById(id);
        }
        public bool RemoveRequestById(int id, IRequestDAL requestDAL)
        {
            return requestDAL.RemoveRequestById(id);
        }
    }
}
