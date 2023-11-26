# Vannvokter.Server
## Overview

This project is an ASP.NET Web API built using Clean Architecture and Domain-Driven Design (DDD) principles. It leverages the features of .NET 7 to provide a scalable and maintainable solution for building robust APIs.

## Table of Contents

- [Architecture Overview](#architecture-overview)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)

## Architecture Overview
This project follows the principles of Clean Architecture and Domain-Driven Design. The codebase is organized into layers, each with a specific responsibility:

- Presentation Layer: Contains the API controllers and presentation logic.
- Application Layer: Implements use cases and coordinates the application's behavior.
- Domain Layer: Contains the core business logic and entities.
- Infrastructure Layer: Deals with data access, external services, and other infrastructure concerns.

## Prerequisites
Ensure that the following software is installed on your machine:
- .NET SDK 7

## Installation
Navigate to the project directory and run the following command to restore the dependencies:
``` dotnet restore ```

## Running the Application
The API will be accessible at [http://localhost:25569](http://localhost:25569) by default. Run the following command to start the API:
``` dotnet run --project WebApi/WebApi.csproj --launch-profile httpLocal ```
