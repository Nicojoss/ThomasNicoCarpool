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
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
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
