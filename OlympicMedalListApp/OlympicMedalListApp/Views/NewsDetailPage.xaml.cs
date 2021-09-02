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
    public partial class NewsDetailPage : ContentPage
    {
        public NewsDetailPage(int NewsID)
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.NewsDetailViewModel(NewsID);
        }
    }
}