const getDonaciones = async (obj = {}) => {
    return (
        await
            $.ajax({
                type: 'get',
                url: `/api/insumos`,
                data: "{}",
                success: function (response) {
                    const jsonResponse = JSON.parse(response);
                    if (jsonResponse.length === 0) {
                        const notFound = `<p>No se encontro ninguna donación</p>`;
                        $('.searched-wrapper .row').empty();
                        return $(".searched-wrapper .row").html(notFound);
                    }

                    const html = jsonResponse.map(function (insumos) {
                        return (
                            `<div class='col-lg-4 mb-4' >
                            <a href='/necesidad/' + ${ insumos.IdNecesidad } + '/detalle' class='card h-100' >
                                <h4 class='card-header'>Nombre de necesidad</h4> 
                                <div class='card-body'>
                                    <p class='card-text'>${insumos.idUsuario}</p> 
                                    <p class='card-text'>${insumos.cantidad}</p>      
                                </div> 
                            </a>
                        </div>`
                        )
                    })
                    $('.searched-wrapper .row').empty();
                    $('.searched-wrapper .row').html(html)
                }/* falta ponernombre de usuario y de la necesidad, falta probar y agregar monetaria*/
            })
    )
}