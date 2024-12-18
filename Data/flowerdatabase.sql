USE [FlowerDataBase]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressShop]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressShop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[IdAddress] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deliveryman]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliveryman](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flower]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flower](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityUser]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUser](
	[Id] [int] NOT NULL,
	[Login] [nvarchar](64) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[Time] [datetime] NOT NULL,
	[IdAddressShop] [int] NULL,
	[IdFlower] [int] NULL,
	[IdDeliveryman] [int] NULL,
	[IdPaymentStatus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentStatus]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayStatus]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12.05.2024 18:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [Name]) VALUES (1, N'ул. Огурчекова д.40')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (2, N'ул. Неогуречкено д.10')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (3, N'ул. Хорошенко д.40')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (4, N'ул. Плошенко д. 20')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (5, N'ул. Богатенко д. 3')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (6, N'пр. Легова д. 47')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (7, N'ул. Неоненко д. 23')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (8, N'ул. Перепелко д. 14')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (9, N'ул. Горелко д. 5')
INSERT [dbo].[Address] ([Id], [Name]) VALUES (10, N'ул. Шейхелко д. 1')
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[AddressShop] ON 

INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (1, N'ул. Немедлелко д. 90')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (2, N'ул. Намедлелко д. 98')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (3, N'ул. Влетелко д. 84')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (4, N'ул. Прекрасенко д. 9')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (5, N'ул. Умиленко д. 4')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (6, N'ул. Смешелко д. 34')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (7, N'ул. Горделко д. 49')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (8, N'ул. Припелко д. 12')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (9, N'ул. Роделко д. 8')
INSERT [dbo].[AddressShop] ([Id], [Name]) VALUES (10, N'ул. Немедленко д. 78')
SET IDENTITY_INSERT [dbo].[AddressShop] OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [IdUser]) VALUES (1, 1)
INSERT [dbo].[Admin] ([Id], [IdUser]) VALUES (2, 2)
INSERT [dbo].[Admin] ([Id], [IdUser]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (1, N'Миша', N'Огуречков', 1)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (2, N'Таня', N'Грушева', 2)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (3, N'Данил', N'Ежевичкин', 3)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (4, N'Константин', N'Пирожков', 4)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (5, N'Наталья', N'Тортикова', 5)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (6, N'Руслан', N'Кексиков', 6)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (7, N'Николай', N'Шоколадкин', 7)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (8, N'Ратмир', N'Муков', 8)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (9, N'Оля', N'Нагицева', 9)
INSERT [dbo].[Client] ([Id], [Name], [Surname], [IdAddress]) VALUES (10, N'Александр', N'Сыров', 10)
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Deliveryman] ON 

INSERT [dbo].[Deliveryman] ([Id], [IdUser]) VALUES (1, 7)
INSERT [dbo].[Deliveryman] ([Id], [IdUser]) VALUES (2, 8)
INSERT [dbo].[Deliveryman] ([Id], [IdUser]) VALUES (3, 9)
INSERT [dbo].[Deliveryman] ([Id], [IdUser]) VALUES (4, 10)
SET IDENTITY_INSERT [dbo].[Deliveryman] OFF
GO
SET IDENTITY_INSERT [dbo].[Flower] ON 

INSERT [dbo].[Flower] ([Id], [IdUser]) VALUES (1, 4)
INSERT [dbo].[Flower] ([Id], [IdUser]) VALUES (2, 5)
INSERT [dbo].[Flower] ([Id], [IdUser]) VALUES (3, 6)
SET IDENTITY_INSERT [dbo].[Flower] OFF
GO
INSERT [dbo].[IdentityUser] ([Id], [Login], [Password]) VALUES (1, N'urii', N'123')
INSERT [dbo].[IdentityUser] ([Id], [Login], [Password]) VALUES (2, N'grigorii', N'321')
INSERT [dbo].[IdentityUser] ([Id], [Login], [Password]) VALUES (3, N'mihail', N'33')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [IdClient], [Time], [IdAddressShop], [IdFlower], [IdDeliveryman], [IdPaymentStatus]) VALUES (1, 1, CAST(N'2024-05-10T20:00:00.000' AS DateTime), 9, 1, 1, 1)
INSERT [dbo].[Order] ([Id], [IdClient], [Time], [IdAddressShop], [IdFlower], [IdDeliveryman], [IdPaymentStatus]) VALUES (2, 4, CAST(N'2024-05-11T13:30:00.000' AS DateTime), 8, 2, NULL, 1)
INSERT [dbo].[Order] ([Id], [IdClient], [Time], [IdAddressShop], [IdFlower], [IdDeliveryman], [IdPaymentStatus]) VALUES (5, 4, CAST(N'2024-05-11T13:30:00.000' AS DateTime), 8, NULL, NULL, 1)
INSERT [dbo].[Order] ([Id], [IdClient], [Time], [IdAddressShop], [IdFlower], [IdDeliveryman], [IdPaymentStatus]) VALUES (6, 4, CAST(N'2024-05-11T13:00:00.000' AS DateTime), 5, 3, NULL, 1)
INSERT [dbo].[Order] ([Id], [IdClient], [Time], [IdAddressShop], [IdFlower], [IdDeliveryman], [IdPaymentStatus]) VALUES (9, 9, CAST(N'2024-05-12T13:00:00.000' AS DateTime), 9, NULL, NULL, 2)
INSERT [dbo].[Order] ([Id], [IdClient], [Time], [IdAddressShop], [IdFlower], [IdDeliveryman], [IdPaymentStatus]) VALUES (10, 5, CAST(N'2024-05-10T15:00:00.000' AS DateTime), 1, 1, NULL, 2)
INSERT [dbo].[Order] ([Id], [IdClient], [Time], [IdAddressShop], [IdFlower], [IdDeliveryman], [IdPaymentStatus]) VALUES (11, 6, CAST(N'2024-05-10T16:30:00.000' AS DateTime), 7, 2, 4, 2)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (1, N'Новый')
INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (2, N'В работе')
INSERT [dbo].[OrderStatus] ([Id], [Name]) VALUES (3, N'Готов к доставке')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentStatus] ON 

INSERT [dbo].[PaymentStatus] ([Id], [Name]) VALUES (3, N'Оплачен')
INSERT [dbo].[PaymentStatus] ([Id], [Name]) VALUES (4, N'Ожидает оплаты')
SET IDENTITY_INSERT [dbo].[PaymentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[PayStatus] ON 

INSERT [dbo].[PayStatus] ([Id], [Name]) VALUES (1, N'Ожидает оплаты')
INSERT [dbo].[PayStatus] ([Id], [Name]) VALUES (2, N'Оплачен')
SET IDENTITY_INSERT [dbo].[PayStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (1, N'Юрий', N'Юрьев', N'Отлично смотрит в потолок')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (2, N'Григорий', N'Григорьев', N'Умеет варить огурцы')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (3, N'Михаил', N'Михаилов', N'Ест клиентов')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (4, N'Екатерина', N'Екатиринова', N'Продает кредиты')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (5, N'Никита', N'Коромыслов', N'Ворует текст')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (6, N'Игорь ', N'Игорев', N'Кушает вкусный сало')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (7, N'Таня', N'Танава', N'Может продать крокодила')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (8, N'Николай ', N'Николаев', N'Любит смотреть на клиентов')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (9, N'Виктор', N'Викторов', N'Веролет')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (10, N'Оля', N'Олява', N'Мешает всем кушать')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (11, N'Гриша', N'Который', N'Крыша')
INSERT [dbo].[User] ([Id], [Name], [Surname], [Description]) VALUES (12, N'12', N'12', N'12')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
