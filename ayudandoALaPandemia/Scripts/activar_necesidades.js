$(document).ready(function () {
    $('.activarNecesidades').on('change', function () {
        var id = $(this).is(':checked')
        activarNecesidades(id)
    });
});

const activarNecesidades = async (isActive) => {
    return (
        await
            $.ajax({
                type: 'post',
                url: `/necesidades/ActualizarEstado`,
                data: {
                    isActive,
                },
                success: function (response) {
                    const jsonResponse = JSON.parse(response);
                    if (jsonResponse.length === 0) {
                        const notFound = `<p>No se encontro ninguna necesidad</p>`;
                        $('.misNecesidades .card-body').empty();
                        return $('.misNecesidades .card-body').html(notFound);
                    }
                    const html = jsonResponse.map(function (necesidad) {
                        return (
                            `<div class="row mb-3">
                                <div class="col-md-3">
                                    <a href="#">
                                        <img class="img-fluid rounded mb-3 mb-md-0" src="../..${necesidad.Foto}" alt="">
                                     </a>
                                 </div>
                                <div class="col-md-5">
                                    <h3>${necesidad.Nombre}</h3>
                                    <p>${necesidad.Descripcion}</p>
                                    ${necesidad.Valoracion != null ?
                                    `<div class='star-ratings-sprite'>
                                            <span style='width:${necesidad.Valoracion}%' class='star-ratings-sprite-rating'></span>
                                        </div>`
                                    : ''
                                    }
                                    <div class='badge'>
                                        ${necesidad.TipoDonacion == 1 ? 'Monetaria' : 'Insumos'}
                                    </div>
                                    <div>
                                        <a class="btn btn-primary" href='/necesidad/' + ${ necesidad.IdNecesidad } + '/detalle'>
                                            Ver
                                            <span class="glyphicon glyphicon-chevron-right"></span>
                                        </a>
                                    </div>
                                </div>
                            </div>`
                        )
                    });
                    $('.misNecesidades .card-body').empty();
                    $('.misNecesidades .card-body').html(html)
                }
            })
    );
}

