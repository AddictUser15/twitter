using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using TweetSharp;
using TwitterReader;

namespace ConsoleApp2
{
    [TestFixture]
    class ApiAutomation
    {
        private Tweet[] lastTweets;
        [OneTimeSetUp]
        public void BeforeClass()
        {
            lastTweets = DataFetcher.FetchTweets("@stepin_forum");
            var reqData = DataFetcher.GetTopData(lastTweets);
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Result");
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Result\\FinalOutput.json", JsonConvert.SerializeObject(reqData));
        }

        [Test]
        public void VerifyData()
        {
            
        }

        [Test]
        public void CheckFavUpdate()
        {
            var service = new TwitterService("08EyoPXc8iXlwfYWsefDOj6br", "zFSsMKxJfAdD12lDU70jQHBjBQOEfDwuSpFj5jEyIrvWKhQaG2");
            service.AuthenticateWith("1121269187198976003-wbfPhqFrLF5aZmf9FnTKUyUpek3Hhk", "OulLp7xFFfnpE5C1MgwyoNMT1Rb5CHbJxkKqnHRvkNMhz");
            TwitterSearchResult res = service.Search(new SearchOptions { Q = "TestAutothon", Count = 5 });
            IEnumerable<TwitterStatus> status = res.Statuses;
            foreach (var tweet in status)
            {
                Console.WriteLine(tweet.Text);
                service.FavoriteTweet(new FavoriteTweetOptions { Id = tweet.Id });
            }
        }
    }
}
