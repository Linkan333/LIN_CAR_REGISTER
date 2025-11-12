using PRG_MAUI_Car_Register.Models;


namespace PRG_MAUI_Car_Register.ViewModels
{
    public abstract class TruckViewModel : VehicleViewModel
    {
        private double loadCapacity { get; set; }

        public double LoadCapacity
        {
            get => LoadCapacity;
            set
            {
                if (loadCapacity != value)
                {
                    loadCapacity = value;
                    OnPropertyChanged();
                }
            }
        }

        protected Vehicle CreateVehicle()
        {
            var truck = new Truck
            {
                RegistrationNumber = RegistrationNumber,
                Manufacturer = Manufacturer,
                Model = Model,
                YearModel = YearModel,
            };

            truck.LoadCapacity = LoadCapacity;

            return truck;
        }

        public override string ToString()
        {
            return $"Lastbil - {Manufacturer} {Model} ({YearModel}) - {LoadCapacity} ton lastkapacitet";
        }
    }
}