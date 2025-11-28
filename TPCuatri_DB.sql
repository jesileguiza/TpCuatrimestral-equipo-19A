USE master;
GO

-- CREAR BASE DE DATOS
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'TPCuatri_DB')
    CREATE DATABASE [TPCuatri_DB];
GO

USE [TPCuatri_DB];
GO

------------------------------------------------------
-- ELIMINAR TABLAS SI EXISTEN
------------------------------------------------------
IF OBJECT_ID('dbo.VentaDetalle', 'U') IS NOT NULL DROP TABLE dbo.VentaDetalle;
IF OBJECT_ID('dbo.Ventas', 'U') IS NOT NULL DROP TABLE dbo.Ventas;
IF OBJECT_ID('dbo.Compras', 'U') IS NOT NULL DROP TABLE dbo.Compras;
IF OBJECT_ID('dbo.Productos', 'U') IS NOT NULL DROP TABLE dbo.Productos;
IF OBJECT_ID('dbo.Clientes', 'U') IS NOT NULL DROP TABLE dbo.Clientes;
IF OBJECT_ID('dbo.CATEGORIAS', 'U') IS NOT NULL DROP TABLE dbo.CATEGORIAS;
IF OBJECT_ID('dbo.MARCAS', 'U') IS NOT NULL DROP TABLE dbo.MARCAS;
IF OBJECT_ID('dbo.Proveedores', 'U') IS NOT NULL DROP TABLE dbo.Proveedores;
IF OBJECT_ID('dbo.Usuario', 'U') IS NOT NULL DROP TABLE dbo.Usuario;
GO

------------------------------------------------------
-- TABLA CLIENTES
------------------------------------------------------
CREATE TABLE dbo.Clientes (
    ClientesId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    DNI NVARCHAR(50) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    Activo BIT DEFAULT 1
);
GO

INSERT INTO dbo.Clientes (Nombre, Apellido, DNI, Email)
VALUES
('Orlando', 'Gomez', '24500575', ''),
('Keith', 'Bolaño', '30696899', 'keith0@adventure-works.com'),
('Donna', 'Davidson', '35474989', 'donna0@adventure-works.com'),
('Janet', 'Torres', '40578898', 'janet1@adventure-works.com');
GO

------------------------------------------------------
-- TABLA CATEGORIAS
------------------------------------------------------
CREATE TABLE [dbo].[CATEGORIAS](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Descripcion] VARCHAR(50),
    [Activo] bit DEFAULT 1
);
GO

INSERT INTO CATEGORIAS (Descripcion)
VALUES ('Cotillon'),('Papelera'),('Jugueteria'),('Reposteria'),('Libreria');
GO

------------------------------------------------------
-- TABLA MARCAS
------------------------------------------------------
CREATE TABLE [dbo].[MARCAS](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Descripcion] VARCHAR(50),
    [Activo] bit DEFAULT 1
);
GO

INSERT INTO MARCAS (Descripcion)
VALUES ('Cotillón Rex'), ('Cotishop'), ('Fiestísima'), ('Cotillón Los Chicos'), ('Cofetti');
GO

------------------------------------------------------
-- TABLA PROVEEDORES
------------------------------------------------------
CREATE TABLE Proveedores (
    id_Proveedor INT PRIMARY KEY IDENTITY(1,1),
    RazonSocial VARCHAR(100) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Cuit VARCHAR(50) NOT NULL,
    Telefono VARCHAR(50),
    Email VARCHAR(100) NOT NULL,
    Direccion VARCHAR(100) NOT NULL,
    Localidad VARCHAR(100) NOT NULL,
    Activo BIT DEFAULT 1,
    fecha_alta DATE NOT NULL DEFAULT GETDATE()
);
GO

INSERT INTO Proveedores (RazonSocial, Nombre, Cuit, Telefono, Email, Direccion, Localidad)
VALUES
('Distribuidora La Nueva', 'Juan Pérez', '30-12345678-9', '1122334455', 'contacto@lanueva.com', 'Av. Siempre Viva 123', 'Buenos Aires'),
('Ferretería El Tornillo', 'María López', '27-87654321-0', '1133445566', 'ventas@eltornillo.com', 'Calle Belgrano 456', 'Rosario');
GO

