Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class HistoricoChamada
		Public Property ID As Int64
		Public Property Colaborador As Colaborador
		Public Property Telefone As Telefone
		<Display(Name:="Data/Hora da Chamada")>
		Public Property DataHora As DateTime
		Public Property Atendeu As Boolean
		Public Property Funcionario As Funcionario
		Public Property Instituto As Instituto
		Public Property Campanha As Campanha
		<Display(Name:="Número de Tentativas")>
		Public Property NumeroTentativas As Int16
	End Class

	Public Class HistoricosChamadas

		Private RHistoricosChamadas As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.HistoricoChamadas)
		Private LHistoricosChamadas As List(Of DAL.Modelos.HistoricoChamadas)
		Private _Colaboradores As Colaboradores
		Private _Telefones As Telefones
		Private _Funcionarios As Funcionarios
		Private _Institutos As Institutos
		Private _Campanhas As Campanhas


		Public Sub New(Conexao As String)
			RHistoricosChamadas = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.HistoricoChamadas)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)

			_Colaboradores = New Colaboradores(Conexao)
			_Telefones = New Telefones(Conexao)
			_Funcionarios = New Funcionarios(Conexao)
			_Institutos = New Institutos(Conexao)
			_Campanhas = New Campanhas(Conexao)
		End Sub

		Public Function ObterTodos() As List(Of HistoricoChamada)
			Dim TP As List(Of HistoricoChamada) = Nothing

			RHistoricosChamadas.LimparParametros()
			LHistoricosChamadas = RHistoricosChamadas.ObterTodos

			If LHistoricosChamadas.Count > 0 Then

				TP = New List(Of HistoricoChamada)

				For X As Int16 = 0 To LHistoricosChamadas.Count - 1
					Dim T As New HistoricoChamada

					Popular(LHistoricosChamadas(X), T)
					'T.ID = LHistoricosChamadas(X).ID
					'T.HistoricoChamada = LHistoricosChamadas(X).HistoricoChamada
					'T.Alias = LHistoricosChamadas(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function ObterTodos(Inicio As Date) As List(Of HistoricoChamada)
			Dim TP As List(Of HistoricoChamada) = Nothing

			RHistoricosChamadas.LimparParametros()
			RHistoricosChamadas.AdicionarParametro(DAL.Modelos.HistoricoChamadas.Campos.DataHora.ToString, CompareType.MaiorOuIgualA, Inicio)
			LHistoricosChamadas = RHistoricosChamadas.Obter

			If LHistoricosChamadas.Count > 0 Then

				TP = New List(Of HistoricoChamada)

				For X As Int16 = 0 To LHistoricosChamadas.Count - 1
					Dim T As New HistoricoChamada

					Popular(LHistoricosChamadas(X), T)
					'T.ID = LHistoricosChamadas(X).ID
					'T.HistoricoChamada = LHistoricosChamadas(X).HistoricoChamada
					'T.Alias = LHistoricosChamadas(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As HistoricoChamada
			Dim TP As HistoricoChamada = Nothing

			RHistoricosChamadas.LimparParametros()
			RHistoricosChamadas.AdicionarParametro(DALFilantropia.DAL.Modelos.HistoricoChamadas.Campos.IDPessoaTelefone.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LHistoricosChamadas = RHistoricosChamadas.Obter

			If LHistoricosChamadas.Count > 0 Then

				TP = New HistoricoChamada

				Popular(LHistoricosChamadas(0), TP)
			End If

			Return TP

		End Function

		Public Function Obter(IDColaborador As Int64) As List(Of HistoricoChamada)
			Dim TP As List(Of HistoricoChamada) = Nothing

			RHistoricosChamadas.LimparParametros()
			RHistoricosChamadas.AdicionarParametro(DALFilantropia.DAL.Modelos.HistoricoChamadas.Campos.IDPessoaTelefone.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, IDColaborador)
			LHistoricosChamadas = RHistoricosChamadas.Obter

			If LHistoricosChamadas.Count > 0 Then

				TP = New List(Of HistoricoChamada)

				Popular(LHistoricosChamadas(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As HistoricoChamada) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.HistoricoChamadas

				Popular(Dados, B)

				RHistoricosChamadas.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As HistoricoChamada) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.HistoricoChamadas

				Popular(Dados, B)

				RHistoricosChamadas.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As HistoricoChamada) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.HistoricoChamadas

				Popular(Dados, B)

				RHistoricosChamadas.AdicionarParametro(DAL.Modelos.HistoricoChamadas.Campos.ID.ToString, CompareType.Igual, B.ID)
				RHistoricosChamadas.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace