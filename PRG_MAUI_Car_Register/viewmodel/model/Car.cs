namespace PRG_MAUI_Car_Register.Models
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public override string ToString() => base.ToString() + $"\tDörrar: {NumberOfDoors}";
    }
}
