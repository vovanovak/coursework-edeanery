docker run --rm -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Install_new!' --network host --name sqlserver -p 1433:1433 -d microsoft/mssql-server-linux:2017-latest

sudo ./createDatabaseIfNotExists.sh

cd ../
docker build --rm -t edeanery .
docker run --rm --network host -p 61195:61195 --name coursework_edeanery edeanery