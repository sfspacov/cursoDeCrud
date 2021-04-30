async function Salvar() {
    let e = document.getElementById("comboCidade");
    let idCidade = e.value;
    let method = "POST";
    let user =
    {
        nome: document.getElementById("txtNome").value,
        cpf: document.getElementById("txtCpf").value,
        idCity: idCidade
    }

    if (user.cpf == "" || user.nome == "" || user.idCity == 0) {
        alert("Preencha todo os campos");
    }
    else {
        let url = "/usuario/CriarNovoUsuario";

        await fetch(url,
            {
                method: "POST",
                body: JSON.stringify(user),
                headers:
                {
                    'Content-Type': 'application/json;charset=utf-8'
                }
            })
            .then(response => {
                debugger;
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response;
            })
            .then(x => {
                debugger;
                alert('ok = ' + x.ok)
            })
    }
}
/*
 * CREATE   =   POST
 * READ     =   GET
 * UPDATE   =   PUT
 * DELETE   =   DELETE
 *
 * */