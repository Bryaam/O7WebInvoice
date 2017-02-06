function editClient(clientId) {
    window.location.href = './Edit?idClient=' + clientId;
}

function detail(clientId) {
    window.location.href = './ViewDetail?idClient=' + clientId;
}

function renderButtonChange(data, type, full, meta) {    
    if (data == 'Activo') { return '<span class="label label-success" style="cursor: pointer;" onclick="changeStateClient(\'' + full.Id + '\');">' + data + '&nbsp;<i class="fa fa-refresh" aria-hidden="true"></i></span>'; }
    if (data == 'Inactivo') { return '<span class="label label-warning" style="cursor: pointer;" onclick="changeStateClient(\'' + full.Id + '\');">' + data + '&nbsp;<i class="fa fa-refresh" aria-hidden="true"></i></span>'; }
    return "<span class='label label-primary'>" + data + "</span>";
}

function renderButtonSet(data, type, full, meta) {    
    var buttonSearch = '<button type="button" class="btn btn-outline btn-primary" onclick="detail(\'' + full.Id + '\')";><i class="fa fa-eye" aria-hidden="true"></i></button>&nbsp;';
    var buttonEdit = ( full.State == 'Activo' ?
                       '<button type="button" class="btn btn-outline btn-success" onclick="editClient(\'' + full.Id + '\')";><i class="fa fa-pencil" aria-hidden="true"></i></button>&nbsp;' :
                       '<button style="cursor: pointer; background-color: #807C7B !important; border-color: #807C7B !important;" type="button" class="btn btn-outline btn-success" onclick="editClient(\'' + full.Id + '\');" disabled="disabled"><i class="fa fa-pencil" style="color:#323032!important;" aria-hidden="true"></i></button>&nbsp;');
    return buttonSearch + buttonEdit;
}

function afterInitializeInvoices(settings, json) {
    $('.dataTables_scrollBody').slimscroll({
        height: '42vh',
        disableFadeOut: false
    });
    $(".dt-button").removeClass("dt-button").addClass("btn btn-w-m btn-default").wrap("<div class='col-md-6' style='padding-left: 0px;'></div>");
    $(".dt-buttons").addClass("col-md-12").attr("style", "padding-left: 0px; padding-right: 0px;");
    $("#tblInvoices_wrapper .dt-buttons").append('<div class="col-md-6 pull-right"><div class="row"><div class="col-md-2"></div><div class="input-group col-md-10"><input id="txtFilterClient" class="form-control" type="text"><span class="input-group-btn" style="width:1%!important;"><a id="btnSearchClient" href="#" class="btn btn-primary" disabled="true">Buscar&nbsp;<i class="fa fa-search"></i></a></span></div></div></div>');
    $("#txtFilterClient").keyup(function (event) { keyupFilterClient(event); });
    $("#btnSearchClient").on("click", function () { onclickSearchClient(); });
}

function changeStateClient(clientId) {    
    $.alert({
        title: 'Confirmación',
        content: '<p>Deseas cambiar el estado del cliente ' + clientId + '</p>',
        animation: 'zoom',
        closeAnimation: 'zoom',
        type: 'green',
        buttons: {
            confirm: {
                text: 'Aceptar',
                btnClass: 'btn-primary btn-confirm-normal btn-confirm',
                action: function () {
                    submitChangeState(this.$content.find('p'), clientId);
                    $('#btnSearchClient').click();
                }
            },
            cancel: {
                text: 'Cancelar',
                btnClass: 'btn-danger btn-confirm-normal',
                action: function () { $('#btnSearchClient').click(); }
            }
        }
    });
}

function keyupFilterClient(keyEvent) {
    if ($('#txtFilterClient').val().length >= 3) { $('#btnSearchClient').removeAttr('disabled'); }
    else { $('#btnSearchClient').attr('disabled', 'true'); }
}

function onclickSearchClient() {
    var tblInvoices = $("#tblInvoices").DataTable();
    var filterValue = $("#txtFilterClient").val();
    if (filterValue.length >= 3) {
        $.ajax({ method: 'GET', url: '/Finantial/Client/Index_PopulateClient', data: { filter: filterValue }, timeout: 70000 })
            .done(function (result) {
                var objResult = jQuery.parseJSON(result);
                tblInvoices.clear().rows.add(objResult).draw();
            })
            .fail(function (result) {
                toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
            });
    }
}

function submitChangeState(span, clientId) {
    $.ajax({ method: 'POST', url: '/Finantial/Client/ChangeState', data: { clientId: clientId }, async: false })
         .done(function (result) {
             if (result == 'True') {
                 span.html('Se actualizo correctamente el estado.');
                 $('.btn-confirm').hide();
             }
         })
        .fail(function (result) {
            toastr.error(result.statusText, 'Mensaje', { positionClass: 'toast-top-full-width' });
        });
    return false;
}
