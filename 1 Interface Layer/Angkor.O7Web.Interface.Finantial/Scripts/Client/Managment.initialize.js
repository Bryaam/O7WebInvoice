function initialize() {
    moment.locale('es');

    $("#hddCountReciber").val("0");
    $("#hddCountInvoicer").val("0");

    $("#dpckRegister").datepicker({
        format: "dd/mm/yyyy"
    });

    $("#chkDepartment").chosen({
        width: "100%"
    });

    var action = $("#txtAction").val();

    if (action == "3") {
        $("#btnSubmit").hide();
    }

    $("#dpckRegister").val(moment().format("DD/MM/YYYY"));

    $("#chkOriginClient").chosen({
        width: "100%",
        disable_search: true
    });

    $("#chkClientState").chosen({
        width: "100%",
        disable_search: true
    });

    $("#chkpersonType").chosen({
        width: "100%",
        disable_search: true
    });

    $("#chkDocumentType").chosen({
        width: "100%",
        disable_search: true
    });

    $("#chkCountry").chosen({
        width: "100%"
    });

    $("#chkZone").chosen({
        width: "100%"
    });

    $("#chkPostale").chosen({
        width: "100%"
    });

    $("#chkProvince").chosen({
        width: "100%"
    });

    $("#chkDistrict").chosen({
        width: "100%"
    });

    on_Combos();

    if (action == "1") {
        get_allClientProvinces();
        get_allClientDistrict();
    }
}
function iterate_Combo(documentType, objResult) {
    $.each(objResult, function (index, value) {
        documentType.append("<option value='" + value.Id + "'>" + value.Description + "</option>");
    });
    documentType.trigger("chosen:updated");
}

function on_Combos() {
    get_allPersonType();
    get_allCountries();
    get_allClientZone();

    $("#chkCountry").on('change', function (e) {
        get_allClientZone();
        get_allClientDepartments(1);
        get_allClientDistrict();
        get_allClientProvinces();
    });

    $("#chkProvince").on('change', function (e) {
        get_allClientDistrict();
    });

    $("#chkDepartment").on('change', function (e) {
        get_allClientProvinces();
    });

    get_allPostales();
    get_allClientOrigins();
    get_allClientStates();
    get_allClientType();
    get_allClientDepartments(0);
}


function get_allPersonType() {
    $('#chkpersonType').on('change', function (e) {
        var personType = $(this).val();

        if (personType == "N") $("#divRuc").removeAttr("style");
        else $("#divRuc").attr("style", "visibility:hidden;");

        $.ajax({ method: "GET", url: "/Finantial/Client/DocumentType", data: { clientType: personType }, async: false })
            .done(function (result) {
                var objResult = jQuery.parseJSON(result);
                var documentType = $("#chkDocumentType");
                documentType.html("");
                iterate_Combo(documentType, objResult);
            }).fail(function (result) {
                toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
            });
    });
}

function get_allCountries() {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllCountries", async: false })
        .done(function (result) {
            var objResult = jQuery.parseJSON(result);
            var documentType = $("#chkCountry");
            iterate_Combo(documentType, objResult);
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}

function get_allClientZone() {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllClientZones", data: { countryId: $("#chkCountry").val() }, async: false })
        .done(function (result) {
            var objResult = jQuery.parseJSON(result);
            var documentType = $("#chkZone");
            documentType.html("");
            iterate_Combo(documentType, objResult);
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}

function get_allClientDistrict() {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllDistricts", data: { countryId: $("#chkCountry").val(), departmentId: $("#chkDepartment").val(), provinceId: $(this).val() }, async: false })
            .done(function (result) {
                var objResult = jQuery.parseJSON(result);
                var documentType = $("#chkDistrict");
                documentType.html("");
                iterate_Combo(documentType, objResult);
            }).fail(function (result) {
                toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
            });
}

function get_allClientProvinces() {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllProvinces", data: { countryId: $("#chkCountry").val(), departmentId: $(this).val() }, async: false })
             .done(function (result) {
                 var objResult = jQuery.parseJSON(result);
                 var documentType = $("#chkProvince");
                 documentType.html("");
                 iterate_Combo(documentType, objResult);
             }).fail(function (result) {
                 toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
             });
}

function get_allClientDepartments(flag) {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllDepartments", data: { countryId: $("#chkCountry").val() }, async: false })
           .done(function (result) {
               var objResult = jQuery.parseJSON(result);
               var documentType = $("#chkDepartment");
               if (flag == 1) {
                   documentType.html("");
               }
               iterate_Combo(documentType, objResult);
           }).fail(function (result) {
               toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
           });
}

function get_allPostales() {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllPostales", async: false })
        .done(function (result) {
            var objResult = jQuery.parseJSON(result);
            var documentType = $("#chkPostale");
            documentType.html("");
            iterate_Combo(documentType, objResult);
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}

function get_allClientOrigins() {
    $.ajax({ method: "GET", url: "/Finantial/Client/ClientOrigins", async: false })
       .done(function (result) {
           var objResult = jQuery.parseJSON(result);
           var documentType = $("#chkOriginClient");
           iterate_Combo(documentType, objResult);
       }).fail(function (result) {
           toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
       });
}

function get_allClientStates() {
    $.ajax({ method: "GET", url: "/Finantial/Client/ClientStates", async: false })
        .done(function (result) {
            var objResult = jQuery.parseJSON(result);
            var documentType = $("#chkClientState");
            iterate_Combo(documentType, objResult);
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}

function get_allClientType() {
    $.ajax({ method: "GET", url: "/Finantial/Client/ClientType", async: false })
        .done(function (result) {
            var objResult = jQuery.parseJSON(result);
            var documentType = $("#chkpersonType");
            iterate_Combo(documentType, objResult);
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}