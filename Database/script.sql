IF DB_ID('EmpresaDB') IS NULL
    CREATE DATABASE EmpresaDB;
GO

USE EmpresaDB;
GO

IF OBJECT_ID('dbo.Clientes', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Clientes (
        Id        INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Clientes PRIMARY KEY,
        Nombre    VARCHAR(100) NOT NULL,
        Apellido  VARCHAR(100) NOT NULL,
        Email     VARCHAR(150) NOT NULL CONSTRAINT UQ_Clientes_Email UNIQUE,
        Telefono  VARCHAR(30)  NULL
    );
END
GO

INSERT INTO dbo.Clientes (Nombre, Apellido, Email, Telefono)
VALUES ('Juan', 'Pérez', 'juan.perez@mail.com', '0981123456');
GO