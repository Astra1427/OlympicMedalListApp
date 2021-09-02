using NotifyServer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OlympicMedalListApp.ViewModel
{
    public class CountryMedalListViewModel:BaseViewModel
    {

        private List<Country> countries;

        public List<Country> Countries
        {
            get { return countries; }
            set { countries = value; RaisePropertyChanged("Countries"); }
        }
        public new Command RefreshCommand => new Command((obj)=> {
            LoadData(()=>Countries = App.Countries);
        });

        public CountryMedalListViewModel()
        {
            LoadData(() => Countries = App.Countries);
        }

    }
}
