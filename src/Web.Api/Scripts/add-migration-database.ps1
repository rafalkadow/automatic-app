param (
    [string]$name
)

dotnet ef migrations add $name --project ../../Persistence/Persistence.csproj --startup-project ../../Web.Api/Web.Api.csproj