# ContactCentre
- **Time spend:** 5h
- **Two test projects:** Integration Tests in MSTest and Unit Tests in Xunit
- **To build solution run:** dotnet build
- **To execute tests run:** dotnet test

Project is a class library which targets .Net 6.0

To implement functionality of incoming interactions I used chain of responsibility design pattern.

Employees as handlers can handle incoming request and if current employer is already busy then it passes the responsibility of handling interaction to next defined employer.

Before coding I just decided how this library will be used.
Client create the instance of functionality which route interactions/requests. 
Client passes incoming interaction to router. Interaction must be handled by one of employer in defined chain of employees order and can be handled by anyone in that chain.
It looks like chain of responsibility design pattern so I prepared first simple abstractions, first integration test and then processed to implement all requirements.
