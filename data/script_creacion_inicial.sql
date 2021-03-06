USE [GD1C2015]
GO
/****** Object:  Schema [ESCUADRON_SUICIDA]    Script Date: 06/20/2015 23:09:56 ******/
CREATE SCHEMA [ESCUADRON_SUICIDA] AUTHORIZATION [gd]
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Usuario]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Usuario](
	[Usuario] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Fecha_Modificacion] [datetime] NOT NULL,
	[Pregunta_Secreta] [varchar](255) NULL,
	[Respuesta_Secreta] [varchar](255) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[TipoMoneda]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[TipoMoneda](
	[Tipo_Moneda] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoMoneda] PRIMARY KEY CLUSTERED 
(
	[Tipo_Moneda] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[TipoCuenta]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[TipoCuenta](
	[Tipo_Cuenta] [varchar](50) NOT NULL,
	[Costo] [numeric](18, 2) NOT NULL,
	[Costo_Apertura] [numeric](18, 2) NOT NULL,
	[Dias_Suscripcion] [int] NOT NULL,
	[Tipo_Moneda] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoCuenta] PRIMARY KEY CLUSTERED 
(
	[Tipo_Cuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Banco]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Banco](
	[Id_Banco] [numeric](18, 0) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[Id_Banco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Roles]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Roles](
	[Id_Rol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Pais]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Pais](
	[Cod_Pais] [numeric](18, 0) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[Cod_Pais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Estado]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Estado](
	[Estado] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Estado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[EmisorTarjeta]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[EmisorTarjeta](
	[Emisor] [varchar](255) NOT NULL,
 CONSTRAINT [PK_EmisorTarjeta] PRIMARY KEY CLUSTERED 
(
	[Emisor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Documento]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Documento](
	[Tipo_Doc] [varchar](255) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Documento_1] PRIMARY KEY CLUSTERED 
(
	[Tipo_Doc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Funcionalidades]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Funcionalidades](
	[Id_Funcionalidad] [smallint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[Id_Funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Cliente]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Cliente](
	[Cod_Cli] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Apellido] [varchar](255) NOT NULL,
	[Tipo_Doc] [varchar](255) NOT NULL,
	[Nro_Doc] [numeric](18, 0) NOT NULL,
	[Mail] [varchar](255) NOT NULL,
	[Calle] [varchar](255) NOT NULL,
	[Nro_Calle] [numeric](18, 0) NOT NULL,
	[Piso] [numeric](18, 0) NOT NULL,
	[Depto] [varchar](10) NOT NULL,
	[Localidad] [varchar](60) NOT NULL,
	[Nacionalidad] [varchar](60) NOT NULL,
	[Fecha_Nac] [datetime] NOT NULL,
	[Cod_Pais] [numeric](18, 0) NOT NULL,
	[Usuario] [varchar](255) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cod_Cli] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[LoginAudit]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[LoginAudit](
	[Id_Audit] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](255) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Resultado] [varchar](50) NOT NULL,
	[Intentos] [int] NOT NULL,
 CONSTRAINT [PK_LoginAudit] PRIMARY KEY CLUSTERED 
(
	[Id_Audit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[RolPorUsuario]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[RolPorUsuario](
	[Id_Rol] [int] NOT NULL,
	[Usuario] [varchar](255) NOT NULL,
 CONSTRAINT [PK_RolPorUsuario] PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC,
	[Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[FuncionalidadesPorRol]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[FuncionalidadesPorRol](
	[Id_Rol] [int] NOT NULL,
	[Id_Funcionalidad] [smallint] NOT NULL,
 CONSTRAINT [PK_FuncionalidadesPorRol] PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC,
	[Id_Funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Tarjeta]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Tarjeta](
	[Nro_Tarjeta] [varchar](16) NOT NULL,
	[Emisor] [varchar](255) NOT NULL,
	[Fecha_Emision] [datetime] NOT NULL,
	[Fecha_Vencimiento] [datetime] NOT NULL,
	[Codigo_Seg] [varchar](3) NOT NULL,
	[Cod_Cli] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[Nro_Tarjeta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Cuenta]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Cuenta](
	[Nro_Cuenta] [numeric](18, 0) IDENTITY(1111111111111451,1) NOT NULL,
	[Cod_Cli] [int] NOT NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
	[Estado] [varchar](255) NOT NULL,
	[Cod_Pais] [numeric](18, 0) NOT NULL,
	[Fecha_Cierre] [datetime] NULL,
	[Tipo_Cuenta] [varchar](50) NOT NULL,
	[Saldo] [numeric](18, 2) NOT NULL,
	[Tipo_Moneda] [varchar](50) NOT NULL,
	[Periodo_Suscripcion] [int] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[Nro_Cuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Factura]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Factura](
	[Id_Factura] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cod_Cli] [int] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[Id_Factura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Transferencia]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Transferencia](
	[Id_Transf] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha_Transf] [datetime] NOT NULL,
	[Importe] [numeric](18, 2) NOT NULL,
	[Costo] [numeric](18, 2) NOT NULL,
	[Cuenta_Origen] [numeric](18, 0) NOT NULL,
	[Cuenta_Destino] [numeric](18, 0) NOT NULL,
	[Facturado] [bit] NOT NULL,
	[Tipo_Moneda] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Transferencia] PRIMARY KEY CLUSTERED 
(
	[Id_Transf] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Deposito]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Deposito](
	[Cod_Deposito] [numeric](18, 0) IDENTITY(35135160439,1) NOT NULL,
	[Nro_Cuenta] [numeric](18, 0) NOT NULL,
	[Importe] [numeric](18, 2) NOT NULL,
	[Fecha_Deposito] [datetime] NOT NULL,
	[Tipo_Moneda] [varchar](50) NOT NULL,
	[Nro_Tarjeta] [varchar](16) NOT NULL,
 CONSTRAINT [PK_Deposito] PRIMARY KEY CLUSTERED 
(
	[Cod_Deposito] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Retiro]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Retiro](
	[Cod_Retiro] [numeric](18, 0) IDENTITY(15315188276,1) NOT NULL,
	[Fecha_Retiro] [datetime] NOT NULL,
	[Importe] [numeric](18, 2) NOT NULL,
	[Nro_Cuenta] [numeric](18, 0) NOT NULL,
	[Tipo_Moneda] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Retiro] PRIMARY KEY CLUSTERED 
(
	[Cod_Retiro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Item]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Item](
	[Id_Item] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Id_Factura] [numeric](18, 0) NOT NULL,
	[Descripcion] [varchar](255) NOT NULL,
	[Importe] [numeric](18, 2) NOT NULL,
	[Tipo_Moneda] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Item_1] PRIMARY KEY CLUSTERED 
(
	[Id_Item] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [ESCUADRON_SUICIDA].[Cheque]    Script Date: 06/20/2015 23:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ESCUADRON_SUICIDA].[Cheque](
	[Id_Cheque] [numeric](18, 0) IDENTITY(151550274,1) NOT NULL,
	[Nro_Cuenta] [numeric](18, 0) NOT NULL,
	[Fecha_Cheque] [datetime] NOT NULL,
	[Importe] [numeric](18, 2) NOT NULL,
	[Id_Banco] [numeric](18, 0) NOT NULL,
	[Cli_Nombre] [varchar](255) NOT NULL,
	[Tipo_Moneda] [varchar](50) NOT NULL,
	[Nro_Egreso] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Cheque_1] PRIMARY KEY CLUSTERED 
(
	[Id_Cheque] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Cheque] UNIQUE NONCLUSTERED 
(
	[Nro_Egreso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Cliente_Piso]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente] ADD  CONSTRAINT [DF_Cliente_Piso]  DEFAULT ((0)) FOR [Piso]
GO
/****** Object:  Default [DF_Cliente_Localidad]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente] ADD  CONSTRAINT [DF_Cliente_Localidad]  DEFAULT (' ') FOR [Localidad]
GO
/****** Object:  Default [DF_Cliente_Nacionalidad]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente] ADD  CONSTRAINT [DF_Cliente_Nacionalidad]  DEFAULT (' ') FOR [Nacionalidad]
GO
/****** Object:  Default [DF_Cliente_Estado]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente] ADD  CONSTRAINT [DF_Cliente_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_Cuenta_Estado]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] ADD  CONSTRAINT [DF_Cuenta_Estado]  DEFAULT ('Pendiente') FOR [Estado]
GO
/****** Object:  Default [DF_Cuenta_Tipo_Cuenta]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] ADD  CONSTRAINT [DF_Cuenta_Tipo_Cuenta]  DEFAULT ('Gratuita') FOR [Tipo_Cuenta]
GO
/****** Object:  Default [DF_Cuenta_Saldo]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] ADD  CONSTRAINT [DF_Cuenta_Saldo]  DEFAULT ((0)) FOR [Saldo]
GO
/****** Object:  Default [DF_Cuenta_Tipo_Moneda]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] ADD  CONSTRAINT [DF_Cuenta_Tipo_Moneda]  DEFAULT ('USD') FOR [Tipo_Moneda]
GO
/****** Object:  Default [DF_Cuenta_Periodo_Suscripcion]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] ADD  CONSTRAINT [DF_Cuenta_Periodo_Suscripcion]  DEFAULT ((1)) FOR [Periodo_Suscripcion]
GO
/****** Object:  Default [DF_Roles_Estado]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Roles] ADD  CONSTRAINT [DF_Roles_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_Tarjeta_Estado]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Tarjeta] ADD  CONSTRAINT [DF_Tarjeta_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_TipoCuenta_Costo]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[TipoCuenta] ADD  CONSTRAINT [DF_TipoCuenta_Costo]  DEFAULT ((0)) FOR [Costo]
GO
/****** Object:  Default [DF_Transferencia_Facturado]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Transferencia] ADD  CONSTRAINT [DF_Transferencia_Facturado]  DEFAULT ((0)) FOR [Facturado]
GO
/****** Object:  Default [DF_Usuario_Estado]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Usuario] ADD  CONSTRAINT [DF_Usuario_Estado]  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  ForeignKey [FK_Cheque_Banco]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_Cheque_Banco] FOREIGN KEY([Id_Banco])
REFERENCES [ESCUADRON_SUICIDA].[Banco] ([Id_Banco])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cheque] CHECK CONSTRAINT [FK_Cheque_Banco]
GO
/****** Object:  ForeignKey [FK_Cheque_Retiro]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cheque]  WITH CHECK ADD  CONSTRAINT [FK_Cheque_Retiro] FOREIGN KEY([Nro_Egreso])
REFERENCES [ESCUADRON_SUICIDA].[Retiro] ([Cod_Retiro])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cheque] CHECK CONSTRAINT [FK_Cheque_Retiro]
GO
/****** Object:  ForeignKey [FK_Cliente_Documento1]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Documento1] FOREIGN KEY([Tipo_Doc])
REFERENCES [ESCUADRON_SUICIDA].[Documento] ([Tipo_Doc])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente] CHECK CONSTRAINT [FK_Cliente_Documento1]
GO
/****** Object:  ForeignKey [FK_Cliente_Pais]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Pais] FOREIGN KEY([Cod_Pais])
REFERENCES [ESCUADRON_SUICIDA].[Pais] ([Cod_Pais])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente] CHECK CONSTRAINT [FK_Cliente_Pais]
GO
/****** Object:  ForeignKey [FK_Cliente_Usuario1]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario1] FOREIGN KEY([Usuario])
REFERENCES [ESCUADRON_SUICIDA].[Usuario] ([Usuario])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario1]
GO
/****** Object:  ForeignKey [FK_Cuenta_Cliente]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente] FOREIGN KEY([Cod_Cli])
REFERENCES [ESCUADRON_SUICIDA].[Cliente] ([Cod_Cli])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente]
GO
/****** Object:  ForeignKey [FK_Cuenta_Estado]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Estado] FOREIGN KEY([Estado])
REFERENCES [ESCUADRON_SUICIDA].[Estado] ([Estado])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Estado]
GO
/****** Object:  ForeignKey [FK_Cuenta_Pais]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Pais] FOREIGN KEY([Cod_Pais])
REFERENCES [ESCUADRON_SUICIDA].[Pais] ([Cod_Pais])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Pais]
GO
/****** Object:  ForeignKey [FK_Cuenta_TipoCuenta]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_TipoCuenta] FOREIGN KEY([Tipo_Cuenta])
REFERENCES [ESCUADRON_SUICIDA].[TipoCuenta] ([Tipo_Cuenta])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_TipoCuenta]
GO
/****** Object:  ForeignKey [FK_Cuenta_TipoMoneda]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_TipoMoneda] FOREIGN KEY([Tipo_Moneda])
REFERENCES [ESCUADRON_SUICIDA].[TipoMoneda] ([Tipo_Moneda])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_TipoMoneda]
GO
/****** Object:  ForeignKey [FK_Deposito_Cuenta]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Deposito]  WITH CHECK ADD  CONSTRAINT [FK_Deposito_Cuenta] FOREIGN KEY([Nro_Cuenta])
REFERENCES [ESCUADRON_SUICIDA].[Cuenta] ([Nro_Cuenta])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Deposito] CHECK CONSTRAINT [FK_Deposito_Cuenta]
GO
/****** Object:  ForeignKey [FK_Factura_Cliente]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([Cod_Cli])
REFERENCES [ESCUADRON_SUICIDA].[Cliente] ([Cod_Cli])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
/****** Object:  ForeignKey [FK_FuncionalidadesPorRol_Funcionalidades]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[FuncionalidadesPorRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadesPorRol_Funcionalidades] FOREIGN KEY([Id_Funcionalidad])
REFERENCES [ESCUADRON_SUICIDA].[Funcionalidades] ([Id_Funcionalidad])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[FuncionalidadesPorRol] CHECK CONSTRAINT [FK_FuncionalidadesPorRol_Funcionalidades]
GO
/****** Object:  ForeignKey [FK_FuncionalidadesPorRol_Roles]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[FuncionalidadesPorRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadesPorRol_Roles] FOREIGN KEY([Id_Rol])
REFERENCES [ESCUADRON_SUICIDA].[Roles] ([Id_Rol])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[FuncionalidadesPorRol] CHECK CONSTRAINT [FK_FuncionalidadesPorRol_Roles]
GO
/****** Object:  ForeignKey [FK_Item_Factura]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura] FOREIGN KEY([Id_Factura])
REFERENCES [ESCUADRON_SUICIDA].[Factura] ([Id_Factura])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Item] CHECK CONSTRAINT [FK_Item_Factura]
GO
/****** Object:  ForeignKey [FK_Item_Transferencia]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Transferencia] FOREIGN KEY([Id_Item])
REFERENCES [ESCUADRON_SUICIDA].[Transferencia] ([Id_Transf])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Item] CHECK CONSTRAINT [FK_Item_Transferencia]
GO
/****** Object:  ForeignKey [FK_LoginAudit_Usuario]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[LoginAudit]  WITH CHECK ADD  CONSTRAINT [FK_LoginAudit_Usuario] FOREIGN KEY([Usuario])
REFERENCES [ESCUADRON_SUICIDA].[Usuario] ([Usuario])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[LoginAudit] CHECK CONSTRAINT [FK_LoginAudit_Usuario]
GO
/****** Object:  ForeignKey [FK_Retiro_Cuenta]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Retiro]  WITH CHECK ADD  CONSTRAINT [FK_Retiro_Cuenta] FOREIGN KEY([Nro_Cuenta])
REFERENCES [ESCUADRON_SUICIDA].[Cuenta] ([Nro_Cuenta])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Retiro] CHECK CONSTRAINT [FK_Retiro_Cuenta]
GO
/****** Object:  ForeignKey [FK_RolPorUsuario_Roles]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[RolPorUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolPorUsuario_Roles] FOREIGN KEY([Id_Rol])
REFERENCES [ESCUADRON_SUICIDA].[Roles] ([Id_Rol])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[RolPorUsuario] CHECK CONSTRAINT [FK_RolPorUsuario_Roles]
GO
/****** Object:  ForeignKey [FK_RolPorUsuario_Usuario]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[RolPorUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolPorUsuario_Usuario] FOREIGN KEY([Usuario])
REFERENCES [ESCUADRON_SUICIDA].[Usuario] ([Usuario])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[RolPorUsuario] CHECK CONSTRAINT [FK_RolPorUsuario_Usuario]
GO
/****** Object:  ForeignKey [FK_Tarjeta_Cliente]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Cliente] FOREIGN KEY([Cod_Cli])
REFERENCES [ESCUADRON_SUICIDA].[Cliente] ([Cod_Cli])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Cliente]
GO
/****** Object:  ForeignKey [FK_Tarjeta_EmisorTarjeta]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_EmisorTarjeta] FOREIGN KEY([Emisor])
REFERENCES [ESCUADRON_SUICIDA].[EmisorTarjeta] ([Emisor])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_EmisorTarjeta]
GO
/****** Object:  ForeignKey [FK_Transferencia_Cuenta]    Script Date: 06/20/2015 23:09:58 ******/
ALTER TABLE [ESCUADRON_SUICIDA].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Cuenta] FOREIGN KEY([Cuenta_Origen])
REFERENCES [ESCUADRON_SUICIDA].[Cuenta] ([Nro_Cuenta])
GO
ALTER TABLE [ESCUADRON_SUICIDA].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Cuenta]
GO












