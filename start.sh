#!/bin/bash

##########################################################################
# Set output color variables

BLUE='\033[1;34m'
GREEN='\033[0;32m'
NC='\033[0m'
RED='\033[0;31m'
YELLOW='\033[0;33m'

printf "\n{$GREEN}Starting..."

{
	printf "\n{$GREEN}docker run database"
	docker run spakov/banco_aulas:blackWomen -d
} && {
	printf "\n{$GREEN}dotnet run project"
	dotnet run ./src/Crud.sln --force --configuration Debug
}
