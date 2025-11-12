namespace PRG_MAUI_Car_Register.Models
{
    public class Car : Vehicle
    {
        public int Seats { get; internal set; }

        public override string GetDescription() =>
            $"Bil: {Manufacturer} {Model}, {YearModel}. Registreringsnummer: {RegistrationNumber}.";
    }
}
