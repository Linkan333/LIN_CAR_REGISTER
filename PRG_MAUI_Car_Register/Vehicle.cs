using System;
using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register.Models
{
    public partial class Vehicle
    {
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string yearModel = string.Empty;

        public Vehicle()
        {
        }

        public string RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Du måste fylla i registreringsnumret.");

                if (value.Length == 6)
                {
                    for (int i = 0; i < 3; i++)
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("De första tre tecknen måste vara bokstäver.");

                    for (int i = 3; i < 6; i++)
                    {
                        if (i < 5)
                        {
                            if (!char.IsDigit(value[i]))
                                throw new ArgumentException("Fjärde och femte måste vara siffror.");
                        }
                        else
                        {
                            if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                            {
                                throw new ArgumentException("Sjätte måste vara siffra eller bokstav.");
                            }
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Registreringsnumret måste vara exakt 6 tecken.");
                }

                registrationNumber = value.ToUpper();
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Du måste fylla i tillverkaren.");
                manufacturer = value;
            }
        }

        public string Model
        {
            get => model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Du måste fylla i modell.");
                model = value;
            }
        }

        public string YearModel
        {
            get => yearModel;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Du måste fylla i årsmodell.");

                // Vi använder GeneratedRegexAttribute senare, men för nu kan vi behålla en regexmatcher
                if (!YearPattern().IsMatch(value))
                    throw new ArgumentException("Årsmodellen måste vara i formatet YYYY, giltigt år.");

                int parsed = int.Parse(value);
                int currentYear = DateTime.Now.Year;
                if (parsed < 1886 || parsed > currentYear)
                    throw new ArgumentException($"Årsmodellen måste vara mellan 1886 och {currentYear}.");

                yearModel = value;
            }
        }

        [GeneratedRegex("^(18[8-9]\\d|19\\d{2}|20\\d{2}|21\\d{2}|22\\d{2}|23\\d{2}|24\\d{2}|25\\d{2})$")]
        private static partial Regex YearPattern();

        public override string ToString()
        {
            return $"{registrationNumber}\t{manufacturer}\t{model}\t{yearModel}";
        }
    }
}
