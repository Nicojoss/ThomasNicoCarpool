using System.ComponentModel.DataAnnotations;
using ThomasNicoCarpool.Models;
using Newtonsoft.Json;

namespace ThomasNicoCarpool.ViewModels
{
    public class AddAnOffersViewModel
    {
        private string departure;
        private string arrival;
        private DateTime date;
        private int nbrKm;
        private bool smoke;
        private bool pause;
        private User driver;
        private int idVehicle;
        public int IdVehicle
        {
            get { return idVehicle; }
            set { idVehicle = value; }
        }
        public User Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        [Required(ErrorMessage = "Empty Field!.")]
        public string Departure
        {
            get { return departure; }
            set { departure = value; }
        }
        [Required(ErrorMessage = "Empty Field!.")]
        public string Arrival
        {
            get { return arrival; }
            set { arrival = value; }
        }
        [Required(ErrorMessage = "Empty Field!."), DataType(DataType.DateTime)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        [Required(ErrorMessage = "Number of Km Invalid!"), Range(1, 5000, ErrorMessage = "Enter a positive number between 1 and 5000 km.")]
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
        public AddAnOffersViewModel(string departure, string arrival, DateTime date, User u)
        {
            this.departure = departure;
            this.arrival = arrival;
            this.date = date;
            this.driver = u;
        }
        public AddAnOffersViewModel(User u)
        {
            this.driver = u;
        }
        public AddAnOffersViewModel()
        {
            
        }
    }
}
