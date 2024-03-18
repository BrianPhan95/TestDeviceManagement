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
COPY ["services/device/NuGet.Config", "services/device/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/host/TDM.AdministrationService.HttpApi.Host/TDM.AdministrationService.HttpApi.Host.csproj", "services/administration/host/TDM.AdministrationService.HttpApi.Host/"]
COPY ["shared/TDM.Shared.Hosting/TDM.Shared.Hosting.csproj", "shared/TDM.Shared.Hosting/"]
COPY ["services/device/src/TDM.DeviceService.Application.Contracts/TDM.DeviceService.Application.Contracts.csproj", "services/device/src/TDM.DeviceService.Application.Contracts/"]
COPY ["services/device/src/TDM.DeviceService.Domain.Shared/TDM.DeviceService.Domain.Shared.csproj", "services/device/src/TDM.DeviceService.Domain.Shared/"]
COPY ["services/identity/src/TDM.IdentityService.Application.Contracts/TDM.IdentityService.Application.Contracts.csproj", "services/identity/src/TDM.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/TDM.IdentityService.Domain.Shared/TDM.IdentityService.Domain.Shared.csproj", "services/identity/src/TDM.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/TDM.IdentityService.EntityFrameworkCore/TDM.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/TDM.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/TDM.IdentityService.Domain/TDM.IdentityService.Domain.csproj", "services/identity/src/TDM.IdentityService.Domain/"]
COPY ["services/saas/src/TDM.SaaSService.Application.Contracts/TDM.SaaSService.Application.Contracts.csproj", "services/saas/src/TDM.SaaSService.Application.Contracts/"]
COPY ["services/saas/src/TDM.SaaSService.Domain.Shared/TDM.SaaSService.Domain.Shared.csproj", "services/saas/src/TDM.SaaSService.Domain.Shared/"]
COPY ["services/administration/src/TDM.AdministrationService.HttpApi/TDM.AdministrationService.HttpApi.csproj", "services/administration/src/TDM.AdministrationService.HttpApi/"]
COPY ["services/administration/src/TDM.AdministrationService.Application.Contracts/TDM.AdministrationService.Application.Contracts.csproj", "services/administration/src/TDM.AdministrationService.Application.Contracts/"]
COPY ["services/administration/src/TDM.AdministrationService.Domain.Shared/TDM.AdministrationService.Domain.Shared.csproj", "services/administration/src/TDM.AdministrationService.Domain.Shared/"]
COPY ["services/administration/src/TDM.AdministrationService.Application/TDM.AdministrationService.Application.csproj", "services/administration/src/TDM.AdministrationService.Application/"]
COPY ["services/administration/src/TDM.AdministrationService.Domain/TDM.AdministrationService.Domain.csproj", "services/administration/src/TDM.AdministrationService.Domain/"]
COPY ["services/administration/src/TDM.AdministrationService.EntityFrameworkCore/TDM.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/TDM.AdministrationService.EntityFrameworkCore/"]
RUN dotnet restore "./services/administration/host/TDM.AdministrationService.HttpApi.Host/TDM.AdministrationService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/administration/host/TDM.AdministrationService.HttpApi.Host"
RUN dotnet build "./TDM.AdministrationService.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TDM.AdministrationService.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TDM.AdministrationService.HttpApi.Host.dll"]