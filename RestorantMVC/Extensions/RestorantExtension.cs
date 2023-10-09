using DAL.Contexts;
using Entites.Abstract;
using Entites.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace RestorantMVC.Extensions
{
    public static class RestorantExtension
    {
        /// <summary>
        /// Veritabanı tablosu içindeki nesneleri belirli bir Firma ID'ye göre filtrelemek için kullanılan extension method.
        /// </summary>
        /// <typeparam name="TModel">Filtreleme işlemi yapılacak nesne türü.</typeparam>
        /// <param name="model">Filtreleme işlemi uygulanacak olan DbSet nesnesi. (boş bırak)</param>
        /// <param name="id">Filtreleme için kullanılacak olan Firma ID değeri.</param>
        /// <returns>Filtrelenmiş nesneleri içeren bir IQueryable nesnesi.</returns>
        public static IQueryable<TModel> FirmaFilter<TModel>(this DbSet<TModel> model , string id) where TModel : BaseEntity
        {
            return model.Where(a => a.FirmaId == id);
        }

        /// <summary>
        /// Controller nesnesinin içindeki kullanıcı bilgisini ayarlamak ve ViewBag üzerinden kullanıcı bilgisine erişim sağlamak için kullanılan extension method.
        /// </summary>
        /// <param name="model">Controller nesnesi. (this) </param>
        /// <param name="userManager">UserManager<Firma> nesnesi, kullanıcı bilgisini almak için kullanılır.</param>
        /// <returns>Controller nesnesi, kullanıcı bilgisi ViewBag üzerinden ayarlandıktan sonra döndürülür.</returns>
        /// <remarks>
        /// Bu method, bir Controller nesnesinin içindeki kullanıcı bilgisini UserManager aracılığıyla alır ve bu bilgiyi ViewBag.User üzerinden Controller'a ekler.
        /// Kullanıcı bilgisine erişim sağlamak için Controller içinde ViewBag.User kullanabilirsiniz.
        /// </remarks>
        public static async Task<dynamic> SetUser(this Controller model , UserManager<Firma> userManager)
        {
            var user = await userManager.GetUserAsync(model.User);
            model.ViewBag.User = user;
            return model;
        }

        public static SiparisDetay GetActiveOne(this List<SiparisDetay>? list)
        {
            foreach (var item in list)
            {
                if (item.status == SiparisDetay.Status.Onay_Bekliyor)
                {
                    return item;
                }
            }

            return null;
        }

        public static async Task<bool> isUnuqieafa<TModel>(this DbSet<TModel> model , string ad, string fir) where TModel : Kategori
        {

            var value = model.FirstOrDefault(c => c.KategoriAdi == ad && c.FirmaId == fir);

            return false;
        }
        //public static async Task<bool> isUnuqieafa<TModel>(this DbSet<TModel> model , string ad , string fir) where TModel : Urun
        //{

        //    var value = model.FirstOrDefault(c => c.UrunAdi == ad && c.FirmaId == fir);

        //    return false;
        //}

        public static async Task ViewBagSettings(this Controller model , SqlDbContext dbContext)
        {
            string decryptValue = "";
            model.Request.Cookies.TryGetValue("f" , out decryptValue);
            byte[] bytes = WebEncoders.Base64UrlDecode(decryptValue);
            string firmaId = await RestorantExtension.DecryptAsync(bytes,"YeyoYoOyeŞifrehehe");
            var result = await dbContext.Kategoriler.FirmaFilter(firmaId).ToListAsync();
            model.ViewBag.Firma = result;
        }

        #region Encrypt

        private static byte[] IV = { 0x01 , 0x02 , 0x03 , 0x04 , 0x05 , 0x06 , 0x07 , 0x08 , 0x09 , 0x10 , 0x11 , 0x12 , 0x13 , 0x14 , 0x15 , 0x16 };

        private static byte[] DeriveKeyFromPassword(string password)
        {
            var emptySalt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16; // 16 bytes equal 128 bits.
            var hashMethod = HashAlgorithmName.SHA384;
            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password) ,
                                             emptySalt ,
                                             iterations ,
                                             hashMethod ,
                                             desiredKeyLength);
        }

        public static async Task<byte[]> EncryptAsync(string clearText , string passphrase)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(passphrase);
            aes.IV = IV;

            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);

            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(clearText));
            await cryptoStream.FlushFinalBlockAsync();

            return output.ToArray();
        }

        public static async Task<string> DecryptAsync(byte[] encrypted , string passphrase)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(passphrase);
            aes.IV = IV;

            using MemoryStream input = new(encrypted);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);

            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);

            return Encoding.Unicode.GetString(output.ToArray());
        }

        #endregion Encrypt
    }
}