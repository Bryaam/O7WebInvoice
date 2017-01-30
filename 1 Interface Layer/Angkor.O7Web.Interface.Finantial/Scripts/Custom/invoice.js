$("#tableProducts").on('change',function(){
    calculate_total();
});

$('#data_1 .input-group.date').datepicker({
    format: 'dd/mm/yyyy',
    todayBtn: "linked",
    keyboardNavigation: false,
    forceParse: false,
    calendarWeeks: true,
    autoclose: true
});

$('#clienteOcasionalCB').on('ifChecked', function(){
    $('#botonBuscarCliente').hide();
    $('#codInput').hide();
    $('#docInput').prop('disabled',false);
    $('#docInput').removeClass('emulate-label');
    $('#codLabel').hide();
    $('.typeInput').hide();
    $('#typeLabel').hide();

    $('#docInput').val('');
    $('#nameInput').val('');
    $('#phoneInput').val('');
    $('#mailInput').val('');
    $('#clientCode').html('');
    $('#dirInput').val("");
    $('#dirInputContent').val("");

    $('#dirInputContent').removeClass("hidden");
    $('#dirInputSelect').addClass("hidden");
    $('#dirInputSelect').next().addClass("hidden");

    $('#perception_chosen').hide();
});

$('#clienteOcasionalCB').on('ifUnchecked', function(){
    $('#botonBuscarCliente').show();
    $('#codInput').show();
    $('#docInput').prop('disabled',true);
    $('#docInput').addClass('emulate-label');
    $('#codLabel').show();
    $('.typeInput').show();
    $('#typeLabel').show();

    $('#dirInputContent').addClass("hidden");
    $('#dirInputSelect').removeClass("hidden");
    $('#dirInputSelect').next().removeClass("hidden");

    $('#perception_chosen').show();
});

$('.i-checks').iCheck({
    checkboxClass: 'icheckbox_square-green',
    radioClass: 'iradio_square-green',
});

$("#dirInputSelect").chosen({
    width: "100%",
    disable_search: true
});

$("#condVenta").chosen({
    width: "100%",
    disable_search: true
});

$("#codFinanciero").chosen({
    width: "100%",
    disable_search: true
});

$("#tipoVenta").chosen({
    width: "100%",
    disable_search: true
});

$("#vendedor").chosen({
    width: "100%",
    disable_search: true
});

$("#formaPago").chosen({
    width: "100%",
    disable_search: true
});

$("#lineaNegocio").chosen({
    width: "100%",
    disable_search: true
});

$("#invoiceType").chosen({
    width: "100%",
    disable_search: true
});

$("#idSerieExterno").chosen({
    width: "100%",
    disable_search: true
});

$("#currency").chosen({
    width: "100%",
    disable_search: true
});

$("#language").chosen({
    width: "100%",
    disable_search: true
});

$("#taxe").chosen({
    width: "100%",
    disable_search: true
});

$("#perception").chosen({
    width: "100%",
    disable_search: true
});
//ComboBox Tab1

initialize_combo_ajax("#condVenta","/Finantial/Invoice/GetCondSells");
initialize_combo_ajax("#tipoVenta","/Finantial/Invoice/GetSellTypes");
initialize_combo_ajax("#codFinanciero","/Finantial/Invoice/GetFinantialCodes");
initialize_combo_ajax("#vendedor","/Finantial/Invoice/GetSellers");
initialize_combo_ajax("#lineaNegocio","/Finantial/Invoice/GetBussinessLine");

$("#condVenta").change(function(){
    var condition = $(this).val();
    $.ajax({ method: "GET", url: "/Finantial/Invoice/GetPayments", data: {cond_sell: condition} })
    .done(function (result) {
        var jsonResult = jQuery.parseJSON(result);
        //console.log(result);
        //console.log(jsonResult);
        console.log("Actualiza");
        if (!jQuery.isEmptyObject(jsonResult)) {
            populate_combo_box("#formaPago", jsonResult);
        }
    })
    .fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
});


