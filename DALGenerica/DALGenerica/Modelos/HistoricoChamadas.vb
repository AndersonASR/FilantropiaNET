Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class HistoricoChamadas
		Public Enum Campos
			ID
			IDPessoaTelefone
			DataHora
			Atendeu
			IDFuncionario
			IDInstituto
			IDCampanha
			NumeroTentativas
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDPessoaTelefone As Long
		<Required>
		Public Property DataHora As DateTime
		<Required>
		Public Property Atendeu As Boolean
		<Required>
		Public Property IDFuncionario As Long
		<Required>
		Public Property IDInstituto As Long
		Public Property IDCampanha As Long
		Public Property NumeroTentativas As Int16
	End Class
End Namespace