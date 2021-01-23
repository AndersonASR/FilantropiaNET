Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class FormasPagamentos
		Public Enum Campos
			ID
			FormaPagamento
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property FormaPagamento As String
	End Class
End Namespace