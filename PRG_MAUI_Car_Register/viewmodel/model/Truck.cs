namespace PRG_MAUI_Car_Register.Models
{
    public class Truck : Vehicle
    {
        public double MaxLoadKg { get; set; }
        public override string ToString() => base.ToString() + $"\tMaxlast (kg): {MaxLoadKg}";
    }
}
