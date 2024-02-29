FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SkorubaDuendeIdentityServer.STS.Identity/SkorubaDuendeIdentityServer.STS.Identity.csproj", "src/SkorubaDuendeIdentityServer.STS.Identity/"]
COPY ["src/SkorubaDuendeIdentityServer.Admin.EntityFramework.Shared/SkorubaDuendeIdentityServer.Admin.EntityFramework.Shared.csproj", "src/SkorubaDuendeIdentityServer.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaDuendeIdentityServer.Shared/SkorubaDuendeIdentityServer.Shared.csproj", "src/SkorubaDuendeIdentityServer.Shared/"]
RUN dotnet restore "src/SkorubaDuendeIdentityServer.STS.Identity/SkorubaDuendeIdentityServer.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/SkorubaDuendeIdentityServer.STS.Identity"
RUN dotnet build "SkorubaDuendeIdentityServer.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaDuendeIdentityServer.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaDuendeIdentityServer.STS.Identity.dll"]