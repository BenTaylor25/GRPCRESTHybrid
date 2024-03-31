
# Actions

`dotnet --version`
\> 7.0.117

```bash
mkdir GRPCRESTHybrid
cd GRPCRESTHybrid

dotnet new webapi

git init
git add .
git commit -m "new webapi template"
```

Copy over `Services` and `Protos` folders from `grpc` template project.

We will need to set up the backend with two ports so that the
REST API can use HTTP/1 and gRPC can use HTTP/2.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Kestrel": {
    "Endpoints": {
      "WebApi": {
        "Url": "http://localhost:5001",
        "Protocols": "Http1"
      },
      "gRPC": {
        "Url": "http://localhost:5002",
        "Protocols": "Http2"
      }
    }
  }
}
```