//Fin ComboBox Tab1

//ComboBox Tab2

initialize_combo_ajax("#invoiceType","/Finantial/Invoice/GetDocumentTypes",false);
$("#invoiceType").val("");
$("#invoiceType").trigger("chosen:updated");

initialize_combo_ajax("#currency","/Finantial/Invoice/GetCurrencies");
initialize_combo_ajax("#language","/Finantial/Invoice/GetLanguages");
initialize_combo_ajax("#taxe","/Finantial/Invoice/GetTaxes", false);
$("#taxe").val("");
$("#taxe").trigger("chosen:updated");

$("#taxe").change(function(){
    var selectedVal = $("#taxe option:selected").text();
    var selectedNumber = selectedVal.split(" ").pop();
    $("#taxeNumber").val(selectedNumber.split("%")[0]);
});

$("#dirInputSelect").change(function(){
    $("#dirInputContent").val($("#dirInputSelect option:selected").text());
    $("#dirInput").val($("#dirInputSelect").val());
});

$.ajax({ method: "GET", url: "/Finantial/Invoice/GetPerception", async: false })
.done(function (result) {
    //console.log(result);
    var jsonResult = jQuery.parseJSON(result);

    combo_box = $("#perception");
    $.each(jsonResult, function (index, value) {
        combo_box.append("<option>"+value.Value+"</option>");
    });
    combo_box.trigger("chosen:updated");
})
.fail(function (result) {
    toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
});
$("#perception").val("");
$("#perception").trigger("chosen:updated");

$("#invoiceType").change(function(){
    var invoice = $(this).val();
    $.ajax({ method: "GET", url: "/Finantial/Invoice/GetSeries", data: {doctype: invoice} })
    .done(function (result) {
        //console.log(result);
        var jsonResult = jQuery.parseJSON(result);

        combo_box = $("#idSerieExterno");
        combo_box.empty();
        combo_box.trigger("chosen:updated");
        var default_value;
        $.each(jsonResult, function (index, value) {
            combo_box.append("<option>"+value.Value+"</option>");
            if(value.Default == "true")
                default_value = value.Value;
        });
        combo_box.val(default_value);
        combo_box.trigger("chosen:updated");

    })
    .fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
});

$("#invoiceType").change(function(){
    var docType = $(this).val();
    $.ajax({ method: "GET", url: "/Finantial/Invoice/DocumentFlg", data: {documentType: docType} })
    .done(function (result) {
        var jsonResult = jQuery.parseJSON(result);
        if (!jQuery.isEmptyObject(jsonResult)) {
            if(jsonResult[0].Content == "N"){
                $(".docFlgTrigger").hide();
                $("#serNumber").val("");
                $("#nroInt").val("");
                $("#nroDocRef").val("");
                $("#nroDocRefExt").val("");
            }
            else{
                $(".docFlgTrigger").show();
            }
        }
    })
    .fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
});

//calculate_expiration_date("#formaPago");
//calculate_expiration_date("#fechaDoc");



//Fin ComboBox Tab2

//Tab 4

$("#btnCrearFactura").click(function(){
    getInvoiceHeader();
});

//Fin Tab 4

//Inicio de data dummy
var dataClient = {"ClientCode" :"666", "ClientType" :"Natural", "DocumentNumber" : "6688", "ClientPhone" :"442131231", "ClientEmail" :"a@caca.com"};
var dataClient2 = {"ClientCode" :"6662", "ClientType" :"Natural2", "DocumentNumber" : "6688222", "ClientPhone" :"442131231", "ClientEmail" :"a@caca.com"};

var dataSetClient = [];
dataSetClient.push(dataClient);
dataSetClient.push(dataClient2);

