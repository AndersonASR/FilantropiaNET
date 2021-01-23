Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class PessoasRestricoes
		Public Enum Campos
			ID
			IDColaborador
			IDOperador
			IDMotivo
			Data
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDColaborador As Long
		<Required>
		Public Property IDOperador As Long
		<Required>
		Public Property IDMotivo As Long
		<Required>
		Public Property Data As DateTime
	End Class
End Namespace