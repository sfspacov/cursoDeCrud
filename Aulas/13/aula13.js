
async function Salvar()
{
	let user = 
	{
		firstName: document.getElementById("firstName").value,
		lastName: document.getElementById("lastName").value
	}

	if (user.firstName == "" || user.lastName == "")
	{
		alert("Preencha todos os dados");		
	}
	else
	{
		const url = "/Usuario/" + urlParam;
		
		await fetch(url,
            {
                method: "POST",
                body: JSON.stringify(user),
                headers:
                {
                    'Content-Type': 'application/json;charset=utf-8'
                },
            })
            .then(response => {
                if (!response.ok)
                    throw Error(response.statusText);
                return response;
            })
            .then(() => {
                toastrSuccess('Item salvo com sucesso!');
                $('#tbUsers').DataTable().destroy();
                loadUsers();
                cancel();
                cpfEdit = null;
            })
            .catch(function (error) {
                toastrError(error.responseText);
            })
            .finally(function () {
                hideModalLoading();
            });
	}
}
*/