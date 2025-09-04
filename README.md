A simple project aimed at learning the basics of ASP.NET and API usage.

The application provides meteorological (synoptic) data downloaded from the public API of the Institute of Meteorology and Water Management (IMGW). The project demonstrates topics such as:

-Creating a REST API in ASP.NET Core

-Handling HTTP requests and path and query parameters

-Handling exceptions and custom middleware

-Integration with an external API (IMGW)

-Logging events using NLog

-Serialization and deserialization of JSON data

Application funcionality:
Downloading weather data for all stations or a selected station by name or ID
Error handling (e.g., missing stations, connection errors)
Sample REST endpoints
Configuring logging to file and console

To start application you need:

1.Clone the repository

2.Prepare the .NET 9.0 environment

3.Run the project with the command:

  dotnet run --project API

By default, the API is available at http://localhost:5124

Sample queries
All stations: GET /api/weather/synop

Station by name: GET /api/weather/synop?name=Chojnice

Station by ID: GET /api/weather/synop/{id}
