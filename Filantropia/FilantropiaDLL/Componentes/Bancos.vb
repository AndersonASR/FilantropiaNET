Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Banco
		Public Property ID As Long
		Public Property Numero As Int64
		Public Property Banco As String
		Public Property Apelido As String
	End Class

	Public Class Bancos

		Private RBancos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Bancos)
		Private LBancos As List(Of DAL.Modelos.Bancos)

		Public Sub New(Conexao As String)
			RBancos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Bancos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Banco)
			Dim TP As List(Of Banco) = Nothing

			RBancos.LimparParametros()
			LBancos = RBancos.ObterTodos

			If LBancos.Count > 0 Then

				TP = New List(Of Banco)

				For X As Int16 = 0 To LBancos.Count - 1
					Dim T As New Banco

					Popular(LBancos(X), T)
					'T.ID = LBancos(X).ID
					'T.Banco = LBancos(X).Banco
					'T.Alias = LBancos(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(ID As Int64) As Banco
			Dim TP As Banco = Nothing

			RBancos.LimparParametros()
			RBancos.AdicionarParametro(DALFilantropia.DAL.Modelos.Bancos.Campos.ID.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, ID)
			LBancos = RBancos.Obter

			If LBancos.Count > 0 Then

				TP = New Banco

				Popular(LBancos(0), TP)
			End If

			Return TP

		End Function

		Public Function Obter(Nome As String) As Banco
			Dim TP As Banco = Nothing

			RBancos.LimparParametros()
			RBancos.AdicionarParametro(DALFilantropia.DAL.Modelos.Bancos.Campos.BANCO.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Nome)
			LBancos = RBancos.Obter

			If LBancos.Count > 0 Then

				TP = New Banco

				Popular(LBancos(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Banco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Bancos

				Popular(Dados, B)

				RBancos.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Banco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Bancos

				Popular(Dados, B)

				RBancos.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Banco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Bancos

				Popular(Dados, B)

				RBancos.AdicionarParametro(DAL.Modelos.Bancos.Campos.ID.ToString, CompareType.Igual, B.ID)
				RBancos.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace