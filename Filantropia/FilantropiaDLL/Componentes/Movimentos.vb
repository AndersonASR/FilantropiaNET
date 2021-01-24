Imports DALFilantropia
Imports DALFilantropia.DAL
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class Movimento
		Public Property ID As Int64
		Public Property Agendamento As Agendamento
		Public Property Telefone As Telefone
		Public Property Telefonista As Funcionario
		Public Property Instituto As Instituto
		Public Property Apanhador As Funcionario
		<Display(Name:="Data/Hora Agendada")>
		Public Property DataHoraAgendada As DateTime
		<Display(Name:="Endereço")>
		Public Property Endereco As Endereco
		<Display(Name:="Forma de Pagamento")>
		Public Property FormaPagamento As FormaPagamento
		<Display(Name:="Agência")>
		Public Property Agencia As Int16
		Public Property Conta As Int64
		<Display(Name:="Dígito")>
		Public Property DigitoConta As Int16
		Public Property Banco As Banco
		<Display(Name:="Momento da Confirmação")>
		Public Property DataHoraConfirmacao As DateTime
		<Display(Name:="Valor Previsto")>
		Public Property ValorPrevisto As Single
		<Display(Name:="Valor Recebido")>
		Public Property ValorRecebido As Single
		<Display(Name:="Número do Recibo")>
		Public Property NumeroRecibo As String
	End Class

	Public Class Movimentos

		Private RMovimentos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Movimentos)
		Private LMovimentos As List(Of DAL.Modelos.Movimentos)

		Public Sub New(Conexao As String)
			RMovimentos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Movimentos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Movimento)
			Dim TP As List(Of Movimento) = Nothing

			RMovimentos.LimparParametros()
			LMovimentos = RMovimentos.ObterTodos

			If LMovimentos.Count > 0 Then

				TP = New List(Of Movimento)

				For X As Int16 = 0 To LMovimentos.Count - 1
					Dim T As New Movimento

					Popular(LMovimentos(X), T)
					'T.ID = LMovimentos(X).ID
					'T.Movimento = LMovimentos(X).Movimento
					'T.Alias = LMovimentos(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As Movimento
			Dim TP As Movimento = Nothing

			RMovimentos.LimparParametros()
			RMovimentos.AdicionarParametro(DALFilantropia.DAL.Modelos.Movimentos.Campos.IDAgendamento.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LMovimentos = RMovimentos.Obter

			If LMovimentos.Count > 0 Then

				TP = New Movimento

				Popular(LMovimentos(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Movimento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Movimentos

				Popular(Dados, B)

				RMovimentos.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Movimento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Movimentos

				Popular(Dados, B)

				RMovimentos.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Movimento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Movimentos

				Popular(Dados, B)

				RMovimentos.AdicionarParametro(DAL.Modelos.Movimentos.Campos.ID.ToString, CompareType.Igual, B.ID)
				RMovimentos.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace