using Microsoft.Maui.Controls;
using PRG_MAUI_Car_Register.ViewModels;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new BaseVehicleVM();
        }
    }
}