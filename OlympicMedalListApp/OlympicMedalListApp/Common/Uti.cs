using Newtonsoft.Json;
using OlympicMedalListApp.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OlympicMedalListApp.Common
{
    public static class Uti
    {
        #region Resources
        public static ImageSource GetImage(string name)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream((byte[])Resources.ResourceManager.GetObject(name)))
                {
                    return ImageSource.FromStream(() => { return ms; });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region Network


        public static string BaseIP = "http://192.168.1.6:57601/api/";

        public static HttpClient Client = new HttpClient() { BaseAddress = new Uri(BaseIP) ,Timeout = new TimeSpan(0,0,10)};


        public static async Task<string> GetStringAsync(string route)
        {
            try
            {
                var json = await Client.GetStringAsync(route);

                return json;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static async Task<T> GetTAsync<T>(string route)
        {
            string json = await GetStringAsync(route);
            if (json == null || json == "")
            {
                throw new NullReferenceException();
            }
            try
            {

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Message

        public static void Message(string content, string title="Tips",string ok = "Ok")
        {
            App.Current.MainPage.DisplayAlert(title,content,ok);
        }

        public static void SuccessMessage(string content = "Success!",string title = "Tips",string OK = "OK")
        {
            Message(content,title, OK);
        }

        public static void FailedMessage(string content = "Failed!", string title = "Tips", string OK = "OK")
        {
            Message(content,title, OK);
        }

        public static void NetworkMessage(string content = "Failed!\nPlease check your network and try again!",string title = "Tips",string ok = "OK")
        {
            Message(content,title, ok);
        }

        #endregion

    }
}
