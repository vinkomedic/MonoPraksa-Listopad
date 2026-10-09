# Movies API

ASP.NET Core Web API application using PostgreSQL and Entity Framework Core.

## Database

Create the PostgreSQL database and run the provided SQL script.

Database name:

PraksaDB

## Connection string

The connection string is stored using User Secrets.

Set it with:

dotnet user-secrets set "ConnectionStrings:DefaultConnectionString" "Host=localhost;Port=5432;Database=PraksaDB;Username=postgres;Password=YOUR_PASSWORD" --project MoviesTVShows

## Run

dotnet run --project MoviesTVShows