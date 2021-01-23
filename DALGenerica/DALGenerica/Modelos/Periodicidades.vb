Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Periodicidades
		Public Enum Campos
			ID
			Periodo
			Meses
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property Periodo As String
		<Required>
		Public Property Meses As Int16
	End Class
End Namespace