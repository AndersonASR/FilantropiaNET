Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class MotivosRestricoes
		Public Enum Campos
			ID
			Motivo
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property Motivo As String
	End Class
End Namespace