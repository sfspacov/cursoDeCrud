function salvar()
{	
	//Booleano -> true ou false
	let resposta = confirm('Deseja salvar?');
	
	if (resposta == true)
	{
		//executado se condição for verdadeira
		alert('Salvo com sucesso');
	}
	else
	{
		//executado se condição NÃO for verdadeira
		alert('Não foi salvo');
	}	
}

function cancelar()
{	debugger;
	console.log('Isso aqui é um texto do console.log');
	const usuarios = ['Maria', 'João', 'Fernanda', 'Beto'];
}
