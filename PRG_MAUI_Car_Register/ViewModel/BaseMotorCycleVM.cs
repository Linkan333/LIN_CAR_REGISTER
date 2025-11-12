using PRG_MAUI_Car_Register.Models;


namespace PRG_MAUI_Car_Register.ViewModels
{
        public class BaseMotorCycleVM : BaseVehicleVM
        {
            private int seats { get; set; }


            public int Seats
            {
                get => seats;
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
                var motorcycle = new Motorcycle
                {
                    RegistrationNumber = RegistrationNumber,
                    Manufacturer = Manufacturer,
                    Model = Model,
                    Seats = Seats,
                    YearModel = YearModel,
                };

                motorcycle.Seats = Seats;


                return motorcycle;
            }

            public override string ToString()
            {
                return $"Motorcykel - {Manufacturer} {Model} ({YearModel}) - {Seats} antal säten";
            }
        }
}
