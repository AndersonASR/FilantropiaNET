Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class Campanha
		Public Property ID As Long
		Public Property Instituto As Instituto
		Public Property Campanha As String
		<Display(Name:="Descrição")>
		Public Property Descricao As String
		Public Property Inicio As DateTime
		Public Property Fim As DateTime
	End Class

	Public Class Campanhas

		Private RCampanhas As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Campanhas)
		Private LCampanhas As List(Of DAL.Modelos.Campanhas)

		Public Sub New(Conexao As String)
			RCampanhas = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Campanhas)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Campanha)
			Dim TP As List(Of Campanha) = Nothing

			RCampanhas.LimparParametros()
			LCampanhas = RCampanhas.ObterTodos

			If LCampanhas.Count > 0 Then

				TP = New List(Of Campanha)

				For X As Int16 = 0 To LCampanhas.Count - 1
					Dim T As New Campanha

					Popular(LCampanhas(X), T)
					'T.ID = LCampanhas(X).ID
					'T.Campanha = LCampanhas(X).Campanha
					'T.Alias = LCampanhas(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As Campanha
			Dim TP As Campanha = Nothing

			RCampanhas.LimparParametros()
			RCampanhas.AdicionarParametro(DALFilantropia.DAL.Modelos.Campanhas.Campos.Campanha.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LCampanhas = RCampanhas.Obter

			If LCampanhas.Count > 0 Then

				TP = New Campanha

				Popular(LCampanhas(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Campanha) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Campanhas

				Popular(Dados, B)

				RCampanhas.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Campanha) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Campanhas

				Popular(Dados, B)

				RCampanhas.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Campanha) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Campanhas

				Popular(Dados, B)

				RCampanhas.AdicionarParametro(DAL.Modelos.Campanhas.Campos.ID.ToString, CompareType.Igual, B.ID)
				RCampanhas.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace