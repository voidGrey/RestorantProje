﻿using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SiparisController : Controller
    {
        private readonly SqlDbContext dbContext;

        public SiparisController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var Siparisler = await dbContext.SiparisMasterlar.ToListAsync();
            return View(Siparisler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var masaListesi = (from item in dbContext.Masalar
                               select new SelectListItem
                               {
                                   Text = item.MasaID.ToString(),
                                   Value = item.MasaID.ToString()
                               }).ToList();
            ViewBag.Masalar = masaListesi;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SiparisMaster siparisMaster)
        {
            dbContext.SiparisMasterlar.Add(siparisMaster);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CloseOrder(int id)
        {
            var siparis = await dbContext.SiparisMasterlar.FindAsync(id);

            if (siparis == null)
            {
                return NotFound();
            }

            siparis.IsActive = false; 

            dbContext.Update(siparis);
            await dbContext.SaveChangesAsync();

            var Siparisler = await dbContext.SiparisMasterlar.ToListAsync();
            return View("Index", Siparisler);
        }
    }
}
