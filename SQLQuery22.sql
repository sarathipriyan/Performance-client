USE [sarathidemo]
GO  
/****** Object:  Table [dbo].[Employee]    Script Date: 2/2/2019 9:15:36 PM ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
CREATE TABLE [dbo].[sarathi](  
    [Id] [bigint] IDENTITY(1,1) NOT NULL,  
    [Name] [varchar](100) NULL,  
 CONSTRAINT [PK_sarathi] PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]   
GO  
SET IDENTITY_INSERT [dbo].[sarathi] ON   
GO  
INSERT [dbo].[sarathi] ([Id], [Name]) VALUES (1, N'Akshay')
GO  
INSERT [dbo].[sarathi] ([Id], [Name]) VALUES (2, N'Panth')
GO  
SET IDENTITY_INSERT [dbo].[sarathi] OFF  
GO 


select * from sarathi;