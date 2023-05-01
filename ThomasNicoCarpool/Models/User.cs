using System.ComponentModel.DataAnnotations;

namespace ThomasNicoCarpool.Models
{
    public class User
    {
        private int id;
        private string firstname;
        private string lastname;
        private string nickname;
        private string telephone;
        private string email;
        private string password;
        private List<Request> requests;
        private List<Registration> registrations;
        private List<Carpool> carpools;
        private List<Review> reviews;
        private List<Vehicle> vehicles;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Required(ErrorMessage = "Firstname Invalid."), StringLength(20, MinimumLength = 3, ErrorMessage = " Enter between 3 and 20 characters")]
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        [Required(ErrorMessage = "Lastname Invalid."), StringLength(30, MinimumLength = 3, ErrorMessage = " Enter between 3 and 30 characters")]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        [Required(ErrorMessage = "Nickname Invalid."), StringLength(15, MinimumLength = 3, ErrorMessage = " Enter between 3 and 15 characters")]
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        [Required(ErrorMessage = "Telephone Invalid !"), DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number not valid !")]
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        [DataType(DataType.EmailAddress), Required(ErrorMessage = "Email Invalid!")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [Required(ErrorMessage = "Password Invalid!"), DataType(DataType.Password, ErrorMessage = "Password not valid !")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public List<Request> Requests
        {
            get { return requests; }
            set { requests = value; }
        }
        public List<Registration> Registrations
        {
            get { return registrations; }
            set { registrations = value; }
        }
        public List<Carpool> Carpools
        {
            get { return carpools; }
            set { carpools = value; }
        }
        public List<Review> Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }
        [Required(ErrorMessage = "Vehicles Invalid!")]
        public List<Vehicle> Vehicles
        {
            get { return vehicles; }
            set { vehicles = value; }
        }
        // Constructeur tout
        public User(int id, string firstname, string lastname, string nickname, string telephone, string email, string password, List<Request> requests, List<Registration> registrations, List<Carpool> carpools, List<Review> reviews, List<Vehicle> vehicles)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.nickname = nickname;
            this.telephone = telephone;
            this.email = email;
            this.password = password;
            this.requests = requests;
            this.registrations = registrations;
            this.carpools = carpools;
            this.reviews = reviews;
            this.vehicles = vehicles;
        }
        public User()
        {
        }
        // Constructeur mais sans l'id pour create account et initialiser les listes
        public User(string firstname, string lastname, string nickname, string telephone, string email, string password)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.nickname = nickname;
            this.telephone = telephone;
            this.email = email;
            this.password = password;
            requests = new List<Request>();
            carpools = new List<Carpool>();
            registrations = new List<Registration>();
            reviews = new List<Review>();
            vehicles = new List<Vehicle>();
        }

        public User(int id, string firstname, string lastname, string nickname, string telephone, string email, string password)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.nickname = nickname;
            this.telephone = telephone;
            this.email = email;
            this.password = password;
            requests = new List<Request>();
            carpools = new List<Carpool>();
            registrations = new List<Registration>();
            reviews = new List<Review>();
            vehicles = new List<Vehicle>();
        }

        // Return null a changer
        static User Authenticate(string nickName, string password)
        {
            return null;
        }
        public void SaveAccount()
        {
            
        }
        public List<Vehicle> GetVehicles()
        {
            return null;
        }
        public List<Carpool> GetOffers()
        {
            return null;
        }
        public void AddCarpool(Carpool carpool) => this.carpools.Add(carpool);
        public void AddRegistration(Registration registration) => this.registrations.Add(registration);
        public void AddReview(Review review) => this.reviews.Add(review);
        public void AddRequest(Request request) => this.requests.Add(request);
        public void AddVehicle(Vehicle vehicle) => this.vehicles.Add(vehicle);
    }
}
