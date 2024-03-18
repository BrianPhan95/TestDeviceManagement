#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["apps/TDM.AuthServer/TDM.AuthServer.csproj", "apps/TDM.AuthServer/"]
COPY ["services/administration/src/TDM.AdministrationService.EntityFrameworkCore/TDM.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/TDM.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/TDM.AdministrationService.Domain/TDM.AdministrationService.Domain.csproj", "services/administration/src/TDM.AdministrationService.Domain/"]
COPY ["services/administration/src/TDM.AdministrationService.Domain.Shared/TDM.AdministrationService.Domain.Shared.csproj", "services/administration/src/TDM.AdministrationService.Domain.Shared/"]
COPY ["services/identity/src/TDM.IdentityService.EntityFrameworkCore/TDM.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/TDM.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/TDM.IdentityService.Domain/TDM.IdentityService.Domain.csproj", "services/identity/src/TDM.IdentityService.Domain/"]
COPY ["services/identity/src/TDM.IdentityService.Domain.Shared/TDM.IdentityService.Domain.Shared.csproj", "services/identity/src/TDM.IdentityService.Domain.Shared/"]
COPY ["services/saas/src/TDM.SaaSService.EntityFrameworkCore/TDM.SaaSService.EntityFrameworkCore.csproj", "services/saas/src/TDM.SaaSService.EntityFrameworkCore/"]
COPY ["services/saas/src/TDM.SaaSService.Domain/TDM.SaaSService.Domain.csproj", "services/saas/src/TDM.SaaSService.Domain/"]
COPY ["services/saas/src/TDM.SaaSService.Domain.Shared/TDM.SaaSService.Domain.Shared.csproj", "services/saas/src/TDM.SaaSService.Domain.Shared/"]
COPY ["shared/TDM.Microservice.Shared/TDM.Microservice.Shared.csproj", "shared/TDM.Microservice.Shared/"]
COPY ["shared/TDM.Shared.Hosting/TDM.Shared.Hosting.csproj", "shared/TDM.Shared.Hosting/"]
RUN dotnet restore "./apps/TDM.AuthServer/TDM.AuthServer.csproj"
COPY . .
WORKDIR "/src/apps/TDM.AuthServer"
RUN dotnet build "./TDM.AuthServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TDM.AuthServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TDM.AuthServer.dll"]