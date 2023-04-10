var identidad;

//limpiando los inputs
function Limpiar() {
    $("#identidad").val('');
    $("#ident").val('');
    $("#censoId").val('');
    $("#Nombre").val('');
    $("#Departamento").val('');
    $("#Municipio").val('');
    $("#Colonia").val('');
    $("#CentroV").val('');
    $("#mer").val('');
    $("#Linea").val('');
    $("#messageError").empty();
}

function Clean() {
    Limpiar();
    $('#Voto').empty();
    $('#Voto').append("No");
    $('#Voto').css("background-color","darkgray");
}

//Mostrando data
function GetData() {
    var data = {
        identidad: identidad
    }
    $.ajax({
        url: "/Censo/Buscar",
        type: "POST",
        dataType: "json",
        data: data,
    }).done(function (result) {

        if (result != null) {
            $("#censoId").val(result.censo_Id);
            $("#identidad").val(result.censo_Identidad);
            $("#Nombre").val(result.nombreCompleto);
            $("#Departamento").val(result.departamento);
            $("#Municipio").val(result.municipio);
            $("#Colonia").val(result.colonia);
            $("#CentroV").val(result.centroVotacion);
            $("#mer").val(result.numeroMesa);
            $("#Linea").val(result.numeroLinea);

            if (result.voto == false) {
                $("#btnVotar").css("display","inline-block");
                $('#Voto').empty();
                $('#Voto').append("No");
                $('#Voto').css("background-color","#ED2B17");
            }
            else {
                $('#Voto').empty();
                $('#Voto').append("Si");
                $('#Voto').css("background-color","#32FB77");
                $("#btnVotar").css("display","none");
            }
        }
        else {
            $("#messageError").empty();
            $("#messageError").append("La identidad no existe o no es valida.");
        }
    })
}

// validaciones para la busquedad de la identidad
function Buscar() {
    identidad = $("#ident").val();

    if (identidad != "") {
        if (identidad.length != 13) {
            Limpiar();
            $("#messageError").append("La identidad debe contener un mínimo de 13 digitos.");            
        }
        else {
            $("#messageError").empty();
            GetData();
        }        
    }
    else {
        Limpiar();
        $("#messageError").append("Introduzca un numero de identidad");
    }
}

// cambiando el estado de votar a true
function Votar() {
    var data = {
        id: $("#censoId").val()
    }

    $.ajax({
        url: "/Censo/Votar",
        type: "POST",
        dataType: "json",
        data: data,

    }).done(function (result) {
        if (result != "-1") {
            appConfig.alert("success", "Su voto se registro Correctamente.");
            GetData();
        }
        else {
            appConfig.alert("error", "No se pudo realizar la su votación.");
        }
    })
}