var dataUnit = {"item":"1","concept":"observacion","desc":"descripcion","price":"8","tax":"18","porc":"5"};
dataUnit.amount = "<input class='form-control pull-left' style='width: 70%;margin-right: -100px;' type='number' value='' id='item_amount_"+1+"'>";
dataUnit.comment = "<input class='form-control' value='' id='item_comment_"+1+"'>";
dataUnit.price = "<input class='form-control pull-left' style='width: 70%;margin-right: -100px;' type='number' id='item_price_"+1+"'>";

var dataSet = [];
dataSet.push(dataUnit);

//Fin de data dummy


var tableClients = $('#seleccionarCliente').DataTable({
    "bPaginate": false,
    "bLengthChange": false,
    "bFilter": true,
    "bInfo": false,
    "bAutoWidth": false,
    "searching" : false,
    "paging": true,
    columns: [
    { title: "Cod.", data: "ClientCode"},
    { title: "Nombre", data: "ClientName"},
    { title: "RUC/DNI", data: "DocumentNumber"},
    { title: "Teléfono", data: "ClientPhone"},
    { title: "Email", data: "ClientEmail"}
    ]
});
//Tabla de Facturas
var tableSeries = $('#seleccionarSerie').DataTable({
    "bPaginate": false,
    "bLengthChange": false,
    "bFilter": true,
    "bInfo": false,
    "bAutoWidth": false,
    "searching" : false,
    "paging": true,
    columns:[
    { title: "Documento", data: "DocumentType", width: "12%" },
    { title: "Serie", data: "Serie", width: "10%" },
    { title: "Cod. Cliente", data: "ClientCode", width: "5%" },
    { title: "Razón Social", data: "ClientName", width: "8%" },
    { title: "RUC/DNI", data: "ClientDoc", width: "5%" },
    { title: "Fecha", data: "Date", width: "10%" },
    { title: "Moneda", data: "Currency", width: "5%" },
    { title: "Importe", data: "Amount", width: "5%" },
    ]
});

$('#seleccionarCliente tbody').on( 'click', 'tr', function () {
    if ( $(this).hasClass('selected') ) {
        $(this).removeClass('selected');
    }
    else {
        tableClients.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
} );

$('#seleccionarSerie tbody').on( 'click', 'tr', function () {
    if ( $(this).hasClass('selected') ) {
        $(this).removeClass('selected');
    }
    else {
        tableSeries.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
    }
} );


$('#modalClientOk').click( function () {
    var parentRow = $('.selected');
    if(parentRow.val() != undefined){
        $("#codInput").val(parentRow.children('td').eq(0).text());
        //$(".typeInput").val(parentRow.children('td').eq(1).text());
        $("#docInput").val(parentRow.children('td').eq(2).text());
        $("#nameInput").val(parentRow.children('td').eq(1).text());
        $("#phoneInput").val(parentRow.children('td').eq(3).text());
        $("#mailInput").val(parentRow.children('td').eq(4).text());
        tableClients.row('.selected').remove().draw( false );

        var clientCode = parentRow.children('td').eq(0).text();

        $("#clientCode").html(clientCode);

        $.ajax({ method: "GET", url: "/Finantial/Invoice/GetInvoiceAdresses", data: {clientId: clientCode } })
        .done(function (result) {
            var jsonResult = jQuery.parseJSON(result);
            if (!jQuery.isEmptyObject(jsonResult)) {
                populate_combo_box("#dirInputSelect", jsonResult);
                $("#dirInputSelect").val("");
                $("#dirInputSelect").trigger("chosen:updated");
            }
        })
        .fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });

        //Pedir el codigo (Usuario) segun cada caso para poder actualizar los chosen

        $.ajax({ method: "GET", url: "/Finantial/Invoice/ClientDefaultValues", data: {clientId: clientCode } })
        .done(function (result) {
            var jsonResult = jQuery.parseJSON(result);
            if (!jQuery.isEmptyObject(jsonResult)) {
                update_chosen_select("#taxe",jsonResult[0].TaxId);
                update_chosen_select("#currency",jsonResult[0].CurrencyId);
                update_chosen_select("#tipoVenta",jsonResult[0].TypeSell);
                update_chosen_select("#condVenta",jsonResult[0].CondSell);
                update_chosen_select("#formaPago",jsonResult[0].Payment);
                update_chosen_select("#vendedor",jsonResult[0].Seller);
                update_chosen_select("#codFinanciero",jsonResult[0].FinantialCode);
                update_chosen_select("#lineaNegocio",jsonResult[0].BussinessLine);
                update_chosen_select("#language",jsonResult[0].Language);
                if(jsonResult[0].FlgPer == "N"){
                    $('#perception_chosen').hide();
                    $('#perceptionLabel').hide();
                    update_chosen_select("#perception","");
                }
                else{
                    $('#perception_chosen').show();
                    $('#perceptionLabel').show();
                }

                var condition = $("#condVenta").val();
                $.ajax({ method: "GET", url: "/Finantial/Invoice/GetPayments", data: {cond_sell: condition} })
                .done(function (result) {
                    var jsonResult = jQuery.parseJSON(result);
                    if (!jQuery.isEmptyObject(jsonResult)) {
                        populate_combo_box("#formaPago", jsonResult);
                    }
                })
                .fail(function (result) {
                    toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                });

            }
        })
        .fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });

        /*update_chosen_select("#condVenta","0002");
        update_chosen_select("#"formaPago);
        update_chosen_select("#vendedor");
        update_chosen_select("#tipoVenta");
        update_chosen_select("#codFinanciero");
        update_chosen_select("#lineaNegocio"); */
    }
});

