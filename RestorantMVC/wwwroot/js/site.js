
function increaseQuantity(itemId, postDetailsId) {
    var fiyatelementi = document.getElementById('GuncelFiyat-'+postDetailsId);
    var masterId = document.getElementById('masterId');
    
var postMasterId = parseInt(masterId.value);


var quantityElement = document.getElementById('quantity-' + itemId);
var currentQuantity = parseInt(quantityElement.textContent);
var newQuantity = currentQuantity + 1;

// AJAX isteği gönder
$.ajax({
    type: "POST",
url: "/Musteri/Siparis/UpdateQuantity",
data: {itemId: itemId, newQuantity: newQuantity, masterId: postMasterId, detailsId: postDetailsId },
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

function decreaseQuantity(itemId, postDetailsId) {
    var fiyatelementi = document.getElementById('GuncelFiyat-'+postDetailsId);
    var masterId = document.getElementById('masterId');
var postMasterId = parseInt(masterId.value);


var quantityElement = document.getElementById('quantity-' + itemId);
var currentQuantity = parseInt(quantityElement.textContent);
    if (currentQuantity > 1) {
        var newQuantity = currentQuantity - 1;

// AJAX isteği gönder
$.ajax({
    type: "POST",
url: "/Musteri/Siparis/UpdateQuantity",
data: {itemId: itemId, newQuantity: newQuantity, masterId: postMasterId, detailsId: postDetailsId },
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
}
