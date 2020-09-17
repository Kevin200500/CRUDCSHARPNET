function Mandar(idObj) {
    $.ajax({
        data: { idObjeto: idObj},
        dataType: 'json',
        url: '/Home/ObtenerObjeto'
    }).done(function (data) {
        console.log(data)

        $('#Nombre').val(data.NOMBRE)

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(textStatus + ': ' + errorThrown)
    });
}


function Agregar() {

    var nombre = $('#TextBoxNombre').val()
    var color = $('#TextBoxColor').val()
    var fechaRegistro = $('#TextBoxFechaRegistro').val()
    var precio = $('#TextBoxPrecio').val()


    $.ajax({
        data: { nombre: nombre, color: color, fechaRegistro: fechaRegistro, precio: precio},
        dataType: 'json',
        url: '/Home/AgregarObjeto'
    }).done(function (data) {
        if (data == 0) 
            alert('Se agrego correctamente');
        else 
            alert('No se agrego correctamente');
        
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(textStatus + ': ' + errorThrown)
        });

}