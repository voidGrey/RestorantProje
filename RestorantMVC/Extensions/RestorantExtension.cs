using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entites.Concrate;
using Entites.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json.Linq;

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

        private static byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
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
    }
}
