#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SampleWebApp/SampleWebApp.csproj", "SampleWebApp/"]
COPY ["Nox.Generator/Nox.Generator.csproj", "Nox.Generator/"]
COPY ["Nox.Solution/Nox.Solution.csproj", "Nox.Solution/"]
COPY ["Nox.Types.Abstractions/Nox.Types.Abstractions.csproj", "Nox.Types.Abstractions/"]
COPY ["Nox.Abstractions/Nox.Abstractions.csproj", "Nox.Abstractions/"]
COPY ["Nox.Types/Nox.Types.csproj", "Nox.Types/"]
COPY ["Nox.Lib/Nox.Lib.csproj", "Nox.Lib/"]
COPY ["Nox.EntityFramework.Postgres/Nox.EntityFramework.Postgres.csproj", "Nox.EntityFramework.Postgres/"]
COPY ["Nox.Types.EntityFramework/Nox.Types.EntityFramework.csproj", "Nox.Types.EntityFramework/"]
COPY ["Nox.EntityFramework.Sqlite/Nox.EntityFramework.Sqlite.csproj", "Nox.EntityFramework.Sqlite/"]
COPY ["Nox.EntityFramework.SqlServer/Nox.EntityFramework.SqlServer.csproj", "Nox.EntityFramework.SqlServer/"]
COPY ["Nox.Secrets.Azure/Nox.Secrets.Azure.csproj", "Nox.Secrets.Azure/"]
COPY ["Nox.Secrets/Nox.Secrets.csproj", "Nox.Secrets/"]
COPY ["Nox.Secrets.Hashicorp/Nox.Secrets.Hashicorp.csproj", "Nox.Secrets.Hashicorp/"]
COPY ["Nox.Localization/Nox.Localization.csproj", "Nox.Localization/"]
COPY ["Nox.Logging.Serilog/Nox.Logging.Serilog.csproj", "Nox.Logging.Serilog/"]
COPY ["Nox.Monitoring.ElasticApm/Nox.Monitoring.ElasticApm.csproj", "Nox.Monitoring.ElasticApm/"]
RUN dotnet restore "SampleWebApp/SampleWebApp.csproj"
COPY . .
WORKDIR "/src/SampleWebApp"
RUN dotnet build "SampleWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleWebApp.dll"]