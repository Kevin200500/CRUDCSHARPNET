function Mandar(idObj) {
    $.ajax({
        method:'GET',
        data: { idObjeto: idObj},
        dataType: 'json',
        url: '/Home/ObtenerObjeto'
    }).done(function (data) {
        console.log(data)
        $('#idObjeto').val(data.ID_OBJETO)
        $('#Nombre').val(data.NOMBRE)
        $('#Color').val(data.COLOR)
        $('#FechaRegistro').val(data.FECHA_REGISTRO)
        $('#Precio').val(data.PRECIO)
        
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
        method:"POST",
        data: { nombre: nombre, color: color, fechaRegistro: fechaRegistro, precio: precio},
        dataType: 'json',
        url: '/Home/AgregarObjeto'
    }).done(function (data) {
        if (data === 0) {
            alert('Se agrego correctamente');
            location.reload();
            window.location.replace('/Home/Index');
        }
        else {
            alert('No se agrego correctamente');
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(textStatus + ': ' + errorThrown)
        });

}

const Editar=()=>{

    let id = $('#idObjeto').val();
    let nombre = $('#Nombre').val();
    let color = $('#Color').val();
    let fechaRegistro = $('#FechaRegistro').val();
    let precio = $('#Precio').val();

    $.ajax({
        data: {idObjeto:id, nombre: nombre, color: color, fechaRegistro: fechaRegistro, precio: precio },
        dataType: 'json',
        url: '/Home/EditarObjeto'
    }).done(function (data) {
        if (data === 0) {
            alert('Se edito correctamente');
            location.reload();
        }
        else{
        alert('No se edito correctamente');
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(textStatus + ': ' + errorThrown)
    });
}
const Delete = (idObj) => {
    $.ajax({
        data: { idObjeto: idObj },
        dataType: 'json',
        url: '/Home/EliminarObjeto'
    }).done(function (data) {
        if (data === 0) {
            alert('Eliminado Correctamente');
            location.reload();
        } else {
            alert('Hubo un Problema con el servidor');
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(textStatus + ': ' + errorThrown)
    });
}
const sendform = () => {
    window.location.replace('/Home/Form');
}