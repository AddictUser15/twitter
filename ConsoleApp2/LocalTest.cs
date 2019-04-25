using System.Text.RegularExpressions;
using NUnit.Framework;

namespace ConsoleApp2
{
    [TestFixture("local", "chrome")]
    public class LocalTest : BrowserStackNUnitTest
    {
        public LocalTest(string profile, string environment) : base(profile, environment) { }

        //[Test]
        public void HealthCheck()
        {
            driver.Navigate().GoToUrl("http://bs-local.com:45691/check");
            Assert.IsTrue(Regex.IsMatch(driver.PageSource, "Up and running", RegexOptions.IgnoreCase));
        }
    }
}