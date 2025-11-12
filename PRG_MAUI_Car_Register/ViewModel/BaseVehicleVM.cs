using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PRG_MAUI_Car_Register.Models;

namespace PRG_MAUI_Car_Register.ViewModels
{
    public class BaseVehicleVM : INotifyPropertyChanged
    {
        public string RegistrationNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string YearModel { get; set; }

        public int Seats { get; set; } // Bil / MC
        public int LoadCapacity { get; set; } // Lastbil

        public string SelectedType { get; set; }
        public string SearchText { get; set; }
        public string SearchResult { get; set; }

        public ObservableCollection<Vehicle> Vehicles { get; } = new();

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
                    "Bil" => new Car
                    {
                        RegistrationNumber = RegistrationNumber,
                        Manufacturer = Manufacturer,
                        Model = Model,
                        YearModel = YearModel,
                        Seats = Seats
                    },
                    "MC" => new Motorcycle
                    {
                        RegistrationNumber = RegistrationNumber,
                        Manufacturer = Manufacturer,
                        Model = Model,
                        YearModel = YearModel,
                        Seats = Seats
                    },
                    "Lastbil" => new Truck
                    {
                        RegistrationNumber = RegistrationNumber,
                        Manufacturer = Manufacturer,
                        Model = Model,
                        YearModel = YearModel,
                        LoadCapacity = LoadCapacity
                    },
                    _ => null
                };

                if (vehicle != null)
                {
                    Vehicles.Add(vehicle);

                    // nollställ fälten
                    RegistrationNumber = Manufacturer = Model = YearModel = string.Empty;
                    Seats = 0;
                    LoadCapacity = 0;
                    SelectedType = null;
                    OnPropertyChanged(nameof(RegistrationNumber));
                    OnPropertyChanged(nameof(Manufacturer));
                    OnPropertyChanged(nameof(Model));
                    OnPropertyChanged(nameof(YearModel));
                    OnPropertyChanged(nameof(Seats));
                    OnPropertyChanged(nameof(LoadCapacity));
                    OnPropertyChanged(nameof(SelectedType));
                }
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
            }
            else
            {
                var found = Vehicles.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == SearchText.ToLower());
                SearchResult = found != null ? found.GetDescription() : "Inget fordon hittades med det registreringsnumret.";
            }
            OnPropertyChanged(nameof(SearchResult));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
