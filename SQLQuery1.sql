GO
CREATE DATABASE [EmployeeDB]
GO
USE [EmployeeDB]

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO
CREATE TABLE [dbo].[Companies] (
    [CompanyId]   INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (50) NOT NULL,
    [Size]        INT           NOT NULL,
    [Form]        NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

GO
CREATE TABLE [dbo].[Employees] (
    [EmployeeId] INT           IDENTITY (1, 1) NOT NULL,
    [Surname]    NVARCHAR (50) NOT NULL,
    [Name]       NVARCHAR (30) NOT NULL,
    [Patronymic] NVARCHAR (30) NOT NULL,
    [StartDate]  DATETIME      NOT NULL,
    [Post]       NVARCHAR (20) NOT NULL,
    [CompanyId]  INT           NOT NULL,
	PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);

SET IDENTITY_INSERT [dbo].[Companies] ON
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (1002, N'Зефирка', 18, N'Общество с ограниченной ответственностью')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (2002, N'Атмосфера', 32, N'Открытое акционерное общество')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (2003, N'Ткани от Тани', 9, N'Общество с ограниченной ответственностью')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (2004, N'Тимошка', 25, N'Открытое акционерное общество')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (3002, N'Звонок другу', 32, N'Открытое акционерное общество')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (4002, N'Медуза', 25, N'Закрытое акционерное общество')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (4005, N'Кот в мешке', 25, N'Производственный кооператив')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (5002, N'Лютик', 13, N'Индивидуальный предприниматель')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (6004, N'Отчаянный Домохозяин', 39, N'Открытое акционерное общество')
INSERT INTO [dbo].[Companies] ([CompanyId], [CompanyName], [Size], [Form]) VALUES (6005, N'Ручка Помощи', 23, N'Закрытое акционерное общество')
SET IDENTITY_INSERT [dbo].[Companies] OFF

SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (7006, N'Грицук', N'Андрей', N'Викторович', N'2019-01-20 00:00:00', N'Разработчик', 2004)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (7009, N'Рыбак', N'Дмитрий', N'Федорович', N'2019-10-27 00:00:00', N'Менеджер', 3002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (7010, N'Копищик', N'Вадим', N'Олегович', N'2020-02-08 00:00:00', N'Разработчик', 1002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (8010, N'Ролич', N'Павел', N'Викторович', N'2020-01-18 00:00:00', N'Разработчик ', 3002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (8012, N'Калинина', N'Яна', N'Павловна', N'2019-09-07 00:00:00', N'Менеджер', 5002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (8013, N'Андрейковец', N'Кирилл', N'Богданович', N'2019-05-11 00:00:00', N'Бизнес-аналитик', 2002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (8014, N'Киндрук', N'Василий', N'Леонидович', N'2017-10-13 00:00:00', N'Разработчик ', 4002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (9010, N'Марчук', N'Андрей', N'Григорьевич', N'2018-04-13 00:00:00', N'Тестировщик ', 4005)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (9011, N'Орешкевич', N'Владимир', N'Геннадьевич', N'2014-03-07 00:00:00', N'Разработчик ', 1002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (9012, N'Матвеюк', N'Анна', N'Романовка', N'2017-09-08 00:00:00', N'Бизнес-аналитик', 6005)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (9013, N'Роща', N'Игнат', N'Павлович', N'2019-10-28 00:00:00', N'Бизнес-аналитик', 6004)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (9014, N'Самуилова', N'Инна', N'Дмитриевна', N'2017-07-21 00:00:00', N'Разработчик ', 4002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (9015, N'Петров', N'Артем', N'Владимирович', N'2018-09-11 00:00:00', N'Тестировщик ', 3002)
INSERT INTO [dbo].[Employees] ([EmployeeId], [Surname], [Name], [Patronymic], [StartDate], [Post], [CompanyId]) VALUES (10010, N'Ромашко', N'Антон', N'Александрович', N'2015-05-06 00:00:00', N'Бизнес-аналитик', 4005)
SET IDENTITY_INSERT [dbo].[Employees] OFF
