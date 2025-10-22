namespace PRG_MAUI_Car_Register.Models
{
    public class Car : Vehicle
    {
        public override string GetDescription() =>
            $"Bil: {Manufacturer} {Model}, {YearModel}. Registreringsnummer: {RegistrationNumber}.";
    }
}
