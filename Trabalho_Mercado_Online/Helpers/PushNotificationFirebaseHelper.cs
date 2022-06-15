using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Mercado_Online.Helpers
{
    public class PushNotificationFirebaseHelper
    {
        /*
         //dT1DJYzUT8a3P__RFnbjRP:APA91bGSSjrw64CIzjQgRu-GTWOE8hpHcHiQiaUvl_9EyBDI67XxLTghKWll55lq5thvaKq0nKrM896svieWaNSpXYAbRyTrBJ34ujq7Qonu87G8nc3QduYyq46H2reQGcxEZv64qT9d
         //cop-xEv8TkKhIj-yMMjJ3g:APA91bFG6DR7m71h6Iz0BYwMIbajSSz-7AxNZt43H21M-qEEX-Zc2xr_CwRuG3fCbuhT_6ibmkfOKSUjdYXDTTp7AigNpebK6uyGs2VrYXIUP5Voc3u7RcPV30hMKzfo18xXvWuXV1Si
         //http://codepickup.in/csharp/fcm-push-notification-in-csharp/
         */
        private static string URL = "https://fcm.googleapis.com/fcm/send";
        private static string SERVER_API_KEY = "AAAAjnIWGgs:APA91bHr2oGfhdQDKD0U8nFMnA7tj8IlAaehaqNQo-WmgJazxAaYR4JDy97zZbxO0rewh3AwrUJd4a4kxnw18CVbvhdvAx006Pn58-BkgxtqQzK-GjA8UcieucI7CtvDxmM2whE3e0uc";
        private static string SENDER_ID = "611799407115";
        public static void EnvioUnico(string Token,string titulo, string menssagem)
        {
            try
            {
                dynamic data = new
                {
                    to = Token,
                    notification = new
                    {
                        title = titulo,
                        body = menssagem,
                        link = "",
                        priority = "high"
                    }
                };
                var json = JsonConvert.SerializeObject(data);
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);
                WebRequest tRequest;
                tRequest = WebRequest.Create(URL);
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse tResponse = tRequest.GetResponse();
                dataStream = tResponse.GetResponseStream();
                StreamReader tReader = new StreamReader(dataStream);
                String sResponseFromServer = tReader.ReadToEnd();
                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void EnvioMulti(List<string> Token, string titulo, string menssagem)
        {
            try
            {  
                dynamic data = new
                {
                    registration_ids = Token,
                    notification = new
                    {
                        title = titulo,
                        body = menssagem,
                        link = "",
                        priority = "high"
                    }
                };
                var json = JsonConvert.SerializeObject(data);
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);
                WebRequest tRequest;
                tRequest = WebRequest.Create(URL);
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse tResponse = tRequest.GetResponse();
                dataStream = tResponse.GetResponseStream();
                StreamReader tReader = new StreamReader(dataStream);
                String sResponseFromServer = tReader.ReadToEnd();
                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

