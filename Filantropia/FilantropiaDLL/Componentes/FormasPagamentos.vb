Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class FormaPagamento
		Public Property ID As Long
		Public Property FormaPagamento As String
	End Class

	Public Class FormasPagamentos

		Private RFormasPagamentos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.FormasPagamentos)
		Private LFormasPagamentos As List(Of DAL.Modelos.FormasPagamentos)

		Public Sub New(Conexao As String)
			RFormasPagamentos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.FormasPagamentos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of FormaPagamento)
			Dim TP As List(Of FormaPagamento) = Nothing

			RFormasPagamentos.LimparParametros()
			LFormasPagamentos = RFormasPagamentos.ObterTodos

			If LFormasPagamentos.Count > 0 Then

				TP = New List(Of FormaPagamento)

				For X As Int16 = 0 To LFormasPagamentos.Count - 1
					Dim T As New FormaPagamento

					Popular(LFormasPagamentos(X), T)
					'T.ID = LFormasPagamentos(X).ID
					'T.FormaPagamento = LFormasPagamentos(X).FormaPagamento
					'T.Alias = LFormasPagamentos(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As FormaPagamento
			Dim TP As FormaPagamento = Nothing

			RFormasPagamentos.LimparParametros()
			RFormasPagamentos.AdicionarParametro(DALFilantropia.DAL.Modelos.FormasPagamentos.Campos.FormaPagamento.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LFormasPagamentos = RFormasPagamentos.Obter

			If LFormasPagamentos.Count > 0 Then

				TP = New FormaPagamento

				Popular(LFormasPagamentos(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As FormaPagamento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.FormasPagamentos

				Popular(Dados, B)

				RFormasPagamentos.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As FormaPagamento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.FormasPagamentos

				Popular(Dados, B)

				RFormasPagamentos.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As FormaPagamento) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.FormasPagamentos

				Popular(Dados, B)

				RFormasPagamentos.AdicionarParametro(DAL.Modelos.FormasPagamentos.Campos.ID.ToString, CompareType.Igual, B.ID)
				RFormasPagamentos.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace