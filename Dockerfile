# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Xero-Grad-Days.csproj", "./"]
RUN dotnet restore "./Xero-Grad-Days.csproj"
COPY . .
RUN dotnet build "Xero-Grad-Days.csproj" -c Release -o /src/build

FROM build AS publish
WORKDIR /src
RUN dotnet publish "Xero-Grad-Days.csproj" -c Release -o /src/publish

# Use the runtime image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /src/publish .
ENTRYPOINT ["dotnet", "Xero-Grad-Days.dll"]