FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SkorubaDuendeIdentityServer.Admin/SkorubaDuendeIdentityServer.Admin.csproj", "src/SkorubaDuendeIdentityServer.Admin/"]
COPY ["src/SkorubaDuendeIdentityServer.Admin.EntityFramework.Shared/SkorubaDuendeIdentityServer.Admin.EntityFramework.Shared.csproj", "src/SkorubaDuendeIdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaDuendeIdentityServer.Admin.EntityFramework.SqlServer/SkorubaDuendeIdentityServer.Admin.EntityFramework.SqlServer.csproj", "src/SkorubaDuendeIdentityServer.Admin.EntityFramework.SqlServer/"]
COPY ["src/SkorubaDuendeIdentityServer.Shared/SkorubaDuendeIdentityServer.Shared.csproj", "src/SkorubaDuendeIdentityServer.Shared/"]
COPY ["src/SkorubaDuendeIdentityServer.Admin.EntityFramework.PostgreSQL/SkorubaDuendeIdentityServer.Admin.EntityFramework.PostgreSQL.csproj", "src/SkorubaDuendeIdentityServer.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/SkorubaDuendeIdentityServer.Admin.EntityFramework.MySql/SkorubaDuendeIdentityServer.Admin.EntityFramework.MySql.csproj", "src/SkorubaDuendeIdentityServer.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/SkorubaDuendeIdentityServer.Admin/SkorubaDuendeIdentityServer.Admin.csproj"
COPY . .
WORKDIR "/src/src/SkorubaDuendeIdentityServer.Admin"
RUN dotnet build "SkorubaDuendeIdentityServer.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaDuendeIdentityServer.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaDuendeIdentityServer.Admin.dll"]