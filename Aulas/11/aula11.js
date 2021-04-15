function exercicio(n)
{
	let msg = "";
	for (let i = 1; i <= n; i++)
	{
		msg += i;
	}
	
	for (let i = n - 1; i > 0; i--)
	{
		msg += i;
	}
	
	console.log(msg);
}