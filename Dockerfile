# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
ARG TARGETARCH
WORKDIR /app



# copy csproj and restore as distinct layers
COPY *.sln .
COPY aspnetapp/*.csproj .
RUN dotnet clean
RUN dotnet restore


#COPY aspnetapp/. ./aspnetapp/
COPY aspnetapp/. .
#COPY . ./


# copy everything else and build app
#COPY aspnetapp/. ./aspnetapp/
##COPY . .
#WORKDIR /source/aspnetapp
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy
WORKDIR /app
COPY --from=build /app ./
USER $APP_UID
EXPOSE 8080
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
