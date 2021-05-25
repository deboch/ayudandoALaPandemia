var counter = 0;

$(document).ready(function () {
    if ($('#tipoDonacion option:selected').val() == '0') {
        $('#insumos').show();
        $('#monetaria').hide();
    } else {
        $('#monetaria').show();
        $('#insumos').hide();
    }

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
    $(".agregar-insumo").on('click', function () {
        counter++;
        $("#block-insumos").append(generarHtmlInsumo(counter));
    });
    $(".quitar-insumo").on('click', function () {
        if (counter == 0) return;
        counter--;
        $("#block-insumos .block-insumo:last-child").remove();
    });
});

function generarHtmlInsumo(i) {
    const html = 
        `<div class="block-insumo">
            <div class="control-group form-group">
                <div class="controls">
                    <input class="form-control" id="insumos_${i}__nombre" name="insumos[${i}].nombre" placeholder="nombre" type="text" value="">
                </div>
            </div>
            <div class="control-group form-group">
                <div class="controls">
                    <input class="form-control" data-val="true" data-val-number="The field cantidad must be a number." data-val-required="The cantidad field is required." id="insumos_${i}__cantidad" name="insumos[${i}].cantidad" placeholder="cantidad" type="text" value="0">
                </div>
            </div>
        </div>`
    return html;
}
