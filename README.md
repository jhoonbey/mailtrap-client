# MailTrap Client Application

Welcome to the Email Client Application repository! This project provides a simple HTTP client application for sending emails using the MailTrap service.

## Tech used

- [C#] - The primary programming language used for development!
- [.NET Core] - The cross-platform, open-source development framework for building various types of applications
- [ASP.NET Core] - A high-performance, open-source framework for building modern, cloud-based, internet-connected applications.
- [Swagger] - Used for API documentation, providing an interactive UI to explore and interact with the API endpoints
- [Automapper] - A convention-based object-to-object mapper that helps to eliminate tedious and repetitive mapping code between objects of different types
- [Refit] - A library for automatically generating HTTP API clients from interfaces, simplifying the consumption of RESTful APIs

## Installation

Clone the Repository:

```sh
git clone https://github.com/jhoonbey/email-client.git
```
Navigate to the Project Directory and Restore NuGet Packages:

```sh
dotnet restore
```
To configure MailTrap Service URL:
Open the appsettings.json file. Set the value of `${SendUrl}` section to your MailTrap API endpoint.

Build the Solution:
```sh
dotnet build
```


## Docker

Go to DockerFile location and run:

```sh
docker build -t mailsender .
```
Create a container

```sh
docker run --rm -d --name mailsender -p 8080:8080 mailsender
```

Run http://localhost:8080/swagger/index.html on local machine

## Usage

- Ensure the application is running
- Make a POST request to the /api/Mail endpoint
- Include the token in the header and following parameters to Form:
  + Sender name *
  + Sender email *
  + Recipient name *
  + Recipient email *
  + Subject *
  + Text (required if HTML is empty)
  + HTML (required if Text is empty)
  + Optional attachments

## API Documentation

- Navigate to http://localhost:8080/swagger/index.html in your web browser
- Import **MailTrapApi.postman_collection** Postman collection and use it.