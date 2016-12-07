CREATE TABLE [dbo].[Unidade](
	[IDUnidade] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](80) NOT NULL,
	[CEP] [varchar](9) NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Numero] [int] NOT NULL,
	[Complemento] [varchar](100) NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[DataCadastro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDUnidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
