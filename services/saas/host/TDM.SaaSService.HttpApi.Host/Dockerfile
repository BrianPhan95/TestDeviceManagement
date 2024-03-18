#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/TDM.SaaSService.HttpApi.Host/TDM.SaaSService.HttpApi.Host.csproj", "services/saas/host/TDM.SaaSService.HttpApi.Host/"]
COPY ["shared/TDM.Shared.Hosting/TDM.Shared.Hosting.csproj", "shared/TDM.Shared.Hosting/"]
COPY ["services/administration/src/TDM.AdministrationService.EntityFrameworkCore/TDM.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/TDM.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/TDM.AdministrationService.Domain/TDM.AdministrationService.Domain.csproj", "services/administration/src/TDM.AdministrationService.Domain/"]
COPY ["services/administration/src/TDM.AdministrationService.Domain.Shared/TDM.AdministrationService.Domain.Shared.csproj", "services/administration/src/TDM.AdministrationService.Domain.Shared/"]
COPY ["services/saas/src/TDM.SaaSService.HttpApi/TDM.SaaSService.HttpApi.csproj", "services/saas/src/TDM.SaaSService.HttpApi/"]
COPY ["services/saas/src/TDM.SaaSService.Application.Contracts/TDM.SaaSService.Application.Contracts.csproj", "services/saas/src/TDM.SaaSService.Application.Contracts/"]
COPY ["services/saas/src/TDM.SaaSService.Domain.Shared/TDM.SaaSService.Domain.Shared.csproj", "services/saas/src/TDM.SaaSService.Domain.Shared/"]
COPY ["services/saas/src/TDM.SaaSService.Application/TDM.SaaSService.Application.csproj", "services/saas/src/TDM.SaaSService.Application/"]
COPY ["services/saas/src/TDM.SaaSService.Domain/TDM.SaaSService.Domain.csproj", "services/saas/src/TDM.SaaSService.Domain/"]
COPY ["services/saas/src/TDM.SaaSService.EntityFrameworkCore/TDM.SaaSService.EntityFrameworkCore.csproj", "services/saas/src/TDM.SaaSService.EntityFrameworkCore/"]
RUN dotnet restore "./services/saas/host/TDM.SaaSService.HttpApi.Host/TDM.SaaSService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/TDM.SaaSService.HttpApi.Host"
RUN dotnet build "./TDM.SaaSService.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TDM.SaaSService.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TDM.SaaSService.HttpApi.Host.dll"]