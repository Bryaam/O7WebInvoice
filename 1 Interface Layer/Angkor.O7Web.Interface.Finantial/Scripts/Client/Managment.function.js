function getNumber(id){
    return parseInt($("#hddCountInvoicer").val());
}

function initializeInput(inputName, count){
    var result = {};
    result.HiddenDepartment ='#txt'+inputName+'DepartmentId_'+count;
    result.InputDepartment ='#txt'+inputName+'Department_'+count;
    result.HiddenProvince ='#txt'+inputName+'ProvinceId_'+count;
    result.InputProvince ='#txt'+inputName +'Province_'+count;
    result.HiddenDistrict ='#txt'+inputName+'DistrictId_'+count;
    result.InputDistrict ='#txt'+inputName +'District_'+count;
    result.HiddenCountry ='#txt'+inputName+'CountryId_'+count;
    result.InputCountry ='#txt'+inputName +'Country_'+count;
    result.HiddenZone ='#txt'+inputName+'ZoneId_'+count;
    result.InputZone ='#txt'+inputName+ 'Zone_'+count;
    return result;
}

function autocompleteInitialization2(autocompleteId, hiddenId, source, functionCallback) {
    $(autocompleteId).typeahead({
        source: source,
        afterSelect: function () {
            var value = $(autocompleteId).typeahead("getActive");
            $(hiddenId).val(value.id);
            functionCallback(arguments[4]);
        }
    });
}

function autocompleteProvince(objParameters){
    autocompleteDistricts(districtAutocomplete, districtId, country.id, department.id, province.id);
}

