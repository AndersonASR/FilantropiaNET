Namespace Modelos
	Partial Public Class Agendamentos
		Public Enum Campos
			ID
			IDChamada
			IDInstituto
			Inicio
			Valor
			UltimaContribuicao
			IDPessoaTelefone
			IDTelefonista
		End Enum

		Public Property ID As Long
		Public Property IDChamada As Long
		Public Property IDInstituto As Long
		Public Property Inicio As DateTime
		Public Property Valor As Single
		Public Property UltimaContribuicao As DateTime
		Public Property IDPessoaTelefone As Long
		Public Property IDTelefonista As Long
	End Class
End Namespace