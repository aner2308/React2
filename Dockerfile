# Fil för att starta mitt API på Render

# Build stadie
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

# Låt appen lyssna på den port som Render sätter
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE 8080

# Startar appen
ENTRYPOINT ["dotnet", "React2.dll"]
