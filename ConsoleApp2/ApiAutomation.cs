using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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
        }

        [Test]
        public void VerifyData()
        {
            
        }
    }
}