function onclickBtnReciber () {
    var count = getNumber("#hddCountInvoicer");
    addRowAddress (tblInvoicer, 'Invoicer', reciber_count);
    var inputs = initializeInput('Invoicer', count);    
    autocompletePostales(postaleAutocomplete);

    $.ajax({ method: "GET", url: "/Finantial/Client/AllCountries", async: false })
        .done(function (resultCountry) {            
            var objResultCountry = jQuery.parseJSON(formatJsonAutocomplete(resultCountry));

            $(countryAutocomplete).typeahead({
                source: objResultCountry,
                afterSelect: function () {
                    var country = $(countryAutocomplete).typeahead("getActive");
                    $(countryId).val(country.id);
                    var ubigs=[inputs.InputDepartment, inputs.InputProvince, inputs.InputDistrict, inputs.InputZone];
                    validateCountry('ValidateCountryInvoicer', country.id, ubigs);
                    autocompleteZones(inputs.InputZone, zoneId, country.id);                    

                    $.ajax({ method: "GET", url: "/Finantial/Client/AllDepartments", data: { countryId: country.id } , async: false })
                        .done(function (result) {
                            var objResult = jQuery.parseJSON(parseAutocomplete(result));

                            $(inputs.InputDepartment).typeahead({
                                source: objResult,
                                afterSelect: function () {
                                    var department = $(inputs.InputDepartment).typeahead("getActive");
                                    $(inputs.HiddenDepartment).val(department.id);
                                    $.ajax({ method: "GET", url: "/Finantial/Client/AllProvinces", data: {countryId:"PER", departmentId: department.id }, async: false })
                                        .done(function (resultProv) {
                                            var objResultProv = jQuery.parseJSON(parseAutocomplete(resultProv));
                                            autocompleteInitialization2(inputs.InputProvince,inputs.HiddenProvince,objResultProv,)
                                            $(inputs.InputProvince).typeahead({
                                                source: objResultProv,
                                                afterSelect: function () {
                                                    var province = $(inputs.InputProvince).typeahead("getActive");
                                                    $(inputs.HiddenProvince).val(province.id);
                                                    autocompleteDistricts(districtAutocomplete, districtId, country.id, department.id, province.id);
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
    reciber_count = reciber_count + 1;
    $("#hddCountInvoicer").val(reciber_count);
    $('.dataTables_scrollBody').slimscroll({
        height: '30vh',
        disableFadeOut : false
    });

function disableInputs(inputs) {
    for (var i = 0; i < inputs.length; i++)
        $(inputs[i]).attr('disabled', 'disabled');
}

function ableInputs(inputs) {
    for (var i = 0; i < inputs.length; i++)
        $(inputs[i]).removeAttr('disabled');
}

function validateCountry(path, country, ubigs) {
    $.ajax({ method: 'GET', url: '/Finantial/Client/' + path, data: { countryId: country } })
        .done(function (resultValidation) {
            var objResultValidation = jQuery.parseJSON(resultValidation.toLowerCase());
            if (objResultValidation == true) { ableInputs(ubigs); }
            else { disableInputs(ubigs); }
        }).fail(function (result) {
            toastr.error(result.statusText, 'Mensaje', { positionClass: 'toast-top-full-width' });
        });
}

function autocompleteZones(autocompleteId, hiddenId, country) {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllClientZones", data: { countryId: country } })
    .done(function (resultZone) {        
        var objResultZone = jQuery.parseJSON(formatJsonAutocomplete(resultZone));
        autocompleteInitialization(autocompleteId, hiddenId, objResultZone);        
    }).fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
}

function autocompleteInitialization(autocompleteId, hiddenId, source) {
    $(autocompleteId).typeahead({
        source: source,
        afterSelect: function () {
            var value = $(autocompleteId).typeahead("getActive");
            $(hiddenId).val(value.id);
        }
    });
}



function autocompleteDistricts(districtAutocomplete, districtHidden, country, department, province) {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllDistricts", data: { countryId: country, departmentId: department, provinceId: province }, async: false })
        .done(function (resultDistrict) {
            var objResultDis = jQuery.parseJSON(parseAutocomplete(resultDistrict));
            autocompleteInitialization(districtAutocomplete, districtHidden, objResultDis);    
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}

function autocompletePostales(autocompleteId) {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllPostales" })
        .done(function (resultPostale) {
            var objResultPostale = jQuery.parseJSON(formatJsonAutocomplete(resultPostale));
            $(autocompleteId).typeahead({ source: objResultPostale });
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}

function formatJsonAutocomplete(json) {
    json = json.replace(/Description/g, 'name');
    json = json.replace(/Id/g, 'id');
    return json;
}

function addRowAddress(tblAddress, tblName, count) {
    var row = {};
    row.CodDir = '';
    row.Address = buildTextbox(tblName, 'Address', count);
    row.Department = buildTextbox(tblName, 'Department', count) + buildHidden(tblName, 'Department', count);
    row.Province = buildTextbox(tblName, 'Province', count) + buildHidden(tblName, 'Province', count);
    row.District = buildTextbox(tblName, 'District', count) + buildHidden(tblName, 'District', count);
    row.Country = buildTextbox(tblName, 'Country', count) + buildHidden(tblName, 'Country', count);
    row.City = buildTextbox(tblName, 'City', count);
    row.Zone = buildTextbox(tblName, 'Zone', count) + buildHidden(tblName, 'Zone', count);
    row.Phone = buildTextbox(tblName, 'Phone', count);
    row.Contact = buildTextbox(tblName, 'Contact', count);
    var rowCollection = [];
    rowCollection.push(row);
    tblAddress.rows.add(rowCollection).draw();
}

function buildTextbox(area, name, count) {
    var textboxName = 'txt' + area + name + '_' + count;
    return '<input class="form-control pull-left" style="width: 100%;" id="' + textboxName + '" name="' + textboxName + '" />';
}

function buildHidden(area, name, count) {
    var textboxName = 'txt' + area + name + 'Id_' + count;
    return '<input type="hidden" id="' + textboxName + '" name="' + textboxName + '" />';
}

function getAutoCompleteDataSingle(field, requestUrl, data) {
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

function autocompleteDependencies(){
    $.ajax({ method: "GET", url: "/Finantial/Client/AllDepartments", data: { countryId: country.id } , async: false })
            .done(function (result) {
                var objResult = jQuery.parseJSON(parseAutocomplete(result));
                $(departmentAutocomplete).typeahead({
                    source: objResult,
                    afterSelect: function () {
                        var department = $(departmentAutocomplete).typeahead("getActive");
                        $(departmentId).val(department.id);
                        $.ajax({ method: "GET", url: "/Finantial/Client/AllProvinces", data: {countryId:"PER", departmentId: department.id }, async: false })
                            .done(function (resultProv) {
                                var objResultProv = jQuery.parseJSON(parseAutocomplete(resultProv));   
                                $(provinceAutocomplete).typeahead({
                                    source: objResultProv,
                                    afterSelect: function () {
                                        var province = $(provinceAutocomplete).typeahead("getActive");
                                        $(provinceId).val(province.id);
                                        $.ajax({ method: "GET", url: "/Finantial/Client/AllDistricts", data: { countryId:"PER", departmentId: department.id, provinceId: province.id }, async: false })
                                            .done(function (resultDistrict) {
                                                var objResultDis = jQuery.parseJSON(parseAutocomplete(resultDistrict));
                                                autocompleteInitialization(districtAutocomplete, districtId, objResultDis);    
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



function rowValidate(i,tblName,curName, buttonName) {
    $("#"+tblName+ " input[name*=" + curName + "][class]:lt(7)").each(function () {
        $(this).change(function () {
            i = 0;
            $("#"+tblName+" input[name*=" + curName + "][class]:lt(7)").each(function () {
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

function toolAutoComplete(nameAutoComplete, objResultDis, name) {
    $(nameAutoComplete).typeahead({
        source: objResultDis,
    });
    $.each(objResultDis, function (index, value) {
        if (value.id == name) {
            $(nameAutoComplete).val(value.name);
        }
    });
}

<<<<<<< HEAD
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
=======
>>>>>>> 55ac8539cee326c1ffc2a81eebc2344dd55bac7a

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

    var departmentField = {},provinceField = [],districtField = [],countryField = [], zoneField = [], postaleField = [];
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

