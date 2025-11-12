namespace PRG_MAUI_Car_Register.Models
{
    public class Motorcycle : Vehicle
    {
        public int Seats { get; internal set; }

        public override string GetDescription() =>
            $"Motorcykel: {Manufacturer} {Model}, {YearModel}. Registreringsnummer: {RegistrationNumber}.";
    }
}
