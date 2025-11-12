using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PRG_MAUI_Car_Register.Models;

namespace PRG_MAUI_Car_Register.ViewModels
{
    public class BaseVehicleVM : BindableObject
    {
        // Properties som View binder till
        private string registrationNumber;
        private string manufacturer;
        private string model;
        private string yearModel;
        private string selectedType;
        private string searchText;
        private string searchResult;

        public ObservableCollection<Vehicle> Vehicles { get; set; } = new();

        public string RegistrationNumber
        {
            get => registrationNumber;
            set { registrationNumber = value; OnPropertyChanged(); }
        }

        public string Manufacturer
        {
            get => manufacturer;
            set { manufacturer = value; OnPropertyChanged(); }
        }

        public string Model
        {
            get => model;
            set { model = value; OnPropertyChanged(); }
        }

        public string YearModel
        {
            get => yearModel;
            set { yearModel = value; OnPropertyChanged(); }
        }

        public string SelectedType
        {
            get => selectedType;
            set { selectedType = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => searchText;
            set { searchText = value; OnPropertyChanged(); }
        }

        public string SearchResult
        {
            get => searchResult;
            set { searchResult = value; OnPropertyChanged(); }
        }

        // Commands som View anropar via XAML
        public ICommand RegisterCommand { get; }
        public ICommand SearchCommand { get; }

        public BaseVehicleVM()
        {
            RegisterCommand = new Command(RegisterVehicle);
            SearchCommand = new Command(SearchVehicle);
        }

        private void RegisterVehicle()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedType))
                {
                    Application.Current.MainPage.DisplayAlert("Fel", "Du måste välja en fordons typ.", "OK");
                    return;
                }

                Vehicle vehicle = SelectedType switch
                {
                    "Bil" => new Car(),
                    "MC" => new Motorcycle(),
                    "Lastbil" => new Truck(),
                    _ => throw new ArgumentException("Ogiltig fordonstyp")
                };

                vehicle.RegistrationNumber = RegistrationNumber;
                vehicle.Manufacturer = Manufacturer;
                vehicle.Model = Model;
                vehicle.YearModel = YearModel;

                Vehicles.Add(vehicle);

                // Nollställ fälten
                RegistrationNumber = Manufacturer = Model = YearModel = string.Empty;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void SearchVehicle()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                SearchResult = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var found = Vehicles.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == SearchText.ToLower());
            if (found != null)
            {
                string typeName = found switch
                {
                    Car => "Bil",
                    Motorcycle => "MC",
                    Truck => "Lastbil",
                    _ => "Okänd typ"
                };

                SearchResult = $"Fordon hittat:\n" +
                               $"Registreringsnummer: {found.RegistrationNumber}\n" +
                               $"Tillverkare: {found.Manufacturer}\n" +
                               $"Modell: {found.Model}\n" +
                               $"Typ: {typeName}";
            }
            else
            {
                SearchResult = "Inget fordon hittades med det registreringsnumret.";
            }
        }
    }
}
