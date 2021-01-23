Namespace Modelos
	Partial Public Class Funcionario
		Public Enum Campos
			ID
			CPFCNPJ
			DataAdmissao
			DataDesligamento
			RG
			IDTipoFuncionario
			Pessoa
			Ativo
			Senha
		End Enum

		Public Property ID As Long
		Public Property CPFCNPJ As Long
		Public Property Nome As String
		Public Property DataAdmissao As DateTime
		Public Property DataDesligamento As DateTime
		Public Property RG As Long
		Public Property IDTipoFuncionario As Long
		Public Property EstadoCivil As String
		Public Property Ativo As Boolean
		Public Property Senha As String
		Public Property IDResponsavelCadastro As Long
		Public Property Enderecos As List(Of Enderecos)
		Public Property Telefones As List(Of Telefones)
	End Class
End Namespace