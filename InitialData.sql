/*Insert Usuarios*/
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([Id], [FechaCreacion], [Nombre], [Apellido], [FecNacimiento], [Email], [Pass]) VALUES (1, N'2019-11-10 00:00:00', N'Jose', N'Mendez', N'1990-07-05 00:00:00', N'jose@gmail.com', N'1234')
INSERT INTO [dbo].[Usuarios] ([Id], [FechaCreacion], [Nombre], [Apellido], [FecNacimiento], [Email], [Pass]) VALUES (2, N'2019-11-10 00:00:00', N'Juan', N'Perez', N'2000-09-05 00:00:00', N'prueba@prueba.com', N'1111')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF

/*Insert Productos*/
SET IDENTITY_INSERT [dbo].[Productos] ON
INSERT INTO [dbo].[Productos] ([Id], [FechaCreacion], [Descripcion], [Estado], [Precio], [UrlImagen], [Titulo]) VALUES (2, N'2019-11-10 00:00:00', N'Servicio de e-commerce en la nube', N'vigente', 1000, N'https://img.business.com/rc/300x200/aHR0cHM6Ly93d3cuYnVzaW5lc3MuY29tL2ltYWdlcy9jb250ZW50LzVjYS8zY2MxMzVhMjE1ZThhNDU4YjUwNTAvMC04MDAt', N'E-commerce Cloud')
INSERT INTO [dbo].[Productos] ([Id], [FechaCreacion], [Descripcion], [Estado], [Precio], [UrlImagen], [Titulo]) VALUES (3, N'2019-11-10 00:00:00', N'Servicio Mesa de ayuda 24/7', N'vigente', 20000, N'https://img.business.com/rc/300x200/aHR0cHM6Ly93d3cuYnVzaW5lc3MuY29tL2ltYWdlcy9jb250ZW50LzVjYS8zY2MxMzVhMjE1ZThhNDU4YjUwNTAvMC04MDAt', N'HelpDesk 24/7')
INSERT INTO [dbo].[Productos] ([Id], [FechaCreacion], [Descripcion], [Estado], [Precio], [UrlImagen], [Titulo]) VALUES (4, N'2019-11-10 00:00:00', N'Servicio Pagina Web', N'vigente', 5000, N'https://img.business.com/rc/300x200/aHR0cHM6Ly93d3cuYnVzaW5lc3MuY29tL2ltYWdlcy9jb250ZW50LzVjYS8zY2MxMzVhMjE1ZThhNDU4YjUwNTAvMC04MDAt', N'Pagina Web')
SET IDENTITY_INSERT [dbo].[Productos] OFF

/*Insert Logs*/
SET IDENTITY_INSERT [dbo].[Logs] ON
INSERT INTO [dbo].[Logs] ([Id], [FechaCreacion], [UsuarioId], [Accion], [Descripcion], [FechaActual]) VALUES (1, N'2019-11-10 00:00:00', N'1', N'Login_usuario', N'El usuario 1 se ha logueado', N'2019-11-10 00:00:00')
SET IDENTITY_INSERT [dbo].[Logs] OFF


