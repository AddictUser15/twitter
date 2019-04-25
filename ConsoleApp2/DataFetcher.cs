using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceStack;
using ServiceStack.Text;

namespace TwitterReader
{
    public static class DataFetcher
    {
        public static Tweet[] FetchTweets(string screenname)
        {
            var oAuthConsumerKey = "08EyoPXc8iXlwfYWsefDOj6br";
            var oAuthConsumerSecret = "zFSsMKxJfAdD12lDU70jQHBjBQOEfDwuSpFj5jEyIrvWKhQaG2";
            var oAuthUrl = "https://api.twitter.com/oauth2/token";
            

            // Do the Authenticate
            var authHeaderFormat = "Basic {0}";

            var authHeader = string.Format(authHeaderFormat,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oAuthConsumerKey) + ":" +
                                                              Uri.EscapeDataString((oAuthConsumerSecret)))
                ));

            var postBody = "grant_type=client_credentials";

            HttpWebRequest authRequest = (HttpWebRequest) WebRequest.Create(oAuthUrl);
            authRequest.Headers.Add("Authorization", authHeader);
            authRequest.Method = "POST";
            authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (Stream stream = authRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }

            authRequest.Headers.Add("Accept-Encoding", "gzip");

            WebResponse authResponse = authRequest.GetResponse();
            // deserialize into an object
            TwitAuthenticateResponse twitAuthResponse;
            using (authResponse)
            {
                using (var reader = new StreamReader(authResponse.GetResponseStream()))
                {
                    var objectText = reader.ReadToEnd();
                    twitAuthResponse = JsonConvert.DeserializeObject<TwitAuthenticateResponse>(objectText);
                }
            }


            // Do the timeline
            var timelineFormat =
                "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&include_rts=1&exclude_replies=1&count=50";

            var timelineUrl = string.Format(timelineFormat, screenname);
            var timelineHeaderFormat = "{0} {1}";
            return timelineUrl.GetJsonFromUrl(req => req.Headers.Add("Authorization",
                    string.Format(timelineHeaderFormat, twitAuthResponse.token_type, twitAuthResponse.access_token)))
                .FromJson<Tweet[]>();
        }
    }

    public class TwitAuthenticateResponse
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
    }
}