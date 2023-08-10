using DAL.Contexts;
using Entites.Abstract;
using Entites.Concrate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestorantMVC.Controllers
{
    public class KategoriController : Controller
    {
        public readonly SqlDbContext dbContext;

        public KategoriController(SqlDbContext sqlDbContext)
        {
            this.dbContext = sqlDbContext;
        }

        public IActionResult Index()
        {
            var result = dbContext.Kategoriler.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            Kategori kategori = new();
            return View(kategori);
        }

        [HttpPost]
        public IActionResult Add(Kategori kategori)
        {
            if(ModelState.IsValid)
            {
                return View(kategori);
            }

            try
            {
                dbContext.Kategoriler.Add(kategori);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("" , "beklenmedik bir hata oluştu, lütfen daha sonra tekrar deneyiniz.");
                return View(kategori);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var kategori = dbContext.Kategoriler.Find(id);
            return View(kategori);
        }

        [HttpPost]
        public IActionResult Update(Kategori kategori)
        {
            if(ModelState.IsValid)
            {
                return View(kategori);
            }
            else
            {
                dbContext.Kategoriler.Update(kategori);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kategori = dbContext.Kategoriler.Find(id);
            return View(kategori);
        }

        [HttpPost]
        public IActionResult Delete(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                return View(kategori);
            }
            else
            {
                dbContext.Kategoriler.Remove(kategori);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}