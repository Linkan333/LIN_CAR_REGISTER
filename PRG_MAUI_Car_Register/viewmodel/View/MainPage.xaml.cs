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
                Vehicle vehicle;

                string selectedType = pickerType.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedType))
                    throw new ArgumentException("Du måste välja en fordons typ.");
                if (selectedType == "Bil")
                    vehicle = new Car();
                else if (selectedType == "MC")
                    vehicle = new Motorcycle();
                else if (selectedType == "Lastbil")
                    vehicle = new Truck();
                else
                    throw new ArgumentException("Välj ett giltigt fordons typ.");

                vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                vehicle.Manufacturer = entryManufacturer.Text;
                vehicle.Model = entryModel.Text;
                vehicle.YearModel = entryYearModel.Text;


                vehicleList.Add(vehicle);

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
