# Odyssey Publishers
This is a sample .NET Core 3.1 implementation of a RESTful Web API interface for a fictional book publishing house named Odyssey publishers.The APIs expose methods for manipulating two primary entities within this context, namely authors and books. Domain Driven Design (DDD) was followed for the architectural design. 

## Libraries Used ##
* AutoMapper
* Dapper
## Installation & Configuration ##
Once you clone the repo, create a new database (locally or as required) and use the CreateTables.sql and SeedData.sql scripts to generate the required database objects and load them with some seed data. 

Add your database connection string to the following files:

* `OdysseyPublishers.API/appsettings.json` 
* `TestUtils/appsettings.json`
