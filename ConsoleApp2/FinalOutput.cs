using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class FinalOutput
    {
        public int top_retweet_count { get; set; }
        public string top_retweet_tweet { get; set; }
        public int top_like_count { get; set; }
        public string top_like_tweet { get; set; }
        public string[] top_10_hashtags { get; set; }
        public Biograhies[] biograhies { get; set; }
        
    }

    public class Biograhies
    {
        public string name { get; set; }
        public string handle_name { get; set; }
        public string follower_count { get; set; }
        public string following_count { get; set; }
    }
}