Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Agendamentos
		Public Enum Campos
			ID
			IDChamada
			IDInstituto
			Valor
			IDPessoaTelefone
			IDTelefonista
			DataContribuicao
			Ativo
			ValorExtra
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDChamada As Long
		<Required>
		Public Property IDInstituto As Long
		<Required>
		Public Property Valor As Single
		<Required>
		Public Property IDPessoaTelefone As Long
		<Required>
		Public Property IDTelefonista As Long
		Public Property DataContribuicao As Date
		<Required>
		Public Property Ativo As Boolean
		Public Property ValorExtra As Single
	End Class
End Namespace