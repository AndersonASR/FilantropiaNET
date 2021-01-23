Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class EstadosCivis
		Public Enum Campos
			ID
			EstadoCivil
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property EstadoCivil As String
	End Class
End Namespace