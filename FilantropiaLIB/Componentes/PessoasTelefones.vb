Namespace Modelos
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
			DataRegistro
		End Enum

		Public Property ID As Long
		Public Property IDPessoa As Long
		Public Property IDTelefone As Long
		Public Property IDTipoTelefone As Long
		Public Property IDContato As Long
		Public Property IDResponsavelCadastro As Long
		Public Property SMS As Boolean
		Public Property WhatsApp As Boolean
		Public Property DataRegistro As DateTime
	End Class
End Namespace