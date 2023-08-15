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
    public class UrunController : Controller
    {
        private readonly SqlDbContext _context;

        public UrunController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: Urun
        public async Task<IActionResult> Index()
        {
            var sqlDbContext = _context.Urunler.Include(u => u.Kategori);
            return View(await sqlDbContext.ToListAsync());
        }

        // GET: Urun/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urun = await _context.Urunler
                .Include(u => u.Kategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        
    }
}
