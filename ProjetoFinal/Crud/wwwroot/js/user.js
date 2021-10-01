let users = [];
let cpfEdit = null;
let cpfDelete = null;

function cancel() {
    $("#txtNome").val("");
    $("#txtCpf").val("");
    $("#comboUF").val('0');
    $("#comboCidade").empty();
    cpfEdit = null;
    cpfDelete = null;
}

function cancelDelete() {
    cpfDelete = null;
}

async function confirmDelete() {
    const url = "/Usuario/Delete?cpf=" + cpfDelete;

    showModalLoading();

    await fetch(url,
        {
            method: "DELETE",
        })
        .then(response => {
            if (!response.ok)
                throw Error(response.statusText);
            return response;
        })
        .then(response => {
            toastrSuccess('Item deletado com sucesso!!');
            $('#tbUsers').DataTable().destroy();
            loadUsers();
        })
        .catch(function () {
            toastrSuccess('Não foi possível deletar este item. Tente novamente!');
            hideModalLoading();
        })
        .finally(function () {
            hideModalLoading();
            cancel();
        });
}

function deleteUser(cpf) {
    cpfDelete = cpf;
    $('#modalConfirm').modal({
        keyboard: false,
        show: true
    });
}

function edit(cpf) {
    cpfEdit = cpf;
    let user = users.filter(obj => {
        if (obj[1] == [cpf]) {
            return obj;
        }
    })[0];
    $("#txtNome").val(user[0]);
    $("#txtCpf").val(user[1]);
    $("#comboUF").val(user[4]);
    loadCities(user[4], () => $("#comboCidade").val(user[3]));

    window.scrollTo(
        {
            top: 0,
            behavior: 'smooth'
        })
}

async function loadUsers() {
    const createTable = function (data) {
        users = [];
        $.each(data, function (key, obj) {
            let row = [obj.name, obj.cpf, obj.city, obj.idCity, obj.idUf];
            users.push(row);
        });

        $('#tbUsers').DataTable({
            order: [[0, "asc"]],
            data: users,
            "lengthMenu": [[5, 10, -1], [5, 10, "Tudo"]],
            columns: [
                { title: "Nome" },
                { title: "CPF" },
                { title: "Cidade" },
                {
                    data: null,
                    orderable: false,
                    render: function (data, type, row) {
                        return '<img onclick="edit(\'' + data[1] + '\')" style="cursor:pointer" src="../img/edit-icon.png" width="20" /> ' +
                            '<img style="cursor:pointer" onclick="deleteUser(\'' + data[1] + '\')" src="../img/delete-icon.png" width="20" />';
                    }
                },
            ],
            language: {
                url: 'https://cdn.datatables.net/plug-ins/1.10.22/i18n/Portuguese-Brasil.json'
            }
        });
    }
    showModalLoading();
    const url = "/Usuario/GetAll/"
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
        .then(users => createTable(users))
        .catch(function (error) {
            toastrError("Não foi possível carregar os usuários já cadastrados");
        })
        .finally(function () {
            hideModalLoading();
        });
}

async function save() {

    let user =
    {
        name: $("#txtNome").val(),
        idUf: $("#comboUF").val(),
        idCity: $("#comboCidade").val()
    }

    if (user.name == "" || user.cpf == "" || user.idCity == undefined) {
        toastrError('Preencha todos os campos');
    }
    else {
        let existsUser = null;

        if (validateCpf($("#txtCpf").val()) === false) {
            toastrError('Cpf inválido');
            return;
        }

        if (cpfEdit !== null) {
            user.newCpf = $("#txtCpf").val();
            user.cpf = cpfEdit;
        }
        else {
            user.newCpf = null;
            user.cpf = $("#txtCpf").val();
            existsUser = users.filter(function (obj) {
                if (obj[1] == [user.cpf]) {
                    return obj;
                }
            });
            if (existsUser.length > 0) {
                toastrError('Já existe usuário com este cpf');
                return;
            }
        }

        const method = cpfEdit == null ? "POST" : "PUT";

        const urlParam = cpfEdit == null ? "Save" : "Update";

        const url = "/Usuario/" + urlParam;

        showModalLoading();

        await fetch(url,
            {
                method: method,
                body: JSON.stringify(user),
                headers:
                {
                    'Content-Type': 'application/json;charset=utf-8'
                },
            })
            .then(response => {
                if (!response.ok)
                    throw Error(response.statusText);
                return response;
            })
            .then(() => {
                toastrSuccess('Item salvo com sucesso!');
                $('#tbUsers').DataTable().destroy();
                loadUsers();
                cancel();
                cpfEdit = null;
            })
            .catch(function (error) {
                toastrError(error.responseText);
            })
            .finally(function () {
                hideModalLoading();
            });
    }
}

function validateCpf(strCPF) {
    strCPF = strCPF.replace(/\./g, "").replace("-", "")
    let Resto;
    let Soma = 0;
    if (strCPF == "00000000000") return false;

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) return false;
    return true;
}