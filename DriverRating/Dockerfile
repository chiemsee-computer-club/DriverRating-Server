FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DriverRating/DriverRating.csproj", "DriverRating/"]
RUN dotnet restore "DriverRating/DriverRating.csproj"
COPY . .
WORKDIR "/src/DriverRating"
RUN dotnet build "DriverRating.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DriverRating.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DriverRating.dll"]
