server:
		dotnet run --project Ditto.Server
web:
		dotnet run --project Ditto.Web
build:
		dotnet build
restore:
		dotnet restore
update-db:
		dotnet ef database update -s Ditto.Server/ -p Ditto.Data/