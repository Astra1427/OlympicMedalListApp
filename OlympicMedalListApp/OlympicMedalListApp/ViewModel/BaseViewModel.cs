using NotifyServer.Models;
using OlympicMedalListApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace OlympicMedalListApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

        private bool isRefreshing;

        public virtual bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; RaisePropertyChanged("IsRefreshing"); }
        }

        public virtual Command RefreshCommand => new Command((obj)=> {
            LoadData(()=> { });
        });

        public async virtual void LoadData(Action callBack)
        {
            
            IsRefreshing = true;
            try
            {
                App.MedalList = await Uti.GetTAsync<List<MedalList>>("MedalLists");
                App.News = await Uti.GetTAsync<List<News>>("News");
                App.Sports = await Uti.GetTAsync<List<Sport>>("Sports");
                App.Athletes = await Uti.GetTAsync<List<Athlete>>("Athletes");
                App.Countries = await Uti.GetTAsync<List<Country>>("Countries");

            }
            catch (Exception ex)
            {
                Uti.NetworkMessage();
                IsRefreshing = false;
                return;
            }
            try
            {

                int no = 1;
                App.Countries = App.Countries.OrderByDescending(a=>a.GoldNumber).ToList();
                App.Countries.ForEach(a =>
                {
                    a.No = no++;
                });

                no = 1;
                App.Athletes = App.Athletes.OrderByDescending(a => a.GoldNumber).ToList();
                App.Athletes.ForEach(a=> {
                    a.No = no++;
                });

            }
            catch (Exception ex)
            {
                Uti.FailedMessage();
                IsRefreshing = false;
            }

            IsRefreshing = false;

            callBack.Invoke();
        }


    }
}
