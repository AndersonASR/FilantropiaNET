Imports DALFilantropia
Imports DALFilantropia.DAL
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class Agendamento
		Public Property ID As Long
		Public Property Chamada As HistoricoChamada
		Public Property Instituto As Instituto
		Public Property Inicio As DateTime
		Public Property Valor As Single
		<Display(Name:="Data da Última Contribuição")>
		Public Property UltimaContribuicao As DateTime
		Public Property Telefone As Telefone
		Public Property Telefonista As Funcionario
	End Class

	Public Class Agendamentos

		Private RAgendamentos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Agendamentos)
		Private LAgendamentos As List(Of DAL.Modelos.Agendamentos)

		Public Sub New(Conexao As String)
			RAgendamentos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Agendamentos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Agendamento)
			Dim TP As List(Of Agendamento) = Nothing

			RAgendamentos.LimparParametros()
			LAgendamentos = RAgendamentos.ObterTodos

			If LAgendamentos.Count > 0 Then

				TP = New List(Of Agendamento)

				For X As Int16 = 0 To LAgendamentos.Count - 1
					Dim T As New Agendamento

					Popular(LAgendamentos(X), T)
					'T.ID = LAgendamentos(X).ID
					'T.Agendamento = LAgendamentos(X).Agendamento
					'T.Alias = LAgendamentos(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As Agendamento
			Dim TP As Agendamento = Nothing

			RAgendamentos.LimparParametros()
			RAgendamentos.AdicionarParametro(DALFilantropia.DAL.Modelos.Agendamentos.Campos.IDPessoaTelefone.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LAgendamentos = RAgendamentos.Obter

			If LAgendamentos.Count > 0 Then

				TP = New Agendamento

				Popular(LAgendamentos(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Agendamento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Agendamentos

				Popular(Dados, B)

				RAgendamentos.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Agendamento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Agendamentos

				Popular(Dados, B)

				RAgendamentos.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Agendamento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Agendamentos

				Popular(Dados, B)

				RAgendamentos.AdicionarParametro(DAL.Modelos.Agendamentos.Campos.ID.ToString, CompareType.Igual, B.ID)
				RAgendamentos.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace