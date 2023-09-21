using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Identity;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KapaliSiparisController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;

        public KapaliSiparisController(SqlDbContext dbContext, UserManager<Firma> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
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
