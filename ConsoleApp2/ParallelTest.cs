using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleApp2
{
    [TestFixture("parallel", "chrome")]
    [TestFixture("parallel", "firefox")]
    [TestFixture("parallel", "safari")]
    [TestFixture("parallel", "ie")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ParallelTest // : SingleTest //todo no broswerstack account
    {
        //public ParallelTest(string profile, string environment) : base(profile, environment) { }
    }
}
