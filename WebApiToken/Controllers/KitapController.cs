using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiToken.Models;

namespace WebApiToken.Controllers
{
    [Authorize]
    public class KitapController : ApiController
    {
        KutuphaneServis db = new KutuphaneServis();
        [HttpGet]
        public List<Kitap> GetKitaps()
        {
            return db.Kitaplar.ToList();
        }
        [HttpPost]
        public IHttpActionResult KitapEkle(Kitap kitap)
        {
            db.Kitaplar.Add(kitap);
            db.SaveChanges();
            return Json("Başarılı");
        }
        [HttpPut]
        public IHttpActionResult KitapGuncelle(Kitap kitap)
        {
            db.Entry(kitap).State = EntityState.Modified;
            db.SaveChanges();
            return Json("Başarılı");
        }
        [HttpDelete]
        public IHttpActionResult KitapSil(int id)
        {
            var silinecek = db.Kitaplar.FirstOrDefault(k => k.Id == id);
            db.Kitaplar.Remove(silinecek);
            db.SaveChanges();
            return Json("Başarılı");
        }
    }
}
