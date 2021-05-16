using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiToken.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string kitapAd { get; set; }
        public string yazarAd { get; set; }
    }
}