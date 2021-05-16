using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiToken.Models
{
    public class KutuphaneServis:DbContext
    {
        public KutuphaneServis():base("name=KutuphaneEntity")
        {
                
        }
        public DbSet<Kitap> Kitaplar { get; set; }
    }
}