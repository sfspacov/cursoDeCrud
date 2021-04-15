function msg(){
	//ja ta feito
	imprimirMenorNumero();
	//tem que fazer
	imprimirMaiorNumero();
	imprimirNumeroRepetido();
	ordernarArray();
}

function imprimirMenorNumero(){
	let array = [4,2,1,3];
	let minimo = Number.MAX_SAFE_INTEGER;
	
	for (let i = 0; i < array.length ; i++)
	{		
		if (array[i] < minimo)
		{
			minimo = array[i];
		}			
	}
	console.log('Menor valor do array: ' + minimo);
}

function imprimirMaiorNumero(){
	let array = [4,2,1,3];
}

function imprimirNumeroRepetido(){
	let array = [1,2,2,3];
}

function ordernarArray(){
	let array = [4,2,1,3];
}