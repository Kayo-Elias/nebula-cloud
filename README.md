# NebulaCloud

NebulaCloud is a .NET solution containing the initial API and background worker services.

## Projects

- `NebulaCloud.Api`: ASP.NET Core API with OpenAPI support in development.
- `NebulaCloud.Agent`: .NET hosted background worker.

## Requirements

- .NET SDK 10.0 or later

## Run the API

```powershell
dotnet run --project .\NebulaCloud.Api
```

The development OpenAPI document is available from the URL printed by the application.

## Run the worker

```powershell
dotnet run --project .\NebulaCloud.Agent
```

## Build

```powershell
dotnet build .\NebulaCloud.slnx
```

Local secrets should be supplied through .NET user secrets or environment variables and must not be committed.