Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Log
		Public Enum Campos
			ID
			DataHora
			Acao
			IDPessoa
			Descricao
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property DataHora As DateTime
		<Required>
		Public Property Acao As String
		<Required>
		Public Property IDPessoa As Long
		<Required>
		Public Property Descricao As String
	End Class
End Namespace