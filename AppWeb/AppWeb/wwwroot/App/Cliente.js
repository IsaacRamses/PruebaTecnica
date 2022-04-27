$(document).ready(function () {
    $('#dataTablessss').DataTable({
        "columnDefs": [
            {
                "targets": [0,1,2,3,4,6,9,10,11,12,14],
                "visible": false,
                "searchable": false
            },
           
        ]
    });


    $('#dataTablessss tbody').on('click', '#Update', function () {
        var table = $('#dataTablessss').DataTable();
        var data = table.row($(this).parents('tr')).data();
        ModalUpdate(data);
    });

    $('#dataTablessss tbody').on('click', '#Delete', function () {
        var table = $('#dataTablessss').DataTable();
        var data = table.row($(this).parents('tr')).data();
        ModalDelete(data);
    });

});

function soloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = [8, 37, 39, 46, 6, 44, 45];
    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        // alert('Tecla no aceptada');
        return false;
    }
}

function validarNro(e) {
    var key;
    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }
    if (key < 48 || key > 57) {
        if (key == 8) // Detectar . (punto) y backspace (retroceso)
        { return true; }
        else { return false; }
    }
    return true;
}

function ModalRegistrer() {
    $('#Save').attr('onclick','SaveChanges()');
    $('#ModalRegistrer').modal('show');
}

function ModalUpdate(data) {

    $('#IdCliente__').val(data[0]);
    $('#IdEmail__').val(data[12]);
    $('#PrimerNombre').val(data[1]);
    $('#SegundoNombre').val(data[2]);
    $('#PrimerApellido').val(data[3]);
    $('#SegundoApellido').val(data[4]);
    $('#NroDocument').val(data[8]);
    $('#TDocumento').val(data[6]);
    $('#Nacionalidad').val(data[7]);
    $('#Email').val(data[13]);
    $('#TEmail').val(data[14]);

    $('#Save').attr('onclick', 'UpdateChanges()');
    $('#ModalRegistrer').modal('show');

}

function ModalDelete(data) {

    $('#IdCliente__').val(data[0]);
    $('#ModalDelete').modal('show');

}

function SaveChanges() {

    var PrimerNombre_ = $('#PrimerNombre').val();
    var SegundoNombre_ = $('#SegundoNombre').val();
    var PrimerApellido_ = $('#PrimerApellido').val();
    var SegundoApellido_ = $('#SegundoApellido').val();
    var NroDocument_ = $('#NroDocument').val();
    var TDocumento_ = $('#TDocumento').val();
    var Nacionalidad_ = $('#Nacionalidad').val();
    var Email_ = $('#Email').val();
    var TEmail_ = $('#TEmail').val();

    var cont = 0;

    if (PrimerNombre_ != null && PrimerNombre_ != "") {
        $('#PrimerNombre').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#PrimerNombre').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }
    
    if (PrimerApellido_ != null && PrimerApellido_ != "") {
        $('#PrimerApellido').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#PrimerApellido').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (NroDocument_ != null && NroDocument_ != 0) {
        $('#NroDocument').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#NroDocument').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (TDocumento_ != null && TDocumento_ != 0) {
        $('#TDocumento').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#TDocumento').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (Email_ != null && Email_ != "") {
        $('#Email').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#Email').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (TEmail_ != null && TEmail_ != 0) {
        $('#TEmail').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#TEmail').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }
        

    if (cont > 0) {
        alert("Debe Completar los Campos resaltados")
    }
    else {
        var Model = { Nombre_1: PrimerNombre_, Nombre_2: SegundoNombre_, Apellido_1: PrimerApellido_, Apellido_2: SegundoApellido_, Id_Fkdocumento: TDocumento_, Nacionalidad: Nacionalidad_, Nro_Documento: NroDocument_, IdFktipo: TEmail_, Email1: Email_ };


        $.ajax({
            url: '/Cliente/SaveChanges/',
            data: Model,
            type: 'POST',
            dataType: 'json',
            success: function (json) {
                if (json.result) {
                    alert("Proceso de Regsitro Exitoso")
                    window.location.reload();
                } else {
                    alert("Se ha encontrado un error al realizar su registro")
                }

            },
            error: function (xhr, status) {
                alert('Disculpe, hay un problema para procesar su solicitud');
            }
        });
    }
    

}

function UpdateChanges() {

    var IdCliente_ = $('#IdCliente__').val();
    var IdEmail_ = $('#IdEmail__').val();
    var PrimerNombre_ = $('#PrimerNombre').val();
    var SegundoNombre_ = $('#SegundoNombre').val();
    var PrimerApellido_ = $('#PrimerApellido').val();
    var SegundoApellido_ = $('#SegundoApellido').val();
    var NroDocument_ = $('#NroDocument').val();
    var TDocumento_ = $('#TDocumento').val();
    var Nacionalidad_ = $('#Nacionalidad').val();
    var Email_ = $('#Email').val();
    var TEmail_ = $('#TEmail').val();

    var cont = 0;

    if (PrimerNombre_ != null && PrimerNombre_ != "") {
        $('#PrimerNombre').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#PrimerNombre').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (PrimerApellido_ != null && PrimerApellido_ != "") {
        $('#PrimerApellido').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#PrimerApellido').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (NroDocument_ != null && NroDocument_ != 0) {
        $('#NroDocument').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#NroDocument').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (TDocumento_ != null && TDocumento_ != 0) {
        $('#TDocumento').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#TDocumento').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (Email_ != null && Email_ != "") {
        $('#Email').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#Email').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }

    if (TEmail_ != null && TEmail_ != 0) {
        $('#TEmail').removeClass('form-control-Resaltar').addClass('form-control');
    }
    else {
        $('#TEmail').removeClass('form-control').addClass('form-control-Resaltar');
        cont++
    }


    if (cont > 0) {
        alert("Debe Completar los Campos resaltados")
    }
    else {
        var Model = { IdCliente: IdCliente_, Nombre_1: PrimerNombre_, Nombre_2: SegundoNombre_, Apellido_1: PrimerApellido_, Apellido_2: SegundoApellido_, Id_Fkdocumento: TDocumento_, Nacionalidad: Nacionalidad_, Nro_Documento: NroDocument_, IdEmail: IdEmail_, IdFktipo: TEmail_, Email1: Email_ };


        $.ajax({
            url: '/Cliente/UpdateCliente/',
            data: Model,
            type: 'POST',
            dataType: 'json',
            success: function (json) {
                if (json.result) {
                    alert("Se actualizo correctamente el registro")
                    window.location.reload();
                } else {
                    alert("Se ha encontrado un error al realizar su registro")
                }

            },
            error: function (xhr, status) {
                alert('Disculpe, hay un problema para procesar su solicitud');
            }
        });
    }
}

function Delete() {

    var IdCliente_ = $('#IdCliente__').val();
    var Model = { IdCliente: IdCliente_};


    $.ajax({

        url: '/Cliente/DeleteCliente/',
        data: Model,
        type: 'POST',
        dataType: 'json',

        success: function (json) {
            if (json.result) {
                alert("Cliente eliminado exitosamente")
                window.location.reload();
            } else {
                alert("Se ha encontrado un error al realizar su registro")
            }

        },
        error: function (xhr, status) {
            alert('Disculpe, hay un problema para procesar su solicitud');
        }
    });

}