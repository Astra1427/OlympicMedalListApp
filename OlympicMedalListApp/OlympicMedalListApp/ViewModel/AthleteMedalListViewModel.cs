using NotifyServer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OlympicMedalListApp.ViewModel
{
    class AthleteMedalListViewModel:BaseViewModel
    {
        private List<Athlete> athletes;

        public List<Athlete> Athletes
        {
            get { return athletes; }
            set { athletes = value;RaisePropertyChanged("Athletes"); }
        }

        public new Command RefreshCommand => new Command((obj)=> { 
            LoadData(()=> { Athletes = App.Athletes; });

        });

        public AthleteMedalListViewModel()
        {
            LoadData(()=> { Athletes = App.Athletes; });
        }



    }
}
