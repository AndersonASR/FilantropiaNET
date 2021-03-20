Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class PessoasEnderecos
		Public Enum Campos
			ID
			IDPessoa
			IDEndereco
			IDTipoEndereco
			IDResponsavelCadastro
			DataRegistro
			Padrao
			DataDesativacao
			MotivoDesativacao
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDPEssoa As Long
		<Required>
		Public Property IDEndereco As Long
		<Required>
		Public Property IDTipoEndereco As Long
		<Required>
		Public Property IDResponsavelCadastro As Long
		<Required>
		Public Property DataRegistro As DateTime
		Public Property Padrao As Boolean
		Public Property DataDesativacao As DateTime
		Public Property MotivoDesativacao As String
	End Class
End Namespace