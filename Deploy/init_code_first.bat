cd ../EDeanery.PL
dotnet ef migrations add AddUniqueIndexes -p ../EDeanery.DAL/EDeanery.DAL.csproj
dotnet ef database update -p ../EDeanery.DAL/EDeanery.DAL.csproj
cd ../Deploy