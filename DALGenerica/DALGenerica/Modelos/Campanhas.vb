Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Campanhas
		Public Enum Campos
			ID
			IDInstituto
			Campanha
			Descricao
			Inicio
			Fim
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDInstituto As Long
		<Required>
		Public Property Campanha As String
		<Required>
		Public Property Descricao As String
		<Required>
		Public Property Inicio As DateTime
		Public Property Fim As DateTime
	End Class
End Namespace