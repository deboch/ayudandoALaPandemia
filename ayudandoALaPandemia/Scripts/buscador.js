$(document).ready(function () {
    getNecesidades();
    $("#form-search").submit(function(event) {
        event.preventDefault();
        const search_field = $('#search-field').val();
        const keyword = 'keyword';
        window.history.pushState({ keyword: `/necesidades/home?${keyword}=${search_field}` }, 'title', `/necesidades/home?${keyword}=${search_field}`);
        getNecesidades({ keyword: search_field });
        
    });
});

const getNecesidades = async (obj = {}) => {
    return (
        await
            $.ajax({
            type: 'get',
            url: `/api/search`,
            data: obj,
            success: function (response) {
                const jsonResponse = JSON.parse(response);
                if (jsonResponse.length === 0) {
                    const notFound = `<p>No se encontro ninguna necesidad</p>`;
                    $('.wrapper').empty();
                    return $(".wrapper").html(notFound);
                }
                const html = jsonResponse.map(function (necesidad) {
                    return (
                        `<div class='card'>
                            <span class='card-title'>${necesidad.IdNecesidad}</span>
                            <p class='card-text'> ${necesidad.Nombre} </p>
                            <p>${necesidad.Descripcion}</p>
                        </div>`
                    )
                })
                $('.wrapper').empty();
                $(".wrapper").html(html)
            }
            })
    )
}