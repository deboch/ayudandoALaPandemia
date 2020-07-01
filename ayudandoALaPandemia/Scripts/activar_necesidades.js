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
                        $('.collapse .card-body').empty();
                        return $('.collapse .card-body').html(notFound);
                    }
                    const html = jsonResponse.map(function (necesidad) {
                        return (
                            `<div class="row">
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
                                    : null
                                    }
                                    <span class='badge'>
                                        ${necesidad.TipoDonacion == 1 ? 'Monetaria' : 'Insumos'}
                                    </span>

                                    <a class="btn btn-primary" href='/necesidad/' + ${ necesidad.IdNecesidad } + '/detalle'>
                                        Ver
                                        <span class="glyphicon glyphicon-chevron-right"></span>
                                    </a>
                                </div>
                            </div>`
                        )
                    });
                    $('.collapse .card-body').empty();
                    $('.collapse .card-body').html(html)
                }
            })
    );
}

