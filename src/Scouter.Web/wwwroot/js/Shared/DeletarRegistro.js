function DeletarRegistro(id, url, callbackSuccess) {
    swal("", "Remover o registro?", "warning", {
        buttons: {
            cancel: "Não",
            catch: {
                text: "Sim",
                value: "sim"
            }
        }
    }).then((value) => {
        switch (value) {
            case "sim":
                $.ajax({
                    url: url,
                    type: 'DELETE',
                    data: { id: tiparIdDelete(id) },
                    success: function (response) {
                        if (response) {
                            toastr.success(response);
                            callbackSuccess();
                        }
                    }, error: function (request) {
                        toastr.error(request.responseText);
                    }
                });
                break;
            default:
                break;
        }
    });
}
function tiparIdDelete(id) {
    if (isNaN(id))
        return id;

    return parseInt(id);
}