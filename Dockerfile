#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /NetCoreDemoApp
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src/NetCoreDemoApp
COPY ["NetCoreDemoApp.csproj", ""]
RUN dotnet restore "./NetCoreDemoApp.csproj"
COPY . .
WORKDIR "/src/NetCoreDemoApp"
RUN dotnet build "NetCoreDemoApp.csproj" -c Release -o /app/NetCoreDemoApp/build

FROM build AS publish
RUN dotnet publish "NetCoreDemoApp.csproj" -c Release -o /app/NetCoreDemoApp/publish

FROM base AS final
WORKDIR /app/NetCoreDemoApp
COPY --from=publish /app/NetCoreDemoApp/publish .
ENTRYPOINT ["dotnet", "NetCoreDemoApp.dll"]