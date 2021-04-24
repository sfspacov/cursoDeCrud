async function loadUfs() {

    const url = "/Uf/GetAll/";

    showModalLoading();

    await fetch(url,
        {
            method: "GET",
        })
        .then(response => {
            if (response.ok) {
                return response;
            }
            throw Error(response.statusText);
        })
        .then(response => response.json())
        .then(response => {
            let $dropdown = $("#comboUF");
            $dropdown.empty();
            $.each(response, function () {
                $dropdown.append($("<option value=" + this.id + ">").text(this.name));
            });
            $dropdown.prepend("<option value='0' selected='selected'>Selecione</option>")
        })
        .catch(() => toastrError("Não foi possível carregar as Ufs"))
        .finally(() => hideModalLoading());
}

function changeUf() {
    let idUf = $("#comboUF").val();

    if (idUf == 0)
        $("#comboCidade").empty();
    else
        loadCities(idUf);
}