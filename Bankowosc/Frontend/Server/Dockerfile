FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Frontend/Server/Frontend.Server.csproj", "Frontend/Server/"]
COPY ["Frontend/Client/Frontend.Client.csproj", "Frontend/Client/"]
COPY ["Frontend/Shared/Frontend.Shared.csproj", "Frontend/Shared/"]
COPY ["Shared/Bankowosc.Shared.csproj", "Shared/"]
RUN dotnet restore "Frontend/Server/Frontend.Server.csproj"
COPY . .
WORKDIR "/src/Frontend/Server"
RUN dotnet build "Frontend.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Frontend.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frontend.Server.dll"]
