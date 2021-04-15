function msg(element){
	//ja ta feito
	//imprimirMenorNumero();
	//imprimirMaiorNumero();
	signicadoDosIguais();
	ordernarArray();
		
	//tem que fazer
	//imprimirNumeroRepetido();
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
	let maximo = Number.MIN_SAFE_INTEGER;
	
	for (let i = 0; i < array.length ; i++)
	{		
		if (array[i] > maximo)
		{
			maximo = array[i];
		}			
	}
	console.log('Maior valor do array: ' + maximo);
}

function imprimirNumeroRepetido(){
	let array = [2,1,3,2];	
}

function signicadoDosIguais(){		
	let x = 2;
	let y = "2";	
	
	if (x == y)
	{
		console.log('Comparação valor. Verdadeira. x = ' + x + ', y = ' + y);
	}
	else
	{
		console.log('Comparação valor. Falsa. x = ' + x + ', y = ' + y);
	}
	
	if (x === y)
	{
		console.log('Comparação tipo e valor. Verdadeira. x = ' + x + ', y = ' + y);
	}
	else
	{
		console.log('Comparação tipo e valor. Falsa. x = ' + x + ', y = ' + y);
	}
}

function ordernarArray(){	
	let Arr = [1, 7, 2, 8, 3, 4, 5, 0, 9];

	for (let i = 1; i < Arr.length; i++)
	{
		for (let j = 0; j < i; j++)
		{
			if (Arr[i] < Arr[j]) 
			{
			  //Muda de posição
			  let x = Arr[i];
			  Arr[i] = Arr[j];
			  Arr[j] = x;
			}			
		}
	}

	console.log(Arr);
}