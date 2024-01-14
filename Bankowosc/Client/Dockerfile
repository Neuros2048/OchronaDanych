FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Client/Bankowosc.Client.csproj", "Client/"]
COPY ["Shared/Bankowosc.Shared.csproj", "Shared/"]
RUN dotnet restore "Client/Bankowosc.Client.csproj"
COPY . .
WORKDIR "/src/Client"
RUN dotnet build "Bankowosc.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bankowosc.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bankowosc.Client.dll"]
