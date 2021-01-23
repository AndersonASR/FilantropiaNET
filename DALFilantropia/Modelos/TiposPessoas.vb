Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class TiposPessoas
		Public Enum Campos
			ID
			Tipo
			Funcionario
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property Tipo As String
		<Required>
		Public Property Funcionario As Boolean
	End Class
End Namespace