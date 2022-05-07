FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Analyzer.API/Analyzer.API.csproj", "src/Services/Analyzer.API/"]
RUN dotnet restore "src/Services/Analyzer.API/Analyzer.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Analyzer.API"
RUN dotnet build "Analyzer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Analyzer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Analyzer.API.dll"]





