# domweb

Prueba de concepto: Arquitectura Microservicios para DOMweb

# Bibliografía y referencias

Implementación de Microservicios: https://docs.microsoft.com/es-es/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice

Entity Framework: https://docs.microsoft.com/es-es/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-3.1

# Proyecto paso a paso
1. Ser crean los 3 proyectos principales: Dominio, Infraestructura y API. La idea es hacer la separación tal cual se define en la documentación:

	1.1. El Dominio es el corazón del proyecto, donde se definen las entidades y toda la lógica de negocio. Este proyecto debe ser totalmente agnostico sobre la persistencia de los datos, solamente se definen las interfaces para persistir las entidades(Aggregates). Se han creado 3 AggregatesRoot:
		- Leave: es la entidad principal
		- Resources: AggregateRoot secundario que se referencia desde Leave
		- LeaveTypes: AggregateRoot secundario que se referencia desde Leave. En un primer momento se intentó implementar esta entidad como un ChildEntity pero esto tiene como consecuencia un comportamiento no deseado dado que cada nuevo registro en Leave considera una nueva instancia del tipo. Es decir, cada Leave tendría su propio tipo y esto no es lo deseado.
		Tampoco encaja del todo aquí un Enumerado ya que los valores no es un conjunto cerrado como puede ser una máquina de estados
	
	1.2. En la Infraestructura se definirá la forma de persistir los datos en este caso mediante el ORM Entity Framework
	
	1.3. La API es la encargada de exponer métodos para que sean consumidos desde fuera, y también desde este proyecto se debe gestionar tantos los eventos del propio dominio como eventos de integración con otros microservicios.
		- Se añade Dapper para gestionar queries directas contra la base de datos. De esta forma separamos los comandos de las consultas tal y como se recomienda en CQRS
	
2. Añadir Entity Framework. Siguiendo la guía referenciada en al comienzo se aprender a crear la base de datos y gestionar la primera Migración. En este proyecto el problema está en que del DBContext no está en el proyecto principial (en este caso sería la API)
Esto obligar a realizar varias acciones con respecto a la guía:

	2.1. La guía indica que se ejecuten estas 2 acciones desde línea de comandos:
	
		dotnet tool install --global dotnet-ef
		
		dotnet ef migrations add InitialCreate

	Esto implica lo siguiente:
	
		1. La primera de ellas funciona, es decir se instala la tool dotnet-ef. La propia línea de comandos indica como agregar esta ruta a la variable Path
		2. En el fichero del DBContext en el proyecto de Infraestructura, se añade la clase LeaveContextDesignFactory. Esta clase se necesita para crear la primera Migración con el comando siguiente dado que el proyecto principal (API) no contiene el DbContext
		3. Este segundo comando para crear la primera migración obliga a hacer varias cosas:
			3.1. Instalar el paquete nuget Microsoft.EntityFrameworkCore.Design
			3.2. Por otro lado, y dado que el DBContext no se encuentra en el proyecto principal hay que modificar el comando para indicar en qué proyecto se encuentra el el DBContext. En este ejemplo el comando ejecutado sería el siguiente:
					& "C:\Users\Javier Herrero\.dotnet\tools\dotnet-ef" migrations --project ../Leaves.Infrastructure add InitialCreate
			3.3	 Al ejecutar dicho comando se crea la carpeta Migrations en el proyecto de Infraestructura
		4. La base de datos se crear en la ruta C:\Users\Javier Herrero con el nombre indicado en la clase anteriormente definida
		5. Desde el Explorador de servidores se puede añadir la base de datos, se ha creado la base de datos pero aún sin las tablas

	2.2. De forma posterior ya se pueden agregar más migraciones. Pongo de ejemplo, añadir una unique key al campo ResourceCode de la entidad Recurso para ello:

		1. En la clase ResourceEntityTypeConfiguration se añade esta sentencia: resourceConfiguration.HasIndex(p => new { p.ResourceCode }).IsUnique();
		2. Desde linea de comando se ejecuta esta sentencia: dotnet ef migrations  --project ../Leaves.Infrastructure  add UniqueKey_ResourceCode
		3. De esta forma se crea automaticamente la migración en el proyecto de Infraestructura
	
	
# Siguientes pasos pendientes de implementar:

1. Crear una Child Entity para la entidad Leave (a modo de ejemplo y poder probar)
2. Probar un evento de Dominio, por ejemplo LeaveStartedDomainEvent, al lanzar este evento hay que probar que otra entidad se suscriba. Por ejemplo Resource reciba el evento de que a alguno de los recursos le han asigando un Leave


10. Crear otro Microservicio, por ejemplo uno para gestionar Tareas (Duties)
11. Una vez tengamos el microservicio de Tareas se puede probar la gestión de un evento de integración
15. Crear una API Gateway para devolver información o permitir que a partir de un comando a la API Gateway eso desencadene varios comandos internos en el microservicio. Por ejemplo la acción CrearLeave desde una aplicación cliente a través de la API Gateway 
tendrá como consecuencia el lanzamiento del comando CreateLeave y por otro lado el comando que desasigne las Tareas correspondientes en el microservicio de tareas. Con eventos de integración se debe controlar la integridad entre ambos microservicios

20. Añadir Logger

25. Añadir contenedores Docker