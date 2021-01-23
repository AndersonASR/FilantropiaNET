Namespace Modelos
	Partial Public Class Colaborador
		Public Enum Campos
			ID
			CPFCNPJ
			Nome
			DataRestricao
			MotivoRestricao
			EstadoCivil
			Enderecos
			Telefones
			Chamadas
			Contribuicoes
		End Enum

		Public Property ID As Long
		Public Property CPFCNPJ As Long
		Public Property Nome As String
		Public Property DataRestricao As DateTime
		Public Property MotivoRestricao As MotivosRestricoes
		Public Property EstadoCivil As EstadosCivis
		Public Property Enderecos As List(Of Enderecos)
		Public Property Telefones As List(Of Telefones)
		Public Property Chamadas As List(Of HistoricoChamadas)
		Public Property Contribuicoes As List(Of Movimentos)
		Public Property Agendamentos As List(Of Agendamentos)
	End Class
End Namespace