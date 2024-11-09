# rillion-expense-tracker


dotnet ef migrations add InitialCreate --verbose --project Application --startup-project WebApi

dotnet ef database update --verbose --project Application --startup-project WebApi     

docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=MyStrongPassword123!' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge

Header:
Key: Authorization
Value: bearer blabla


## Known Issues
- Logged in user can edit other users expenses
- Passwords are stored in plain text
- No built-in Swagger authentication (use Postman or similar to pass headers)
- No foreign key between Expenses.UserId and Users