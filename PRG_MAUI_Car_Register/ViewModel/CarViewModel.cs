using PRG_MAUI_Car_Register.Models;


namespace PRG_MAUI_Car_Register.ViewModels
{
    public abstract class CarViewModel : VehicleViewModel
    {
        private int seats { get; set; }


        public int Seats
        {
            get => Seats;
            set
            {
                if (seats != value)
                {
                    seats = value;
                    OnPropertyChanged();
                }
            }
        }

        protected Vehicle CreateVehicle()
        {
            var car = new Car
            {
                RegistrationNumber = RegistrationNumber,
                Manufacturer = Manufacturer,
                Model = Model,
                YearModel = YearModel,
            };

            car.Seats = Seats;


            return car;
        }

        public override string ToString()
        {
            return $"Bil - {Manufacturer} {Model} ({YearModel}) - {Seats} antal säten";
        }
    }
}
