using System.Collections.Generic;

namespace ResAlbumFlickr
{
    class Album
    {
        public string id { get; set; }
        public int photo_count { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public List<string> photos { get; set; }


        /*
         "url": "https://www.flickr.com/photos/xukien/albums/72157682664440290",
			"title": "Quy Nhon trip",
			"description": "27 - 30.04.2017",
			"view_count": "0",
			"created": "1496595750",
			"last_updated": "1496595767",
			"cover_photo": "https://www.flickr.com/photos/xukien/34707950170",
         
         */
    }
}
