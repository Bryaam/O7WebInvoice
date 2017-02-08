function afterSelectCountry() {
    var country = $(countryAutocomplete).typeahead("getActive");
    $(countryId).val(country.id);
    var ubigs = [departmentAutocomplete, provinceAutocomplete, districtAutocomplete, zoneAutocomplete]

    validateCountry('ValidateCountryInvoicer', country.id, ubigs);
    autocompleteZones(zoneAutocomplete, zoneId, country.id);

    $.ajax({ method: "GET", url: "/Finantial/Client/AllDepartments", data: { countryId: country.id }, async: false })
        .done(function (result) {
            var objResult = jQuery.parseJSON(parseAutocomplete(result));
            $(departmentAutocomplete).typeahead({
                source: objResult,
                afterSelect: function () {
                    var department = $(departmentAutocomplete).typeahead("getActive");
                    $(departmentId).val(department.id);
                    $.ajax({ method: "GET", url: "/Finantial/Client/AllProvinces", data: { countryId: "PER", departmentId: department.id }, async: false })
                        .done(function (resultProv) {
                            var objResultProv = jQuery.parseJSON(parseAutocomplete(resultProv));
                            $(provinceAutocomplete).typeahead({
                                source: objResultProv,
                                afterSelect: function () {
                                    var province = $(provinceAutocomplete).typeahead("getActive");
                                    $(provinceId).val(province.id);
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

function onclickBtnReciver() {
    var count = getNumber("#hddCountInvoicer");
    addRowAddress(tblInvoicer, 'Invoicer', reciber_count);
    var inputs = initializeInput('Invoicer', count);
    $.ajax({ method: "GET", url: "/Finantial/Client/AllCountries", async: false })
        .done(function (resultCountry) {
            var objResultCountry = jQuery.parseJSON(parseAutocomplete(resultCountry));
            $(inputs.InputCountry).typeahead({
                source: objResultCountry,
                afterSelect: function () { afterSelectCountry(); }
            });
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
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

function initializeInput(inputName, count) {
    var result = {};
    result.HiddenDepartment = '#txt' + inputName + 'DepartmentId_' + count;
    result.InputDepartment = '#txt' + inputName + 'Department_' + count;
    result.HiddenProvince = '#txt' + inputName + 'ProvinceId_' + count;
    result.InputProvince = '#txt' + inputName + 'Province_' + count;
    result.HiddenDistrict = '#txt' + inputName + 'DistrictId_' + count;
    result.InputDistrict = '#txt' + inputName + 'District_' + count;
    result.HiddenCountry = '#txt' + inputName + 'CountryId_' + count;
    result.InputCountry = '#txt' + inputName + 'Country_' + count;
    result.HiddenZone = '#txt' + inputName + 'ZoneId_' + count;
    result.InputZone = '#txt' + inputName + 'Zone_' + count;
    return result;
}

function autocompletePostales(autocompleteId) {
    $.ajax({ method: 'GET', url: '/Finantial/Client/AllPostales' })
        .done(function (resultPostale) {
            var objResultPostale = jQuery.parseJSON(formatJsonAutocomplete(resultPostale));
            $(autocompleteId).typeahead({ source: objResultPostale });
        }).fail(function (result) {
            toastr.error(result.statusText, 'Mensaje', { positionClass: 'toast-top-full-width' });
        });
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
            autocompleteBasic(autocompleteId, hiddenId, objResultZone);
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}

function autocompleteDistricts(autocompleteId, hiddenId, country, department, province) {
    $.ajax({ method: "GET", url: "/Finantial/Client/AllDistricts", data: { countryId: country, departmentId: department, provinceId: province } })
        .done(function (resultDistrict) {
            var objResultDis = jQuery.parseJSON(parseAutocomplete(resultDistrict));
            autocompleteBasic(autocompleteId, hiddenId, objResultDis);
        }).fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
}

function formatJsonAutocomplete(json) {
    json = json.replace(/Description/g, 'name');
    json = json.replace(/Id/g, 'id');
    return json;
}

function buildTextbox(area, name, count) {
    var textboxName = 'txt' + area + name + '_' + count;
    return '<input class="form-control pull-left" style="width: 100%;" id="' + textboxName + '" name="' + textboxName + '" />';
}

function buildHidden(area, name, count) {
    var textboxName = 'txt' + area + name + 'Id_' + count;
    return '<input type="hidden" id="' + textboxName + '" name="' + textboxName + '" />';
}

function autocompleteBasic(autocompleteId, hiddenId, source) {
    $(autocompleteId).typeahead({
        source: source,
        afterSelect: function () {
            var value = $(autocompleteId).typeahead("getActive");
            $(hiddenId).val(value.id);
        }
    });
}