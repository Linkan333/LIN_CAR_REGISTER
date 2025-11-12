namespace PRG_MAUI_Car_Register.Models
{
    public class Truck : Vehicle
    {
        public double LoadCapacity { get; internal set; }

        public override string GetDescription() =>
            $"Lastbil: {Manufacturer} {Model}, {YearModel}. Registreringsnummer: {RegistrationNumber}.";
    }
}