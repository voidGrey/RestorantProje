
//#region Sepet / Ürün Adet'i güncelleme

// Ürün Arttırmak için AJAX İsteği Gönder
function increaseQuantity(itemId, postDetailsId) {
    // Fiyat Text
    var fiyatelementi = document.getElementById('GuncelFiyat-' + postDetailsId);
    // MasterID
    var masterId = document.getElementById('masterId');
    // Fonksiyona Pass'lenen MasterID
    var postMasterId = parseInt(masterId.value);
    // Adet Elementi
    var quantityElement = document.getElementById('quantity-' + itemId);
    // Güncel Adet.
    var currentQuantity = parseInt(quantityElement.textContent);
    // Yeni Adet.
    var newQuantity = currentQuantity + 1;

    // AJAX isteği gönder
    $.ajax({
        type: "POST",
        url: "/Musteri/Siparis/UpdateQuantity",
        data: {
            itemId: itemId,
            newQuantity: newQuantity,
            masterId: postMasterId,
            detailsId: postDetailsId
        },
        success: function (data) {
            // Veritabanı güncellendikten sonra geri dönen veriyi işle
            quantityElement.textContent = data.updatedQuantity;
            fiyatelementi.textContent = data.updatedFiyat + " TL";
            var toplamelement = document.querySelectorAll('span[name="urunToplam"]');
            var toplam = 0;
            var toplamtext = document.getElementById('toplamTutarSon');
            for (var i = 0; i < toplamelement.length; i++) {
                var sayi = parseInt(toplamelement[i].textContent, 10); // Sayıyı al ve integere çevir
                toplam += sayi; // Toplamı güncelle
            }
            toplamtext.textContent = "Toplam Tutar : " + toplam + " TL";
        }
    });
}

// Ürün Azaltmak için AJAX İsteği Gönder
function decreaseQuantity(itemId, postDetailsId) {

    // Fiyat Text
    var fiyatelementi = document.getElementById('GuncelFiyat-' + postDetailsId);
    // MasterID
    var masterId = document.getElementById('masterId');
    // Fonksiyona Pass'lenen MasterID
    var postMasterId = parseInt(masterId.value);
    // Adet Elementi
    var quantityElement = document.getElementById('quantity-' + itemId);
    // Güncel Adet.
    var currentQuantity = parseInt(quantityElement.textContent);

    // Eğer Adet 1'den fazla ise:
    if (currentQuantity > 1)
    {
        var newQuantity = currentQuantity - 1;
        // AJAX isteği gönder
        $.ajax({
        type: "POST",
        url: "/Musteri/Siparis/UpdateQuantity",
            data:
            {
                itemId: itemId,
                newQuantity: newQuantity,
                masterId: postMasterId,
                detailsId: postDetailsId
            },
            success: function (data)
            {
                // Veritabanı güncellendikten sonra geri dönen veriyi işle
                quantityElement.textContent = data.updatedQuantity;
                fiyatelementi.textContent = data.updatedFiyat + " TL";
                var toplamelement = document.querySelectorAll('span[name="urunToplam"]');
                var toplam = 0;
                var toplamtext = document.getElementById('toplamTutarSon');
                for (var i = 0; i < toplamelement.length; i++) {
                var sayi = parseInt(toplamelement[i].textContent, 10); // Sayıyı al ve integere çevir
                toplam += sayi; // Toplamı güncelle
            }
                toplamtext.textContent = "Toplam Tutar : " + toplam + " TL";
        }});
    }
}

//#endregion Sepet / Ürün Adet'i güncelleme
