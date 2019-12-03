USE [test]  
GO  
/****** Object:  Table [dbo].[Plant]    Script Date: 2/2/2019 9:15:36 PM ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
CREATE TABLE [dbo].[Plant](  
    [PlantId] [int] IDENTITY(1,1) NOT NULL,  
    [Name] [varchar](255) NULL,  
    [TypeofDistributedEnergy] [varchar](255) NULL,  
    [Powerdistributor] [int] NULL,  
    [installedCapacity] [float] NULL,  
    [Source] [varchar](255) NULL,  
    [PowerBillExpectedDate] [DATE] NULL,  
 CONSTRAINT [PK_Plant] PRIMARY KEY CLUSTERED   
(  
    [PlantId] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY] 
GO  
SET IDENTITY_INSERT [dbo].[Plant] ON   
GO  
INSERT [dbo].[Plant] ([PlantId], [Name], [TypeofDistributedEnergy], [Powerdistributor], [installedCapacity], [Source], [PowerBillExpectedDate]) VALUES (111, N'WAY2', N'TypeofDistributedEnergy', 20, 25.4, N'Source', N'2019-11-14')  
GO  
INSERT [dbo].[Plant] ([PlantId], [Name], [TypeofDistributedEnergy], [Powerdistributor], [installedCapacity], [Source], [PowerBillExpectedDate]) VALUES (112, N'WAY2', N'TypeofDistributedEnergy', 20, 25.4, N'Source', N'2019-11-15')  
GO  
SET IDENTITY_INSERT [dbo].[Plant] OFF  
GO 

select * From Plant