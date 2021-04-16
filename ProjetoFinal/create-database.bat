@ECHO OFF
sqlcmd -S localhost -i .\scripts-sql\script.sql
PAUSE