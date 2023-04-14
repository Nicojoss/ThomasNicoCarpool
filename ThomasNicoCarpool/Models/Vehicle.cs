namespace ThomasNicoCarpool.Models
{
    public class Vehicle
    {
		private int id;
        private TypeVehicle type;
        private int nbrPlace;
        private int storagePlace;
        private double priceMultiplier;
        private List<Carpool> carpools;
        private User owner;
        public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public TypeVehicle Type
		{
			get { return type; }
			set { type = value; }
		}
		public int NbrPlace
		{
			get { return nbrPlace; }
			set { nbrPlace = value; }
		}
		public int StoragePlace
		{
			get { return storagePlace; }
			set { storagePlace = value; }
		}
		public double PriceMultiplier
		{
			get { return priceMultiplier; }
			set { priceMultiplier = value; }
		}
		public List<Carpool> Carpools
		{
			get { return carpools; }
			set { carpools = value; }
		}
		public User Owner
		{
			get { return owner; }
			set { owner = value; }
		}
		// Pour recuperer dans carpoolIDAL
        public Vehicle(int id, string type, int nbrPlace, int storagePlace, double priceMultiplier, User owner)
        {
            this.id = id;
            this.type = Enum.Parse<TypeVehicle>(type);
            this.nbrPlace = nbrPlace;
            this.storagePlace = storagePlace;
            this.priceMultiplier = priceMultiplier;
            this.owner = owner;
			carpools = new List<Carpool>();
        }

        public Vehicle(int id, TypeVehicle type, int nbrPlace, int storagePlace, double priceMultiplier, List<Carpool> carpools, User owner)
        {
            this.id = id;
            this.type = type;
            this.nbrPlace = nbrPlace;
            this.storagePlace = storagePlace;
            this.priceMultiplier = priceMultiplier;
            this.carpools = carpools;
            this.owner = owner;
        }

        public Vehicle(TypeVehicle type, int nbrPlace, int storagePlace, double priceMultiplier, User owner)
        {
            this.type = type;
            this.nbrPlace = nbrPlace;
            this.storagePlace = storagePlace;
            this.priceMultiplier = priceMultiplier;
            this.owner = owner;
			this.carpools = new List<Carpool>();
        }

        public void SaveVehicle()
		{

		}

	}
}
