# autoPartesTpProgra
--Script Base de Datos--
--

GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[tipo_cliente] [int] NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](70) NULL,
	[tel] [bigint] NULL,
	[direccion] [varchar](200) NULL,
	[id_barrio] [int] NULL,
 CONSTRAINT [pk_id_cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VisClientes]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VisClientes]
as
select id_cliente id,nombre+', '+apellido nombreCompleto,tel,direccion,id_barrio from CLIENTES;
GO
/****** Object:  Table [dbo].[VENDEDORES]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENDEDORES](
	[id_vendedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](70) NULL,
	[tel] [bigint] NULL,
	[direccion] [varchar](200) NULL,
	[id_barrio] [int] NULL,
 CONSTRAINT [pk_id_vendedor] PRIMARY KEY CLUSTERED 
(
	[id_vendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VisVendedores]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VisVendedores]
as
select id_vendedor id,nombre+', '+apellido nombreCompleto,tel,direccion,id_barrio from VENDEDORES;
GO
/****** Object:  Table [dbo].[TIPO_PRODUCCIONES]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_PRODUCCIONES](
	[id_tipo_produccion] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](200) NULL,
 CONSTRAINT [pk_id_tipo_produccion] PRIMARY KEY CLUSTERED 
(
	[id_tipo_produccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VisTipoProd]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VisTipoProd]
as
select * from TIPO_PRODUCCIONES
GO
/****** Object:  Table [dbo].[FACTURAS]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURAS](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[id_cliente] [int] NULL,
	[id_vendedor] [int] NULL,
 CONSTRAINT [pk_id_factura] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VisFact]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VisFact]
as
select id_factura,fecha,c.nombre+', '+c.apellido nombreCliente,v.nombre+', '+v.apellido nombreVendedor from FACTURAS f join CLIENTES c  on f.id_cliente=c.id_cliente join VENDEDORES v on v.id_vendedor=f.id_vendedor
GO
/****** Object:  Table [dbo].[AUTO_PARTES]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTO_PARTES](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](300) NULL,
	[fecha_fab] [date] NULL,
	[id_tipo_produccion] [int] NULL,
	[activo] [bit] NULL,
	[precio] [decimal](10, 2) NULL,
	[idMarca] [int] NULL,
	[idModelo] [int] NULL,
 CONSTRAINT [pk_id_articulo] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_FACTURAS]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_FACTURAS](
	[id_detalle_fact] [int] IDENTITY(1,1) NOT NULL,
	[id_factura] [int] NULL,
	[id_articulo] [int] NULL,
	[cantidad] [int] NULL,
	[bonificacion] [bit] NULL,
	[descuento] [int] NULL,
 CONSTRAINT [pk_id_detalle_fact] PRIMARY KEY CLUSTERED 
(
	[id_detalle_fact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VisDetFac]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VisDetFac]
as
select id_detalle_fact idDetalle,id_factura,ap.descripcion,cantidad,bonificacion,descuento from DETALLE_FACTURAS dt join AUTO_PARTES ap on ap.id_articulo=dt.id_articulo
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[marca] [varchar](40) NULL,
 CONSTRAINT [pkMarca] PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[idModelo] [int] IDENTITY(1,1) NOT NULL,
	[modelo] [varchar](40) NULL,
 CONSTRAINT [pkModelo] PRIMARY KEY CLUSTERED 
(
	[idModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vis_AutoPartes]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vis_AutoPartes]
as
select id_articulo Id,descripcion Descripcion,fecha_fab as 'Fecha Fabricacion',tp.tipo as 'Tipo de Produccion',activo Activo,precio Precio, m.marca Marca, mo.modelo Modelo
from AUTO_PARTES ap join TIPO_PRODUCCIONES tp on tp.id_tipo_produccion=ap.id_tipo_produccion
			join Marca m on ap.idMarca=m.idMarca
			join Modelo mo on mo.idModelo=ap.idModelo
			
GO
/****** Object:  Table [dbo].[BARRIOS]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BARRIOS](
	[id_barrio] [int] IDENTITY(1,1) NOT NULL,
	[barrio] [varchar](200) NULL,
	[id_ciudad] [int] NULL,
 CONSTRAINT [pk_id_barrio] PRIMARY KEY CLUSTERED 
(
	[id_barrio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPO_CLIENTES]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_CLIENTES](
	[id_tipo] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NULL,
 CONSTRAINT [pk_id_tipo] PRIMARY KEY CLUSTERED 
(
	[id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VisClie]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VisClie]
as
select id_cliente Id,nombre Nombre,apellido Apellido,tel Telefono,tp.tipo Tipo,direccion Direccion,b.barrio Barrio from CLIENTES c join TIPO_CLIENTES tp on c.tipo_cliente=tp.id_tipo join BARRIOS b on b.id_barrio=c.id_barrio
GO
/****** Object:  View [dbo].[VisVen]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VisVen]
as
select id_vendedor Id,nombre Nombre,apellido Apellido,tel Telefono,direccion Direccion,b.barrio Barrio from VENDEDORES c join  BARRIOS b on b.id_barrio=c.id_barrio
GO
/****** Object:  View [dbo].[VisDet]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VisDet]
as
select id_detalle_fact idDetalle,id_factura idFactura,a.descripcion Descripcion,cantidad,bonificacion,descuento,(a.precio*cantidad)-((a.precio*cantidad)*descuento/100) Importe  from DETALLE_FACTURAS  d join AUTO_PARTES a on d.id_articulo=a.id_articulo 
GO
/****** Object:  Table [dbo].[CIUDADES]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CIUDADES](
	[id_ciudad] [int] IDENTITY(1,1) NOT NULL,
	[ciudad] [varchar](200) NULL,
	[id_provincia] [int] NULL,
 CONSTRAINT [pk_id_ciudad] PRIMARY KEY CLUSTERED 
(
	[id_ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDENES_DE_PEDIDOS]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDENES_DE_PEDIDOS](
	[id_orden_pedido] [int] IDENTITY(1,1) NOT NULL,
	[id_articulo] [int] NULL,
	[fecha] [date] NULL,
	[fecha_entrega] [date] NULL,
	[id_cliente] [int] NULL,
	[id_vendedor] [int] NULL,
 CONSTRAINT [pk_id_orden_pedido] PRIMARY KEY CLUSTERED 
(
	[id_orden_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVINCIAS]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVINCIAS](
	[id_provincia] [int] IDENTITY(1,1) NOT NULL,
	[provincia] [varchar](200) NULL,
 CONSTRAINT [pk_id_provincia] PRIMARY KEY CLUSTERED 
(
	[id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STOCKS]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STOCKS](
	[id_stock] [int] IDENTITY(1,1) NOT NULL,
	[stock_actual] [int] NULL,
	[stock_min] [int] NULL,
	[id_articulo] [int] NULL,
 CONSTRAINT [pk_id_stock] PRIMARY KEY CLUSTERED 
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AUTO_PARTES] ON 
GO
INSERT [dbo].[AUTO_PARTES] ([id_articulo], [descripcion], [fecha_fab], [id_tipo_produccion], [activo], [precio], [idMarca], [idModelo]) VALUES (2, N'Capot', CAST(N'2022-01-01' AS Date), 1, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[AUTO_PARTES] ([id_articulo], [descripcion], [fecha_fab], [id_tipo_produccion], [activo], [precio], [idMarca], [idModelo]) VALUES (3, N'Alfombra', CAST(N'2022-11-14' AS Date), 1, 1, CAST(500.00 AS Decimal(10, 2)), 1, 1)
GO
INSERT [dbo].[AUTO_PARTES] ([id_articulo], [descripcion], [fecha_fab], [id_tipo_produccion], [activo], [precio], [idMarca], [idModelo]) VALUES (4, N'Filtro Aire', CAST(N'2022-11-16' AS Date), 1, 0, CAST(1500.00 AS Decimal(10, 2)), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[AUTO_PARTES] OFF
GO
SET IDENTITY_INSERT [dbo].[BARRIOS] ON 
GO
INSERT [dbo].[BARRIOS] ([id_barrio], [barrio], [id_ciudad]) VALUES (39, N'VCP centro', 21)
GO
INSERT [dbo].[BARRIOS] ([id_barrio], [barrio], [id_ciudad]) VALUES (40, N'Los Manantiales', 21)
GO
INSERT [dbo].[BARRIOS] ([id_barrio], [barrio], [id_ciudad]) VALUES (41, N'Sol y Lago', 21)
GO
INSERT [dbo].[BARRIOS] ([id_barrio], [barrio], [id_ciudad]) VALUES (42, N'San Isidro', 15)
GO
INSERT [dbo].[BARRIOS] ([id_barrio], [barrio], [id_ciudad]) VALUES (43, N'San Alfonso', 15)
GO
INSERT [dbo].[BARRIOS] ([id_barrio], [barrio], [id_ciudad]) VALUES (44, N'Villa Allende Parque', 15)
GO
SET IDENTITY_INSERT [dbo].[BARRIOS] OFF
GO
SET IDENTITY_INSERT [dbo].[CIUDADES] ON 
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (12, N'Cordoba', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (13, N'Rio Ceballos', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (14, N'Saldan', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (15, N'Agua de Oro', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (16, N'Salsipuedes', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (17, N'Villa Allende', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (18, N'Mendiolaza', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (19, N'Arguello', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (20, N'El Pueblito', 1)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (21, N'Pinamar', 2)
GO
INSERT [dbo].[CIUDADES] ([id_ciudad], [ciudad], [id_provincia]) VALUES (22, N'Mar del Plata', 2)
GO
SET IDENTITY_INSERT [dbo].[CIUDADES] OFF
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] ON 
GO
INSERT [dbo].[CLIENTES] ([id_cliente], [tipo_cliente], [nombre], [apellido], [tel], [direccion], [id_barrio]) VALUES (1, 1, N'Pedro', N'Martinez', 3524545, N'Velez Sarfield', 40)
GO
SET IDENTITY_INSERT [dbo].[CLIENTES] OFF
GO
SET IDENTITY_INSERT [dbo].[DETALLE_FACTURAS] ON 
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (1, 1, 3, 3, 0, 0)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (2, 1, 4, 4, 0, 0)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (3, 2, 3, 30, 0, 0)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (4, 2, 4, 40, 0, 0)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (5, 3, 3, 1, 0, 0)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (6, 3, 4, 2, 0, 0)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (11, 7, 3, 1, 0, 0)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (12, 8, 4, 1, 0, 0)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (13, 8, 3, 3, 1, 3)
GO
INSERT [dbo].[DETALLE_FACTURAS] ([id_detalle_fact], [id_factura], [id_articulo], [cantidad], [bonificacion], [descuento]) VALUES (16, 10, 3, 1, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[DETALLE_FACTURAS] OFF
GO
SET IDENTITY_INSERT [dbo].[FACTURAS] ON 
GO
INSERT [dbo].[FACTURAS] ([id_factura], [fecha], [id_cliente], [id_vendedor]) VALUES (1, CAST(N'2020-01-01' AS Date), 1, 1)
GO
INSERT [dbo].[FACTURAS] ([id_factura], [fecha], [id_cliente], [id_vendedor]) VALUES (2, CAST(N'2020-02-02' AS Date), 1, 1)
GO
INSERT [dbo].[FACTURAS] ([id_factura], [fecha], [id_cliente], [id_vendedor]) VALUES (3, CAST(N'2022-11-15' AS Date), 1, 1)
GO
INSERT [dbo].[FACTURAS] ([id_factura], [fecha], [id_cliente], [id_vendedor]) VALUES (5, CAST(N'2022-11-15' AS Date), 1, 1)
GO
INSERT [dbo].[FACTURAS] ([id_factura], [fecha], [id_cliente], [id_vendedor]) VALUES (7, CAST(N'2022-11-15' AS Date), 1, 1)
GO
INSERT [dbo].[FACTURAS] ([id_factura], [fecha], [id_cliente], [id_vendedor]) VALUES (8, CAST(N'2022-11-16' AS Date), 1, 1)
GO
INSERT [dbo].[FACTURAS] ([id_factura], [fecha], [id_cliente], [id_vendedor]) VALUES (10, CAST(N'2022-11-16' AS Date), 1, 1)
GO
SET IDENTITY_INSERT [dbo].[FACTURAS] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 
GO
INSERT [dbo].[Marca] ([idMarca], [marca]) VALUES (1, N'Toyota')
GO
INSERT [dbo].[Marca] ([idMarca], [marca]) VALUES (2, N'BMW')
GO
INSERT [dbo].[Marca] ([idMarca], [marca]) VALUES (14, N'Vw')
GO
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelo] ON 
GO
INSERT [dbo].[Modelo] ([idModelo], [modelo]) VALUES (1, N'Hillux')
GO
INSERT [dbo].[Modelo] ([idModelo], [modelo]) VALUES (2, N'SW4')
GO
SET IDENTITY_INSERT [dbo].[Modelo] OFF
GO
SET IDENTITY_INSERT [dbo].[PROVINCIAS] ON 
GO
INSERT [dbo].[PROVINCIAS] ([id_provincia], [provincia]) VALUES (1, N'Cordoba')
GO
INSERT [dbo].[PROVINCIAS] ([id_provincia], [provincia]) VALUES (2, N'Buenos Aires')
GO
SET IDENTITY_INSERT [dbo].[PROVINCIAS] OFF
GO
SET IDENTITY_INSERT [dbo].[TIPO_CLIENTES] ON 
GO
INSERT [dbo].[TIPO_CLIENTES] ([id_tipo], [tipo]) VALUES (1, N'Consumidor Final')
GO
INSERT [dbo].[TIPO_CLIENTES] ([id_tipo], [tipo]) VALUES (2, N'Empresa')
GO
INSERT [dbo].[TIPO_CLIENTES] ([id_tipo], [tipo]) VALUES (3, N'Responsable Inscripto')
GO
SET IDENTITY_INSERT [dbo].[TIPO_CLIENTES] OFF
GO
SET IDENTITY_INSERT [dbo].[TIPO_PRODUCCIONES] ON 
GO
INSERT [dbo].[TIPO_PRODUCCIONES] ([id_tipo_produccion], [tipo]) VALUES (1, N'A pedido')
GO
INSERT [dbo].[TIPO_PRODUCCIONES] ([id_tipo_produccion], [tipo]) VALUES (2, N'Inmediato')
GO
INSERT [dbo].[TIPO_PRODUCCIONES] ([id_tipo_produccion], [tipo]) VALUES (3, N'En cadena')
GO
SET IDENTITY_INSERT [dbo].[TIPO_PRODUCCIONES] OFF
GO
SET IDENTITY_INSERT [dbo].[VENDEDORES] ON 
GO
INSERT [dbo].[VENDEDORES] ([id_vendedor], [nombre], [apellido], [tel], [direccion], [id_barrio]) VALUES (1, N'Juan', N'Perez', 34534345, N'Av. Leopoldo', 39)
GO
INSERT [dbo].[VENDEDORES] ([id_vendedor], [nombre], [apellido], [tel], [direccion], [id_barrio]) VALUES (6, N'dasd', N'asddasd', 243, N'asdasd', 40)
GO
SET IDENTITY_INSERT [dbo].[VENDEDORES] OFF
GO
ALTER TABLE [dbo].[AUTO_PARTES]  WITH CHECK ADD  CONSTRAINT [fk_id_tipo_produccion] FOREIGN KEY([id_tipo_produccion])
REFERENCES [dbo].[TIPO_PRODUCCIONES] ([id_tipo_produccion])
GO
ALTER TABLE [dbo].[AUTO_PARTES] CHECK CONSTRAINT [fk_id_tipo_produccion]
GO
ALTER TABLE [dbo].[AUTO_PARTES]  WITH CHECK ADD  CONSTRAINT [fkMarca] FOREIGN KEY([idMarca])
REFERENCES [dbo].[Marca] ([idMarca])
GO
ALTER TABLE [dbo].[AUTO_PARTES] CHECK CONSTRAINT [fkMarca]
GO
ALTER TABLE [dbo].[AUTO_PARTES]  WITH CHECK ADD  CONSTRAINT [fkModelo] FOREIGN KEY([idModelo])
REFERENCES [dbo].[Modelo] ([idModelo])
GO
ALTER TABLE [dbo].[AUTO_PARTES] CHECK CONSTRAINT [fkModelo]
GO
ALTER TABLE [dbo].[BARRIOS]  WITH CHECK ADD  CONSTRAINT [fk_id_ciudad] FOREIGN KEY([id_ciudad])
REFERENCES [dbo].[CIUDADES] ([id_ciudad])
GO
ALTER TABLE [dbo].[BARRIOS] CHECK CONSTRAINT [fk_id_ciudad]
GO
ALTER TABLE [dbo].[CIUDADES]  WITH CHECK ADD  CONSTRAINT [fk_id_provincia] FOREIGN KEY([id_provincia])
REFERENCES [dbo].[PROVINCIAS] ([id_provincia])
GO
ALTER TABLE [dbo].[CIUDADES] CHECK CONSTRAINT [fk_id_provincia]
GO
ALTER TABLE [dbo].[CLIENTES]  WITH CHECK ADD  CONSTRAINT [fk_id_barrio] FOREIGN KEY([id_barrio])
REFERENCES [dbo].[BARRIOS] ([id_barrio])
GO
ALTER TABLE [dbo].[CLIENTES] CHECK CONSTRAINT [fk_id_barrio]
GO
ALTER TABLE [dbo].[CLIENTES]  WITH CHECK ADD  CONSTRAINT [fk_tipo_cliente] FOREIGN KEY([tipo_cliente])
REFERENCES [dbo].[TIPO_CLIENTES] ([id_tipo])
GO
ALTER TABLE [dbo].[CLIENTES] CHECK CONSTRAINT [fk_tipo_cliente]
GO
ALTER TABLE [dbo].[DETALLE_FACTURAS]  WITH CHECK ADD  CONSTRAINT [fk_id_articulo2] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[AUTO_PARTES] ([id_articulo])
GO
ALTER TABLE [dbo].[DETALLE_FACTURAS] CHECK CONSTRAINT [fk_id_articulo2]
GO
ALTER TABLE [dbo].[DETALLE_FACTURAS]  WITH CHECK ADD  CONSTRAINT [fk_id_factura] FOREIGN KEY([id_factura])
REFERENCES [dbo].[FACTURAS] ([id_factura])
GO
ALTER TABLE [dbo].[DETALLE_FACTURAS] CHECK CONSTRAINT [fk_id_factura]
GO
ALTER TABLE [dbo].[FACTURAS]  WITH CHECK ADD  CONSTRAINT [fk_id_cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[CLIENTES] ([id_cliente])
GO
ALTER TABLE [dbo].[FACTURAS] CHECK CONSTRAINT [fk_id_cliente]
GO
ALTER TABLE [dbo].[FACTURAS]  WITH CHECK ADD  CONSTRAINT [fk_id_vendedor] FOREIGN KEY([id_vendedor])
REFERENCES [dbo].[VENDEDORES] ([id_vendedor])
GO
ALTER TABLE [dbo].[FACTURAS] CHECK CONSTRAINT [fk_id_vendedor]
GO
ALTER TABLE [dbo].[ORDENES_DE_PEDIDOS]  WITH CHECK ADD  CONSTRAINT [fk_id_articulo3] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[AUTO_PARTES] ([id_articulo])
GO
ALTER TABLE [dbo].[ORDENES_DE_PEDIDOS] CHECK CONSTRAINT [fk_id_articulo3]
GO
ALTER TABLE [dbo].[ORDENES_DE_PEDIDOS]  WITH CHECK ADD  CONSTRAINT [fk_id_cliente3] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[CLIENTES] ([id_cliente])
GO
ALTER TABLE [dbo].[ORDENES_DE_PEDIDOS] CHECK CONSTRAINT [fk_id_cliente3]
GO
ALTER TABLE [dbo].[ORDENES_DE_PEDIDOS]  WITH CHECK ADD  CONSTRAINT [fk_id_vendedor3] FOREIGN KEY([id_vendedor])
REFERENCES [dbo].[VENDEDORES] ([id_vendedor])
GO
ALTER TABLE [dbo].[ORDENES_DE_PEDIDOS] CHECK CONSTRAINT [fk_id_vendedor3]
GO
ALTER TABLE [dbo].[STOCKS]  WITH CHECK ADD  CONSTRAINT [fk_id_articulo] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[AUTO_PARTES] ([id_articulo])
GO
ALTER TABLE [dbo].[STOCKS] CHECK CONSTRAINT [fk_id_articulo]
GO
ALTER TABLE [dbo].[VENDEDORES]  WITH CHECK ADD  CONSTRAINT [fk_id_barrio2] FOREIGN KEY([id_barrio])
REFERENCES [dbo].[BARRIOS] ([id_barrio])
GO
ALTER TABLE [dbo].[VENDEDORES] CHECK CONSTRAINT [fk_id_barrio2]
GO
/****** Object:  StoredProcedure [dbo].[idFactDelet]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[idFactDelet]
@id int
as
select id_factura from FACTURAS where id_cliente=@id
GO
/****** Object:  StoredProcedure [dbo].[insertAutoParte]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertAutoParte]
@desc varchar(50) ,
@fechFab date ,
@idTipoProd int ,
@activo int
as
if @desc is null or @fechFab is null or @idTipoProd is null
	raiserror('No se permiten valores nulos',16,1)
else
begin
insert into AUTO_PARTES values(@desc,@fechFab,@idTipoProd,@activo)
end
GO
/****** Object:  StoredProcedure [dbo].[listarApNom]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[listarApNom]
@nombre varchar(30),
@activo bit
as
if(@nombre is null)
begin
	if(@activo is null)
		begin
			select * from vis_AutoPartes
		end
	if(@activo =0)
		begin
			select * from vis_AutoPartes where Activo=0
		end
	if(@activo =1)
		begin
			select * from vis_AutoPartes where Activo=1
		end
end
else
begin
	if(@activo is null)
		begin
			select * from vis_AutoPartes where Descripcion like '%'+@nombre+'%'
		end
	if(@activo =0)
		begin
			select * from vis_AutoPartes where Activo=0 and Descripcion like '%'+@nombre+'%'
		end
	if(@activo =1)
		begin
			select * from vis_AutoPartes where Activo=1 and Descripcion like '%'+@nombre+'%'
		end
end
GO
/****** Object:  StoredProcedure [dbo].[listarAutoparteNombre]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[listarAutoparteNombre]
@nombre varchar(30),
@activo bit
as
if(@activo is null)
	begin
	select * from vis_AutoPartes where Descripcion like @nombre+'%'
	end
else
	begin
		if(@activo =0)
			begin 
			select * from vis_AutoPartes where Activo=0 and Descripcion like @nombre+'%'
			end
		else
			begin
			select * from vis_AutoPartes where Activo=1 and Descripcion like @nombre+'%'
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_auto_partes]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_auto_partes]
@descripcion varchar(100),
@fecha_fab datetime,
@id_tipo_produccion int,
@activo bit,
@precio decimal(10,2),
@idMarca int,
@idModelo int
as
if(@descripcion is null or @fecha_fab is null or @precio is null or 
   @idMarca is null or @idModelo is null)
begin
raiserror('Faltan ingresar datos',16,2)
rollback transaction
end
else
begin
insert into AUTO_PARTES (descripcion, fecha_fab, id_tipo_produccion, activo,
                         precio, idMarca, idModelo)
values(@descripcion, @fecha_fab, @id_tipo_produccion, @activo, @precio,
                     @idMarca, @idModelo)
end

GO
/****** Object:  StoredProcedure [dbo].[SpDeleteAp]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpDeleteAp]
@id int
as
delete from AUTO_PARTES where id_articulo=@id
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteCli]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SpDeleteCli]
@id int,
@idFact int
as
delete from DETALLE_FACTURAS WHERE id_factura=@idFact
delete from FACTURAS WHERE id_cliente=@id
delete from CLIENTES WHERE id_cliente=@id
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteCliente]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpDeleteCliente]
@id int
as
delete from CLIENTES where id_cliente=@id
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteDetalle]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpDeleteDetalle]
@idFact int
as
delete from DETALLE_FACTURAS where @idFact=id_factura
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteFactura]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpDeleteFactura]
@id int
as
delete from FACTURAS where @id=id_cliente
GO
/****** Object:  StoredProcedure [dbo].[SpDeleteVen]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SpDeleteVen]
@id int
as
delete from VENDEDORES where id_vendedor=@id
GO
/****** Object:  StoredProcedure [dbo].[spFacturasEntre]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spFacturasEntre]  
@desde datetime,  
@hasta datetime  
as  
select * from visFact where fecha between @desde and @hasta
GO
/****** Object:  StoredProcedure [dbo].[SpInsertClie]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpInsertClie]
@nobmre varchar(30),
@apellido varchar(30),
@tel bigint,
@direc varchar(30),
@idBarrio int,
@tipoClie int
as
insert into CLIENTES values(@tipoClie,@nobmre,@apellido,@tel,@direc,@idBarrio)
GO
/****** Object:  StoredProcedure [dbo].[SpInsertDetalle]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpInsertDetalle]
@idFactura int,
@idArticulo int,
@cantidad int,
@bonificacion int,
@descuento int
as
insert into DETALLE_FACTURAS values (@idFactura,@idArticulo,@cantidad,@bonificacion,@descuento)
GO
/****** Object:  StoredProcedure [dbo].[SpInsertFact]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpInsertFact]
@idFactura int output,
@fecha date,
@idCliente int,
@idVendedor int
as
insert into FACTURAS values (@fecha,@idCliente,@idVendedor)
set @idFactura = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[spInsertMarcas]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsertMarcas]
 @nombre varchar(40)
 as
 insert into Marca values(@nombre)
GO
/****** Object:  StoredProcedure [dbo].[SpInsertModelos]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpInsertModelos]
@nombre varchar(30)
as
insert into Modelo values(@nombre)
GO
/****** Object:  StoredProcedure [dbo].[SpInsertVend]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpInsertVend]
@nobmre varchar(30),
@apellido varchar(30),
@tel bigint,
@direc varchar(30),
@idBarrio int
as
insert into VENDEDORES values(@nobmre,@apellido,@tel,@direc,@idBarrio)
GO
/****** Object:  StoredProcedure [dbo].[spMarcas]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spMarcas]
as
begin
select * from Marca
end
GO
/****** Object:  StoredProcedure [dbo].[spModelo]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spModelo]
as
begin
select * from Modelo
end
GO
/****** Object:  StoredProcedure [dbo].[spProxId]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spProxId]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(id_factura)+1  FROM facturas);
END
GO
/****** Object:  StoredProcedure [dbo].[SpUpAutoPartes]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpUpAutoPartes]
@id int,
@fecha date,
@idProd int,
@activo bit,
@precio decimal(10,2),
@idMarca int,
@idModelo int
as
update AUTO_PARTES set fecha_fab=@fecha, id_tipo_produccion=@idProd, activo=@activo,precio=@precio,idMarca=@idMarca,idModelo=@idModelo where id_articulo=@id
GO
/****** Object:  StoredProcedure [dbo].[SpUpClie]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpUpClie]
@id int,
@tipo int,
@tel bigint,
@direc varchar(30),
@barrio int
as
update CLIENTES set tipo_cliente=@tipo , tel=@tel,direccion=@direc,id_barrio=@barrio where id_cliente=@id
GO
/****** Object:  StoredProcedure [dbo].[SpUpVen]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SpUpVen]
@id int,
@tel bigint,
@direc varchar(30),
@barrio int
as
update VENDEDORES set tel=@tel,direccion=@direc,id_barrio=@barrio where id_vendedor=@id
GO
/****** Object:  StoredProcedure [dbo].[spVerClientes]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spVerClientes]
as
select * from CLIENTES
GO
/****** Object:  StoredProcedure [dbo].[spVerTipoCliente]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spVerTipoCliente]
as
select * from TIPO_CLIENTES
GO
/****** Object:  StoredProcedure [dbo].[spVerVendedores]    Script Date: 16/11/2022 1:14:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spVerVendedores]
as
select * from VENDEDORES
GO
select * from AUTO_PARTES
