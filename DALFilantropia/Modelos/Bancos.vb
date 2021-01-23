Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Bancos
		Public Enum Campos
			ID
			Numero
			BANCO
			[Alias]
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property Numero As Int64
		<Required>
		Public Property Banco As String
		Public Property [Alias] As String
	End Class
End Namespace