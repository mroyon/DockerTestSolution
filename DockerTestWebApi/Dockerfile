#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DockerTestWebApi/DockerTestWebApi.csproj", "DockerTestWebApi/"]
RUN dotnet restore "DockerTestWebApi/DockerTestWebApi.csproj"
COPY . .
WORKDIR "/src/DockerTestWebApi"
RUN dotnet build "DockerTestWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerTestWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerTestWebApi.dll"]
