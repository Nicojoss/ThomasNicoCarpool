using System.ComponentModel.DataAnnotations;
using ThomasNicoCarpool.DAL;
using ThomasNicoCarpool.DAL.IDAL;
using ThomasNicoCarpool.ViewModels;

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
        [Required(ErrorMessage = "Password Invalid!"), DataType(DataType.Password)]
        public string Password
        {
            get { return password; }
            set { password = value; }
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
        public User(int id, string firstname, string lastname, string nickname, string telephone, string email, string password, List<Registration> registrations, List<Carpool> carpools, List<Review> reviews, List<Vehicle> vehicles)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.nickname = nickname;
            this.telephone = telephone;
            this.email = email;
            this.password = password;
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
            carpools = new List<Carpool>();
            registrations = new List<Registration>();
            reviews = new List<Review>();
            vehicles = new List<Vehicle>();
        }
        // Ctor pour mon UserViewModel
        public User(UserViewModel userVm)
        {
            firstname = userVm.Firstname;
            lastname = userVm.Lastname;
            nickname = userVm.Nickname;
            telephone = userVm.Telephone;
            email = userVm.Email;
            password = userVm.Password;
        }
        public static User Authenticate(string nickName, string password, IUserDAL userDAL)
        {
            return userDAL.Authenticate(nickName, password);
        }
        public void SaveAccount(IUserDAL userDAL)
        {
            userDAL.SaveAccount(this);
        }
        public List<Carpool> GetOffers()
        {
            return null;
        }
        public void AddCarpool(Carpool carpool) => this.carpools.Add(carpool);
        public void AddRegistration(Registration registration) => this.registrations.Add(registration);
        public void AddReview(Review review) => this.reviews.Add(review);
        public void AddVehicle(Vehicle vehicle)
        {
            if(!vehicles.Contains(vehicle))
                this.vehicles.Add(vehicle);
        }
        public Vehicle GetVehicle(int id)
        {
            foreach (Vehicle v in Vehicles)
            {
                if (v.Id == id)
                {
                    return v;
                }
            }
            return null;
        }
    }
}
