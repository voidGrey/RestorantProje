using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Contexts;
using Entites.Concrate;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KapaliSiparisController : Controller
    {
        private readonly SqlDbContext dbContext;

        public KapaliSiparisController(SqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var sqlDbContext = dbContext.SiparisMasterlar.Include(s => s.Masa);
            return View(await sqlDbContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            var siparismaster = await dbContext.SiparisMasterlar.FindAsync(id);

            return View(siparismaster);
        }

        
    }
}
