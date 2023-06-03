SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[Id] [int] NOT NULL,
	[Name] [varchar](max) NULL,
	[Size] [bigint] NULL,
	[SpeciesCount] [int] NULL,
	[Temperature] [float] NULL,
	[WeatherConditions] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
