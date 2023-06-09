FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY MsgWeb/MsgWeb.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish "MsgWeb/MsgWeb.csproj" -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MsgWeb.dll"]