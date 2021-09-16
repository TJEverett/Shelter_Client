# Shelter Client

#### _Interface with the Shelter API, 09/16/2021_

#### By _**Tristen Everett**_

## Description

This project was an attempt at showing the skills I learned to program in C# to Create an API using JWT. In this project I built a ASP.NET MVC webapp that allows a user to interact with an API that I also created. This project will let users log into the API and store their authentication tokens as cookies in their browser for 2 hours after creation. Users will be able to view and filter a listing of dogs and cats retrieved from the API, while authenticated users will also be able to modify the API database through this webapp.

### Cookies for storing Json Web Tokens (Further Exploration)

* When Cookies are Made
  1. User logs in through Login portal
  2. Client sends information to API to generate Authentication Token
  3. Client receives Token
  4. Old cookie is removed and a new cookie is created with the Authentication Token stored within that will last for 2 hours
* How Cookie is used
  1. When user tries to Create/Edit/Delete content in the API the website will check if they have an unexpired cookie
  2. If they have no cookie they are sent to the Login page to acquire a new Authentication Token
  3. If they have a cookie the website will retrieve their Authentication Token and send it with request to the API to prove they are a valid user

## Setup/Installation Requirements

1. Clone this Repo
2. Run `dotnet restore` from within /ShelterClient file location
3. Ensure the ShelterAPI is running (follow instruction in that project's [README](https://github.com/TJEverett/Shelter_API "ShelterAPI"))
3. Change the `apiRoute` variable in the /ShelterClient/Model/ApiHelper.cs file to match the path to where your api is hosted, by default the api is hosted on http://localhost:5000/api
4. Run `dotnet build` from within /ShelterClient file location
5. Run `dotnet run` from within /ShelterClient file location
6. Using your preferred web browser navigate to http://localhost:5004
8. Navigate to login with default user
   * username: `admin`
   * password: `cat123dog`

### Current Bugs and Usage Limitations

* Cookies must be accepted on user's computer so login token can be stored

## Technologies Used

* C#
* ASP.NET Core
* Entity Framework Core
* Razor Pages

### License

This software is licensed under the MIT license

Copyright (c) 2021 **_Tristen Everett_**