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
		Public Property ID As Int64
		<Required>
		Public Property DDD As Int16
		<Required>
		Public Property Prefixo As String
		<Required>
		Public Property Sulfixo As String
	End Class
End Namespace