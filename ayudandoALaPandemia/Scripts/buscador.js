$(document).ready(function () {
    $(".searched-wrapper").on("click", ".like", function (event) {
        const idNecesidad = $('.idNecesidad').attr('id');
        onValue(1, idNecesidad);
    });
    $(".searched-wrapper").on("click", ".dislike", function (event) {
        const idNecesidad = $('.idNecesidad').attr('id');
        onValue(0, idNecesidad);
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
            url: `/api/search`,
            data: obj,
            success: function (response) {
                const jsonResponse = JSON.parse(response);
                if (jsonResponse.length === 0) {
                    const notFound = `<p>No se encontro ninguna necesidad</p>`;
                    $('.searched-wrapper').empty();
                    return $(".searched-wrapper").html(notFound);
                }
                const html = jsonResponse.map(function (necesidad) {
                    return (
                        `<div class='card'>
                            <span id=${necesidad.IdNecesidad} class='idNecesidad card-title'>${necesidad.IdNecesidad}</span>
                            <p class='card-text'>${necesidad.Nombre}</p>
                            <p>${necesidad.Descripcion}</p>
                            <div id="values" class="flex">
                                <button id='like' class='like'>like</button>
                                <button id='dislike' class='dislike'>dislike</button>
                            </div>
                        </div>`
                    )
                })
                $('.searched-wrapper').empty();
                $('.searched-wrapper').html(html)
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
                    console.log(response)
                }
            })
    );
}
