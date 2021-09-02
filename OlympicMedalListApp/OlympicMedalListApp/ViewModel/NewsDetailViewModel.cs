using NotifyServer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OlympicMedalListApp.ViewModel
{
    public class NewsDetailViewModel:BaseViewModel
    {
        private News anews;

        public News aNews
        {
            get { return anews; }
            set { anews = value; RaisePropertyChanged("aNews"); }
        }



        public NewsDetailViewModel(int NewsID)
        {
            this.aNews = App.News.FirstOrDefault(a=>a.ID == NewsID);
            if (this.aNews == null)
            {
                LoadData(()=> { this.aNews = App.News.FirstOrDefault(a => a.ID == NewsID); });
            }
        }
    }
}
