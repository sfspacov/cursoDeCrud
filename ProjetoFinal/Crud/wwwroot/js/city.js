async function loadCities(id, callback) {
    const url = "/City/GetByIdUf/" + id;

    showModalLoading();

    await fetch(url,
        {
            method: "GET",
        })
        .then(response => {
            if (!response.ok)
                throw Error(response.statusText);
            return response;
        })
        .then(data => data.json())
        .then(cities => {
            let $dropdown = $("#comboCidade");
            $dropdown.empty();

            let idCapital = 0;

            $.each(cities, function () {
                if (this.isCapital)
                    idCapital = this.id;

                $dropdown.append($("<option value=" + this.id + " selected=" + this.isCapital + ">").text(this.name));
            });

            $("#comboCidade").val(idCapital);

        })
        .catch(() => toastrError("Não foi possível carregar as cidades"))
        .finally(() => {
            if (callback != undefined)
                callback();

            hideModalLoading();
        });
}