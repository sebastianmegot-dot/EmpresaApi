## Instrucciones para ejecutar

1. Requisitos: Visual Studio 2026 con la carga de trabajo "Desarrollo de ASP.NET y web" (incluye SQL Server LocalDB y .NET 10).
2. Clonar el repositorio y abrir `EmpresaApi.slnx` en Visual Studio.
3. Ejecutar `Database/script.sql` sobre `(localdb)\MSSQLLocalDB` (Ver → Explorador de objetos de SQL Server → clic derecho → Nueva consulta).
4. Verificar la cadena de conexión en `EmpresaApi/appsettings.json` (por defecto usa LocalDB).
5. Presionar F5. Se abrirá Swagger en http://localhost:5080/swagger para probar los endpoints.

## Evidencias

En la carpeta `evidencias/` se incluyen capturas de: listado de clientes, consulta por Id, registro (201), modificación (204), eliminación (204), validaciones (400), cliente inexistente (404) y persistencia de los datos tras reiniciar la aplicación.

## Autor

Sebastián Melgarejo Gómez – Universidad Autónoma de Asunción

