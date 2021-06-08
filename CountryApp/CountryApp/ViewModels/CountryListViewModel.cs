using System.Collections.Generic;

using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using CountryApp.Models;
using CountryApp.Services;

using Microsoft.Maui.Controls;
using System;

namespace CountryApp.ViewModels
{
    public class CountryListViewModel : BaseViewModel
    {
        public ObservableCollection<Country> Countries { get; }

        public ICommand LoadCountriesCommand { get; private set; }

        private void LoadData()
        {
            IsBusy = true;

            var list = Task.Run(async () => await GeonamesService.GetCountries()).Result;
            Countries.Clear();

            foreach (Country country in list)
            {
                if (!string.IsNullOrWhiteSpace(country.CurrencyCode))
                {
                    string code = country.CountryCode.ToLower();
                    //country.FlagUrl = $"https://raw.githubusercontent.com/hjnilsson/country-flags/master/png250px/{code}.png";
                    country.FlagUrl = "dotnet_bot.png";
                }

                Countries.Add(country);
            }

            IsBusy = false;

        }

        public CountryListViewModel()
        {
            Countries = new ObservableCollection<Country>();
            LoadCountriesCommand = new Command(LoadData);
        }
    }
}
