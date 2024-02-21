FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SkorubaAdmin.STS.Identity/SkorubaAdmin.STS.Identity.csproj", "src/SkorubaAdmin.STS.Identity/"]
COPY ["src/SkorubaAdmin.Admin.EntityFramework.Shared/SkorubaAdmin.Admin.EntityFramework.Shared.csproj", "src/SkorubaAdmin.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaAdmin.Shared/SkorubaAdmin.Shared.csproj", "src/SkorubaAdmin.Shared/"]
RUN dotnet restore "src/SkorubaAdmin.STS.Identity/SkorubaAdmin.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/SkorubaAdmin.STS.Identity"
RUN dotnet build "SkorubaAdmin.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaAdmin.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaAdmin.STS.Identity.dll"]