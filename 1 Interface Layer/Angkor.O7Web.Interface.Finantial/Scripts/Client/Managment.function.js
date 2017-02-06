function getAutoCompleteDataSingle(id,hiddenId, requestUrl) {
    $.ajax({ method: "GET", url: requestUrl, async: false })
    .done(function (resultField) {
        var objResult = jQuery.parseJSON(parseAutocomplete(resultField));
        var autocomplete = $(id).typeahead({ source: objResult });
        if (hiddenId != null) {
            autocomplete.afterSelect = function () {
                var field = $(id).typeahead("getActive");
                $(hiddenId).val(field.id);
            }
        }
        //if (hiddenId==null) {
         //   $(id).typeahead({ source: objResult });
       // } else {
           // $(id).typeahead({
               // source: objResult,
               // afterSelect: function () {
                //    var field = $(id).typeahead("getActive");
              //      $(hiddenId).val(field.id);
            //    }
          //  });
        //}
    }).fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
}
function toggleFields(status) {
    for (i = 1; i < arguments.length; i++) {
        if (status == "enabled") {
            $(arguments[i]).removeAttr("disabled");
        } else {
            $(arguments[i]).attr("disabled", "disabled");
        }
    }
}
function getAutoCompleteDataNested(counAuto,depAuto,proAuto,disAuto,zoneAuto) {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllCountries", async: false }).done(function (resultCountry) {
        var objResultCountry = jQuery.parseJSON(parseAutocomplete(resultCountry));
        $(counAuto).typeahead({
            source: objResultCountry,
            afterSelect: function () {
                var country = $(counAuto).typeahead("getActive");
                $(countryId).val(country.id);
                $.ajax({ method: "GET", url: "/Finantial/Client/ValidateCountryEntry", data: { countryId: country.id }, async: false })
                .done(function (resultValidation) {
                    var objResultValidation = jQuery.parseJSON(resultValidation.toLowerCase());
                    if (objResultValidation == true) {
                        toggleFields("enabled", depAuto, proAuto, disAuto, zoneAuto);
                    } else {
                        toggleFields("disabled", depAuto, proAuto, disAuto, zoneAuto);
                    }
                }).fail(function (result) {
                    toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                });
                getAutoCompleteDataSingle(zoneAutocomplete,zoneId,"/Finantial/Client/AllClientZones");

                $.ajax({ method: "GET", url: "/Finantial/Client/AllDepartments", data: { countryId: country.id }, async: false })
                .done(function (result) {
                    var objResult = jQuery.parseJSON(parseAutocomplete(result));
                    $(departmentAutocomplete).typeahead({
                        source: objResult,
                        afterSelect: function () {
                        var department = $(departmentAutocomplete).typeahead("getActive");
                        $(departmentId).val(department.id);
                        $.ajax({ method: "GET", url: "/Finantial/Client/AllProvinces", data: { countryId: country.id, departmentId: department.id }, async: false })
                            .done(function (resultProv) {
                                var objResultProv = jQuery.parseJSON(parseAutocomplete(resultProv));
                                $(provinceAutocomplete).typeahead({
                                    source: objResultProv,
                                    afterSelect: function () {
                                        var province = $(provinceAutocomplete).typeahead("getActive");
                                        $(provinceId).val(province.id);
                                        getAutoCompleteDataSingle(districtAutocomplete,districtId,"/Finantial/Client/AllDistricts");
                                    }
                                });
                            }).fail(function (result) {
                                toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                            });
                        }
                    });
                }).fail(function (result) {
                    toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                });
            }
        });
    }).fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
}

function parseAutocomplete(json) {
    json = json.replace(/Description/g, 'name');
    json = json.replace(/Id/g, 'id');
    return json;
}