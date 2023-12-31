﻿using DAL.Contexts;
using Entites.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestorantMVC.Extensions;
using System.Security.Claims;

namespace RestorantMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class KategoriController : Controller
    {
        private readonly SqlDbContext dbContext;
        private readonly UserManager<Firma> userManager;
        private string firmaId;


        public KategoriController(SqlDbContext context , UserManager<Firma> userManager)
        {
            dbContext = context;
            this.userManager = userManager;
            //AssingUser
        }
        // GET: Admin/Kategori
        public async Task<IActionResult> Index()
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);


            return dbContext.Kategoriler != null ? View(await dbContext.Kategoriler.FirmaFilter(firmaId).ToListAsync()) : Problem("Entity set 'SqlDbContext.Kategoriler'  is null.");

        }

        // GET: Admin/Kategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            await this.SetUser(userManager);

            firmaId = userManager.GetUserId(User);
            if (id == null || dbContext.Kategoriler == null)

            {
                return NotFound();
            }

            var kategori = await dbContext.Kategoriler.FirmaFilter(firmaId)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // GET: Admin/Kategori/Create
        public async Task<IActionResult> Create()
        {
            await this.SetUser(userManager);
            Kategori kategori = new();
            return View(kategori);
        }

        // POST: Admin/Kategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriAdi,KategoriAciklama,ID,CreateTime,UpdateTime")] Kategori kategori)
        {
            await this.SetUser(userManager);
            
            firmaId = userManager.GetUserId(User);
            kategori.FirmaId = firmaId;

            if(kategori.KategoriAciklama != null)
            {
                if (kategori.KategoriAciklama.Length >= 100)
                {
                    kategori.KategoriAciklama = kategori.KategoriAciklama.Substring(0 , 90) + "...";
                }
            }

            int value = await dbContext.Kategoriler.FirmaFilter(firmaId).CountAsync();
            kategori.SelfKategoriID = value + 1;

            if (!IsUniqueForFirma(kategori.KategoriAdi,firmaId))
            {
                ModelState.AddModelError("KategoriAdi", "Kategori adı zaten mevcut");
                return View(kategori);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Kategoriler.Add(kategori);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("" , "Aynı İsimde bir kategori zaten mevcut");
                    return View(kategori);
                }
            }
            return View(kategori);
        }

        private bool IsUniqueForFirma(string kategoriadi, string firmaId)
        {
            firmaId = userManager.GetUserId(User);

            var kategorivarmi = dbContext.Kategoriler.FirstOrDefault(c => c.KategoriAdi == kategoriadi && c.FirmaId == firmaId);
            return kategorivarmi == null;
        }

        // GET: Admin/Kategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await this.SetUser(userManager);

            var kategori = dbContext.Kategoriler.Find(id);


            return View(kategori);
        }

        // POST: Admin/Kategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , [Bind("KategoriAdi,KategoriAciklama,ID,CreateTime,UpdateTime")] Kategori kategori)
        {
            await this.SetUser(userManager);
            firmaId = userManager.GetUserId(User);

            kategori.FirmaId = firmaId;
            kategori.UpdateTime = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return View(kategori);
            }
            try
            {
                dbContext.Kategoriler.Update(kategori);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError("" , "Aynı İsimde bir kategori zaten mevcut");
                return View(kategori);
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Kategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await this.SetUser(userManager);

            firmaId = userManager.GetUserId(User);

            if (id == null || dbContext.Kategoriler == null)

            {
                return NotFound();
            }

            var kategori = await dbContext.Kategoriler.FirmaFilter(firmaId)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // POST: Admin/Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.SetUser(userManager);

            if (dbContext.Kategoriler == null)

            {
                return Problem("Entity set 'SqlDbContext.Kategoriler'  is null.");
            }
            var kategori = await dbContext.Kategoriler.FindAsync(id);
            if (kategori != null)
            {
                dbContext.Kategoriler.Remove(kategori);
            }

            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriExists(int id)
        {
            return (dbContext.Kategoriler?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}