$('#modalSerieOk').click( function () {
    var parentRow = $('.selected');
    var invoiceDoc = parentRow.children('td').eq(0).text();
    var invoiceSerie = parentRow.children('td').eq(1).text();
    var invoiceParsed = invoiceDoc.split("-");
    var invoiceSerieParsed = invoiceSerie.split("-");
    $("#serNumber").val($.trim(invoiceParsed[0]));
    $("#nroInt").val($.trim(invoiceParsed[1]));
    $("#nroDocRef").val($.trim(invoiceSerieParsed[0]));
    $("#nroDocRefExt").val($.trim(invoiceSerieParsed[1]));
    tableSeries.row('.selected').remove().draw( false );
});


//Agregar un cliente a la tabla - Step 1
$('#btnFilter').click(function(){
    var filterContent = $('#filterInput').val();
    //tableClients.clear().rows.add(dataSetClient).draw();
    $.ajax({ method: "GET", url: "/Finantial/Invoice/Get_Clients", data: {filter: filterContent} })
    .done(function (result) {
        //console.log(result);
        var jsonResult = jQuery.parseJSON(result);
        if (!jQuery.isEmptyObject(jsonResult)) {
            tableClients.clear().rows.add(jsonResult).draw();
        }
    })
    .fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
});

//Filtrar las series
$('#btnFilterSerie').click(function(){
    var filterContent = $('#filterInputSerie').val();
    //tableSeries.clear().rows.add(dataSetClient).draw();
    $.ajax({ method: "GET", url: "/Finantial/Invoice/Invoices_Populate", data: {filter: filterContent} })
    .done(function (result) {
        //console.log(result);
        var jsonResult = jQuery.parseJSON(result);

        tableSeries.clear().rows.add(jsonResult).draw();

    })
    .fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
});

function calculate_expiration_date(idElement){
    $(idElement).change(function(){
        var docType = $("#formaPago").val();
        var currDate = $("#fechaDoc").val();
        console.log(docType);
        console.log(currDate);
        $.ajax({ method: "GET", url: "/Finantial/Invoice/GetExpirationDate", data: {payment: docType, documentDate: currDate} })
        .done(function (result) {
            var jsonResult = jQuery.parseJSON(result);
            console.log(jsonResult[0]);
            $("#fechaVenc").val(jsonResult[0].Content);
        })
        .fail(function (result) {
            toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
        });
    });
}


