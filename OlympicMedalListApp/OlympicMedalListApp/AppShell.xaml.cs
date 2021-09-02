using OlympicMedalListApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OlympicMedalListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Icon_Medal = Uti.GetImage("icon_medal");
            BindingContext = this;
            this.BackgroundColor = Color.FromRgb(48,135,235);
        }

        

        public ImageSource Icon_Medal { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}