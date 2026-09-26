# EmpresaApi

API REST para la administración de clientes de una empresa, desarrollada como Examen del Primer Parcial de Programación Orientada por Eventos Avanzada – V. Basic (UAA).

## Descripción

La API permite registrar, consultar, modificar y eliminar clientes (CRUD), usando SQL Server para la persistencia de datos. La solución está organizada en capas con el flujo:

Controller → Service → Repository → Entity Framework Core → SQL Server

Las dependencias se integran mediante Inyección de Dependencias (no se crean manualmente en el Controller). El Service contiene la lógica de negocio: validación de campos obligatorios, longitudes máximas, formato de email y control de emails duplicados.

## Tecnologías utilizadas

- Visual Basic .NET (.NET 10)
- ASP.NET Core Web API
- Entity Framework Core (proveedor SQL Server)
- SQL Server Express LocalDB
- Swagger (Swashbuckle) para documentación y pruebas
- Visual Studio 2026

## Estructura del proyecto

- `EmpresaApi/Controllers/` – ClientesController.vb
- `EmpresaApi/Services/` – IClienteService.vb, ClienteService.vb
- `EmpresaApi/Repositories/` – IClienteRepository.vb, ClienteRepository.vb
- `EmpresaApi/Models/` – Cliente.vb
- `EmpresaApi/Data/` – EmpresaDbContext.vb
- `EmpresaApi/Program.vb` – configuración e inyección de dependencias
- `Database/script.sql` – script de creación de la base de datos y la tabla
- `evidencias/` – capturas de las pruebas realizadas

## Endpoints

| Método | Ruta | Descripción | Respuestas |
|---|---|---|---|
| GET | /api/Clientes | Lista todos los clientes | 200 |
| GET | /api/Clientes/{id} | Obtiene un cliente por Id | 200, 400, 404 |
| POST | /api/Clientes | Registra un cliente | 201, 400 |
| PUT | /api/Clientes/{id} | Modifica un cliente | 204, 400, 404 |
| DELETE | /api/Clientes/{id} | Elimina un cliente | 204, 404 |

Ejemplo de cuerpo para POST y PUT:

    {
      "nombre": "Ana",
      "apellido": "Gómez",
      "email": "ana.gomez@mail.com",
      "telefono": "0971000000"
    }

## Instrucciones para ejecutar

1. Requisitos: Visual Studio 2026 con la carga de trabajo "Desarrollo de ASP.NET y web" (incluye SQL Server LocalDB y .NET 10).
2. Clonar el repositorio y abrir

*** Sebastian Melgarejo Gomez ***

