using NotifyServer.Models;
using OlympicMedalListApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OlympicMedalListApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        public static List<MedalList> MedalList { get; set; }
        public static List<News> News { get; set; }
        public static List<Athlete> Athletes { get; set; }
        public static List<Sport> Sports { get; set; }
        public static List<Country> Countries { get; set; }

        SignalRHelper signal { get; set; }

        protected override void OnStart()
        {
            //Start SignalR
            signal = new SignalRHelper();
            
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
