using System.Threading.Tasks;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

using CountryApp.ViewModels;

namespace CountryApp
{
    public partial class CountryView : ContentPage, IPage
    {
        CountryListViewModel vm;

        public CountryView()
        {
            InitializeComponent();

            vm = new CountryListViewModel();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.LoadCountriesCommand.Execute(null);
        }
    }
}