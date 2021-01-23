Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Telefones
		Public Enum Campos
			ID
			DDD
			Prefixo
			Sulfixo
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property DDD As Integer
		<Required>
		Public Property Prefixo As Integer
		<Required>
		Public Property Sulfixo As Integer
	End Class
End Namespace