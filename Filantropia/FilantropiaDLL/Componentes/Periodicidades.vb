Imports DALFilantropia
Imports DALFilantropia.DAL

Namespace Componentes

	Partial Public Class Periodicidade
		Public Property ID As Long
		Public Property Periodo As String
		Public Property Meses As Int64
	End Class

	Public Class Periodicidades
		Private RPeriodicidades As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Periodicidades)
		Private LPeriodicidades As List(Of DALFilantropia.DAL.Modelos.Periodicidades)

		Public Sub New(Conexao As String)
			RPeriodicidades = New DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Periodicidades)(DALFilantropia.DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Periodicidade)
			Dim TP As List(Of Periodicidade) = Nothing

			RPeriodicidades.LimparParametros()
			LPeriodicidades = RPeriodicidades.ObterTodos

			If LPeriodicidades.Count > 0 Then

				TP = New List(Of Periodicidade)

				For X As Int16 = 0 To LPeriodicidades.Count - 1
					Dim T As New Periodicidade
					Popular(LPeriodicidades(X), T)
					'T.ID = LPeriodicidades(X).ID
					'T.Periodo = LPeriodicidades(X).Periodo
					'T.Meses = LPeriodicidades(X).Meses
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(ID As Int64) As Periodicidade
			Dim TP As Periodicidade = Nothing

			RPeriodicidades.LimparParametros()
			RPeriodicidades.AdicionarParametro(DALFilantropia.DAL.Modelos.Periodicidades.Campos.ID.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, ID)
			LPeriodicidades = RPeriodicidades.Obter

			If LPeriodicidades.Count > 0 Then

				TP = New Periodicidade

				Popular(LPeriodicidades(0), TP)
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As Periodicidade
			Dim TP As Periodicidade = Nothing

			RPeriodicidades.LimparParametros()
			RPeriodicidades.AdicionarParametro(DALFilantropia.DAL.Modelos.Periodicidades.Campos.Periodo.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LPeriodicidades = RPeriodicidades.Obter

			If LPeriodicidades.Count > 0 Then

				TP = New Periodicidade

				Popular(LPeriodicidades(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Periodicidade) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Periodicidades

				Popular(Dados, B)

				RPeriodicidades.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Periodicidade) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.periodicidades

				Popular(Dados, B)

				RPeriodicidades.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Periodicidade) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.periodicidades

				Popular(Dados, B)

				RPeriodicidades.AdicionarParametro(DAL.Modelos.periodicidades.Campos.ID.ToString, CompareType.Igual, B.ID)
				RPeriodicidades.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class
End Namespace