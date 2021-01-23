Namespace Modelos
	Partial Public Class Enderecos
		Public Enum Campos
			ID
			Logradouro
			Numero
			Complemento
			Bairro
			Cidade
			UF
			CEP
			OBS
		End Enum

		Public Property ID As Long
		Public Property Logradouro As String
		Public Property Numero As String
		Public Property Complemento As String
		Public Property Bairro As String
		Public Property Cidade As String
		Public Property UF As String
		Public Property CEP As Int64
		Public Property OBS As String
	End Class
End Namespace