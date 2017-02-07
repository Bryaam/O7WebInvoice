function getAutoCompleteDataSingle(field, requestUrl,data) {
    var fieldId = field.hidden;
    $.ajax({ method: "GET", url: requestUrl, data: { fieldId: data.id }, async: false })
    .done(function (resultField) {
        var objResult = jQuery.parseJSON(parseAutocomplete(resultField));
        var autocomplete = $(field.auto).typeahead({ source: objResult });
        if (field.hidden != "") {
            autocomplete.afterSelect = function () {
                var curField = $(field.auto).typeahead("getActive");
                $(field.hidden).val(curField.id);
            }
        }
    }).fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
}
function toggleFields(status) {
    for (i = 1; i < arguments.length; i++) {
        if (status) {
            $(arguments[i]).removeAttr("disabled");
        } else {
            $(arguments[i]).attr("disabled", "disabled");
        }
    }
}

//departmentId,departmentAutocomplete
//provinceId, provinceAutocomplete
//districtId,districtAutocomplete
//countryId,countryAutocomplete
//zoneId,zoneAutocomplete
//postaleAutocomplete

function getAutoCompleteDataNested(countryField,departmentField,provinceField,districtField,zoneField) {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllCountries", async: false }).done(function (resultCountry) {
        var objResultCountry = jQuery.parseJSON(parseAutocomplete(resultCountry));
        $(countryField.auto).typeahead({
            source: objResultCountry,
            afterSelect: function () {
                var country = $(countryField.auto).typeahead("getActive");
                $(countryField.hidden).val(country.id);
                $.ajax({ method: "GET", url: "/Finantial/Client/ValidateCountryEntry", data: { countryId: country.id }, async: false })
                .done(function (resultValidation) {
                    var objResultValidation = jQuery.parseJSON(resultValidation.toLowerCase());
                    toggleFields(objResultValidation, departmentField.auto, provinceField.auto, districtField.auto, zoneField.auto);
                }).fail(function (result) {
                    toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                });
                getAutoCompleteDataSingle(zoneField,"/Finantial/Client/AllClientZones");

                $.ajax({ method: "GET", url: "/Finantial/Client/AllDepartments", data: { countryId: country.id }, async: false })
                .done(function (result) {
                    var objResult = jQuery.parseJSON(parseAutocomplete(result));
                    $(departmentField.auto).typeahead({
                        source: objResult,
                        afterSelect: function () {
                            var department = $(departmentField.auto).typeahead("getActive");
                        $(departmentField.hidden).val(department.id);
                        $.ajax({ method: "GET", url: "/Finantial/Client/AllProvinces", data: { countryId: country.id, departmentId: department.id }, async: false })
                            .done(function (resultProv) {
                                var objResultProv = jQuery.parseJSON(parseAutocomplete(resultProv));
                                $(provinceField.auto).typeahead({
                                    source: objResultProv,
                                    afterSelect: function () {
                                        var province = $(provinceField.auto).typeahead("getActive");
                                        $(provinceField.hidden).val(province.id);
                                        getAutoCompleteDataSingle(districtField,"/Finantial/Client/AllDistricts");
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

function get_allClientDepartments() {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllDepartments", data: { countryId: $("#chkCountry").val() }, async: false })
           .done(function (result) {
               var objResult = jQuery.parseJSON(result);
               var documentType = $("#chkDepartment");
               documentType.html("");
               iterate_Combo(documentType, objResult);
           }).fail(function (result) {
               toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
           });
}

function toolAutoComplete(nameAutoComplete, objResultDis,name) {
    $(nameAutoComplete).typeahead({
        source: objResultDis,
    });
    $.each(objResultDis, function (index, value) {
        if (value.id == name) {
            $(nameAutoComplete).val(value.name);
        }
    });
}

function generateAddressFields(row,reciber_count) {
    row.CodDir = "";
    row.Address = "<input class='form-control' style='width:100%' name='txtInvoicerAddress_" + reciber_count + "'>";
    row.Department = "<input class='form-control pull-left' style='width: 100%;' id='txtInvoicerDepartment_" + reciber_count + "' name='txtInvoicerDepartment_" + reciber_count + "'><input type='hidden' id='txtInvoicerDepartmentId_" + reciber_count + "' name='txtInvoicerDepartmentId_" + reciber_count + "'>";
    row.Province = "<input class='form-control pull-left' style='width: 100%;' id='txtInvoicerProvince_" + reciber_count + "' name='txtInvoicerProvince_" + reciber_count + "'><input type='hidden' id='txtInvoicerProvinceId_" + reciber_count + "' name='txtInvoicerProvinceId_" + reciber_count + "'>";
    row.District = "<input class='form-control pull-left' style='width: 100%;' id='txtInvoicerDistrict_" + reciber_count + "' name='txtInvoicerDistrict_" + reciber_count + "'><input type='hidden' id='txtInvoicerDistrictId_" + reciber_count + "' name='txtInvoicerDistrictId_" + reciber_count + "'>";
    row.Country = "<input class='form-control pull-left' style='width: 100%;' id='txtInvoicerCountry_" + reciber_count + "' name='txtInvoicerCountry_" + reciber_count + "'><input type='hidden' id='txtInvoicerCountryId_" + reciber_count + "' name='txtInvoicerCountryId_" + reciber_count + "'>";
    row.City = "<input class='form-control pull-left' style='width: 100%;' name='txtInvoicerCity_" + reciber_count + "'>";
    row.Zone = "<input class='form-control pull-left' style='width: 100%;' id='txtInvoicerZone_" + reciber_count + "' name='txtInvoicerZone_" + reciber_count + "'><input type='hidden' id='txtInvoicerZoneId_" + reciber_count + "' name='txtInvoicerZoneId_" + reciber_count + "'>";
    row.Phone = "<input class='form-control pull-left' style='width: 100%;' name='txtInvoicerPhone_" + reciber_count + "'>";
    row.Contact = "<input class='form-control pull-left' style='width: 100%;' name='txtInvoicerContact_" + reciber_count + "'>";
}

function onClickBtnAddReciber() {
    var reciber_count = parseInt($("#hddCountInvoicer").val());
    var row = {};
    generateAddressFields(row,reciber_count);
    var rowCollection = [];
    rowCollection.push(row);
    tblInvoicer.rows.add(rowCollection).draw();

    var departmentField = [],provinceField = [],districtField = [],countryField = [], zoneField = [], postaleField = [];
    departmentField.auto = "#txtInvoicerDepartment_" + reciber_count; departmentField.hidden = "#txtInvoicerDepartmentId_" + reciber_count;
    provinceField.auto = "#txtInvoicerProvince_" + reciber_count; provinceField.hidden = "#txtInvoicerProvinceId_" + reciber_count;
    districtField.auto = "#txtInvoicerDistrict_" + reciber_count; districtField.hidden = "#txtInvoicerDistrictId_" + reciber_count;
    countryField.auto = "#txtInvoicerCountry_" + reciber_count; countryField.hidden = "#txtInvoicerCountryId_" + reciber_count;
    zoneField.auto = "#txtInvoicerZone_" + reciber_count; zoneField.hidden = "#txtInvoicerZoneId_" + reciber_count;
    postaleField.auto = "#txtInvoicerPostal_" + reciber_count; postaleField.hidden = "";

    getAutoCompleteDataSingle(postaleField, "/Finantial/Client/AllPostales", "");
    getAutoCompleteDataNested(countryField, departmentField, provinceField, districtField, zoneField);
    rowValidate(i, tblInvoicer, curInvoicerRow, btnAddReciber);
    reciber_count = reciber_count + 1;
    $("#hddCountInvoicer").val(reciber_count);
    $('.dataTables_scrollBody').slimscroll({
        height: '30vh',
        disableFadeOut: false
    });
}

