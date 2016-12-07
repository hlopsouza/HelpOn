CREATE TABLE [dbo].[Funcionario](
	[IDFuncionario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NOT NULL,
	[CPF] [varchar](14) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[DataCadastro] [datetime] NULL,
	[Nivel] VARCHAR(20) NULL, 
    CONSTRAINT [PK_Funcionario] PRIMARY KEY ([IDFuncionario]), 
    )