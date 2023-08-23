using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Contexts;
using Entites.Concrate;

namespace RestorantMVC.Controllers
{
    public class SepetController : Controller
    {
        private readonly SqlDbContext _context;

        public SepetController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: Sepet
        public async Task<IActionResult> Index()
        {
            var sqlDbContext = _context.Sepetler.Include(s => s.masa);
            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Sepet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sepetler == null)
            {
                return NotFound();
            }

            var sepet = await _context.Sepetler
                .Include(s => s.masa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sepet == null)
            {
                return NotFound();
            }

            return View(sepet);
        }

        public async Task<IActionResult> Ekle (int? id, int masaid)
        {
            var gelenUrun = _context.FindAsync(x => x);
        }

    }
}
