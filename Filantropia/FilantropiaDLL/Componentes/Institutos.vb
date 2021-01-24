Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Instituto
		Public Property ID As Long
		Public Property Nome As Long
		Public Property CNPJ As Long
	End Class

	Public Class Institutos

		Private RInstitutos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Institutos)
		Private LInstitutos As List(Of DAL.Modelos.Institutos)

		Public Sub New(Conexao As String)
			RInstitutos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Institutos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Instituto)
			Dim TP As List(Of Instituto) = Nothing

			RInstitutos.LimparParametros()
			LInstitutos = RInstitutos.ObterTodos

			If LInstitutos.Count > 0 Then

				TP = New List(Of Instituto)

				For X As Int16 = 0 To LInstitutos.Count - 1
					Dim T As New Instituto

					Popular(LInstitutos(X), T)
					'T.ID = LInstitutos(X).ID
					'T.Instituto = LInstitutos(X).Instituto
					'T.Alias = LInstitutos(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As Instituto
			Dim TP As Instituto = Nothing

			RInstitutos.LimparParametros()
			RInstitutos.AdicionarParametro(DALFilantropia.DAL.Modelos.Institutos.Campos.Nome.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LInstitutos = RInstitutos.Obter

			If LInstitutos.Count > 0 Then

				TP = New Instituto

				Popular(LInstitutos(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Instituto) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Institutos

				Popular(Dados, B)

				RInstitutos.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Instituto) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Institutos

				Popular(Dados, B)

				RInstitutos.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Instituto) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Institutos

				Popular(Dados, B)

				RInstitutos.AdicionarParametro(DAL.Modelos.Institutos.Campos.ID.ToString, CompareType.Igual, B.ID)
				RInstitutos.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace