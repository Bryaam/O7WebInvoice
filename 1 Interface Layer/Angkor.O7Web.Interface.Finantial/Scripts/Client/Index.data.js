columnInvoices = [{
    data: 'Id',
    width: '9%'
}, {
    data: 'Type',
    width: '9%'
}, {
    data: 'DocumentCode',
    width: '11%'
}, {
    data: 'Name',
    width: '25%'
}, {
    data: 'Phone',
    width: '8%'
}, {
    data: 'Email',
    width: '11%'
}, {
    data: 'State',
    width: '3%',
    render: function (data, type, full, meta) { return renderButtonChange(data, type, full, meta); }
}, {
    orderable: false,
    className: 'text-center',
    render: function (data, type, full, meta) { return renderButtonSet(data, type, full, meta); },
    width: '15%'
}]

buttonInvoices = [{
    text: 'Agregar',
    action: function (e, dt, node, config) { window.location.href = './Insert'; }
}]