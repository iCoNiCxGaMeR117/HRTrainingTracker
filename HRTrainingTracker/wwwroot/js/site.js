$(function () {
    $(':submit, .buttonload').click(function () {
        $('#PageBody').hide();
        $('#Loading').show();
    });
});

$(document).ready(function () {
    $('.CustomDataTable').DataTable({
        dom: 'BQfrtip',
        buttons: [
            'copy', 'excel', 'pdf'
        ]
    });
});