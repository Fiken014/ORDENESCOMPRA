
function crearProveedor() {
    $.cookie('PRVUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });
    location.href = "frmMantenimientoProveedores.aspx";

}

function regresar() {
    location.href = "frmConsultaProveedores.aspx";
}

function cargaListaProveedores() {
    $.cookie('PRVUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqProveedor").val();
    obj_Parametros_JS[1] = $("#bsqEstado").val();
    obj_Parametros_JS[2] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[2] != 0) && (obj_Parametros_JS[2] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmConsultaProveedores.aspx/CargaListaProveedores",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });

                }
                else {
                    if (res === "No se encontraron registros") {

                        $("#tblProveedores").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblProveedores").html(res);
                        paginar("#tblProveedores");
                    }
                }

            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4000);

    }
}

function defineProveedor(uni) {
    $.cookie('PRVUNI', uni, { expires: TLTC, path: '/', domain: g_Dominio });

    location.href = "frmMantenimientoProveedores.aspx";
}

function obtieneDetalleProveedor() {

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("PRVUNI");
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoProveedores.aspx/CargaInfoProveedor",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });

                }
                else {

                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));
                    var resultado = arreglo[0];

                    if (res === "No se encontraron registros") {
                        Swal.fire({
                            title: "Información de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        if (resultado != "") {
                            $("#txtProveedor").val(arreglo[1]);
                            $("#txtTel").val(arreglo[2]);
                            $("#txtEml").val(arreglo[3]);
                            $("#cboPais").val(arreglo[4]);
                            $("#txtDir").val(arreglo[5]);
                            $("#cboSts").val(arreglo[6]);
                        }

                    }
                }

            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4000);

    }

}

function formatDate(dateStr) {
    var dateParts = dateStr.split("/");
    var day = dateParts[0].padStart(2, '0');
    var month = dateParts[1].padStart(2, '0');
    var year = dateParts[2];
    return `${year}-${month}-${day}`;
}

function mantenimientoProveedor() {
        //Crear un objeto para almacenar la información del formulario
        var obj_Parametros_JS = new Array();
        obj_Parametros_JS[0] = $.cookie("PRVUNI");
        obj_Parametros_JS[1] = $("#txtProveedor").val();
        obj_Parametros_JS[2] = $("#txtTel").val();
        obj_Parametros_JS[3] = $("#txtEml").val();
        obj_Parametros_JS[4] = $("#cboPais").val();
        obj_Parametros_JS[5] = $("#txtDir").val();
        obj_Parametros_JS[6] = $("#cboSts").val();
        obj_Parametros_JS[7] = $.cookie("GLBUNI");

        //Convirtiendo los valores del arreglo en un elemento de tipo JSON
        var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
        //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
        if ((obj_Parametros_JS[7] != 0) && (obj_Parametros_JS[7] != undefined)) {
            jQuery.ajax({
                type: "POST",
                url: "frmMantenimientoProveedores.aspx/MantenimientoProveedores",
                data: parametros,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                success: function (msg) {
                    var res = msg.d;

                    if (res === undefined) {
                        Swal.fire({
                            title: "Error en la conexión",
                            text: "Error de conexión a la base de datos",
                            icon: "error"
                        });
                    }
                    else {
                        var arreglo = new Array();
                        var str;

                        str = res;
                        arreglo = (str.split("<SPLITER>"));
                        var resultado = arreglo[0];

                        if ((resultado != "0") && (resultado != "-1")) {
                            Swal.fire({
                                position: "center-center",
                                icon: "success",
                                title: "Información de Registros",
                                text: arreglo[1],
                                showConfirmButton: false,
                                timer: 4500,
                                timerProgressBar: true
                            });

                            //Se redirecciona a la página de consulta
                            setTimeout(function () {
                                location.href = "frmConsultaProveedores.aspx";
                            }, 5000);
                        }
                        else {
                            Swal.fire({
                                title: "Información de Registros",
                                text: arreglo[1],
                                icon: "info"
                            });
                        }
                    }
                },
                failure: function (msg) {

                },
                error: function (msg) {

                }
            });
        }
        else {
            Swal.fire({
                position: 'center-center',
                icon: 'error',
                title: "Error en la conexión",
                text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
                showConfirmButton: false,
                timer: 4500,
                timerProgressBar: true
            });
            //Se redirecciona al Login
            setTimeout(function () {
                location.href = "/Login/frmInicioSesion.aspx";
            }, 4000);
        }

    
}

function eliminaProveedor(uni) {
    //Crear un objeto para almacenar la información del formulario
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    //Convirtiendo los valores del arreglo en un elemento de tipo JSON
    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });
    //Se consumen los métodos ajax de jquery para ejecutar un web Method del code behind
    if ((obj_Parametros_JS[1] != 0) && (obj_Parametros_JS[1] != undefined)) {
        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoProveedores.aspx/EliminarProveedores",
            data: parametros,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (msg) {
                var res = msg.d;

                if (res === undefined) {
                    Swal.fire({
                        title: "Error en la conexión",
                        text: "Error de conexión a la base de datos",
                        icon: "error"
                    });
                }
                else {
                    var arreglo = new Array();
                    var str;

                    str = res;
                    arreglo = (str.split("<SPLITER>"));
                    var resultado = arreglo[0];

                    if ((resultado != "0") && (resultado != "-1")) {
                        Swal.fire({
                            position: "center-center",
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 4500,
                            timerProgressBar: true
                        });

                        //Se redirecciona a la página de consulta
                        setTimeout(function () {
                            cargaListaProveedores();
                        }, 3000);
                    }
                    else {
                        Swal.fire({
                            title: "Información de Registros",
                            text: arreglo[1],
                            icon: "info"
                        });
                    }
                }
            },
            failure: function (msg) {

            },
            error: function (msg) {

            }
        });
    }
    else {
        Swal.fire({
            position: 'center-center',
            icon: 'error',
            title: "Error en la conexión",
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });
        //Se redirecciona al Login
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4000);
    }
}

function paginar(elemento) {


    var table;

    if ($.fn.DataTable.isDataTable(elemento)) {

        table = $(elemento).DataTable({

            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });
    }
    else {
        table = $(elemento).DataTable({

            "iDisplayLength": 5,
            "aLengthMenu": [[5, 10, 50, 100], [5, 10, 50, 100]],
            "oLanguage":
            {
                "sLengthMenu": " Mostrar _MENU_  registros por p&aacute;gina",
                "sProcessing": "Procesando...",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Filtrar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            },
            paging: true,
            destroy: true
        });

    }

};

$(document).ready(function () {

    var PageName = window.location.pathname.split('/').pop();

    if (PageName == 'frmConsultaProveedores.aspx') {
        cargaListaProveedores();
    }
    else if (PageName == 'frmMantenimientoProveedores.aspx') {
        obtieneDetalleProveedor();
    }

});