/* COMIENZO DE INICIALIZACIONES Y MIGRACION DE TABLA MAESTRA*/


/* TABLA ROLES INICIALIZACION */
INSERT INTO ESCUADRON_SUICIDA.Roles (Nombre,Estado) VALUES ('Administrador', 1)
INSERT INTO ESCUADRON_SUICIDA.Roles (Nombre,Estado) VALUES ('Cliente', 2 )

/*TABLA FUNCIONALIDADES INICIALIZACION*/
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('ABM de Rol')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('ABM de Usuario')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('ABM de Cliente')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('ABM de Cuenta')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('Depositos')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('Retiro de Efectivo')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('Transferencias entre Cuentas')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('Facturacion')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('Consultar Saldos')
INSERT INTO ESCUADRON_SUICIDA.Funcionalidades (Nombre) VALUES ('Listado Estadistico')


/* TABLA FUNCIONALIDADESPORROL INICIALIZACION */
--ADMIN
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,1)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,2)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,3)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,4)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,5)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,6)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,7)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,8)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,9)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (1,10)
--CLIENTE
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (2,5)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (2,6)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (2,7)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (2,8)
INSERT INTO ESCUADRON_SUICIDA.FuncionalidadesPorRol (Id_Rol,Id_Funcionalidad) VALUES (2,9)

