function Salvar()
{
	let nome = document.getElementById("txtNome").value;
	let cpf = document.getElementById("txtCpf").value;	
	let comboUf = document.getElementById("comboUf");
	let nomeDoEstado= comboUf.options[comboUf.selectedIndex].text;
	
	let comboCidade = document.getElementById("comboCidade");
	let nomeDaCidade= comboCidade.options[comboCidade.selectedIndex].text;
	
	let msg = 
		"Nome do usuário: "	+ nome 
		+ "; CPF: " 		+ cpf 
		+ "; Estado: " 		+ nomeDoEstado 
		+ "; Cidade: " 		+ nomeDaCidade
	
	alert(msg);
}

function Cancelar()
{
	alert('Cancelado!');
}