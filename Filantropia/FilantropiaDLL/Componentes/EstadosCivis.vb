Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Enumeradores
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class EstadoCivil
		Public Property ID As Long
		<Display(Name:="Estado Civil")>
		Public Property EstadoCivil As String
	End Class

	Public Class EstadosCivis
		Private REstadosCivis As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.EstadosCivis)
		Private LEstadosCivis As List(Of DALFilantropia.DAL.Modelos.EstadosCivis)

		Public Sub New(Conexao As String)
			REstadosCivis = New DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.EstadosCivis)(DALFilantropia.DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of EstadoCivil)
			Dim TP As List(Of EstadoCivil) = Nothing

			REstadosCivis.LimparParametros()
			LEstadosCivis = REstadosCivis.ObterTodos

			If LEstadosCivis.Count > 0 Then

				TP = New List(Of EstadoCivil)

				For X As Int16 = 0 To LEstadosCivis.Count - 1
					Dim T As New EstadoCivil

					Popular(LEstadosCivis(X), T)
					'T.ID = LEstadosCivis(X).ID
					'T.EstadoCivil = LEstadosCivis(X).EstadoCivil
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(ID As Int64) As EstadoCivil
			Dim EC As EstadoCivil = Nothing

			REstadosCivis.LimparParametros()
			REstadosCivis.AdicionarParametro(DAL.Modelos.EstadosCivis.Campos.ID.ToString, CompareType.Igual, ID)
			LEstadosCivis = REstadosCivis.Obter

			If LEstadosCivis.Count > 0 Then
				EC = New EstadoCivil
				Popular(LEstadosCivis(0), EC)
			End If

			Return EC
		End Function

		Public Function InserirNovo(Dados As EstadoCivil) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.EstadosCivis

				Popular(Dados, B)

				REstadosCivis.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As EstadoCivil) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.EstadosCivis

				Popular(Dados, B)

				REstadosCivis.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As EstadoCivil) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.EstadosCivis

				Popular(Dados, B)

				REstadosCivis.AdicionarParametro(DAL.Modelos.EstadosCivis.Campos.ID.ToString, CompareType.Igual, B.ID)
				REstadosCivis.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace