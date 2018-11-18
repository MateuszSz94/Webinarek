using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Webinarek.Models
{
    public class WebinarViewModel
    {
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Czas trwania")]
        public DateTime Duration { get; set; }
        public VideoData VideoData { get; set; }
    }

    [Serializable]
    public class VideoData
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
    }
}