# gRPC - REST Hybrid Demo

REST APIs are semantically geared towards CRUD operations.
If you want to execute a procedure on the server that
isn't CRUD, you can still do it with REST, but it's not
semantically correct.

gRPC is perhaps the most popular implementation of RPC
(Remote Proceedure Call), which allows you to make
calls to methods on the server that do not have this semantic
baggage.  

An example of where you might want to have both is where
you have some modifiable data and you want to be able to
sort the data with logic(e.g. bubble sort, merge sort, etc.)
on the server.  
Data modification should be done via REST, and the
invocation of the sorting should be done via gRPC.

This project is a .NET 7 demo application with
both REST and gRPC functionality in one.  
Setup was done via the dotnet cli,
though the same can also be done in Visual Studio.


# Setup Actions

`dotnet --version`  
\> 7.0.117

```bash
mkdir GRPCRESTHybrid
cd GRPCRESTHybrid

# Create REST API using `webapi` template.
dotnet new webapi

git init
git add .
git commit -m "new webapi template"
```

Create a seperate project with the `grpc` template,
and copy over `Services` and `Protos` folders.  
(You may need to change some namespaces).

We will need to set up the project with two ports so that the
REST API can use HTTP/1 and gRPC can use HTTP/2.

REST calls should be sent via port 5001,
and gRPC calls should be sent via port 5002.  
(The actual port numbers do not matter,
these are just what I have used).

`appsettings.json`
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

# Demo

(Note: I made a small change to the REST route
in `WeatherForecasterController.cs` on line 21).

`dotnet run`

## REST DEMO (Postman VSCode Extension)
![REST Demo](/img/REST_demo.png)

## gRPC Demo
To setup Postman with gRPC,
you will need to provide the `.proto` file.
![gRPC Proto File](/img/gRPC_import_proto.png)

![gRPC Select Proto File](/img/gRPC_selected_proto.png)

![gRPC Demo](/img/gRPC_demo.png)
