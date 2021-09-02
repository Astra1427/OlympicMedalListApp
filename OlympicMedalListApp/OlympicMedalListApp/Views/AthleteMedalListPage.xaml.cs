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
    public partial class AthleteMedalListPage : ContentPage
    {
        public AthleteMedalListPage()
        {
            InitializeComponent();
            this.BackgroundColor = Color.FromRgb(48,135,235);
            this.BindingContext = new ViewModel.AthleteMedalListViewModel();
        }
    }
}