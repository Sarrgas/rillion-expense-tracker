# rillion-expense-tracker


dotnet ef migrations add InitialCreate --verbose --project Application --startup-project WebApi

dotnet ef database update --verbose --project Application --startup-project WebApi     

docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=MyStrongPassword123!' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
