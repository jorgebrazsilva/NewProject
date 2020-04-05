function ExibirErroAlertDanger(erro) {
    $("#AlertErrorModal").text(erro);
    $("#AlertErrorModal").removeClass("d-none");
}

function RenderBodyAjax() {
    $.ajax({
        url: window.location.href,
        dataType: "html",
        success: function (html) {
            $("#Layout-RenderBody").html(html);            
        },
        error: function (res) {
            swal("", res.responseText, "error");
        }
    });
}
function RenderBodyParamAjax(element, url, data) {
    $.ajax({
        url: url,
        data: data,
        dataType: "html",
        success: function (html) {
            $(element).html(html);          
        },
        error: function (res) {
            swal("", res.responseText, "error");
        }
    });
}

function AbrirModalPartialAjax(url, data) {
    $("#boxModal").load(url, data,
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt === "success")
                $(".modal").modal();
            if (statusTxt === "error")
                swal("", responseTxt, "error");
        });
}