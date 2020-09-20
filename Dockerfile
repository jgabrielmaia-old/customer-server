FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
LABEL author="J. Gabriel Maia"
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
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*::$PORT" dotnet CustomerServer.dll