/* ESTAS FUNCIONES PUEDEN RESOLVER ALGUNOS REQUERIMIENTOS DE CRUD, LEER Y ANALIZAR*/
function mantenimientoProveedor() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("PRVUNI");
    obj_Parametros_JS[1] = $("#txtProveedor").val();
    obj_Parametros_JS[2] = $("#txtTel").val();
    obj_Parametros_JS[3] = $("#txtEml").val();
    obj_Parametros_JS[4] = $("#cboPais").val();
    obj_Parametros_JS[5] = $("#txtDir").val();
    obj_Parametros_JS[6] = $("#cboSts").val();
    obj_Parametros_JS[7] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

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
                            position: 'center-center',
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 4500,
                            timerProgressBar: true
                        });

                        //Se redirecciona al LogIn
                        setTimeout(function () {
                            location.href = "frmConsultaProveedores.aspx";
                        }, 5000);
                    }
                    else {
                        Swal.fire({
                            icon: "info",
                            title: "Información de Registros",
                            text: arreglo[1],
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
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4500);

    }
}

function eliminaProveedor(uni) {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = uni;
    obj_Parametros_JS[1] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

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
                            position: 'center-center',
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 2500,
                            timerProgressBar: true
                        });

                        //Se redirecciona al LogIn
                        setTimeout(function () {
                            cargaListaProveedores();
                        }, 3000);
                    }
                    else {
                        Swal.fire({
                            icon: "info",
                            title: "Información de Registros",
                            text: arreglo[1],
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
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4500);

    }
}

function cargaListaOrdenes() {
    $.cookie('ORDUNI', 0, { expires: TLTC, path: '/', domain: g_Dominio });

    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $("#bsqSolicitante").val();
    obj_Parametros_JS[1] = $("#bsqProveedor").val();
    obj_Parametros_JS[2] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[2] != 0) && (obj_Parametros_JS[2] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmConsultaOrdenes.aspx/CargaListaOrdenes",
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

                        $("#tblOrdenes").html("");
                        Swal.fire({
                            title: "Búsqueda de Registros",
                            text: res,
                            icon: "info"
                        });
                    }
                    else {
                        $("#tblOrdenes").html(res);
                        paginar("#tblOrdenes");
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
        }, 4500);

    }
}

function mantenimientoOrden() {
    var obj_Parametros_JS = new Array();
    obj_Parametros_JS[0] = $.cookie("ORDUNI");
    obj_Parametros_JS[1] = $("#txtSolicitante").val();
    obj_Parametros_JS[2] = $("#txtDiasCredito").val();
    obj_Parametros_JS[3] = $("#txtFecOrden").val();
    obj_Parametros_JS[4] = $("#cboProveedor").val();
    obj_Parametros_JS[5] = $("#cboTipoOrden").val();
    obj_Parametros_JS[6] = $("#txtDsc").val();
    obj_Parametros_JS[7] = $("#cboSts").val();
    obj_Parametros_JS[8] = $.cookie("GLBUNI");

    var parametros = JSON.stringify({ 'obj_Parametros_JS': obj_Parametros_JS });

    if ((obj_Parametros_JS[8] != 0) && (obj_Parametros_JS[8] != undefined)) {

        jQuery.ajax({
            type: "POST",
            url: "frmMantenimientoOrdenes.aspx/MantenimientoOrdenes",
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
                            position: 'center-center',
                            icon: "success",
                            title: "Información de Registros",
                            text: arreglo[1],
                            showConfirmButton: false,
                            timer: 4500,
                            timerProgressBar: true
                        });

                        //Se redirecciona al LogIn
                        setTimeout(function () {
                            location.href = "frmConsultaOrdenes.aspx";
                        }, 5000);
                    }
                    else {
                        Swal.fire({
                            icon: "info",
                            title: "Información de Registros",
                            text: arreglo[1],
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
            title: 'Error en la conexión',
            text: "No se ha podido validar la información del usuario. Por favor, inicie sesión en el sistema",
            showConfirmButton: false,
            timer: 4500,
            timerProgressBar: true
        });

        //Se redirecciona al LogIn
        setTimeout(function () {
            location.href = "/Login/frmInicioSesion.aspx";
        }, 4500);

    }
}
