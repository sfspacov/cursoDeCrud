#!/bin/bash
BLUE='\033[1;34m'
GREEN='\033[0;32m'
NC='\033[0m'
RED='\033[0;31m'
YELLOW='\033[0;33m'

printf "${GREEN}STARTED\n\n"

{
	printf "\n${YELLOW} - starting sql server on docker${NC}\n\n"
	docker start sql-server-crud 
} || {
	{
		containersRunning=$(docker ps | grep sql-server-crud | wc -l)
	} && {
		if [ "${containersRunning}" -eq 0 ]; then
			docker run --name sql-server-crud -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -e "MSSQL_PID=Express" -p 1433:1433 -d spakov/banco_aulas:blackWomen
		fi
	}
}  || {
	printf "\n${RED}\n\nERROR! docker failed\n\n"
	exit 1
}
{
	printf "\n${YELLOW} - dotnet run${NC}\n\n"	
	dotnet run --project ./src/Crud/Crud.csproj
} || {
	printf "\n${RED}\n\nERROR!\n\n"
	exit 1
}

