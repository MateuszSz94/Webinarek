using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webinarek.Models.Entity
{
    public class Webinar
    {
        [Column(@"id")]
        public virtual decimal Id { get; set; }

        [Column(@"tytul")]
        public virtual string Title { get; set; }

        [Column(@"CzasTrwania")]
        public virtual DateTime Duration { get; set; }

        [Column(@"opis")]
        public virtual string Description { get; set; }

        [Column(@"FileName")]
        public virtual string FileName { get; set; }

        [Column(@"MimeType")]
        public virtual string MimeType { get; set; }

        public virtual List<Lista_webinarow_w_kursies> Kurses { get; set; }
    }
}