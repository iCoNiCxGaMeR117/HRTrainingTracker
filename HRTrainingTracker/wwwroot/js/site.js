$(function () {
    $(':submit, .buttonload').click(function () {
        $('#PageBody').hide();
        $('#Loading').show();
    });

    $('.summernote').summernote({
        height: 300,
        minHeight: null,
        maxHeight: null,
        toolbar: [
            ['style', ['style']],
            ['font', ['bold', 'italic', 'underline', 'clear']],
            ['fontname', ['fontname']],
            ['fontsize', ['fontsize']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['height', ['height']],
            ['table', ['table']],
            ['insert', ['link', 'picture', 'hr']],
            //['view', ['fullscreen', 'codeview']],
            ['help', ['help']]
        ]
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
        'columnDefs': [
            {
                'targets': 0,
                'orderable': false
            }]
    });

    $('.TrainingDataTable').DataTable({
        dom: 'QBfrtip',
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
        dom: 'QBfrtip',
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
});