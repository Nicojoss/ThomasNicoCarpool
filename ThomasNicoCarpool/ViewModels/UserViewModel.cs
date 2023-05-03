using System.ComponentModel.DataAnnotations;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.ViewModels
{
    public class UserViewModel
    {
        // ViewModel pour create account
        private string firstname;
        private string lastname;
        private string nickname;
        private string telephone;
        private string email;
        private string password;

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
    }
}
