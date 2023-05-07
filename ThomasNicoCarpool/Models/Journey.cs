using System.ComponentModel.DataAnnotations;

namespace ThomasNicoCarpool.Models
{
    public abstract class Journey
    {
		private int id;
        private string departure;
        private string arrival;
        private DateTime date;
        public int Id
		{
			get { return id; }
			set { id = value; }
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
        [Required(ErrorMessage = "Empty Field!."), DataType(DataType.DateTime), ]
        public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

        protected Journey(int id, string departure, string arrival, DateTime date)
        {
            this.id = id;
            this.departure = departure;
            this.arrival = arrival;
            this.date = date;
        }
        protected Journey(string departure, string arrival, DateTime date)
        {
            this.departure = departure;
            this.arrival = arrival;
            this.date = date;
        }
    }
}
