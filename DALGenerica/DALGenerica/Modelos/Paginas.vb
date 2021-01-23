Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Paginas
		Public Enum Campos
			ID
			Pagina
			Publica
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property Pagina As String
		Public Property Publica As Boolean
	End Class
End Namespace