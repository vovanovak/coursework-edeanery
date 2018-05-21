cd ../EDeanery.PL

dotnet ef migrations add InitialMigration -p ../EDeanery.DAL/EDeanery.DAL.csproj

dotnet ef database update InitialMigration -p ../EDeanery.DAL/EDeanery.DAL.csproj
