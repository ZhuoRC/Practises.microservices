FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./Microservice-Publisher /build/Microservice-Publisher
WORKDIR /build/Microservice-Publisher
RUN dotnet restore
RUN dotnet publish -c release -o /app/publisher --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/publisher
COPY --from=build /app/publisher .
ENTRYPOINT ["dotnet", "Microservice-Publisher.dll"]

