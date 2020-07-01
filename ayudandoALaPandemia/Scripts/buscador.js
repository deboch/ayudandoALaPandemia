$(document).ready(function () {
    $(".searched-wrapper").on("click", ".btn-like", function (event) {
        event.preventDefault();
        const isLike = $(".searched-wrapper").find(".like").hasClass(".active");
        if (!isLike) {
            const idNecesidad = $('.idNecesidad').attr('id');
            onValue(1, idNecesidad);
        }
    });
    $(".searched-wrapper").on("click", ".btn-dislike", function (event) {
        event.preventDefault();
        const isDislike = $(".searched-wrapper").find(".dislike").hasClass(".active");
        if (!isDislike) {
            const idNecesidad = $('.idNecesidad').attr('id');
            onValue(0, idNecesidad);
        }
    });
    $("#form-search").submit(function(event) {
        event.preventDefault();
        const search_field = $('#search-field').val();
        const keyword = 'keyword';
        window.history.pushState({ keyword: `/necesidades?${keyword}=${search_field}` }, 'title', `/necesidades?${keyword}=${search_field}`);
        getNecesidades({ keyword: search_field });
        
    });
});

const getNecesidades = async (obj = {}) => {
    return (
        await
            $.ajax({
            type: 'get',
            url: `/api/necesidades`,
            data: obj,
            success: function (response) {
                const jsonResponse = JSON.parse(response);
                if (jsonResponse.length === 0) {
                    const notFound = `<p>No se encontro ninguna necesidad</p>`;
                    $('.searched-wrapper .row').empty();
                    return $(".searched-wrapper .row").html(notFound);
                }
                
                const html = jsonResponse.map(function (necesidad) {
                    return (
                        `<div class='col-lg-4 mb-4' >
                            <a href='/necesidad/' + ${ necesidad.IdNecesidad } + '/detalle' class='card h-100' >
                                <h4 class='card-header'>${necesidad.Nombre}</h4>
                                <img src='../..${necesidad.Foto}' width='100%' height='auto' />
                                <div class='card-body'>
                                    <p class='card-text'>${necesidad.Descripcion}</p>
                                    <span class='badge'>
                                        ${necesidad.TipoDonacion == 1 ? 'Monetaria' : 'Insumos'}
                                    </span>
                                </div>
                                ${necesidad.Valoracion != null ?
                                `<div class='star-ratings-sprite'>
                                        <span style='width:${necesidad.Valoracion}%' class='star-ratings-sprite-rating'></span>
                                    </div>`
                                : null
                                }
                            </a>
                        </div>`
                    )
                })
                $('.searched-wrapper .row').empty();
                $('.searched-wrapper .row').html(html)
            }
            })
    )
}

const onValue = async (like, idNecesidad) => {
    return (
        await
            $.ajax({
                type: 'post',
                url: `/necesidades/valorar`,
                data: {
                    like: like,
                    idNecesidad: idNecesidad
                },
                success: function (response) {
                    if (response == "True") {
                        $(".searched-wrapper").find(".dislike").removeClass("active");
                        $(".searched-wrapper").find(".like").addClass("active");
                    } else {
                        $(".searched-wrapper").find(".like").removeClass("active");
                        $(".searched-wrapper").find(".dislike").addClass("active");
                    }
                }
            })
    );
}
