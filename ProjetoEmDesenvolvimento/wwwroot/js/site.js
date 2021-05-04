let contador = 0;
let maximoTentativas = 3

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

        //Envia os dados pro servidor
        await fetch(url,
            {
                method: "POST",
                body: JSON.stringify(user),
                headers:
                {
                    'Content-Type': 'application/json;charset=utf-8'
                }
            })
            //Analise se a resposta tem erro ou não
            .then(response => {
                if (response.ok) {
                    return response;
                }
                throw Error(response.statusText);
            })
            //Se for ok a resposta, cai aqui
            .then(x => {
                alert('ok = ' + x.ok)
            })
            //Se a resposta for um erro
            .catch(function (error) {
                debugger;
                contador++;
                console.log("Tentativa numero: " + contador + " deu errado");

                if (contador <= maximoTentativas) {
                    console.log("Chamando método salvar novamente")
                    Salvar();
                }

                console.log("Numero máximo de tentativas alcançadas");
            })
            //Sempre é executado
            .finally(function () {

            })
    }
}
/*
 * CREATE   =   POST
 * READ     =   GET
 * UPDATE   =   PUT
 * DELETE   =   DELETE
 *
 */