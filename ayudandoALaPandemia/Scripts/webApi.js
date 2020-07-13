$(document).ready(function () {
    const userId = $('#userId').val();
    getDonaciones(userId);
});

const getDonaciones = async (userId) => {
    return (
        await
            $.ajax({
                type: 'get',
                url: "https://localhost:44301/api/necesidad/" + parseInt(userId),
                success: function (response) {
                    const jsonResponse = response;
                    const monetarias = jsonResponse.filter(function (v) { return ( v.tipoDonacion === 1 ) });
                    const insumos = jsonResponse.filter(function (v) { return ( v.tipoDonacion === 0 ) });
                    console.log(monetarias, insumos);
                    if (jsonResponse.length === 0) {
                        const notFound = `<p>No se encontro ninguna necesidad con donaciones</p>`;
                        $('#htmlMonetarias').empty();
                        return $("#htmlMonetarias").html(notFound);
                    }
                    const htmlMonetarias = monetarias.map(function (donacion) {
                        return (
                            `
                                    <div class='col-lg-4 mb-4' >
                                        <a href='/necesidad/${ donacion.idNecesidad}/detalle' class='card h-100' >
                                            <h4 class='card-header'>${ donacion.nombre}</h4>
                                            <div class='card-body'>
                                                <p class='card-text'>Fecha de creacion: <strong>${donacion.fechaNecesidad}</strong></p>
                                                <p class='card-text'>Estado: <strong>${donacion.estado == 1 ? "Activa" : "Inactiva"}</strong></p> 
                                                <p class='card-text'>Total: <strong>${donacion.totalDonacion}</strong></p> 
                                                <p class='card-text'>Total recaudado: <strong>${donacion.totalRecaudado}</strong></p>      
                                            </div> 
                                        </a>
                                    </div>
                                `
                            )
                    })
                    $('#historialMonetarias').empty();
                    $('#historialMonetarias').html(htmlMonetarias)

                    const htmlInsumos = insumos.map(function (donacion) {
                        return (
                        `
                            <div class='col-lg-4 mb-4' >
                                <a href='/necesidad/' + ${ donacion.IdNecesidad} + '/detalle' class='card h-100' >
                                    <h4 class='card-header'>${donacion.nombre}</h4>
                                    <div class='card-body'>
                                        <p class='card-text'>Fecha de creacion: <strong>${donacion.fechaNecesidad}</strong></p>
                                        <p class='card-text'>Estado: <strong>${donacion.estado == 1 ? "Activa" : "Inactiva"}</strong></p>
                                        <h3>Insumos:</h3>

                            ${donacion.listaInsumos.map(function (v) {
                                return (
                                    `<ul>
                                            <li>nombre: ${v.nombre}</li>
                                            <li>cantidadPedida: ${v.cantidadPedida}</li>
                                            <li>totalDonado: ${v.totalDonado}</li>
                                        </ul>`
                                )
                            })}
                                    </div> 
                                </a>
                            </div>
`
                            )
                    })
                    
                    $('#historialInsumos').empty();
                    $('#historialInsumos').html(htmlInsumos)
                }
            })
    );
};