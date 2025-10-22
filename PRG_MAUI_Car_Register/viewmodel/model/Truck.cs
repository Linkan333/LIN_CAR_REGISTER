namespace PRG_MAUI_Car_Register.Models
{
    public class Truck : Vehicle
    {
        public override string GetDescription() =>
            $"Lastbil: {Manufacturer} {Model}, {YearModel}. Registreringsnummer: {RegistrationNumber}.";
    }
}