/* TABLA USUARIO ADMINISTRADOR INICIALIZACION */ 
INSERT INTO ESCUADRON_SUICIDA.Usuario (Usuario, Password, Fecha_Creacion, Fecha_Modificacion, Pregunta_Secreta, Respuesta_Secreta, Estado)
VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', GETDATE(), GETDATE(), 'admin?' , '97a62ad21d79c01cceb7767952acec4fec86bfe909b06e5f3f6963365cf91ab8' , 1)


/* TABLA ROLPORUSUARIO INICIALIZACION*/
INSERT INTO ESCUADRON_SUICIDA.RolPorUsuario (Id_Rol, Usuario) VALUES (1, 'admin')
INSERT INTO ESCUADRON_SUICIDA.RolPorUsuario (Usuario, Id_Rol) (SELECT U.Usuario, R.Id_Rol FROM ESCUADRON_SUICIDA.Roles as R Join ESCUADRON_SUICIDA.Usuario AS U ON (R.Nombre='Cliente'))
INSERT INTO ESCUADRON_SUICIDA.RolPorUsuario (Id_Rol,Usuario) 
		(SELECT Id_Rol, Usuario FROM ESCUADRON_SUICIDA.Usuario U JOIN ESCUADRON_SUICIDA.Roles ON(U.Usuario<> 'admin' AND Nombre='Cliente'))

