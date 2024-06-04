# Microservices-Contollo

Steps to run the project:
1. Configure in Visual Studio Multiple Startup Projects (Select ApiGateway, ProductService, OrderService, UserService)
2. Run docker-compose up rabbitmq to start rabbitmq container
3. Set the right appsettings.json for each Api service

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "AuthenticationSettings": {
    "JwtKey": "SUPER_SECURE_JWT_KEY",
    "JwtIssuer": "UserService",
    "JwtAudience": "ApiGateway",
    "JwtExpireHours": "1"
  },
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:PORT"
      }
    }
  }


}

```

That's it! :)


# TO-DO:

- [x] Implement MediatR
- [x] Develop an API Gateway (i use Ocelot)
- [x] Develop an Endpoint for Login service
- [x] Develop an Endpoint to get User info
- [x] Develop an Endpoint to create a new User
- [x] Develop an Endpoint to create Orders
- [x] Develop an Endpoint to get Orders by UserId
- [x] Develop an Endpoint to get an Order by ID
- [x] Implement CQRS pattern
- [x] Implement Query Handlers
- [x] Implement Command Handler
- [ ] Implement a database to read items and a database to write items
- [x] Use DDD principles
- [x] Implement RabbitMQ
- [x] Implements Dockers (there is an error between container communication!)
- [ ] Write UnitTests
- [ ] Write Logs


