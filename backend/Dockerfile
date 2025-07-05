# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY backend/*.csproj ./backend/
RUN dotnet restore ./backend

# Copy everything else and build
COPY . ./
WORKDIR /app/backend
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/backend/out ./

# Expose the port the app runs on
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "backend.dll"]
