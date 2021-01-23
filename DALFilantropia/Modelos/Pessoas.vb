Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Pessoas
		Public Enum Campos
			ID
			CPFCNPJ
			IDTipoPessoa
			IDEstadoCivil
			IDResponsavelCadastro
			Nome
			DataRestricao
		End Enum

		<Required>
		Public Property ID As Long
		Public Property CPFCNPJ As String
		<Required>
		Public Property IDTipoPessoa As Long
		<Required>
		Public Property IDEstadoCivil As Long
		<Required>
		Public Property IDResponsavelCadastro As Long
		<Required>
		Public Property Nome As String
		Public Property DataRestricao As DateTime
	End Class
End Namespace