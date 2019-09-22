FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["KssDocker.Products/KssDocker.Products.csproj", "KssDocker.Products/"]
COPY ["KssDocker.Models/KssDocker.Models.csproj", "KssDocker.Models/"]
RUN dotnet restore "KssDocker.Products/KssDocker.Products.csproj"
COPY . .
WORKDIR "/src/KssDocker.Products"
RUN dotnet build "KssDocker.Products.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KssDocker.Products.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KssDocker.Products.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app