#!/bin/bash
BLUE='\033[1;34m'
GREEN='\033[0;32m'
NC='\033[0m'
RED='\033[0;31m'
YELLOW='\033[0;33m'

printf "${GREEN}STARTED\n\n"

{
    containersRunning=$(docker ps | grep sql-server-crud | wc -l)
} && {
    if [ "${containersRunning}" -eq 0 ]; then
		printf "${YELLOW} - docker run${NC}\n\n"
		docker run --name sql-server-crud -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -e "MSSQL_PID=Express" -p 1433:1433 -d spakov/banco_aulas:blackWomen
    fi
}  && { 	
	{
		printf "${YELLOW} - dotnet build${NC}\n\n"
		dotnet build ./src/Crud.sln --force --configuration Debug
	} && {
		printf "${YELLOW} - dotnet run${NC}\n\n"
		dotnet ./src/Crud/bin/Debug/net5.0/Crud.dll
	}
} || {
	printf "${RED}\n\nSTOPED!\n\n"
}