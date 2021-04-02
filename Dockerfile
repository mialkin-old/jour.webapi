FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Jour.WebAPI/Jour.WebAPI.csproj", "src/Jour.WebAPI/"]
RUN dotnet restore "src/Jour.WebAPI/Jour.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Jour.WebAPI"
RUN dotnet build "Jour.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jour.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jour.WebAPI.dll"]