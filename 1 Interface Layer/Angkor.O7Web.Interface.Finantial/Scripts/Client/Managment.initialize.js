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
}