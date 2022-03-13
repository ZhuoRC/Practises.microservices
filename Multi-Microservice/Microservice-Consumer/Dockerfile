FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . /build
WORKDIR /build/Microservice-Consumer
RUN dotnet restore
RUN dotnet publish -c release -o /app/consumer --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/consumer
COPY --from=build /app/consumer .
ENTRYPOINT ["dotnet", "Microservice-Consumer.dll"]
