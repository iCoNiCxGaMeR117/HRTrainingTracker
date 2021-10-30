$(function () {
    $(':submit, .buttonload').click(function () {
        $('#PageBody').hide();
        $('#Loading').show();
    });
});

$(document).ready(function () {
    $('#Loading').hide();
    $('#PageBody').show();

    $('.CustomDataTable').DataTable({
        dom: 'BQlfrtip',
        buttons: [
            'copy', 'excel', 'pdf'
        ],
        fixedHeader: true,
        colReorder: true,
        'columnDefs': [
            {
                'targets': 0,
                'orderable': false
            }]
    });

    $('.TrainingDataTable').DataTable({
        dom: 'BQlfrtip',
        buttons: [
            'copy', 'excel', 'pdf'
        ],
        fixedHeader: true,
        colReorder: true,
        order: [[3, "asc"]],
        buttons: [
            {
                extend: 'excel',
                text: 'Excel',
                className: 'btn btn-default',
                exportOptions: {
                    columns: ':not(.notexport)'
                }
            },
            {
                extend: 'copy',
                text: 'Copy to Clipboard',
                className: 'btn btn-default',
                exportOptions: {
                    columns: ':not(.notexport)'
                }
            },
            {
                extend: 'pdf',
                text: 'PDF',
                className: 'btn btn-default',
                exportOptions: {
                    columns: ':not(.notexport)'
                }
            }],
        'columnDefs': [
            {
                'targets': 0,
                'orderable': false
            },
            {
                'targets': 10,
                'orderable': false
            }],
        searchBuilder: {
            preDefined: {
                criteria: [
                    {
                        condition: '=',
                        data: 'Expired',
                        value: ['No']
                    }
                ]
            }
        }
    });

    $('.EmployeeDataTable').DataTable({
        dom: 'BQlfrtip',
        buttons: [
            'copy', 'excel', 'pdf'
        ],
        fixedHeader: true,
        colReorder: true,
        order: [[3, "asc"]],
        buttons: [
            {
                extend: 'excel',
                text: 'Excel',
                className: 'btn btn-default',
                exportOptions: {
                    columns: ':not(.notexport)'
                }
            },
            {
                extend: 'copy',
                text: 'Copy to Clipboard',
                className: 'btn btn-default',
                exportOptions: {
                    columns: ':not(.notexport)'
                }
            },
            {
                extend: 'pdf',
                text: 'PDF',
                className: 'btn btn-default',
                exportOptions: {
                    columns: ':not(.notexport)'
                }
            }],
        'columnDefs': [
            {
                'targets': 0,
                'orderable': false
            },
            {
                'targets': 11,
                'orderable': false
            }],
        searchBuilder: {
            preDefined: {
                criteria: [
                    {
                        condition: '=',
                        data: 'Active',
                        value: ['Yes']
                    }
                ]
            }
        }
    });

    $('.AttachEmployeeDataTable').DataTable({
        dom: 'lfrtip',
        order: [[1, "asc"]],
        'columnDefs': [
            {
                'targets': 0,
                'orderable': false
            }]
    });
});