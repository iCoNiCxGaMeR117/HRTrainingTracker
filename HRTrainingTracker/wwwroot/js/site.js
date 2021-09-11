$(function () {
    $(':submit, .buttonload').click(function () {
        $('#PageBody').hide();
        $('#Loading').show();
    });
});

$(document).ready(function () {
    $('.CustomDataTable').DataTable({
        dom: 'QBfrtip',
        buttons: [
            'copy', 'excel', 'pdf'
        ],
        fixedHeader: true,
        colReorder: true,
        'columnDefs': [{
            'targets': 0,
            'orderable': false
        }]
    });
});