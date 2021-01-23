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
	End Class
End Namespace