/* TABLA DOCUMENTO MIGRACION */
INSERT INTO ESCUADRON_SUICIDA.Documento 
			(Tipo_Doc, Descripcion) 
SELECT distinct Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc 
		FROM gd_esquema.Maestra;

/* TABLA PAIS CLIENTES MIGRACION */
INSERT INTO ESCUADRON_SUICIDA.Pais (Cod_Pais, Descripcion) SELECT DISTINCT Cli_Pais_Codigo, Cli_Pais_Desc from gd_esquema.Maestra;

/* TABLA USUARIO CLIENTES INICIALIZACION */
INSERT INTO ESCUADRON_SUICIDA.Usuario (Usuario, Password, Fecha_Creacion, Fecha_Modificacion, Pregunta_Secreta, Respuesta_Secreta) ((SELECT DISTINCT Cli_Nro_Doc, '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', getDATE(), getdate(), 'a', '3e23e8160039594a33894f6564e1b1348bbd7a0088d42c4acb73eeaed59c009d' FROM gd_esquema.Maestra))

/* TABLA CLIENTE MIGRACION */
INSERT INTO ESCUADRON_SUICIDA.Cliente (Nro_Doc, Nombre, Apellido, Tipo_Doc, Mail, Calle, Nro_Calle, Piso, Depto, Fecha_Nac, Cod_Pais, Usuario )
SELECT DISTINCT Cli_Nro_Doc, Cli_Nombre, Cli_Apellido, Cli_Tipo_Doc_Cod, Cli_Mail, Cli_Dom_Calle, Cli_Dom_Nro, Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, Cli_Pais_Codigo, Cli_Nro_Doc  from gd_esquema.Maestra 


