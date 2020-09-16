FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["CustomerServer/CustomerServer.csproj", "CustomerServer/"]
RUN dotnet restore "CustomerServer/CustomerServer.csproj"
COPY . .
WORKDIR "/src/CustomerServer"
RUN dotnet build "CustomerServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerServer.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerServer.dll"]
