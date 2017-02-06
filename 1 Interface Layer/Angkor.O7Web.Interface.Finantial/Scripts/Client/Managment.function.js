function getAutoCompleteDataSingle(id, requestUrl) {
    $.ajax({ method: "GET", url: requestUrl, async: false })
        .done(function (resultField) {
            resultField = resultField.replace(/Description/g, 'name');
            resultField = resultField.replace(/Id/g, 'id');
            var objResultPostale = jQuery.parseJSON(resultField);
            $(id).typeahead({ source: objResultPostale });
            }).fail(function (result) {
                 toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
            });
}

function getAutoCompleteDataNested() {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllCountries", async: false }).done(function (resultCountry) {
        resultCountry = resultCountry.replace(/Description/g, 'name');
        resultCountry = resultCountry.replace(/Id/g, 'id');
        var objResultCountry = jQuery.parseJSON(resultCountry);
        $(countryAutocomplete).typeahead({
            source: objResultCountry,
            afterSelect: function () {
                var country = $(countryAutocomplete).typeahead("getActive");
                $(countryId).val(country.id);
                $.ajax({ method: "GET", url: "/Finantial/Client/ValidateCountryEntry", data: { countryId: country.id }, async: false })
                    .done(function (resultValidation) {
                        var objResultValidation = jQuery.parseJSON(resultValidation.toLowerCase());
                        if (objResultValidation == true) {
                            $(departmentAutocomplete).removeAttr("disabled");
                            $(provinceAutocomplete).removeAttr("disabled");
                            $(districtAutocomplete).removeAttr("disabled");
                            $(zoneAutocomplete).removeAttr("disabled");
                        } else {
                            $(departmentAutocomplete).attr("disabled", "disabled");
                            $(provinceAutocomplete).attr("disabled", "disabled");
                            $(districtAutocomplete).attr("disabled", "disabled");
                            $(zoneAutocomplete).attr("disabled", "disabled");
                        }
                    }).fail(function (result) {
                        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                    });

                    $.ajax({ method: "GET", url: "/Finantial/Client/AllClientZones", data: { countryId: country.id }, async: false })
                        .done(function (resultZone) {
                            resultZone = resultZone.replace(/Description/g, 'name');
                            resultZone = resultZone.replace(/Id/g, 'id');
                            var objResultZone = jQuery.parseJSON(resultZone);
                            $(zoneAutocomplete).typeahead({
                                source: objResultZone,
                                afterSelect: function () {
                                    var zone = $(zoneAutocomplete).typeahead("getActive");
                                    $(zoneId).val(zone.id)
                                }
                            });
                        }).fail(function (result) {
                            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                        });
                        $.ajax({ method: "GET", url: "/Finantial/Client/AllDepartments", data: { countryId: country.id }, async: false })
                            .done(function (result) {
                                result = result.replace(/Description/g, 'name');
                                result = result.replace(/Id/g, 'id');
                                var objResult = jQuery.parseJSON(result);
                                $(departmentAutocomplete).typeahead({
                                    source: objResult,
                                    afterSelect: function () {
                                    var department = $(departmentAutocomplete).typeahead("getActive");
                                    $(departmentId).val(department.id);
                                    $.ajax({ method: "GET", url: "/Finantial/Client/AllProvinces", data: { countryId: country.id, departmentId: department.id }, async: false })
                                        .done(function (resultProv) {
                                            resultProv = resultProv.replace(/Description/g, 'name');
                                            resultProv = resultProv.replace(/Id/g, 'id');
                                            var objResultProv = jQuery.parseJSON(resultProv);
                                            $(provinceAutocomplete).typeahead({
                                                source: objResultProv,
                                                afterSelect: function () {
                                                    var province = $(provinceAutocomplete).typeahead("getActive");
                                                    $(provinceId).val(province.id);
                                                    $.ajax({ method: "GET", url: "/Finantial/Client/AllDistricts", data: { countryId: country.id, departmentId: department.id, provinceId: province.id }, async: false })
                                                        .done(function (resultDistrict) {
                                                            resultDistrict = resultDistrict.replace(/Description/g, 'name');
                                                            resultDistrict = resultDistrict.replace(/Id/g, 'id');
                                                            var objResultDis = jQuery.parseJSON(resultDistrict);
                                                            $(districtAutocomplete).typeahead({
                                                                source: objResultDis,
                                                                afterSelect: function () {
                                                                    var district = $(districtAutocomplete).typeahead("getActive");
                                                                    $(districtId).val(district.id);
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
                        });
                    }).fail(function (result) {
                        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                    });
}

function rowValidate(i,tblName,curName, buttonName) {
    $("#tblName input[name*=" + curName + "][class]:lt(7)").each(function () {
        $(this).change(function () {
            i = 0;
            $("#tblName input[name*=" + curName + "][class]:lt(7)").each(function () {
                if ($(this).val() == "") {
                    i++;
                }
            });
            if (i == 0) {
                buttonName.show();
            } else {
                buttonName.hide();
            }
        });
    });
}

function iterate_Combo(documentType, objResult) {
    $.each(objResult, function (index, value) {
        documentType.append("<option value='" + value.Id + "'>" + value.Description + "</option>");
    });
    documentType.trigger("chosen:updated");
}