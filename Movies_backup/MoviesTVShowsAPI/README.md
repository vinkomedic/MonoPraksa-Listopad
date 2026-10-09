# MoviesTVShows API

ASP.NET Core Web API using PostgreSQL and Entity Framework Core (Database First).

## Database

Create the PostgreSQL database `PraksaDB` and run `SQLdatabase.sql`.

## Connection string

The connection string is stored using .NET User Secrets and is not committed to Git.

From the repository root, set it with:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnectionString" "Host=localhost;Port=5432;Database=PraksaDB;Username=postgres;Password=YOUR_PASSWORD" --project MoviesTVShows
```

## Run

```powershell
dotnet run --project MoviesTVShows
```
