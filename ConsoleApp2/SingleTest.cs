using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using ServiceStack;
using TwitterReader;

namespace ConsoleApp2
{
    [TestFixture("single", "chrome")]
    public class SingleTest : BrowserStackNUnitTest
    {
        public SingleTest(string profile, string environment) : base(profile, environment) { }
        private Tweet[] lastTweets;
        private string FinalOutputPath;
        List<UserInfo> userinfos = new List<UserInfo>();

        [Test]
        public void GetUserInfoToFollow()
        {
            //Navigate to the Twitter's Login URL page
            driver.Navigate().GoToUrl("https://twitter.com/login");

            //Find the Email Element for Login
            IWebElement userName = driver.FindElement(By.ClassName("js-username-field"));

            //Enter the Email Address in the Text Box
            userName.SendKeys("anshulagarwal129@gmail.com");


            //Find the PW Element and Enter PW
            IWebElement pass = driver.FindElement(By.ClassName("js-password-field"));

            //Enter the PW in the Pw box
            pass.SendKeys("aesha@14");

            //Find Login Button Element and Click
            IWebElement loginButton = driver.FindElement(By.CssSelector(".submit.EdgeButton.EdgeButton--primary.EdgeButtom--medium"));
            loginButton.Click();

            //wait
            Thread.Sleep(3000);

            if (driver.FindElements(By.Id("challenge_response")).Any())
            {
                driver.FindElement(By.Id("challenge_response")).SendKeys("9873749630");
            }
            //
            if (driver.FindElements(By.Id("email_challenge_submit")).Any())
            {
                driver.FindElement(By.Id("email_challenge_submit")).Click();
            }
            
            Thread.Sleep(5000);
            var followelements =
                driver.FindElements(By.CssSelector(".account-group-inner .username.u-dir.u-textTruncate b"));
            List<string> userHandles = followelements.Select(item => item.Text).ToList();

            //

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

            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
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
            
            foreach (var userHandle in userHandles)
            {
                // Do the timeline
                var userSuggestions =
                    "https://api.twitter.com/1.1/users/show.json?screen_name=@" + userHandle;

                var userSuggestionsFormat = "{0} {1}";
                userinfos.Add(userSuggestions.GetJsonFromUrl(req => req.Headers.Add("Authorization",
                        string.Format(userSuggestionsFormat, twitAuthResponse.token_type, twitAuthResponse.access_token)))
                    .FromJson<UserInfo>());
            }


        }

        [Test]
        public void SendEmailTest()
        {
            lastTweets = DataFetcher.FetchTweets("@stepin_forum");
            var reqData = DataFetcher.GetTopData(lastTweets);
            reqData.timestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //Fill Biography
            reqData.biograhies = new Biograhies[3];
            int counter = 0;
            foreach (var userinfo in userinfos)
            {
                reqData.biograhies[counter++] = new Biograhies()
                {
                    name = userinfo.name,
                    handle_name = userinfo.screen_name,
                    follower_count = userinfo.followers_count,
                    following_count = userinfo.friends_count,
                    numberoftweets = userinfo.statuses_count
                };
            }
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Result");
            FinalOutputPath = AppDomain.CurrentDomain.BaseDirectory + "Result\\FinalOutput.json";
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Result\\FinalReport.html",$"<!DOCTYPE html><html><head><style>table{{font - family:arial,sans-serif;border-collapse:collapse;width:100%}}td,th{{border:1px solid #ddd;text-align:left;padding:8px}}tr:nth-child(even){{background - color:#ddd}}</style></head>" +
                                                                                                  $"<body><button type='button'>Export To</button><br /><h2>Final Report  [{reqData.timestamp}]</h2><h4>Most Retweeted Tweet [Count : {reqData.top_retweet_count}]</h4> {reqData.top_retweet_tweet} <br /><h4>Most Like Tweet [Count : {reqData.top_like_count}]</h4> {reqData.top_like_tweet} <br /><h4>Top 10 hastags</h4><p>{string.Join(" , ", reqData.top_10_hashtags)}<p/> <br /><h4>Whom To Follow biography</h4>" +
                                                                                                  $"<table><tr><th>Name</th><th>Handle Name</th><th>Followers</th><th>Following</th><th>Number of Tweets</th></tr>" +
                                                                                                  $"<tr><td>{reqData.biograhies[0].name}</td><td>{reqData.biograhies[0].handle_name}</td><td>{reqData.biograhies[0].follower_count}</td><td>{reqData.biograhies[0].following_count}</td><td>{reqData.biograhies[0].numberoftweets}</td></tr><tr><td>{reqData.biograhies[1].name}</td><td>{reqData.biograhies[1].handle_name}</td><td>{reqData.biograhies[1].follower_count}</td><td>{reqData.biograhies[1].following_count}</td><td>{reqData.biograhies[1].numberoftweets}</td></tr><tr><td>{reqData.biograhies[2].name}</td><td>{reqData.biograhies[2].handle_name}</td><td>{reqData.biograhies[2].follower_count}</td><td>{reqData.biograhies[2].following_count}</td><td>{reqData.biograhies[2].numberoftweets}</td></tr></table></body></html>");
            File.AppendAllText(FinalOutputPath, JsonConvert.SerializeObject(reqData));
            (new Email()).EmailSend(FinalOutputPath);
        }

        [Test]
        public void VerifyData()
        {
            var client = new JsonServiceClient("http://cgi-lib.berkeley.edu/ex/fup.cgi");
            var fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Result\\FinalOutput.json");
            var response = client.PostFile<object>(
                "http://cgi-lib.berkeley.edu/ex/fup.cgi",
                fileToUpload: fileInfo,
                mimeType: "multipart/form-data; boundary=----WebKitFormBoundaryuCI1ULFipHHBANQR");
        }
    }
}