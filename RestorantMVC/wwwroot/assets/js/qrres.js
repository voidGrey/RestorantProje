﻿//#region Account/Settings - Scriptleri

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

    //#region Account/Settings - Mail AJAX Scriptleri

    //#region Account/Settings - Mail POPUP Aç

    $("#mailRequest").click(function () {
        // Yeni telefon numarasını girmek için input alanını göster

        //$("#newPassword").show();
        //$("#savePassword").show();

        // POPUP AÇ
        $('#mailRequestModel').modal({ backdrop: 'static', keyboard: false }); // Kapatılamaz POPUP
        $('#mailRequestModel').modal('show'); // POPUP Göster
        // POPUP AÇ
    });

    //#endregion

    //#region Account/Settings - Mail POPUP Kapat

    $("#mailRequestVazgec").click(function () {
        location.reload()
    });

    //#endregion

    //#region Account/Settings - Mail AJAX
    $("#mailRequestOnayla").click(function () {

        var newMail = document.getElementById("newMailInput").value;
        var currPassword = document.getElementById("mailRequestPassword").value;
        var mailContent = document.getElementById("mailRequestContent");
        var onaylaButton = document.getElementById("mailRequestOnayla");

        $.ajax({
            url: "/Admin/Account/ChangeMailRequest",
            type: "POST",
            data: {
                mailData: newMail,
                passData: currPassword
            },
            success: function (result) {
                if (result.success) {
                    mailContent.innerHTML = `
                        <div class="modal-content" id="passRequestContent">
                            <div class="modal-header">
                                <h5 class="modal-title">Mail Değişikliği için şuan ki mail adresinize onay gönderildi!</h5>
                                <div class="modal-body" style="word-break:break-all" id="passRequestContent">
                                    <h5 class="modal-title" style="word-break:break-all">
                                </div>
                            </div>
                        </div>
                    `;
                    onaylaButton.style.visibility = "hidden";
                }
                else {
                    mailContent.innerHTML = `
                        <div class="modal-content" id="passRequestContent">
                            <div class="modal-header">
                                <h5 class="modal-title">Mail Değiştirme Başarısız!</h5>
                                <div class="modal-body" style="word-break:break-all" id="passRequestContent">
                                    <h5 class="modal-title" style="word-break:break-all">
                    ` + result.error + `
                                </div>
                            </div>
                        </div>
                    `;

                    onaylaButton.style.visibility = "hidden";
                }
            }
        })
    })
        //#endregion

    //#endregion

    //#region Account/Settings Vergi AJAX

    //#region Account/Settings - Vergi Field Ayarla
    // Edit Button İşlevi
    $("#editVergiDairesi").click(function () {
        // Yeni telefon numarasını girmek için input alanını göster
        $("#newVergiDairesi").show();
        $("#saveVergiDairesi").show();
        $("#editVergiDairesi").hide();
        $("#CurrentVergiDairesi").hide();
    });

    //#endregion

    //#region Account/Settings - Vergi Kaydet
    // Değişiklikleri kaydet düğmesine tıklanınca
    $("#saveVergiDairesi").click(function () {
        // Yeni telefon numarasını al
        var newVergiDairesi = $("#newVergiDairesi").val();

        // AJAX isteği gönder
        $.ajax({
            url: "/Admin/Account/UpdateVergiDairesi", // AJAX isteğinizi yönlendireceğiniz URL'yi ayarla
            type: "POST",
            data: {
                vergiDairesi: newVergiDairesi
            },
            success: function (result) {
                // input alanlarını düzenle
                $("#newVergiDairesi").hide();
                $("#CurrentVergiDairesi").show();
                $("#saveVergiDairesi").hide();
                $("#CurrentVergiDairesi").text(newVergiDairesi);
                $("#editVergiDairesi").show();
            },
            error: function (error) {
                // Hata Durumu
            }
        });
    });
        //#endregion


    //#region Account/Settings - VergiNo Field Ayarla
    // Edit Button İşlevi
    $("#editVergiNo").click(function () {
        // Yeni telefon numarasını girmek için input alanını göster
        $("#newVergiNo").show();
        $("#saveVergiNo").show();
        $("#editVergiNo").hide();
        $("#CurrentVergiNo").hide();
    });

    //#endregion

    //#region Account/Settings - VergiNo Kaydet
    // Değişiklikleri kaydet düğmesine tıklanınca
    $("#saveVergiNo").click(function () {
        // Yeni telefon numarasını al
        var newVergiNo = document.getElementById("newVergiNo").value;

        // AJAX isteği gönder
        $.ajax({
            url: "/Admin/Account/UpdateVergiNo", // AJAX isteğinizi yönlendireceğiniz URL'yi ayarla
            type: "POST",
            data: {
                vergiNo: newVergiNo
            },
            success: function (result) {
                // input alanlarını düzenle
                $("#newVergiNo").hide();
                $("#CurrentVergiNo").show();
                $("#saveVergiNo").hide();
                $("#CurrentVergiNo").text(newVergiNo);
                $("#editVergiNo").show();
            },
            error: function (error) {
                // Hata Durumu
            }
        });
    });
    //#endregion


    //#endregion

//#endregion