------------------------------------------------------
-- TABLA PRODUCTOS
------------------------------------------------------
CREATE TABLE [dbo].[Productos] (
    ProductoId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion VARCHAR(150),
    id_Proveedor INT NOT NULL,
    IdMarca INT NULL,
    IdCategoria INT NULL,
    Stock INT NOT NULL,
    Precio MONEY NOT NULL,
    Activo BIT DEFAULT 1,
    CONSTRAINT FK_Productos_CATEGORIAS FOREIGN KEY(IdCategoria) REFERENCES CATEGORIAS(Id),
    CONSTRAINT FK_Productos_MARCAS FOREIGN KEY(IdMarca) REFERENCES MARCAS(Id),
    CONSTRAINT FK_Productos_Proveedores FOREIGN KEY(id_Proveedor) REFERENCES Proveedores(id_Proveedor)
);
GO

INSERT INTO Productos (Nombre, Descripcion, id_Proveedor, IdMarca, IdCategoria, Stock, Precio)
VALUES
('Globos', 'Bolsa x50 globos 9 Pulgadas', 1, 1, 1, 50, 1000),
('Velas', 'Vela de cumpleaños', 1, 3, 1, 30 , 500),
('Banderin', 'Feliz Cumpleaños Rojo', 2, 3, 1, 20, 200),
('Cortina', 'Color Roja', 2, 4, 2, 10, 1250),
('Lapiceras', 'Colores fluor x12', 1, 2, 2, 100, 350);
GO

------------------------------------------------------
-- TABLA VENTAS
------------------------------------------------------
CREATE TABLE dbo.Ventas (
    VentaId INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT NOT NULL,
    FechaVenta DATE NULL,
    DNI NVARCHAR(50),
    Email NVARCHAR(50),
    Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClientesId)
);
GO

INSERT INTO Ventas (ClienteId, FechaVenta, DNI, Email, Total)
VALUES
(1, '2025-10-25', '24500575', '', 250.00),
(2, '2025-09-15', '30696899', 'keith0@adventure-works.com', 420.00),
(3, '2025-09-16', '35474989', 'donna0@adventure-works.com', 600.00);
GO

------------------------------------------------------
-- TABLA VENTA DETALLE
------------------------------------------------------
CREATE TABLE VentaDetalle (
    IdDetalle INT IDENTITY PRIMARY KEY,
    VentaId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario MONEY NOT NULL,
    Ganancia DECIMAL(5,2) NOT NULL DEFAULT 0,
    Subtotal MONEY NOT NULL,
    FOREIGN KEY (VentaId) REFERENCES Ventas(VentaId),
    FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId)
);
GO

INSERT INTO VentaDetalle (VentaId, ProductoId, Cantidad, PrecioUnitario, Ganancia, Subtotal)
VALUES
(1, 1, 2, 1000, 30, 2600),
(1, 2, 1, 500, 30, 650),
(2, 3, 3, 200, 30, 780);
GO

------------------------------------------------------
-- TABLA COMPRAS
------------------------------------------------------
CREATE TABLE dbo.Compras (
    CompraId INT IDENTITY(1,1) PRIMARY KEY,
    ProveedorId INT NOT NULL,
    Stock INT NOT NULL,
    IdProducto INT NOT NULL,
    Fecha DATE NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ProveedorId) REFERENCES Proveedores(id_Proveedor),
    FOREIGN KEY (IdProducto) REFERENCES Productos(ProductoId)
);
GO

INSERT INTO Compras (ProveedorId, Stock, IdProducto, Fecha, Total)
VALUES
(1,10,3,'2025-10-11',55000),
(2,10,2,'2025-10-12',30000),
(1,10,1,'2025-10-13',40000);
GO

------------------------------------------------------
-- TABLA USUARIO
------------------------------------------------------
CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY,
    Usuario NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Rol NVARCHAR(20) NOT NULL
);
GO

INSERT INTO Usuario (Usuario, Password, Rol)
VALUES ('Julian', 'Once123', 'ADMIN'),
       ('Vendedora', 'MANI897', 'OPERADOR'),
       ('Vendedor', 'Pollo667', 'OPERADOR');
GO
