# Pokedex
Repo intended for educational purposes

The project main purpose is to showcase .Net 6 API best practices: 
![image](https://user-images.githubusercontent.com/1412985/161618557-29399f4f-a629-4980-a6ef-8203cfebab5b.png)

Installation: 
- .net framework 6 (https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

To run in docker:

From the solutions folder run the following commands:
- docker build -f Pokedex.Api\Dockerfile --force-rm -t pokedex .
- docker run -p 11111:80 pokedex

Use http://localhost:11111/swagger/index.html to test the API

Alternatively use dotnet CLI:
From Pokedex.Api folder run the following commands:
- dotnet restore 
- dotnet run

The API should be hosted at: http://localhost:5257
