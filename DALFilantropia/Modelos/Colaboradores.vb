Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Colaboradores
		Public Enum Campos
			ID
			IDPessoa
			DataInativacao
			DiaContribuicao
			ValorContrinuicao
			IDPeriodicidade
			IDChamadaOriginaria
			UltimaContribuicao
			DataCadastro
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDPessoa As Int64
		Public Property DataInativacao As Date
		Public Property DiaContribuicao As Int16
		Public Property ValorContribuicao As Single
		<Required>
		Public Property IDPeriodicidade As Int64
		<Required>
		Public Property IDChamadaOriginaria As Int64
		Public Property UltimaContribuicao As Date
		<Required>
		Public Property DataCadastro As Date
	End Class
End Namespace