#command: docker build -t webmasterdevlin/train-ticket-machine  ./TrainTicketMachine.WebApi

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TrainTicketMachine.WebApi.csproj", "TrainTicketMachine.WebApi"]
RUN dotnet restore "TrainTicketMachine.WebApi"
COPY . .
WORKDIR "/src"
RUN dotnet build "TrainTicketMachine.WebApi.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "TrainTicketMachine.WebApi.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrainTicketMachine.WebApi.dll"]