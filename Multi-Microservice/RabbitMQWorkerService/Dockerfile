FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . /build
WORKDIR /build/RabbitMQWorkerService
RUN dotnet restore
RUN dotnet publish -c release -o /app/worker --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/worker
COPY --from=build /app/worker .
ENTRYPOINT ["dotnet", "RabbitMQWorkerService.dll"]