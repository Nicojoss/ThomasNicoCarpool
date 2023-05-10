using System.ComponentModel.DataAnnotations;
using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.ViewModels
{
    public class AddVehicleViewModel
    {
        private TypeVehicle type;
        private int nbrPlace;
        private int storagePlace;

        [Required(ErrorMessage = "Invalid Type!")]
        public TypeVehicle Type
        {
            get { return type; }
            set { type = value; }
        }
        [Required(ErrorMessage = "Invalid number of places"), Range(1, 9, ErrorMessage = "Enter number of places between 1 and 9")]
        public int NbrPlace
        {
            get { return nbrPlace; }
            set { nbrPlace = value; }
        }
        [Required(ErrorMessage = "Invalid number of storage"), Range(0, 10, ErrorMessage = "Enter number of places between 0 and 10")]
        public int StoragePlace
        {
            get { return storagePlace; }
            set { storagePlace = value; }
        }
    }
}
