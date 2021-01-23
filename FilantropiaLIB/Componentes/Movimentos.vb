Namespace Modelos

	Public Class Movimentos
		Public Enum Campos
			ID
			IDAgendamento
			IDPessoaTelefone
			IDTelefonista
			IDInstituto
			IDApanhador
			DataHoraAgendada
			IDPessoaEndereco
			IDFormaPagamento
			Agencia
			Conta
			DigitoConta
			IDBanco
			DataHoraConfirmacao
			ValorPrevisto
			ValorRecebido
			NumeroRecibo
		End Enum

		Public Property ID As Int64
		Public Property IDAgendamento As Int64
		Public Property IDPessoaTelefone As Int64
		Public Property IDTelefonista As Int64
		Public Property IDInstituto As Int64
		Public Property IDApanhador As Int64
		Public Property DataHoraAgendada As DateTime
		Public Property IDPessoaEndereco As Int64
		Public Property IDFormaPagamento As Int64
		Public Property Agencia As Int16
		Public Property Conta As Int64
		Public Property DigitoConta As Int16
		Public Property IDBanco As Int64
		Public Property DataHoraConfirmacao As DateTime
		Public Property ValorPrevisto As Single
		Public Property ValorRecebido As Single
		Public Property NumeroRecibo As String
	End Class
End Namespace