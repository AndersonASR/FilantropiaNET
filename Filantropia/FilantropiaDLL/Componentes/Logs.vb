Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Log
		Public Property ID As Long
		Public Property DataHora As DateTime
		Public Property Acao As String
		Public Property Pessoa As Pessoas
		Public Property Descricao As String
	End Class

	Public Class Logs

		Private RLogs As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Log)
		Private LLogs As List(Of DAL.Modelos.Log)

		Public Sub New(Conexao As String)
			RLogs = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Log)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Log)
			Dim TP As List(Of Log) = Nothing

			RLogs.LimparParametros()
			LLogs = RLogs.ObterTodos

			If LLogs.Count > 0 Then

				TP = New List(Of Log)

				For X As Int16 = 0 To LLogs.Count - 1
					Dim T As New Log

					Popular(LLogs(X), T)
					'T.ID = LLogs(X).ID
					'T.Log = LLogs(X).Log
					'T.Alias = LLogs(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Inicio As DateTime, Fim As DateTime, Acao As String, Usuario As Pessoa) As Log
			Dim TP As Log = Nothing

			RLogs.LimparParametros()
			RLogs.AdicionarParametro(DALFilantropia.DAL.Modelos.Log.Campos.DataHora.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Entre, Inicio, Fim)
			If Acao <> "" Then RLogs.AdicionarParametro(DALFilantropia.DAL.Modelos.Log.Campos.Acao.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Igual, Acao)
			If Not Usuario Is Nothing Then RLogs.AdicionarParametro(DALFilantropia.DAL.Modelos.Log.Campos.IDPessoa.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Igual, Usuario.ID)
			LLogs = RLogs.Obter

			If LLogs.Count > 0 Then

				TP = New Log

				Popular(LLogs(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Log) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Log

				Popular(Dados, B)

				RLogs.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function InserirNovo(DataHora As DateTime, Acao As String, IDUsuario As Int64, Descricao As String) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Log
				B.DataHora = DataHora
				B.Acao = Acao
				B.IDPessoa = IDUsuario
				B.Descricao = Descricao

				RLogs.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Log) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Log

				Popular(Dados, B)

				RLogs.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Log) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Log

				Popular(Dados, B)

				RLogs.AdicionarParametro(DAL.Modelos.Log.Campos.ID.ToString, CompareType.Igual, B.ID)
				RLogs.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace