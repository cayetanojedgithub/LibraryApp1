NOTES:
- This is built using .NET 8
- I prepared a web API for the backend, I used ASP.NET Core Web API
- I also created a partial implementation of the UI using Blazor WASM(Web Assembly), to showcase how my API integrates with client UI. I understand the request was to use Angular UI but I haven't used Angular in a while and I worried that it could consume more time. Given it was a bonus, I used my best judgment to showcase something that I am more familiar with that I can easily implement.
- The Web API is implemented as inspired by clean architecture.
- To showcase test-driven development, I have added unit tests on the service and repository levels. With dependency injection this makes the code testable and easy to maintain.
- The IDE(Integrated Development Environment) I used for this is Visual Studio 2022.
