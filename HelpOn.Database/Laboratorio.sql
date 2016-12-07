CREATE TABLE [dbo].[Laboratorio](
	[NumeroLab] [int] NOT NULL,
	[NumeroAndar] [int] NOT NULL,
	[IDUnidade] [int] NOT NULL,
 CONSTRAINT [PK_Laboratorio_Unidade] PRIMARY KEY CLUSTERED 
(
	[NumeroLab] ASC,
	[NumeroAndar] ASC,
	[IDUnidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), 
    CONSTRAINT [FK_Laboratorio_Andar] FOREIGN KEY ([NumeroAndar], [IDUnidade]) REFERENCES [Andar]([NumeroAndar], [IDUnidade])
)