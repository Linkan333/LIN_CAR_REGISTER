namespace PRG_MAUI_Car_Register.Models
{
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }
        public override string ToString() => base.ToString() + $"\tSidovagn: {(HasSidecar ? "Ja" : "Nej")}";
    }
}
