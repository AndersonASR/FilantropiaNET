Namespace Modelos
	Partial Public Class Pessoas
		Public Enum Campos
			ID
			TipoPessoa
			EstadoCivil
			MotivoRestricao
			ResponsavelCadastro
			CPFCNPJ
			Nome
			DataRestricao
			Enderecos
			Telefones
		End Enum

		Public Property ID As Long
		Public Property TipoPessoa As TiposPessoas
		Public Property EstadoCivil As String
		Public Property MotivoRestricao As String
		Public Property ResponsavelCadastro As Funcionario
		Public Property CPFCNPJ As String
		Public Property Nome As String
		Public Property DataRestricao As DateTime
		Public Property Enderecos As List(Of Enderecos)
		Public Property Telefones As List(Of Telefones)
	End Class
End Namespace