/*TABLA ESTADO INICIALIZACION*/
INSERT INTO ESCUADRON_SUICIDA.Estado (Estado) VALUES ('Pendiente');
INSERT INTO ESCUADRON_SUICIDA.Estado (Estado) VALUES ('Cerrada');
INSERT INTO ESCUADRON_SUICIDA.Estado (Estado) VALUES ('Inhabilitada');
INSERT INTO ESCUADRON_SUICIDA.Estado (Estado) VALUES ('Habilitada');

/*INICIALIZAR TABLA PAIS CON PAISES CUENTA*/

INSERT INTO ESCUADRON_SUICIDA.Pais (Cod_Pais,Descripcion) (SELECT distinct Cuenta_Pais_Codigo, Cuenta_Pais_Desc FROM gd_esquema.Maestra WHERE Cuenta_Pais_Codigo not IN(Select Cod_Pais FRom ESCUADRON_SUICIDA.Pais))

/*INICIALIZAR TABLA TIPO MONEDA*/

INSERT INTO ESCUADRON_SUICIDA.TipoMoneda (Tipo_Moneda) VALUES ('USD');

/* INICIALIZAR TABLA TIPO CUENTAS */

INSERT INTO ESCUADRON_SUICIDA.TipoCuenta (Tipo_Cuenta, Costo, Costo_Apertura, Dias_Suscripcion,Tipo_Moneda) VALUES ('Oro', 15 , 30, 90, 'USD')
INSERT INTO ESCUADRON_SUICIDA.TipoCuenta (Tipo_Cuenta, Costo, Costo_Apertura, Dias_Suscripcion, Tipo_Moneda) VALUES ('Plata', 10 , 20, 60,'USD')
INSERT INTO ESCUADRON_SUICIDA.TipoCuenta (Tipo_Cuenta, Costo, Costo_Apertura, Dias_Suscripcion, Tipo_Moneda) VALUES ('Bronce', 5 , 10, 30,'USD')
INSERT INTO ESCUADRON_SUICIDA.TipoCuenta (Tipo_Cuenta, Costo, Costo_Apertura, Dias_Suscripcion, Tipo_Moneda) VALUES ('Gratuita', 0 , 0, 3500,'USD')


