function onclickBtnReciver() {
    var reciber_count = parseInt($("#hddCountInvoicer").val());
    addRowAddress(tblInvoicer, 'Invoicer', reciber_count);
    var departmentId = "#txtInvoicerDepartmentId_" + reciber_count;
    var provinceId = "#txtInvoicerProvinceId_" + reciber_count;
    var districtId = "#txtInvoicerDistrictId_" + reciber_count;
    var countryId = "#txtInvoicerCountryId_" + reciber_count;
    var zoneId = "#txtInvoicerZoneId_" + reciber_count;
    var departmentAutocomplete = "#txtInvoicerDepartment_" + reciber_count;
    var provinceAutocomplete = "#txtInvoicerProvince_" + reciber_count;
    var districtAutocomplete = "#txtInvoicerDistrict_" + reciber_count;
    var countryAutocomplete = "#txtInvoicerCountry_" + reciber_count;
    var zoneAutocomplete = "#txtInvoicerZone_" + reciber_count;
    var postaleAutocomplete = "#txtInvoicerPostal_" + reciber_count;

    autocompletePostales(postaleAutocomplete);

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

function autocompletePostales(autocompleteId) {
    $.ajax({ method: 'GET', url: '/Finantial/Client/AllPostales' })
        .done(function (resultPostale) {
            var objResultPostale = jQuery.parseJSON(formatJsonAutocomplete(resultPostale));
            $(autocompleteId).typeahead({ source: objResultPostale });
        }).fail(function (result) {
            toastr.error(result.statusText, 'Mensaje', { positionClass: 'toast-top-full-width' });
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