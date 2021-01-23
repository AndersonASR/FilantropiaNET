Namespace Modelos
	Partial Public Class Campanhas
		Public Enum Campos
			ID
			IDInstituto
			Campanha
			Descricao
			Inicio
			Fim
		End Enum

		Public Property ID As Long
		Public Property IDInstituto As Long
		Public Property Campanha As String
		Public Property Descricao As String
		Public Property Inicio As DateTime
		Public Property Fim As DateTime
	End Class
End Namespace