using NotifyServer.Models;
using OlympicMedalListApp.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OlympicMedalListApp.ViewModel
{
    public class NewsViewModel : BaseViewModel
    {
        private List<News> newsList;

        public List<News> NewsList
        {
            get { return newsList; }
            set { newsList = value; RaisePropertyChanged("NewsList"); }
        }

        public new Command RefreshCommand => new Command((obj)=> {
            LoadData(() => this.NewsList = App.News) ;
        });
        public Command NewsTapCommand => new Command((ID)=> {
            int id = (int)ID;
            App.Current.MainPage.Navigation.PushModalAsync(new Views.NewsDetailPage(id));
        });

        public Command TapCommand{ get { return new Command((obj) => {
            Uti.Message(obj.ToString());
        }); } }

        public NewsViewModel()
        {
            LoadData(() => this.NewsList = App.News) ;
            MessagingCenter.Subscribe<SignalRHelper,int>(this,"News",(sender,arg)=> {
                LoadData(() => this.NewsList = App.News);
            });
        }




    }
}
