using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OlympicMedalListApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryMedalListPage : ContentPage
    {
        public CountryMedalListPage()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.CountryMedalListViewModel();
            this.BackgroundColor = Color.FromRgb(48,135,235);
            
        }
    }
}