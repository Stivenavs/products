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