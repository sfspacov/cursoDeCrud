function salvar()
{
	let nome = document.getElementById("txtNome").value;
	
	let cpf = document.getElementById("txtCpf").value;
	
	if (nome == "")
		alert('Preencha o campo nome');
	
	if (cpf == "")
		alert('Preencha o campo cpf');
}

function cancelar()
{
	const usuarios = listarUsuarios();

	for (let i = 0; i < usuarios.length; i++) {		
		console.log(usuarios[i]);
	}
}

function listarUsuarios()
{
	//Indices de array
	//		   0        1        2         3	    4
	return ['Maria', 'João', 'Fernanda', 'Beto', 'Serafim']
}