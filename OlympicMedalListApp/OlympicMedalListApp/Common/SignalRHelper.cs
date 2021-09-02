using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using NotifyServer.Models;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OlympicMedalListApp.Common
{
    public class SignalRHelper
    {
        public const string NotificationMessage = "notificationMessage";
        public const string NotificationProxy = "notificationHub";

        private HubConnection Hub { get; set; }
        private IHubProxy Chat { get; set; }

        public SignalRHelper(string address = "http://192.168.1.6:57601/")
        {
            Hub = new HubConnection(address);
            Chat = Hub.CreateHubProxy(NotificationProxy);

            Hub.Start().Wait();
            Chat.On<int, string>("notificationMessageToClient",(t,m)=> {
                if (t == 1)
                {
                    //Gold Message
                    //Notification
                    //Uti.Message(m);
                    var news = JsonConvert.DeserializeObject<News>(m);
                    var notification = new NotificationRequest()
                    {

                        BadgeNumber = 1,
                        Description = news.NewsContentPreview,
                        Title = news.Title,
                        ReturningData = m,
                        NotificationId = 1,
                        Schedule = new NotificationRequestSchedule()
                        {
                            NotifyTime = DateTime.Now.AddSeconds(1),
                        },
                        

                    };

                    NotificationCenter.Current.Show(notification);
                    NotificationCenter.Current.NotificationTapped += (e)=> {
                        var _news = JsonConvert.DeserializeObject<News>(e.Request.ReturningData);
                        
                        App.Current.MainPage.Navigation.PushModalAsync(new Views.NewsDetailPage(_news.ID));
                    };

                    MessagingCenter.Send<SignalRHelper,int>(this, "News",t);
                }
                else
                {
                    //Normal Message
                }
            });
            
        }

        private void Current_NotificationTapped(NotificationEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
