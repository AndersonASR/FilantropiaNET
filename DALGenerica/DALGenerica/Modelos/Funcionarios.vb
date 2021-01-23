Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Funcionarios
		Public Enum Campos
			ID
			IDPessoa
			DataAdmissao
			DataDesligamento
			RG
			IDTipoFuncionario
			IDResponsavelCadastro
			Senha
			Ativo
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDPessoa As Int64
		<Required>
		Public Property DataAdmissao As DateTime
		Public Property DataDesligamento As DateTime
		<Required>
		Public Property RG As String
		<Required>
		Public Property IDTipoFuncionario As Int64
		<Required>
		Public Property IDResponsavelCadastro As Int64
		Public Property Senha As String
		<Required>
		Public Property Ativo As Boolean
	End Class
End Namespace