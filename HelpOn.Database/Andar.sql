CREATE TABLE [dbo].[Andar](
	[NumeroAndar] [int] NOT NULL,
	[IDUnidade] [int] NOT NULL,
 CONSTRAINT [PK_Andar_Unidade] PRIMARY KEY CLUSTERED 
(
	[NumeroAndar] ASC,
	[IDUnidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

ALTER TABLE [dbo].[Andar]  ADD  CONSTRAINT [FK_Andar_Unidade] FOREIGN KEY([IDUnidade])
REFERENCES [dbo].[Unidade] ([IDUnidade])
GO

ALTER TABLE [dbo].[Andar] CHECK CONSTRAINT [FK_Andar_Unidade]	