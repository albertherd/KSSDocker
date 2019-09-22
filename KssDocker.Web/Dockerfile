FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["KssDocker.Web/KssDocker.Web.csproj", "KssDocker.Web/"]
COPY ["KssDocker.Models/KssDocker.Models.csproj", "KssDocker.Models/"]
RUN dotnet restore "KssDocker.Web/KssDocker.Web.csproj"
COPY . .
WORKDIR "/src/KssDocker.Web"
RUN dotnet build "KssDocker.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KssDocker.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KssDocker.Web.dll"]