# CaseStudy-SecilStore

## Overview

The Configuration Management System is a dynamic configuration library with SignalR that allows accessing, creating and updating configuration settings without requiring application restarts. The settings are stored in a database and are refreshed periodically.

## Features

- Dynamic configuration retrieval without application restarts
- Periodic refreshing of configuration settings from the database with SignalR
- Secure and efficient configuration management
- User interface for viewing, creating, searching and updating configuration settings

## Requirements

- .NET 8
- SQL Server 

## Project Structure

- **Configuration.Business**: Contains business logic and configuration reading functionality.
- **Configuration.DataAccess**: Manages database interactions using the repository pattern.
- **Configuration.Entities**: Contains entity definitions.
- **Configuration.Web**: ASP.NET Core application for managing configurations via a web interface.

### Clone the Repository

```bash
git clone https://github.com/cantokhay/ConfigurationManagementSystem.git
cd ConfigurationManagementSystem
