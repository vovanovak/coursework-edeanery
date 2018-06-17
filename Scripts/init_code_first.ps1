cd ../EDeanery.PL
dotnet ef migrations add AddUniqueIndexes -p ../EDeanery.Persistence/EDeanery.Persistence.csproj
dotnet ef database update -p ../EDeanery.Persistence/EDeanery.Persistence.csproj
cd ../Deploy