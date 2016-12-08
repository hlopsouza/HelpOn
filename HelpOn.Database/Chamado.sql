CREATE TABLE [dbo].[Chamado](
	[IDChamado] [int] IDENTITY(1,1) NOT NULL,
	[IDDescricao] INT NOT NULL,
	[Processo] [varchar](15) NOT NULL CHECK  (([Processo]='Aberto' OR [Processo]='Em Processo' OR [Processo]='Fechado')),
	[NumeroLab] [int] NOT NULL,
	[NumeroAndar] [int] NOT NULL,
	[IDUnidade] [int] NOT NULL,
	[IDFuncionario] [int] NULL,
	[DataChamado] [datetime] NULL,
[IDNivel] INT NULL, 
    PRIMARY KEY CLUSTERED 
(
	[IDChamado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), 
    CONSTRAINT [FK_Chamado_Laboratorio] FOREIGN KEY ([NumeroLab],[NumeroAndar],[IDUnidade]) REFERENCES [Laboratorio]([NumeroLab],[NumeroAndar],[IDUnidade]), 
    CONSTRAINT [FK_Chamado_Funcionario] FOREIGN KEY ([IDFuncionario]) REFERENCES [Funcionario]([IDFuncionario]), 
    CONSTRAINT [FK_Chamado_Nivel] FOREIGN KEY ([IDNivel]) REFERENCES [Nivel]([IDNivel]), 
    CONSTRAINT [FK_Chamado_Descricao] FOREIGN KEY ([IDDescricao]) REFERENCES [Descricao]([IDDescricao])
)














