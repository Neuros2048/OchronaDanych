FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Frontend/Client/Frontend.Client.csproj", "Frontend/Client/"]
COPY ["Frontend/Shared/Frontend.Shared.csproj", "Frontend/Shared/"]
RUN dotnet restore "Frontend/Client/Frontend.Client.csproj"
COPY . .
WORKDIR "/src/Frontend/Client"
RUN dotnet build "Frontend.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Frontend.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frontend.Client.dll"]
