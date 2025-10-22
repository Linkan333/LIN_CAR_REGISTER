using System;
using System.Linq;
using Microsoft.Maui.Controls;
using PRG_MAUI_Car_Register.Models;

namespace PRG_MAUI_Car_Register
{
    public partial class MainPage : ContentPage
    {
        private readonly List<Vehicle> vehicleList = new();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                Vehicle vehicle = pickerType.SelectedIndex switch
                {
                    0 => new Car(),
                    1 => new Motorcycle(),
                    2 => new Truck(),
                    _ => throw new ArgumentException("Välj en giltig fordonstyp.")
                };

                vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                vehicle.Manufacturer = entryManufacturer.Text;
                vehicle.Model = entryModel.Text;
                vehicle.YearModel = entryYearModel.Text;

                // Om du har unika fält kan du läsa in dem baserat på typ, t.ex.:
                if (vehicle is Car car)
                {
                    // car.NumberOfDoors = ... // hämta från UI
                }
                else if (vehicle is Motorcycle mc)
                {
                    // mc.HasSidecar = ...
                }
                else if (vehicle is Truck tr)
                {
                    // tr.MaxLoadKg = ...
                }

                vehicleList.Add(vehicle);

                listViewVehicles.ItemsSource = null;
                listViewVehicles.ItemsSource = vehicleList;

                entryRegistrationNumber.Text = string.Empty;
                entryManufacturer.Text = string.Empty;
                entryModel.Text = string.Empty;
                entryYearModel.Text = string.Empty;
            }
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!e.Value) return;

            var filtered = radioCar.IsChecked
                ? vehicleList.Where(v => v is Car)
                : radioMC.IsChecked
                    ? vehicleList.Where(v => v is Motorcycle)
                    : radioTruck.IsChecked
                        ? vehicleList.Where(v => v is Truck)
                        : vehicleList;

            listViewVehicles.ItemsSource = filtered.ToList();
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var found = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);
            if (found != null)
            {
                string typeName = found switch
                {
                    Car => "Bil",
                    Motorcycle => "MC",
                    Truck => "Lastbil",
                    _ => "Okänd typ"
                };

                labelSearchResult.Text = $"Fordon hittat:\n" +
                                         $"Registreringsnummer: {found.RegistrationNumber}\n" +
                                         $"Tillverkare: {found.Manufacturer}\n" +
                                         $"Modell: {found.Model}\n" +
                                         $"Typ: {typeName}";
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }
    }
}
