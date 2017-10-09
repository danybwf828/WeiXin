/****** Object:  Table [dbo].[wxLOCATION]    Script Date: 05/29/2015 10:48:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[wxLOCATION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ToUserName] [nvarchar](50) NULL,
	[FromUserName] [nvarchar](50) NULL,
	[CreateTime] [int] NULL,
	[MsgType] [nvarchar](50) NULL,
	[Latitude] [varchar](50) NULL,
	[Longitude] [varchar](50) NULL,
	[Precision] [varchar](50) NULL,
	[AgentID] [int]  NULL,
	Label NVARCHAR(100) NULL,
	MsgId NVARCHAR(50) NULL,
 CONSTRAINT [PK_LOCATION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业号CorpID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxLOCATION', @level2type=N'COLUMN',@level2name=N'ToUserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成员UserID ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxLOCATION', @level2type=N'COLUMN',@level2name=N'FromUserName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息创建时间（整型）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxLOCATION', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息类型，此时固定为：event ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxLOCATION', @level2type=N'COLUMN',@level2name=N'MsgType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地理位置纬度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxLOCATION', @level2type=N'COLUMN',@level2name=N'Latitude'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地理位置经度 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxLOCATION', @level2type=N'COLUMN',@level2name=N'Longitude'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地理位置精度 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxLOCATION', @level2type=N'COLUMN',@level2name=N'Precision'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业应用的id，整型。可在应用的设置页面查看 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxLOCATION', @level2type=N'COLUMN',@level2name=N'AgentID'
GO



CREATE TABLE [dbo].[wxCache](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ItemValue] [nvarchar](100) NOT NULL,
	[Expires] [varchar](50) NULL,
 CONSTRAINT [PK_wxCache] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'键名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxCache', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'键值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxCache', @level2type=N'COLUMN',@level2name=N'ItemValue'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过期时间，整型数字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wxCache', @level2type=N'COLUMN',@level2name=N'Expires'
GO

CREATE TABLE [dbo].[wxSign](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[DeviceId] [nvarchar](100) NULL,
	[SignDate] [varchar](10) NOT NULL,
	[lat] [varchar](50) NULL,
	[lng] [varchar](50) NULL,
	InsertTime DATETIME DEFAULT(GETDATE()),
 CONSTRAINT [PK_wxSign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

