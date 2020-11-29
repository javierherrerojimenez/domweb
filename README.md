# domweb

Prueba de concepto: Arquitectura Microservicios para la entidad Leave de DOMweb

# Bibliografia y referencias

Implementación de Microservicios: https://docs.microsoft.com/es-es/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice
Entity Framework: https://docs.microsoft.com/es-es/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-3.1

# Proyecto paso a paso
1. Ser crean los 3 proyectos principales: Dominio, Infraestructura y API. La idea es hacer la separación tal cual se define en la documentación.
1.1 El Dominio es el corazón del proyecto, donde se definen las entidades y toda la lógica de negocio. Este proyecto debe ser totalmente agnostico sobre la persistencia de los datos, solamente se definen las interfaces para persistir las entidades(Aggregates)
1.2 En la Infraestructura se definirá la forma de persistir los datos en este caso mediante el ORM Entity Framework
1.3 La API es la encargada de exponer métodos para que sean consumidos desde fuera, y también desde este proyecto se debe gestionar tantos los eventos del propio dominio como eventos de integración con otros microservicios

2. Añadir Entity Framework
Siguiendo la guía referenciada en al comienzo se aprender a crear la base de datos y gestionar la primera Migración. En este proyecto el problema está en que del DBContext no está en el proyecto principial (en este caso sería la API)
Esto obligar a realizar varias acciones con respecto a la guía:

2.1 La guía indica que se ejecuten estas 2 acciones desde línea de comandos:
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate

2.1.1 La primera de ellas funciona, es decir se instala la tool dotnet-ef. La propia línea de comandos indica como agregar esta ruta a la variable Path
2.1.2 Este segundo comando para crear la primera migración obliga a hacer varias cosas:
2.1.2.1 Instalar el paquete nuget Microsoft.EntityFrameworkCore.Design
2.1.2.2 Por otro lado, y dado que el DBContext no se encuentra en el proyecto principal hay que modificar el comando para indicar en qué proyecto se encuentra el el DBContext. En este ejemplo el comando ejecutado sería el siguiente:
& "C:\Users\Javier Herrero\.dotnet\tools\dotnet-ef" migrations --project ../Leaves.Infrastructure add InitialCreate