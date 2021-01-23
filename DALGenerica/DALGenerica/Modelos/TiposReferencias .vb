Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class TiposReferencias
		Public Enum Campos
			ID
			Referencia
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property Referencia As String
	End Class
End Namespace