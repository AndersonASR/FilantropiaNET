Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Institutos
		Public Enum Campos
			ID
			IDPessoa
			Nome
			CNPJ
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDPessoa As Long
		<Required>
		Public Property Nome As Long
		Public Property CNPJ As Long
	End Class
End Namespace