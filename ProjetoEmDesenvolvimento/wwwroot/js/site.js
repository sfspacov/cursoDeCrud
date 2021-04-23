async function Salvar() {
    var e = document.getElementById("comboCidade");
    var idCidade = e.value;

    let user =
    {
        nome: document.getElementById("txtNome").value,
        cpf: document.getElementById("txtCpf").value,
        idCity: idCidade
    }
    let url =
        "/usuario/CriarNovoUsuario" +
        "?nome=" + user.nome +
        "&cpf=" + user.cpf +
        "&idCity=" + user.idCity
   
    await fetch(url, { method: "GET" });
}
/*
 * CREATE   =   POST
 * READ     =   GET
 * UPDATE   =   PUT
 * DELETE   =   DELETE
 * 
 * */