Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Bancos
		Public Enum Campos
			ID
			Numero
			BANCO
			Apelido
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property Numero As Int64
		<Required>
		Public Property Banco As String
		Public Property Apelido As String
	End Class
End Namespace