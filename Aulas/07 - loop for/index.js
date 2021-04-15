function msg(){
	let nome = document.getElementById("fname").value;
	
	if (nome == "")
	{
		//Executa se a condição for verdadeira
		alert('Preencha o nome');
	}
	else
	{
		//Executa se a condição for falsa
		let texto = 'nome preenchido: ' + nome;
		console.log(texto);
	}

	let countryValue = document.getElementById("selCountry").value;	
	let sel = document.getElementById("selCountry");
	let countryText = sel.options[sel.selectedIndex].text;
	
	if (countryValue == 0)
	{
		//Executa se a condição for verdadeira
		alert('Selecione um pais');
	}
	else
	{
		//Executa se a condição for falsa
		let texto = 'Pais selecionado: ' + countryText;
		console.log(texto);
	}
}