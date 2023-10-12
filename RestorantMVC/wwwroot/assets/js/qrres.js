//#region Account/Settings - Scriptleri

    //#region Account/Settings - Telefon Numarası Scriptleri

    //#region Account/Settings - Telefon Field Ayarla
        // Edit Button İşlevi
        $("#editPhoneNumber").click(function () {
            // Yeni telefon numarasını girmek için input alanını göster
            $("#newPhoneNumber").show();
            $("#savePhoneNumber").show();
            $("#editPhoneNumber").hide();
            $("#CurrentPhoneNumber").hide();
        });

    //#endregion

    //#region Account/Settings - Telefon Kaydet
        // Değişiklikleri kaydet düğmesine tıklanınca
        $("#savePhoneNumber").click(function () {
            // Yeni telefon numarasını al
            var newPhoneNumber = $("#newPhoneNumber").val();

            // AJAX isteği gönder
            $.ajax({
                url: "/Admin/Account/UpdatePhoneNumber", // AJAX isteğinizi yönlendireceğiniz URL'yi ayarla
                type: "POST",
                data: {
                    phoneNumber: newPhoneNumber
                },
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
    //#endregion

    //#endregion

    //#region Account/Settings - Şifre AJAX Scriptleri

    //#region Account/Settings - Şifre POPUP Aç

    $("#editPasswordRequest").click(function () {
        // Yeni telefon numarasını girmek için input alanını göster

        //$("#newPassword").show();
        //$("#savePassword").show();

        // POPUP AÇ
        $('#passRequestModel').modal({ backdrop: 'static', keyboard: false }); // Kapatılamaz POPUP
        $('#passRequestModel').modal('show'); // POPUP Göster
        // POPUP AÇ

        // Normal Field'leri gizle
        $("#editPasswordRequest").hide();
        $("#currentPassword").hide();
    });

    //#endregion

    //#region Account/Settings - Şifre POPUP Kapat

    $("#passRequestVazgec").click(function () {
        location.reload()
    });

    //#endregion

    //#region Account/Settings - Şifre AJAX
    $("#passRequestOnayla").click(function() {

        var currentPassword = document.getElementById("currentPasswordInput").value;
        var newPassword = document.getElementById("newPasswordInput").value;
        var reNewPassword = document.getElementById("reNewPasswordInput").value;
        var passRequestContent = document.getElementById("passRequestContent");

        $.ajax({
            url: "/Admin/Account/ChangePasswordRequest",
            type: "POST",
            data: {
                currentPassword: currentPassword,
                newPassword: newPassword,
                reNewPassword: reNewPassword
            },
            success: function (result) {
                if (result.success) {
                    console.log("Şifre değiştirme işlemi başarılı");
                    passRequestContent.innerHTML = `
                        <div class="modal-content" id="passRequestContent">
                            <div class="modal-header">
                                <h5 class="modal-title">Şifre Değişikliği Başarılı!</h5>
                            </div>
                        </div>
                    `
                    var onaylaElement = document.getElementById("passRequestOnayla").style.visibility = "hidden";

                }
                else {
                    passRequestContent.innerHTML = `
                        <div class="modal-content" id="passRequestContent">
                            <div class="modal-header">
                                <h5 class="modal-title">Şifre Değişikliği Başarısız!</h5>
                                <div class="modal-body" style="word-break:break-all" id="passRequestContent">
                                    <h5 class="modal-title" style="word-break:break-all">
                    ` + result.error + `
                                </div>
                            </div>
                        </div>
                    `

                    var onaylaElement = document.getElementById("passRequestOnayla").style.visibility = "hidden";
                }

            } 
        })
    })
    //#endregion

    //#endregion



//#endregion

