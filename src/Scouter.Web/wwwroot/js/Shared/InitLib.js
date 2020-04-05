$(document).ready(function () {
    initColorPicker();
    initChosen();
    initInputMaskTelefone();
    initDataTable();
    initToastr();
});

function initInputMaskTelefone() {
    let telefone = $('.telefone');
    if (telefone)
        telefone.inputmask({ "mask": '(99)9999-9999[9]' });
}

function initColorPicker() {
    let colorPicker = $('.color-picker');
    if (colorPicker) {
        colorPicker.colorpicker();
    }
}

function initChosen(element) {
    let seletorElemento = ".chosen-select";

    if (element) {
        seletorElemento = element;
    }
    let chosenSelect = $(seletorElemento);

    if (chosenSelect) {
        chosenSelect.chosen({ width: "100%" });
    }
}

function initChosenDisabled(element) {
    initChosen(element);
    $(element).attr('disabled', 'disabled');
    $(element).data('chosen').search_field_disabled();
    $(element).trigger('update');
}

function initDataTable(elementTable) {
    let seletorElemento = ".dataTables-full";

    if (elementTable) {
        seletorElemento = elementTable;
    }

    var dataTablesFull = $(seletorElemento);
    if (dataTablesFull) {
        dataTablesFull.DataTable().destroy();

        dataTablesFull.DataTable({
            language: {
                url: getLanguageUrlForDatatables()
            },
            dom: '<"html5buttons"B>lTfgitp',
            pageLength: 10,
            buttons: [
                { extend: 'copy' },
                { extend: 'csv' },
                { extend: 'excel', title: 'DocumentoExcel_' + Date.now() },
                { extend: 'pdf', title: 'DocumentoPDF_' + Date.now() },

                {
                    extend: 'print',
                    customize: function (win) {
                        $(win.document.body).addClass('white-bg');
                        $(win.document.body).css('font-size', '10px');

                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    }
                }
            ]
        });
    }

}

function getLanguageUrlForDatatables() {
    var lang = navigator.language || navigator.userLanguage;
    lang = lang.toLowerCase();

    return `/lib/dataTables/languages/${lang}.json`;
}

function initToastr() {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": false,
        "positionClass": "toast-bottom-right",
        "onclick": null
    };
}