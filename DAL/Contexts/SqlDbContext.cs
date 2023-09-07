using Entites.Concrate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Contexts
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Masa> Masalar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }
        public DbSet<SiparisMaster> SiparisMasterlar { get; set; }
        public DbSet<Role> Roller { get; set; }
        public DbSet<Kasa> Kasalar { get; set; }
        public DbSet<KasaHareket> KasaHareketleri { get; set; }
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RestorantProje;Trusted_Connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

      
    }
}