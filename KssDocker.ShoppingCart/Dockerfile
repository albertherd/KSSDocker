FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["KssDocker.ShoppingCart/KssDocker.ShoppingCart.csproj", "KssDocker.ShoppingCart/"]
COPY ["KssDocker.Models/KssDocker.Models.csproj", "KssDocker.Models/"]
RUN dotnet restore "KssDocker.ShoppingCart/KssDocker.ShoppingCart.csproj"
COPY . .
WORKDIR "/src/KssDocker.ShoppingCart"
RUN dotnet build "KssDocker.ShoppingCart.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KssDocker.ShoppingCart.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KssDocker.ShoppingCart.dll"]