/*TABLA CUENTA MIGRACION*/

SET IDENTITY_INSERT ESCUADRON_SUICIDA.Cuenta ON;
GO
INSERT INTO ESCUADRON_SUICIDA.Cuenta (Nro_Cuenta, Cod_Cli, Fecha_Creacion, Cod_Pais, Fecha_Cierre)
	   (SELECT DISTINCT Cuenta_Numero, Cod_Cli, Cuenta_Fecha_Creacion, Cuenta_Pais_Codigo,Cuenta_Fecha_Cierre FROM gd_esquema.Maestra M JOIN ESCUADRON_SUICIDA.Cliente C ON (M.Cli_Nro_Doc=C.Nro_Doc) )

SET IDENTITY_INSERT ESCUADRON_SUICIDA.Cuenta OFF;
GO

UPDATE ESCUADRON_SUICIDA.Cuenta SET Estado = 'Habilitada' WHERE Fecha_Cierre IS NULL
UPDATE ESCUADRON_SUICIDA.Cuenta SET Estado = 'Cerrada' WHERE Fecha_Cierre IS NOT NULL 

/* TABLA EMISOR TARJETA INICIALIZACION*/
INSERT INTO ESCUADRON_SUICIDA.EmisorTarjeta (Emisor) 
(SELECT DISTINCT Tarjeta_Emisor_Descripcion FROM gd_esquema.Maestra WHERE Tarjeta_Emisor_Descripcion IS NOT NULL)


/*TABLA TARJETA MIGRACION*/

