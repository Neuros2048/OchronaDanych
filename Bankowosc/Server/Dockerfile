FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/Bankowosc.Server.csproj", "Server/"]
COPY ["Shared/Bankowosc.Shared.csproj", "Shared/"]
COPY ["Client/Bankowosc.Client.csproj", "Client/"]
RUN dotnet restore "Server/Bankowosc.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Bankowosc.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bankowosc.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bankowosc.Server.dll"]
