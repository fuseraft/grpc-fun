# gRPC fun

This project demonstrates a simple gRPC service (`GrpcService`) and a corresponding gRPC client (`GrpcClient`). The service runs in a Docker container and exposes a `Greeter` endpoint that responds to `SayHello` requests with a greeting message. The client sends requests to the service and displays the response.

### Components
- **GrpcService**: A gRPC server defined by the `greet.proto` file, running in a Docker container. It listens on port `50051` and implements a `Greeter` service with a `SayHello` method that returns a greeting: `Hello, <name>`.
- **GrpcClient**: A console application that connects to the gRPC service and sends a `SayHello` request with a name (e.g., `"World"`) to receive the greeting.

## Prerequisites

- **Docker**: Required to build and run the `GrpcService` container.
  ```bash
  sudo apt update
  sudo apt install docker.io
  ```  
- **.NET 8.0 SDK**: Required to build and run the `GrpcClient`.
  ```bash
  sudo apt install dotnet-sdk-8.0
  ```

## Project Structure

- **GrpcService/**
  - `Dockerfile`: A multi-stage build for the gRPC service.
  - `Program.cs`, `Startup.cs`, `GreeterService.cs`: The gRPC server implementation.
  - `greet.proto`: Protobuf file defining the `Greeter` service and messages.
  - `GrpcService.csproj`: Project file with dependencies.
- **GrpcClient/**
  - `ClientProgram.cs`: The gRPC client.
  - `greet.proto`: Same Protobuf file as the server (copied for client code generation).
  - `GrpcClient.csproj`: Project file with dependencies.

## Building and Running

### 1. Build and Run the gRPC Service

1. **Build and run the Docker image**:
   ```bash
   cd GrpcService
   docker build -t grpc-service .
   docker run -d -p 50051:50051 --name grpc-service grpc-service
   ```

   This exposes the gRPC service on `localhost:50051`.

2. **Verify the service is running**:
   ```bash
   docker ps
   ```
   You should see the `grpc-service` container.

### 2. Build and Run the gRPC Client

1. **Navigate to the `GrpcClient` directory**:
   ```bash
   cd GrpcClient
   ```

2. **Build and run the client**:
   ```bash
   dotnet restore
   dotnet build
   dotnet run
   ```
   Expected output:
   ```
   Greeting: Hello World
   ```