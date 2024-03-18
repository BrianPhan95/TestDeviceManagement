#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/device/NuGet.Config", "services/device/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/device/host/TDM.DeviceService.HttpApi.Host/TDM.DeviceService.HttpApi.Host.csproj", "services/device/host/TDM.DeviceService.HttpApi.Host/"]
COPY ["shared/TDM.Microservice.Shared/TDM.Microservice.Shared.csproj", "shared/TDM.Microservice.Shared/"]
COPY ["services/administration/src/TDM.AdministrationService.EntityFrameworkCore/TDM.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/TDM.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/TDM.AdministrationService.Domain/TDM.AdministrationService.Domain.csproj", "services/administration/src/TDM.AdministrationService.Domain/"]
COPY ["services/administration/src/TDM.AdministrationService.Domain.Shared/TDM.AdministrationService.Domain.Shared.csproj", "services/administration/src/TDM.AdministrationService.Domain.Shared/"]
COPY ["shared/TDM.Shared.Hosting/TDM.Shared.Hosting.csproj", "shared/TDM.Shared.Hosting/"]
COPY ["services/device/src/TDM.DeviceService.HttpApi/TDM.DeviceService.HttpApi.csproj", "services/device/src/TDM.DeviceService.HttpApi/"]
COPY ["services/device/src/TDM.DeviceService.Application.Contracts/TDM.DeviceService.Application.Contracts.csproj", "services/device/src/TDM.DeviceService.Application.Contracts/"]
COPY ["services/device/src/TDM.DeviceService.Domain.Shared/TDM.DeviceService.Domain.Shared.csproj", "services/device/src/TDM.DeviceService.Domain.Shared/"]
COPY ["services/device/src/TDM.DeviceService.Application/TDM.DeviceService.Application.csproj", "services/device/src/TDM.DeviceService.Application/"]
COPY ["services/device/src/TDM.DeviceService.Domain/TDM.DeviceService.Domain.csproj", "services/device/src/TDM.DeviceService.Domain/"]
COPY ["services/device/src/TDM.DeviceService.EntityFrameworkCore/TDM.DeviceService.EntityFrameworkCore.csproj", "services/device/src/TDM.DeviceService.EntityFrameworkCore/"]
RUN dotnet restore "./services/device/host/TDM.DeviceService.HttpApi.Host/TDM.DeviceService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/device/host/TDM.DeviceService.HttpApi.Host"
RUN dotnet build "./TDM.DeviceService.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TDM.DeviceService.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TDM.DeviceService.HttpApi.Host.dll"]