INSERT INTO ESCUADRON_SUICIDA.Tarjeta (Nro_Tarjeta, Emisor, Fecha_Emision, Fecha_Vencimiento, Codigo_Seg, Cod_Cli)
SELECT DISTINCT Tarjeta_Numero, Tarjeta_Emisor_Descripcion , Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento, Tarjeta_Codigo_Seg,Cod_Cli from gd_esquema.Maestra M JOIN ESCUADRON_SUICIDA.Cliente C ON (M.Cli_Nro_Doc = C.Nro_Doc) 
WHERE Tarjeta_Numero IS NOT NULL

UPDATE ESCUADRON_SUICIDA.Tarjeta SET Estado = 0
 WHERE YEAR(Fecha_Vencimiento) < 2017
 

/* TABLA DEPOSITOS MIGRACION */

SET IDENTITY_INSERT ESCUADRON_SUICIDA.Deposito ON;
GO
INSERT INTO ESCUADRON_SUICIDA.Deposito (Cod_Deposito, Nro_Cuenta, Importe, Fecha_Deposito, Tipo_Moneda, Nro_Tarjeta)
select distinct Deposito_Codigo, Cuenta_Numero, Deposito_Importe, Deposito_Fecha, T.Tipo_Moneda, Tarjeta_Numero from gd_esquema.Maestra M JOIN ESCUADRON_SUICIDA.Cuenta C ON M.Cuenta_Numero = C.Nro_Cuenta JOIN ESCUADRON_SUICIDA.TipoMoneda T ON T.Tipo_Moneda = C.Tipo_Moneda
WHERE Deposito_Codigo IS NOT NULL AND Tarjeta_Numero IS NOT NULL AND Cuenta_Numero IS NOT NULL
SET IDENTITY_INSERT ESCUADRON_SUICIDA.Deposito OFF;
GO

UPDATE ESCUADRON_SUICIDA.Cuenta SET Saldo = Saldo + (SELECT SUM(Importe) SaldoTotal FROM ESCUADRON_SUICIDA.Deposito D  
where D.Nro_Cuenta = ESCUADRON_SUICIDA.Cuenta.Nro_Cuenta
GROUP BY D.Nro_Cuenta)


/* TABLA RETIROS MIGRACION */

SET IDENTITY_INSERT ESCUADRON_SUICIDA.Retiro ON;
GO
INSERT INTO ESCUADRON_SUICIDA.Retiro (Cod_Retiro, Nro_Cuenta, Fecha_Retiro, Importe, Tipo_Moneda)
SELECT Retiro_Codigo, Cuenta_Numero, Retiro_Fecha, Retiro_Importe, 'USD' FROM gd_esquema.Maestra
WHERE Retiro_Codigo IS NOT NULL
SET IDENTITY_INSERT ESCUADRON_SUICIDA.Retiro OFF;
GO

UPDATE ESCUADRON_SUICIDA.Cuenta SET Saldo = Saldo - (SELECT SUM(Importe) SaldoTotal FROM ESCUADRON_SUICIDA.Retiro R  
where R.Nro_Cuenta = ESCUADRON_SUICIDA.Cuenta.Nro_Cuenta
GROUP BY R.Nro_Cuenta)


/* TABLA BANCO INICIALIZACION */

INSERT INTO ESCUADRON_SUICIDA.Banco (Id_Banco, Nombre, Direccion) SELECT DISTINCT Banco_Cogido, Banco_Nombre, Banco_Direccion FROM gd_esquema.Maestra WHERE Banco_Nombre is not null


/*TABLA CHEQUE MIGRACION */

SET IDENTITY_INSERT ESCUADRON_SUICIDA.Cheque ON;
GO
INSERT INTO ESCUADRON_SUICIDA.Cheque (Id_Cheque, Nro_Cuenta, Fecha_Cheque, Importe, Id_Banco, Cli_Nombre, Tipo_Moneda, Nro_Egreso )
SELECT DISTINCT Cheque_Numero, Cuenta_Numero, Cheque_Fecha,  Cheque_Importe,Banco_Cogido, Cli_Apellido+' '+Cli_Nombre as 'Nombre_Y_Apellido', 'USD', Retiro_Codigo FROM gd_esquema.Maestra 
WHERE Cheque_Numero IS NOT NULL
GO
SET IDENTITY_INSERT ESCUADRON_SUICIDA.Cheque OFF;
GO




