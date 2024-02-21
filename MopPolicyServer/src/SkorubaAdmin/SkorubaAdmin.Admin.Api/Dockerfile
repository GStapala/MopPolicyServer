FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SkorubaAdmin.Admin.Api/SkorubaAdmin.Admin.Api.csproj", "src/SkorubaAdmin.Admin.Api/"]
COPY ["src/SkorubaAdmin.Admin.EntityFramework.Shared/SkorubaAdmin.Admin.EntityFramework.Shared.csproj", "src/SkorubaAdmin.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaAdmin.Admin.EntityFramework.SqlServer/SkorubaAdmin.Admin.EntityFramework.SqlServer.csproj", "src/SkorubaAdmin.Admin.EntityFramework.SqlServer/"]
COPY ["src/SkorubaAdmin.Shared/SkorubaAdmin.Shared.csproj", "src/SkorubaAdmin.Shared/"]
COPY ["src/SkorubaAdmin.Admin.EntityFramework.PostgreSQL/SkorubaAdmin.Admin.EntityFramework.PostgreSQL.csproj", "src/SkorubaAdmin.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/SkorubaAdmin.Admin.EntityFramework.MySql/SkorubaAdmin.Admin.EntityFramework.MySql.csproj", "src/SkorubaAdmin.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/SkorubaAdmin.Admin.Api/SkorubaAdmin.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/SkorubaAdmin.Admin.Api"
RUN dotnet build "SkorubaAdmin.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaAdmin.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaAdmin.Admin.Api.dll"]