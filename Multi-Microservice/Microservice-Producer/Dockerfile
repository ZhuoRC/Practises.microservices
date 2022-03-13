FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . /build
WORKDIR /build/Microservice-Producer
RUN dotnet restore
RUN dotnet publish -c release -o /app/producer --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/producer
COPY --from=build /app/producer .
ENTRYPOINT ["dotnet", "Microservice-Producer.dll"]

