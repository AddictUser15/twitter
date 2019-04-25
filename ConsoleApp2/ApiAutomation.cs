using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using ServiceStack;
using TweetSharp;
using TwitterReader;

namespace ConsoleApp2
{
    [TestFixture]
    class ApiAutomation
    {
       
        [OneTimeSetUp]
        public void BeforeClass()
        {
           
            
           

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

        [Test]
        public void FetchBiography()
        {
            DataFetcher.FetchUserSuggestions();
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
                var serviceResponse = service.FavoriteTweet(new FavoriteTweetOptions { Id = tweet.Id });

            }
        }

        
    }
}
