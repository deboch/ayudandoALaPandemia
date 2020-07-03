$(document).ready(function () {
    $('#insumos').hide();
    $('#tipoDonacion').change(function () {
        console.log($('#tipoDonacion').val());
        if ($('#tipoDonacion').val() == '0') {
            $('#insumos').show();
            $('#monetaria').hide();
        } else {
            $('#monetaria').show();
            $('#insumos').hide();
        }
    });
});
