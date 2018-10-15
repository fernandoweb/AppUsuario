USE [dbUsuario]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/15/2018 12:16:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tbPessoa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Login], [Password]) VALUES (1, N'Usuario1', N'email1@email.com', N'login1', N'Pa$$w0rd')
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Login], [Password]) VALUES (2, N'Usuario2', N'email2@email.com', N'login2', N'Pa$$w0rd')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
