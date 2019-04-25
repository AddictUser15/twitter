using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class UserInfo
    {

       public int id { get; set; }
            public string id_str { get; set; }
            public string name { get; set; }
            public string screen_name { get; set; }
            public string location { get; set; }
            public object profile_location { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public Entities entities { get; set; }
            public bool _protected { get; set; }
            public int followers_count { get; set; }
            public int friends_count { get; set; }
            public int listed_count { get; set; }
            public string created_at { get; set; }
            public int favourites_count { get; set; }
            public object utc_offset { get; set; }
            public object time_zone { get; set; }
            public bool geo_enabled { get; set; }
            public bool verified { get; set; }
            public int statuses_count { get; set; }
            public string lang { get; set; }
            public Status status { get; set; }
            public bool contributors_enabled { get; set; }
            public bool is_translator { get; set; }
            public bool is_translation_enabled { get; set; }
            public string profile_background_color { get; set; }
            public string profile_background_image_url { get; set; }
            public string profile_background_image_url_https { get; set; }
            public bool profile_background_tile { get; set; }
            public string profile_image_url { get; set; }
            public string profile_image_url_https { get; set; }
            public string profile_banner_url { get; set; }
            public string profile_link_color { get; set; }
            public string profile_sidebar_border_color { get; set; }
            public string profile_sidebar_fill_color { get; set; }
            public string profile_text_color { get; set; }
            public bool profile_use_background_image { get; set; }
            public bool has_extended_profile { get; set; }
            public bool default_profile { get; set; }
            public bool default_profile_image { get; set; }
            public object following { get; set; }
            public object follow_request_sent { get; set; }
            public object notifications { get; set; }
            public string translator_type { get; set; }
        }

        public class Entities
        {
            public Url url { get; set; }
            public Description description { get; set; }
        }

        public class Url
        {
            public Url1[] urls { get; set; }
        }

        public class Url1
        {
            public string url { get; set; }
            public string expanded_url { get; set; }
            public string display_url { get; set; }
            public int[] indices { get; set; }
        }

        public class Description
        {
            public object[] urls { get; set; }
        }

        public class Status
        {
            public string created_at { get; set; }
            public long id { get; set; }
            public string id_str { get; set; }
            public string text { get; set; }
            public bool truncated { get; set; }
            public Entities1 entities { get; set; }
            public Extended_Entities extended_entities { get; set; }
            public string source { get; set; }
            public object in_reply_to_status_id { get; set; }
            public object in_reply_to_status_id_str { get; set; }
            public object in_reply_to_user_id { get; set; }
            public object in_reply_to_user_id_str { get; set; }
            public object in_reply_to_screen_name { get; set; }
            public object geo { get; set; }
            public object coordinates { get; set; }
            public object place { get; set; }
            public object contributors { get; set; }
            public bool is_quote_status { get; set; }
            public int retweet_count { get; set; }
            public int favorite_count { get; set; }
            public bool favorited { get; set; }
            public bool retweeted { get; set; }
            public bool possibly_sensitive { get; set; }
            public string lang { get; set; }
        }

        public class Entities1
        {
            public Hashtag[] hashtags { get; set; }
            public object[] symbols { get; set; }
            public object[] user_mentions { get; set; }
            public Url2[] urls { get; set; }
            public Medium[] media { get; set; }
        }

        public class Hashtag
        {
            public string text { get; set; }
            public int[] indices { get; set; }
        }

        public class Url2
        {
            public string url { get; set; }
            public string expanded_url { get; set; }
            public string display_url { get; set; }
            public int[] indices { get; set; }
        }

        public class Medium
        {
            public long id { get; set; }
            public string id_str { get; set; }
            public int[] indices { get; set; }
            public string media_url { get; set; }
            public string media_url_https { get; set; }
            public string url { get; set; }
            public string display_url { get; set; }
            public string expanded_url { get; set; }
            public string type { get; set; }
            public Sizes sizes { get; set; }
        }

        public class Sizes
        {
            public Thumb thumb { get; set; }
            public Large large { get; set; }
            public Medium1 medium { get; set; }
            public Small small { get; set; }
        }

        public class Thumb
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Large
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Medium1
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Small
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Extended_Entities
        {
            public Medium2[] media { get; set; }
        }

        public class Medium2
        {
            public long id { get; set; }
            public string id_str { get; set; }
            public int[] indices { get; set; }
            public string media_url { get; set; }
            public string media_url_https { get; set; }
            public string url { get; set; }
            public string display_url { get; set; }
            public string expanded_url { get; set; }
            public string type { get; set; }
            public Sizes1 sizes { get; set; }
            public Video_Info video_info { get; set; }
            public Additional_Media_Info additional_media_info { get; set; }
        }

        public class Sizes1
        {
            public Thumb1 thumb { get; set; }
            public Large1 large { get; set; }
            public Medium3 medium { get; set; }
            public Small1 small { get; set; }
        }

        public class Thumb1
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Large1
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Medium3
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Small1
        {
            public int w { get; set; }
            public int h { get; set; }
            public string resize { get; set; }
        }

        public class Video_Info
        {
            public int[] aspect_ratio { get; set; }
            public int duration_millis { get; set; }
            public Variant[] variants { get; set; }
        }

        public class Variant
        {
            public string content_type { get; set; }
            public string url { get; set; }
            public int bitrate { get; set; }
        }

        public class Additional_Media_Info
        {
            public string title { get; set; }
            public string description { get; set; }
            public bool embeddable { get; set; }
            public bool monetizable { get; set; }
        }

    }
