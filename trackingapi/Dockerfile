# Image of dotnet to run built project
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# /app is where the builded project will run
WORKDIR /app

# Image of dotnet to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Starting to build image
WORKDIR /src

# Sending the project main file
COPY ["trackingapi.csproj", "./"]

# Running dotnet restore because... IDK
RUN dotnet restore "trackingapi.csproj"

# Copying the source code
COPY . .

# Building the project into the /app workdir
RUN dotnet build "trackingapi.csproj" -c Release -o /app/build

# Renaming build to publish
FROM build AS publish

# Publishing the project
RUN dotnet publish "trackingapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "trackingapi.dll"]
