Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class PessoasTelefones
		Public Enum Campos
			ID
			IDPessoa
			IDTelefone
			IDTipoTelefone
			IDContato
			IDResponsavelCadastro
			SMS
			WhatsApp
			Padrao
			DataRegistro
			DataDesativacao
			MotivoDesativacao
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDPessoa As Long
		<Required>
		Public Property IDTelefone As Long
		<Required>
		Public Property IDTipoTelefone As Long
		<Required>
		Public Property IDContato As Long
		<Required>
		Public Property IDResponsavelCadastro As Long
		Public Property Padrao As Long
		Public Property SMS As Boolean
		Public Property WhatsApp As Boolean
		Public Property DataRegistro As DateTime
		Public Property DataDesativacao As DateTime
		Public Property MotivoDesativacao As String
	End Class
End Namespace