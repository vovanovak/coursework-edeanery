cd EDeanery.Host
dotnet ef database update 20180603144816_AddUniqueIndexes -p ../EDeanery.Persistence/EDeanery.Persistence.csproj
dotnet run