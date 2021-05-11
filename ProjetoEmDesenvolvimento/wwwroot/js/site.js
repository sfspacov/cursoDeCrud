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
                let contador = 0;
                let maximoTentativas = 3
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

async function ListarEstados() {
    let url = "/estado/obterEstados";

    await fetch(url)
        .then(response => {
            if (response.ok) {
                return response;
            }
            throw Error(response.statusText);
        })
        .then(response => response.json())
        .then(response => {
            var comboUF = document.getElementById("comboUF");

            for (let i = 0; i < response.length; i++) {
                let value = response[i].id;
                let text = response[i].abbreviation;

                option = document.createElement('option');

                option.setAttribute('value', value);
                option.appendChild(document.createTextNode(text));

                comboUF.appendChild(option);
            }
        })
        .catch(function (error) {
            alert("Não foi possível carregar os Estados. Tente novamente mais tarde.");
        })
        .finally(function () {

        })
}

async function ListarCidades() {
    let comboCidade = document.getElementById("comboCidade");
    let e = document.getElementById("comboUF");
    let idUf = e.options[e.selectedIndex].value;

    //Se o usuário não selecionou nenhum estado, limpa o combo de cidade e não faz requisição pro servidor
    if (idUf == 0) {
        comboCidade.innerHTML = "";
        return;
    }

    let url = "/cidade/obterCidades?idUf=" + idUf;

    await fetch(url)
        .then(response => {
            if (response.ok) {
                return response;
            }
            throw Error(response.statusText);
        })
        .then(response => response.json())
        .then(response => {
            comboCidade.innerHTML = "";

            let option = document.createElement('option');
            option.setAttribute('value', 0);
            option.appendChild(document.createTextNode("Selecione"));
            comboCidade.appendChild(option);

            for (let i = 0; i < response.length; i++) {
                let value = response[i].id;
                let text = response[i].nome;
                let newOption = document.createElement('option');

                newOption.setAttribute('value', value);
                newOption.appendChild(document.createTextNode(text));
                comboCidade.appendChild(newOption);
            }
        })
        .catch(function (error) {
            alert("Não foi possível carregar os Estados. Tente novamente mais tarde.");
        })
        .finally(function () {

        })
}

async function ListarUsuarios() {
    let url = "/usuario/get";

    await fetch(url)
        .then(response => {
            if (response.ok) {
                return response;
            }
            throw Error(response.statusText);
        })
        .then(response => response.json())
        .then(response => {
            let users = [];
            $.each(response, function (key, obj) {
                let row = [obj.nome, obj.cpf, obj.idCity];
                users.push(row);
            });
            debugger;
            $('#tbUsers').DataTable({
                order: [[0, "asc"]],
                data: users,
                "lengthMenu": [[5, 10, -1], [5, 10, "Tudo"]],
                columns: [
                    { title: "Nome" },
                    { title: "CPF" },
                    { title: "Cidade" }
                ],
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/1.10.22/i18n/Portuguese-Brasil.json'
                }
            });
        })
        .catch(function (error) {
            alert("Não foi possível carregar os Usuários. Tente novamente mais tarde.");
        })
        .finally(function () {

        })
}

ListarEstados();
ListarUsuarios();