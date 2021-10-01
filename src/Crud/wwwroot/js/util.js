function showModalLoading() {
    $('#myModal').modal({
        keyboard: false,
        show: true
    })
}

function hideModalLoading() {
    setTimeout(function () {
        $('#myModal').modal('hide')
    }, 800);
}

function toastrSuccess(msg) {
    toastr.success(msg, "Sucesso", {
        timeOut: 3000,
        showMethod: 'fadeIn',
        hideMethod: 'fadeOut',
    });
}

function toastrError(msg) {
    toastr.error(msg, "Erro", {
        timeOut: 3000,
        showMethod: 'fadeIn',
        hideMethod: 'fadeOut',
    });
}