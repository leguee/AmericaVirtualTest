# AmericaVirtualTest
Api America virtual

Api realizada:  .Net Core 2.2 - Entity Framework <br>
Base de datos: Local BD  "Server=(localdb)\\mssqllocaldb"<br>
Documentacion: Swagger 


Inicialización: 
  1. Clonar repo de gitHub
  2. Crear base de datos local:  
  Desde Visual Studio -> Package Manager Consola (PMC) ejecutar las siguientes lineas:
      ### `add-migration initial`
      ### `update-database`     
  3. Start proyect
  
Se abrira automaticamente la página de pruebas/documentacion Swagger

Nota: Datos de pruebas en archivo InitialData.sql, ejecutar los insert en bd local.
  