//Function que por request AJAX llena un comboBox
function initialize_combo_ajax(idSelect, url, async = true){
    $.ajax({ method: "GET", url: url, async: async })
    .done(function (result) {
        var jsonResult = jQuery.parseJSON(result);
        if (!jQuery.isEmptyObject(jsonResult)) {
            populate_combo_box(idSelect, jsonResult);
        }
    })
    .fail(function (result) {
        toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
    });
}

    //Function que llena un comboBox
    function populate_combo_box(idCombo, data){
        combo_box = $(idCombo);
        combo_box.empty();
        combo_box.trigger("chosen:updated");
        $.each(data, function (index, value) {
            combo_box.append("<option value='"+value.Value+"'>"+value.Content+"</option>");
        });
        combo_box.trigger("chosen:updated");
    }

    //Function que hace update a un chosen select
    function update_chosen_select(chosenId, value){
        var chosenElement = $(chosenId);
        //chosenElement.attr("disabled", true);
        chosenElement.val(value);
        chosenElement.trigger("chosen:updated");
    }

    function calculate_total(){
        var sellValue = 0.0;
        var totalTax = 0.0;
        var totalPorc = 0.0;
        tableProduct.rows().every(function(rowIdx,tableLoop,rowLoop){
            var curData = this.data();
            var price = $('#item_price_'+curData.item).val();
            var amount = $('#item_amount_'+curData.item).val();
            console.log(price);
            console.log(amount);
            var curSubTotal = price*amount;
            sellValue+=curSubTotal;
            totalTax+=curSubTotal*curData.tax/100;
            console.log(totalTax);
            totalPorc+=curSubTotal*curData.porc/100;
            console.log(totalPorc);
        })
        $('#venta').val(sellValue);
        $('#impuesto').val(totalTax);
        console.log(sellValue+totalTax);
        $('#totalValor').val(sellValue+totalTax);
        $('#percepcionImport').val(totalPorc);
        $('#totalACobrar').val(sellValue+totalTax+totalPorc);
    }

    function getInvoiceHeader(){
        var ClientCode = $("#clientCode").html();
        var ClientID = $("#docInput").val();
        var ClientPhone = $("#phoneInput").val();
        var ClientName = $("#nameInput").val();
        var ClientMail = $("#mailInput").val();
        var ClientAddressValue = $("#dirInput").val();
        var ClientAddressContent = $("#dirInputContent").val();

        var CondVenta = $("#condVenta").val();
        var TipoVenta = $("#tipoVenta").val();
        var FormaPago = $("#formaPago").val();
        var CodFinanciero = $("#codFinanciero").val();
        var Vendedor = $("#vendedor").val();
        var LineaNegocio = $("#lineaNegocio").val();

        var TipoDoc = $("#invoiceType").val();
        var SerieExterno = $("#idSerieExterno").val();
        var FechaDoc = $("#fechaDoc").val();
        var FechaVenc = $("#fechaVenc").val();
        var Currency = $("#currency").val();
        var Language = $("#language").val();
        var Taxe = $("#taxe").val();
        var Perception = $("#perception").val();

        var Glosa = $("#glosa").val();
        var Donacion = $("#donacionCB").is(":checked") == true ? "S" : "N";
        var SerieNumber = $("#serNumber").val();
        var NroInt = $("#nroInt").val();
        var NroDocRef = $("#nroDocRef").val();
        var NroDocRefExt = $("#nroDocRefExt").val();
        var NroOC = "";
        var NroGuiaRemision = "";
        var Trabajador = "";


        $.ajax({ method: "POST", url: "/Finantial/Invoice/Insert_Invoice", data: { documentType: TipoDoc,  serie: SerieExterno, currency: Currency,  documentDate: FechaDoc, documentExpiration: FechaVenc,  clienteCode: ClientCode,  codTax: Taxe,  clientName: ClientName,  invoiceAddress: ClientAddressContent,  clientId: ClientID,  glosa: Glosa, sellType: TipoVenta,  language: Language, condSell: CondVenta,  payment: FormaPago, bussinessline: LineaNegocio,  finantialcod: CodFinanciero, telephone: ClientPhone,  seller: Vendedor, employeeId: Trabajador,  perception: Perception, donate: Donacion,  documentTypeRef: SerieNumber, documentIdRef: NroInt, documentOc: NroOC, guiRem: NroGuiaRemision, addressId: ClientAddressValue, serieExtRef: NroDocRef, nroDoceExt: NroDocRefExt } })
            .done(function (result) {
                insertInvoiceDetail(result,TipoDoc,Perception);
                $("#btnCrearFactura").prop('disabled', true);
                $("#btnFacturacionE").prop('disabled', false);
                $("#btnPDF").prop('disabled', false);
                $("#btnFacturacionM").prop('disabled', false);
            })
            .fail(function (result) {
                toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
            });


    }

    function insertInvoiceDetail(idInvoice, tipoDoc, perception){
        tableProduct.rows().every( function ( rowIdx, tableLoop, rowLoop ) {

            var curData = this.data();
            var concept = $('#item_concept_' + curData.item).val();
            var comment = $('#item_comment_' + curData.item).val();
            var costCenter = $('#item_cost_center_' + curData.item).val();
            var taxe = $('#item_tax_' + curData.item).val();
            var price = $('#item_price_' + curData.item).val();
            var amount = $('#item_amount_' + curData.item).val();
            var subtotal = $('#item_subtotal_' + curData.item).val();

            var typeConcept = $('#item_concept_' + curData.item);
            var typeCostCenter = $('#item_cost_center_' + curData.item);

            var conceptSource = typeConcept.data('typeahead').source;
            var costCenterSource = typeCostCenter.data('typeahead').source;

            var conceptValue = getCodeByName(conceptSource, concept);
            var costCenterValue = getCodeByName(costCenterSource, costCenter);

            $.ajax({ method: "POST", url: "/Finantial/Invoice/InsertDetailInvoice", data: { documentType: tipoDoc, documentId: idInvoice, conceptId: conceptValue, observacion: comment, cantidad: amount, unitValue: price, taxId: taxe, perception: perception, ccoId: costCenterValue} })
                .done(function (result) {
                })
                .fail(function (result) {
                    toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
                });
        });
    }


    // Agregar dataset a la tabla
    var itemNum = 0;

    var tableProduct = $('#tableProducts').DataTable({
        "bPaginate": false,
        "bLengthChange": false,
        "bFilter": false,
        "bInfo": false,
        "bAutoWidth": false,
        "paging": true,
        columns: [
            { title: "Concepto", data: "concept"},
            { title: "Comentario", data: "comment"},
            { title: "Centro de costos", data: "cost_center"},
            { title: "Impuesto", data: "tax"},
            { title: "Valor Unitario", data: "price"},
            { title: "Cantidad", data: "amount"},
            { title: "Subtotal", data: "subtotal"},
            { title: "", data: "delete"}
        ]
    });

    tableProduct.page.len( 5 ).draw();



    //create_dataset();

    $('#botonAgregarProducto').click(function(){
        create_dataset();
    });

    $('#tableProducts tbody').on( 'click', 'a.delete', function () {
        tableProduct
        .row( $(this).parents('tr') )
        .remove()
        .draw();

        calculate_total();
    } );

    function getCodeByName(source, name){
        var code = "" ;
        $.each( source, function( key, value ) {
            if(name === value.name){
                code = value.Value;
                return false;
            }
        });
        return code;
    }

    // Verificar que todos los campos esten completos
    function verify_complete(){
        var amount = $('#item_amount_'+(itemNum-1)).val();
        var comment = $('#item_comment_'+(itemNum-1)).val();
        var price = $('#item_price_'+(itemNum-1)).val();
        var concept = $('#item_concept_'+(itemNum-1)).val();
        var cost_center = $('#item_cost_center_'+(itemNum-1)).val();
        var tax = $('#item_tax_'+(itemNum-1)).val();

        console.log(tax)

        if (amount != "" && comment != "" && price != "" && concept != "" && cost_center != "" && tax != null){
            $('#botonAgregarProducto').prop( "disabled", false );
        }
    }

    // Crear dataset
    function create_dataset(){
        var dataUnit = {"porc":"5"};
        dataUnit.item = itemNum;
        dataUnit.amount = "<input class='form-control pull-left input-add_product' style='width: 100%;' type='number' value='' id='item_amount_"+itemNum+"'>";
        dataUnit.comment = "<input class='form-control input-add_product' value='' style='width:100%' id='item_comment_"+itemNum+"'>";
        dataUnit.price = "<input class='form-control pull-left input-add_product' style='width: 100%;' type='number' id='item_price_"+itemNum+"'>";
        dataUnit.concept = "<input class='form-control input-add_product' style='width:100%' id='item_concept_"+itemNum+"'>";
        dataUnit.cost_center = "<input class='form-control input-add_product' value='' style='width:100%' id='item_cost_center_"+itemNum+"'>";
        dataUnit.delete = "<a class='delete text-danger text-center' href='#'><i class='fa fa-trash'></i></a>";
        dataUnit.subtotal = "<p id='item_subtotal_"+itemNum+"'>0</p>";
        dataUnit.tax = "<select class='form-control' id='item_tax_"+itemNum+"'></select>"

        var dataSet = [];
        dataSet.push(dataUnit);

        tableProduct.rows.add(dataSet).draw();

        var currentPerception = $("#perception").val();

        $.ajax({ method: "GET", url: "/Finantial/Invoice/GetConcepts", data: { ratePerception: currentPerception }, async: false })
            .done(function (result) {
                var jsonResult = jQuery.parseJSON(result);
                if (!jQuery.isEmptyObject(jsonResult)) {
                    $('#item_concept_'+itemNum).typeahead({
                        source: jsonResult
                    });
                }
            })
            .fail(function (result) {
                toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
            });


        $.ajax({ method: "GET", url: "/Finantial/Invoice/GetCenterCost", async: false })
            .done(function (result) {
                var jsonResult = jQuery.parseJSON(result);
                if (!jQuery.isEmptyObject(jsonResult)) {
                    $('#item_cost_center_'+itemNum).typeahead({
                        source: jsonResult
                    });
                }
            })
            .fail(function (result) {
                toastr.error(result.statusText, "Mensaje", { positionClass: "toast-top-full-width" });
            });

        $("#item_tax_" + itemNum).chosen({
            width: "100%",
            disable_search: true
        });

        initialize_combo_ajax("#item_tax_" + itemNum,"/Finantial/Invoice/GetTaxes", false);
        update_chosen_select("#item_tax_" + itemNum, $("#taxe").val());

        itemNum++;

        $('#botonAgregarProducto').prop( "disabled", true );
        $('.input-add_product').bind('keyup',verify_complete);

    }

    // Calcular total de productos
    function calculate_total(){
        var sellValue = 0.0;
        var totalTax = 0.0;
        var totalPorc = 0.0;

        tableProduct.rows().every(function(rowIdx,tableLoop,rowLoop){
            var curData = this.data();
            var price = $('#item_price_'+curData.item).val();
            var amount = $('#item_amount_'+curData.item).val();
            var tax =  $('#item_tax_'+curData.item+' :selected').text();

            console.log(tax);

            var curSubTotal = price*amount;

            $('#item_subtotal_'+curData.item).text(curSubTotal);

            sellValue += curSubTotal;
            totalTax += curSubTotal*tax/100;
            totalPorc += curSubTotal*curData.porc/100;
        })

        $('#venta').text(sellValue);
        $('#impuesto').text(totalTax);
        $('#totalValor').text(sellValue+totalTax);
        $('#percepcionImport').text(totalPorc);
        $('#totalACobrar').text(sellValue+totalTax+totalPorc);
    }