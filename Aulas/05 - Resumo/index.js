function Salvar()
{
	let nome = document.getElementById('txtNome').value;
	let cpf = document.getElementById('txtCpf').value;	
	let selUf = document.getElementById("comboUf");
	let nomeDoEstado = selUf.options[selUf.selectedIndex].text;	
	let selCidade = document.getElementById("comboCidade");
	let nomeDaCidade = selCidade.options[selCidade.selectedIndex].text;	
	let msg = nome + " "
			+ cpf + " " 
			+ nomeDoEstado 
			+ " " 
			+ nomeDaCidade
	
	let idade = 10;
	
	let lista = BuscaNoBancoDeDados();
	
	alert(lista);
}

function BuscaNoBancoDeDados()
{	
	let usuarios = ['Alvaro', 'Giovanna', 'Marcus'];
	return usuarios;
}