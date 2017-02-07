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
            $(hiddenId).val(value.id)
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

function format_reciber(variable,code) {
    var reciberCode = $(variable);
    var code = reciberCode.html();
    reciberCode.html("");
    return reciberCode;
}

function editTable(tds,tblName,count) {
    var code=0, country=0, department=0, province=0, district=0, address=0, city=0, zone=0, phone=0, contact=0;
    format_reciber(tds[0],code);
    buildTextbox(tblName, 'Code', count, 1, 1, code);
    //var reciberCode = $(tds[0]);
    //var code = reciberCode.html();
    //reciberCode.html("");
    //reciberCode.append("<input type='text' class='form-control pull-left' style='width:100%;' name='txtReciberCode_"+countReciber+"' readonly='readonly' value='"+code+"' />");
    format_reciber(tds[1],country);
    buildTextbox(tblName, 'Country', count, 0, 0, country);
    //var reciberCountry = $(tds[1]);
    //var country = reciberCountry.html();
    //reciberCountry.html("");
    //reciberCountry.append("<input class='form-control pull-left' style='width:100%;' id='txtReciberCountry_"+countReciber+"' name='txtReciberCountry_"+countReciber+"' />
    <input type='hidden' id='txtReciberCountryId_"+countReciber+"' name='txtReciberCountryId_"+countReciber+"' value='"+country+"' />");                
    var reciberDepartment = $(tds[2]);
    var department = reciberDepartment.html(); 
    reciberDepartment.html("");
    reciberDepartment.append("<input class='form-control pull-left' style='width:100%;' id='txtReciberDepartment_"+countReciber+"' name='txtReciberDepartment_"+countReciber+"' /><input type='hidden' id='txtReciberDepartmentId_"+countReciber+"' name='txtReciberDepartmentId_"+countReciber+"' value='"+department+"' />");
    var reciberProvince = $(tds[3]);
    var province = reciberProvince.html(); 
    reciberProvince.html("");
    reciberProvince.append("<input class='form-control pull-left' style='width:100%;' id='txtReciberProvince_"+countReciber+"' name='txtReciberProvince_"+countReciber+"' /><input type='hidden' id='txtReciberProvinceId_"+countReciber+"' name='txtReciberProvinceId_"+countReciber+"' value='"+province+"' />");
    var reciberDistrict = $(tds[4]);
    var district = reciberDistrict.html(); 
    reciberDistrict.html("");
    reciberDistrict.append("<input class='form-control pull-left' style='width:100%;' id='txtReciberDistrict_"+countReciber+"' name='txtReciberDistrict_"+countReciber+"' /><input type='hidden' id='txtReciberDistrictId_"+countReciber+"' name='txtReciberDistrictId_"+countReciber+"' value='"+district+"' />");
    var reciberAddress = $(tds[5]);
    var address = reciberAddress.html();
    reciberAddress.html("");
    reciberAddress.append("<input class='form-control pull-left' style='width:100%;' name='txtReciberAddress_"+countReciber+"' value='"+address+"' />");
    var reciberCity = $(tds[6]);
    var city = reciberCity.html();
    reciberCity.html("");
    reciberCity.append("<input class='form-control pull-left' style='width:100%;' name='txtReciberCity_"+countReciber+"' value='"+city+"' />");
    var reciberZone = $(tds[7]);
    var zone = reciberZone.html(); 
    reciberZone.html("");
    reciberZone.append("<input class='form-control pull-left' style='width:100%;' id='txtReciberZone_"+countReciber+"' name='txtReciberZone_"+countReciber+"' /><input type='hidden' id='txtReciberZoneId_"+countReciber+"' name='txtReciberZoneId_"+countReciber+"' value='"+zone+"' />");
    var reciberPhone = $(tds[8]);
    var phone = reciberPhone.html();
    reciberPhone.html("");
    reciberPhone.append("<input class='form-control pull-left' style='width:100%;' name='txtReciberPhone_"+countReciber+"' value='"+phone+"' />");
    var reciberContact = $(tds[9]);
    var contact = reciberContact.html();
    reciberContact.html("");
    reciberContact.append("<input class='form-control pull-left' style='width:100%;' name='txtReciberContact_"+countReciber+"' value='"+contact+"' />");

    var parametros = [code, country,department,province,district,address,city,zone,phone,contact];
    
}

function addRowAddress(tblAddress, tblName, count) {
    var row = {};
    row.CodDir = '';
    row.Address = buildTextbox(tblName, 'Address', count,0,0,0);
    row.Department = buildTextbox(tblName, 'Department', count,0,0,0) + buildHidden(tblName, 'Department', count);
    row.Province = buildTextbox(tblName, 'Province', count,0,0,0) + buildHidden(tblName, 'Province', count);
    row.District = buildTextbox(tblName, 'District', count,0,0,0) + buildHidden(tblName, 'District', count);
    row.Country = buildTextbox(tblName, 'Country', count,0,0,0) + buildHidden(tblName, 'Country', count);
    row.City = buildTextbox(tblName, 'City', count,0,0,0);
    row.Zone = buildTextbox(tblName, 'Zone', count,0,0,0) + buildHidden(tblName, 'Zone', count);
    row.Phone = buildTextbox(tblName, 'Phone', count,0,0,0);
    row.Contact = buildTextbox(tblName, 'Contact', count,0,0,0);
    var rowCollection = [];
    rowCollection.push(row);
    tblAddress.rows.add(rowCollection).draw();
}

function buildTextbox(area, name, count,flag,readonly,variable) {          
    var textboxName = 'txt' + area + name + '_' + count;
    if (flag == 1) {
        if (readonly == 1) {
            return '<input type = "text" class="form-control pull-left" style="width: 100%;' + ' name="' + textboxName + '" readonly="readonly"' + 'value="' + variable + '" />';
        } else {
            return '<input type = "text" class="form-control pull-left" style="width: 100%;' + ' name="' + textboxName + 'value="' + code + '" />';
        }
    }
    return '<input class="form-control pull-left" style="width: 100%;" id="' + textboxName + '" name="' + textboxName + '" />';
}

function buildHidden(area, name, count,flag,variable) {
    var textboxName = 'txt' + area + name + 'Id_' + count;
    if(flag==1)
        return '<input type="hidden" id="' + textboxName + '" name="' + textboxName +'" value="'+ variable+ '" />';
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

