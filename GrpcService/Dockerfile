# Start the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the csproj and dotnet restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the source code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Start the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the application from the build stage into the runtime stage
COPY --from=build /app/out ./

# Expose the gRPC port
EXPOSE 50051

# Launch the application
ENTRYPOINT ["dotnet", "GrpcService.dll"]