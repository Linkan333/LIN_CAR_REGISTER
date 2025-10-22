namespace PRG_MAUI_Car_Register.Models
{
    public class Motorcycle : Vehicle
    {
        public override string GetDescription() =>
            $"Motorcykel: {Manufacturer} {Model}, {YearModel}. Registreringsnummer: {RegistrationNumber}.";
    }
}
