function estudoDeLoops(element){
	//ja ta feito
	//imprimirMenorNumero();
	//imprimirMaiorNumero();
	//signicadoDosIguais();
	//ordernarArray();
	
	//tem que fazer
	imprimirNumeroRepetido();
	pagarSalarios();
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
	let Arr = [81, 7, 2, 81, 8];	
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

	return Arr;
}

function imprimirNumeroRepetido(){	
	
	let array = [2, 7, 8, 81, 81];;
	
	for (let i = 0; i < array.length ; i++)
	{		
		if (array[i] == array[i+1])
		{
			console.log('Numero repetido: ' + array[i]);
		}
	}	
}

function pagarSalarios()
{
	let funcionarios = 
	[ 
		{ 
			nome: "Fabi",
			salario: 5000,
			recebeuPagamento: false
		}
		,{ 
			nome: "João da Silva",
			salario: 9000,
			recebeuPagamento: false
		}
		,{ 
			nome: "Maria dos Santos",
			salario: 1100,
			recebeuPagamento: true
		}
	]

	for (let i = 0; i < funcionarios.length ; i++)
	{
		if(funcionarios[i].recebeuPagamento === false)
		{
			let msg = 
					"Salario de R$ "
					+ funcionarios[i].salario
					+ " pago para "
					+ funcionarios[i].nome;

			console.log(msg);
		}
	}
}