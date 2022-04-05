#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development 
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pokedex.Api/Pokedex.Api.csproj", "Pokedex.Api/"]

RUN dotnet restore "Pokedex.Api/Pokedex.Api.csproj"
COPY . .
WORKDIR "/src/Pokedex.Api"
RUN dotnet build "Pokedex.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pokedex.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pokedex.Api.dll"]