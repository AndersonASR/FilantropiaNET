Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Enumeradores

Namespace Componentes

	Partial Public Class MotivoRestricao
		Public Property ID As Long
		Public Property Motivo As String
	End Class

	Public Class MotivosRestricoes
		Private RMotivosRestricoes As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.MotivosRestricoes)
		Private LMotivosRestricoes As List(Of DALFilantropia.DAL.Modelos.MotivosRestricoes)

		Public Sub New(Conexao As String)
			RMotivosRestricoes = New DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.MotivosRestricoes)(DALFilantropia.DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of MotivoRestricao)
			Dim TP As List(Of MotivoRestricao) = Nothing

			RMotivosRestricoes.LimparParametros()
			LMotivosRestricoes = RMotivosRestricoes.ObterTodos

			If LMotivosRestricoes.Count > 0 Then

				TP = New List(Of MotivoRestricao)

				For X As Int16 = 0 To LMotivosRestricoes.Count - 1
					Dim T As New MotivoRestricao
					Popular(LMotivosRestricoes(X), T)
					'T.ID = LMotivosRestricoes(X).ID
					'T.Motivo = LMotivosRestricoes(X).Motivo
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(ID As Int64) As MotivoRestricao
			Dim TP As MotivoRestricao = Nothing

			RMotivosRestricoes.LimparParametros()
			RMotivosRestricoes.AdicionarParametro(DALFilantropia.DAL.Modelos.MotivosRestricoes.Campos.ID.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, ID)
			LMotivosRestricoes = RMotivosRestricoes.Obter

			If LMotivosRestricoes.Count > 0 Then

				TP = New MotivoRestricao

				Popular(LMotivosRestricoes(0), TP)
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As MotivoRestricao
			Dim TP As MotivoRestricao = Nothing

			RMotivosRestricoes.LimparParametros()
			RMotivosRestricoes.AdicionarParametro(DALFilantropia.DAL.Modelos.MotivosRestricoes.Campos.Motivo.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LMotivosRestricoes = RMotivosRestricoes.Obter

			If LMotivosRestricoes.Count > 0 Then

				TP = New MotivoRestricao

				Popular(LMotivosRestricoes(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As MotivoRestricao) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.MotivosRestricoes

				Popular(Dados, B)

				RMotivosRestricoes.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As MotivoRestricao) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.MotivosRestricoes

				Popular(Dados, B)

				RMotivosRestricoes.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As MotivoRestricao) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.MotivosRestricoes

				Popular(Dados, B)

				RMotivosRestricoes.AdicionarParametro(DAL.Modelos.MotivosRestricoes.Campos.ID.ToString, CompareType.Igual, B.ID)
				RMotivosRestricoes.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class
End Namespace