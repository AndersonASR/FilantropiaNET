Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class TiposPessoas
		Public Enum Campos
			ID
			Tipo
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property Tipo As String
	End Class
End Namespace