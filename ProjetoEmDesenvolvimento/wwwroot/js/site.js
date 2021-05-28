let usuarios;

async function Salvar() {

    let cpf = document.getElementById("txtCpf").value;

    let isEdit = usuarios.filter(obj => {
        if (obj.cpf == cpf) {
            return obj;
        }
    })[0];

    let e = document.getElementById("comboCidade");
    let idCidade = e.value;
    let user =
    {
        nome: document.getElementById("txtNome").value,
        cpf: cpf,
        idCity: idCidade
    }
    debugger;
    if (user.cpf == "" || user.nome == "" || user.idCity == 0) {
        alert("Preencha todo os campos");
    }
    else {
        let url = "/usuario/CriarNovoUsuario";

        let method = "POST";

        if (isEdit != null) {
            method = "PUT"
            url = "/usuario/Editar"
        }

        //Envia os dados pro servidor
        await fetch(url,
            {
                method: method,
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
                $('#tbUsers').DataTable().destroy();
                ListarUsuarios();
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
                CleanFields();
            })
    }
}

function CleanFields() {
    document.getElementById("txtNome").value = "";
    document.getElementById("txtCpf").value = "";
    comboUF.selectedIndex = 0;
    comboCidade.selectedIndex = 0;
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

async function CarregarCidades(callback) {
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

            debugger;
            if (callback != null)
                callback();
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
            usuarios = response;

            let users = [];

            $.each(response, function (key, obj) {
                let row = [obj.nome, obj.cpf, obj.cidade];
                users.push(row);
            });

            $('#tbUsers').DataTable({
                order: [[0, "asc"]],
                data: users,
                "lengthMenu": [[5, 10, -1], [5, 10, "Tudo"]],
                columns: [
                    { title: "Nome" },   //0
                    { title: "CPF" },    //1
                    { title: "Cidade" }, //2
                    {
                        data: null,
                        orderable: false,
                        render: function (data, type, row) {
                            return '<img onclick="Edit(\'' + data[1] + '\')" style="cursor:pointer" src="../img/edit-icon.png" width="20" /> ' +
                                '<img onclick="Delete(\'' + data[1] + '\')"  style="cursor:pointer" src="../img/delete-icon.png" width="20" />';
                        }
                    },
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

async function DeleteConfirmed(cpf) {

    if (cpf == "" || cpf == null) {
        return;
    }

    let url = "/usuario/Delete?cpf=" + cpf;

    //Envia os dados pro servidor
    await fetch(url, { method: "DELETE" })
        //Analise se a resposta tem erro ou não
        .then(response => {
            if (response.ok) {
                return response;
            }
            throw Error(response.statusText);
        })
        //Se for ok a resposta, cai aqui
        .then(x => {
            $('#tbUsers').DataTable().destroy();
            ListarUsuarios();
            console.log("Deletado com sucesso");
        })
        //Se a resposta for um erro
        .catch(function (error) {
            console.log("Não foi possível deletar, tento novamente");
        })
        //Sempre é executado
        .finally(function () {
        })
}

function Edit(cpf) {

    let user = usuarios.filter(obj => {
        if (obj.cpf == cpf) {
            return obj;
        }
    })[0];

    $("#txtNome").val(user.nome);
    $("#txtCpf").val(user.cpf);
    $("#comboUF").val(user.idUf);

    function selecionarCidade() {
        $("#comboCidade").val(user.idCity);
    }

    CarregarCidades(selecionarCidade);
    console.log("chegou aqui");
}

function Delete(cpf) {
    var response = confirm("Deseja realmente deletar o usuário " + cpf);
    if (response == true) {
        DeleteConfirmed(cpf)
    }
}

ListarEstados();
ListarUsuarios();