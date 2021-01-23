Namespace Modelos
	Partial Public Class HistoricoChamadas
		Public Enum Campos
			IDPessoaTelefone
			DataHora
			Atendeu
			IDFuncionario
			IDInstituto
			IDCampanha
			NumeroTentativas
		End Enum

		Public Property IDPessoaTelefone As Long
		Public Property DataHora As DateTime
		Public Property Atendeu As Boolean
		Public Property IDFuncionario As Long
		Public Property IDInstituto As Long
		Public Property IDCampanha As Long
		Public Property NumeroTentativas As Int16
	End Class
End Namespace