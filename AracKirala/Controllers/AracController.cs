using AracKirala.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AracKirala.Controllers
{
    public class AracController : Controller
    {
        [HttpGet("araclar-police", Name = "araclarRoute")] // uygulama için controller/action dan farklı kendimize ait urller oluşturmak için kullanılan bir teknik
        public IActionResult AracPoliceleriIleBirlikte()
        {
            var db = new AracKiralaDBContext();
           var araclar = db.Araclar.Include(x => x.Police).ToList();


            return View(araclar);
        }

        [HttpGet("araclar-sirket", Name = "araclarSirketRoute")]
        public IActionResult AraclariSirketleriIleGoster()
        {
            var db = new AracKiralaDBContext();
            var araclar = db.Araclar.Include(x => x.AracSirket).OrderByDescending(x => x.SaatlikUcret).ToList();
            return View(araclar);
        }
    }
}
