async function Salvar() {
    let user =
    {
        nome: document.getElementById("nome").value,
        sobrenome: document.getElementById("sobrenome").value,
        cpf: document.getElementById("cpf").value
    }
    let url =
        "/usuario/CriarNovoUsuario" +
        "?nome=" + user.nome +
        "&sobrenome=" + user.sobrenome +
        "&cpf=" + user.cpf
   
    await fetch(url, { method: "GET" });
}
/*
 * CREATE   =   POST
 * READ     =   GET
 * UPDATE   =   PUT
 * DELETE   =   DELETE
 * 
 * */