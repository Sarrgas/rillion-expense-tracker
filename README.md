# Rillion Code Test - Expense Tracker
Welcome to my Expense Tracker for the Rillion home assignment code test.

## Running the application
The simplest way to run the application is to simply clone the repo, open the solution and run the WebApi application.
For simplicity, I have set up a temporary Azure SQL Server Database in the cloud that the application will use by default. This database will be removed on December 1st 2024 or when it has served its purpose.

## Setting up local database
If you want to set up your own local database, use below Docker command or feel free to run SQL Server on your machine.

```
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=MyStrongPassword123!' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
```


Then change the `appsettings.json` file to use your local sql server container. There is a commented-out DefaultConnection under ConnectionStrings prepared for you that you can use.

Then, run the Entity Framework migrations to create the database. Navigate to the root of the folder `ExpenseTracker` and run

```
dotnet ef database update --verbose --project Application --startup-project WebApi
```


Now you should be ready to go! :)

## Authentication
The application comes with simple Authentication. To use the Expense endpoints you must be logged in. To log in, you must first create a user. So let's start there!

**Step 1: Create a user:** To create a user, run the `POST /authentication/create-user` endpoint and enter your desired username and password into the request body.
```json
{
  "username": "kalleanka",
  "password": "julafton2024"
}
```

**Step 2: Log in:** Now that you have a user, run the `POST /authentication/login` endpoint, using the same username and password as before. This will return a JWT token. Copy the token.

**Step 3: Authorization Header:** Using Postman (or similar application), find your Headers and add a header with key `Authorization` and value `bearer [your-token-here]`. Replace *[your-token-here]* with the JWT token you copied in Step 2.

You are now ready to use the Expense-endpoints!

## Using the Expense Endpoints
Now that you are authenticated, let's use the Expense endpoints to create and manage your first expense!

**Step 1: Create an Expense:** Run the `POST /expenses` endpoint with the following body:
```json
{
  "amount": 650,
  "category": 1,
  "description": "Gasoline"
}
```

**Step 2: View all your Expenses:** Run the `GET /expenses` endpoint. This will return all *your* expenses as the logged-in user.

**Step 3: Edit an Expense:** Copy the `id` field of the expense you want to edit (for example `6b4f42d5-eedb-4a29-b249-942b94be579c`), then run `PATCH /expenses/6b4f42d5-eedb-4a29-b249-942b94be579c` with the body of the editable fields. Please note that only Amount and Category can be edited.
```json
{
  "amount": 600,
  "category": 2
}
```

That will update your expense with these new values. Feel free to run `GET /expenses` again to see the update.

The "Category" enum is defined as:
```
0 = Food
1 = Transportation
2 = Utilities
3 = Entertainment
4 = Other
```

## Known Issues
- Logged in user can edit other users expenses
- Passwords are stored in plain text
- No built-in Swagger authentication (use Postman or similar to pass headers)
- No foreign key between Expenses.UserId and Users
- ConnectionStrings stored in repo
- Amount is an integer, should be decimal.
- Inconsistent primary key value (Guid vs int)
