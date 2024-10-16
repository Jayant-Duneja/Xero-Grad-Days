# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR app
EXPOSE 8080 

ENV ASPNETCORE_URLS=http://0.0.0.0:8080

# Use the SDK image to build and publish the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR src
COPY ["Xero-Grad-Days.csproj", "."]
RUN dotnet restore "Xero-Grad-Days.csproj"
COPY . .

# Build and publish the application to the 'publish' directory within WORKDIR
RUN dotnet publish "Xero-Grad-Days.csproj" -c Release -o publish

# Use the runtime image to run the application
FROM base AS final
WORKDIR app
COPY --from=build src/publish .
ENTRYPOINT ["dotnet", "Xero-Grad-Days.dll"]
