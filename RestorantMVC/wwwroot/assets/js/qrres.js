// Edit düğmesine tıklanınca
$("#editPhoneNumber").click(function () {
    // Yeni telefon numarasını girmek için input alanını göster
    $("#newPhoneNumber").show();
    $("#savePhoneNumber").show();
    $("#editPhoneNumber").hide();
    $("#CurrentPhoneNumber").hide();
});

// Değişiklikleri kaydet düğmesine tıklanınca
$("#savePhoneNumber").click(function () {
    // Yeni telefon numarasını al
    var newPhoneNumber = $("#newPhoneNumber").val();

    // AJAX isteği gönder
    $.ajax({
        url: "/Admin/Account/UpdatePhoneNumber", // AJAX isteğinizi yönlendireceğiniz URL'yi ayarla
        type: "POST",
        data: { phoneNumber: newPhoneNumber },
        success: function (result) {
            // input alanlarını düzenle
            $("#newPhoneNumber").hide();
            $("#CurrentPhoneNumber").show();
            $("#savePhoneNumber").hide();
            $("#CurrentPhoneNumber").text(newPhoneNumber);
            $("#editPhoneNumber").show();
        },
        error: function (error) {
            // Hata Durumu
        }
    });
});
