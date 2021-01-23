Namespace Modelos
	Partial Public Class Bancos
		Public Enum Campos
			ID
			Numero
			BANCO
			[Alias]
		End Enum

		Public Property ID As Long
		Public Property Numero As Int64
		Public Property Banco As String
		Public Property [Alias] As String
	End Class
End Namespace