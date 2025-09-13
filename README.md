# Products Management API (Backend)

Este proyecto es un **API REST en .NET 8** siguiendo los principios de **Clean Architecture**.  
Permite la gestión de productos con operaciones CRUD.

---

## 🚀 Tecnologías
- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core (con SQL Server)
- Clean Architecture (separación en capas)
- Swagger (documentación de API)

---

## 📂 Estructura de carpetas
product-management/
│── Application/ # Casos de uso, interfaces
│── Domain/ # Entidades y lógica de negocio
│── Infrastructure/ # Acceso a datos (EF Core, repositorios)
│── WebApi/ # Controladores y configuración ASP.NET Core


---

## 📊 Base de datos
Tabla utilizada: `create_products`

```sql
USE [master]
GO
CREATE DATABASE [Products]
GO

USE [Products]
GO
CREATE TABLE [dbo].[create_products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[CreatedAt] [datetime] DEFAULT getdate() NOT NULL 
) ON [PRIMARY]
GO


INSERT INTO [dbo].[create_products] ([Name], [Description], [Price]) VALUES (N'CELULAR', N'IPHONE 13 PRO MAX', CAST(2500000.00 AS Decimal(10, 2)))
GO
INSERT INTO [dbo].[create_products] ([Name], [Description], [Price]) VALUES (N'CELULAR', N'SAMSUNG S24 PLUS', CAST(3000000.00 AS Decimal(10, 2)))
GO
INSERT INTO [dbo].[create_products] ([Name], [Description], [Price]) VALUES (N'CONMPUTADOR PORTATIL', N'LEVONO IDEAPAD', CAST(3500000.00 AS Decimal(10, 2)))
GO
INSERT INTO [dbo].[create_products] ([Name], [Description], [Price]) VALUES (N'TECLADO', N'TECLADO MECANICO REDRAGON GAMER', CAST(230000.00 AS Decimal(10, 2)))
GO
INSERT INTO [dbo].[create_products] ([Name], [Description], [Price]) VALUES (N'MOUSE', N'MOUSE GAMER', CAST(80000.00 AS Decimal(10, 2)))
GO
INSERT INTO [dbo].[create_products] ([Name], [Description], [Price]) VALUES (N'MONITOR', N'MONITOR JANUS', CAST(600000.00 AS Decimal(10, 2)))
GO


Configurar conexión a SQL Server

En appsettings.json linea 3: 

"ConnectionStrings": {
  "Default": "Server=<YOUR SERVER>;Database=Products;User Id=sa;Password=<YOUR PASSWORD>;TrustServerCertificate=True;"
}

y en program.cs cambiar las lineas 11 y 12 por: 
11 : var cs = builder.Configuration.GetConnectionString("Default")
12 :     ?? "Server=<YOUR SERVER>;Database=Products;User Id=sa;Password=<YOUR PASSWORD>;TrustServerCertificate=True;"


Endpoints principales

GET /api/products?page=1&pageSize=10 → Listar productos con paginación.
GET /api/products/{id} → Obtener producto por ID.
POST /api/products → Crear producto.
PUT /api/products/{id} → Actualizar producto.
DELETE /api/products/{id} → Eliminar producto


swagger

La documentación está disponible en:
en dev https://localhost:5001/swagger

en prod https://products-management.azurewebsites.net/swagger/index.html

