/****** Object:  Table [dbo].[Products]    Script Date: 04/13/2013 15:58:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 04/13/2013 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Category] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (1, N'Kayak', N'A board for one person', N'Watersports', CAST(275.00 AS Decimal(16, 2)))
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (2, N'Lifejacket', N'Protective and fashionable', N'Watersports', CAST(48.90 AS Decimal(16, 2)))
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (3, N'Soccer ball', N'FIFA - approved size and weight', N'Soccer', CAST(19.50 AS Decimal(16, 2)))
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (4, N'Corner flags', N'Give your playing field that professional touch', N'Soccer', CAST(34.95 AS Decimal(16, 2)))
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (5, N'Stadium', N'Flat-packed 35,000-seat stadium', N'Soccer', CAST(79500.00 AS Decimal(16, 2)))
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (8, N'Thinking cap', N'Improve your brain efficiency by 75%', N'Chess', CAST(16.00 AS Decimal(16, 2)))
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (9, N'Unsteady Chair', N'Secretely give your opponent a disadvantage', N'Chess', CAST(29.00 AS Decimal(16, 2)))
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (10, N'Human Chess', N'A fun game for the whole family', N'Chess', CAST(75.00 AS Decimal(16, 2)))
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Category], [Price]) VALUES (11, N'Bling-bling-King', N'Gold-plated, diamond studded King', N'Chess', CAST(1200.00 AS Decimal(16, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF
