using Entites.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Contexts
{
    public class SqlDbContext : IdentityDbContext<Firma , IdentityRole , string>
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Masa> Masalar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }
        public DbSet<SiparisMaster> SiparisMasterlar { get; set; }
        public DbSet<Role> Roller { get; set; }

        public DbSet<Sehir> Sehirler { get; set; }

        public DbSet<Ilce> Ilceler { get; set; }

        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=89.252.181.210\mssqlserver2019;Database=akadem67_mustafaertargin;User Id=akadem67_mustafaertargin;Password=2Z~1qvy36;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}