/*TABLA TRANSFERENCIA MIGRACION*/

INSERT INTO ESCUADRON_SUICIDA.Transferencia (Fecha_Transf, Importe, Costo, Cuenta_Origen, Cuenta_Destino, Tipo_Moneda) 
SELECT Transf_Fecha, Trans_Importe, Trans_Costo_Trans, Cuenta_Numero, Cuenta_Dest_Numero, 'USD'  FROM gd_esquema.Maestra 
WHERE Transf_Fecha IS NOT NULL AND Cuenta_Numero IS NOT NULL AND Cuenta_Dest_Numero IS NOT NULL AND Factura_Numero IS NOT NULL

UPDATE ESCUADRON_SUICIDA.Cuenta SET Saldo = Saldo - (SELECT SUM(Importe) SaldoTotal FROM ESCUADRON_SUICIDA.Transferencia R  
where R.Cuenta_Origen = ESCUADRON_SUICIDA.Cuenta.Nro_Cuenta
GROUP BY R.Cuenta_Origen)

UPDATE ESCUADRON_SUICIDA.Transferencia SET Facturado = 1

/* TABLA FACTURA MIGRACION */

SET IDENTITY_INSERT ESCUADRON_SUICIDA.Factura ON;
GO
INSERT INTO ESCUADRON_SUICIDA.Factura (Id_Factura, Fecha, Cod_Cli)
SELECT DISTINCT Factura_Numero, Factura_Fecha, Cod_Cli FROM gd_esquema.Maestra JOIN ESCUADRON_SUICIDA.Cliente ON Cli_Nro_Doc = Nro_Doc
WHERE Factura_Numero IS NOT NULL
GO
SET IDENTITY_INSERT ESCUADRON_SUICIDA.Factura OFF;
GO


/*TABLA ITEMS MIGRACION*/

INSERT INTO ESCUADRON_SUICIDA.Item (Id_Factura, Descripcion, Importe, Tipo_Moneda)
SELECT Factura_Numero, Item_Factura_Descr, Item_Factura_Importe, 'USD' FROM gd_esquema.Maestra 
WHERE Factura_Numero IS NOT NULL


/*TABLA ROLPORUSUARIO INICIALIZACION*/

INSERT ESCUADRON_SUICIDA.RolPorUsuario (Id_Rol,Usuario) 
		(SELECT Id_Rol, Usuario FROM ESCUADRON_SUICIDA.Usuario U JOIN ESCUADRON_SUICIDA.Roles ON(U.Usuario<> 'admin' AND Nombre='Cliente'))
		
/* ACTUALIZACION DE SALDOS EN TABLA CUENTA */

CREATE TABLE #Temp
(Nro_cuenta NUMERIC(18,0) not null PRIMARY KEY,
 Saldo NUMERIC(18,2) )

INSERT INTO #Temp
SELECT CCD.CN, DI+CCTS.TRI-RI-CCTR.TRI
          FROM ((Select Cuenta_Numero as CN, SUM(Deposito_Importe) as DI FROM gd_esquema.Maestra WHERE Deposito_Codigo IS NOT NULL GROUP BY Cuenta_Numero) AS CCD
          JOIN (SELECT Cuenta_Numero as CN, SUM(Retiro_Importe) as RI FROM gd_esquema.Maestra WHERE Retiro_Codigo IS NOT NULL Group by Cuenta_Numero) AS CCR
          ON(CCD.CN=CCR.CN)
          JOIN (SELECT Cuenta_Numero as CN, SUM(Trans_Importe) as TRI FROM gd_esquema.Maestra WHERE Trans_Importe IS NOT NULL GROUP BY Cuenta_Numero) AS CCTR
          ON (CCTR.CN=CCD.CN)
          JOIN (SELECT Cuenta_Dest_Numero as CN, SUM(Trans_Importe) as TRI FROM gd_esquema.Maestra WHERE Trans_Importe IS NOT NULL GROUP BY Cuenta_Dest_Numero) AS CCTS
          ON (CCTS.CN=CCD.CN))   
 
 UPDATE ESCUADRON_SUICIDA.Cuenta SET Saldo = (SELECT #Temp.Saldo FROM #Temp 
                                WHERE ESCUADRON_SUICIDA.Cuenta.Nro_Cuenta = #Temp.Nro_cuenta)
		
