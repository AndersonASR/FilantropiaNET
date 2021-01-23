Namespace Modelos
	Partial Public Class PessoasEnderecos
		Public Enum Campos
			ID
			IDPessoa
			IDEndereco
			IDTipoEndereco
			IDResponsavelCadastro
			DataRegistro
		End Enum

		Public Property ID As Long
		Public Property IDPEssoa As Long
		Public Property IDEndereco As Long
		Public Property IDTipoEndereco As Long
		Public Property IDResponsavelCadastro As Long
		Public Property DataRegistro As DateTime
	End Class
End Namespace