Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class PessoaEndereco
		Public Property ID As Long
		Public Property IDPEssoa As Long
		Public Property IDEndereco As Long
		Public Property IDTipoEndereco As Long
		Public Property IDResponsavelCadastro As Long
		<Display(Name:="Data de Registro")>
		Public Property DataRegistro As DateTime
		<Display(Name:="Data da Desativação")>
		Public Property DataDesativacao As DateTime
		Public Property Padrao As Boolean
		<Display(Name:="Motivo da Desativação")>
		Public Property MotivoDesativacao As String
	End Class

	Public Class PessoasEnderecos

		Private RPessoasEnderecos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.PessoasEnderecos)
		Private LPessoasEnderecos As List(Of DAL.Modelos.PessoasEnderecos)

		Public Sub New(Conexao As String)
			RPessoasEnderecos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.PessoasEnderecos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos(Optional IDPessoa As Int64 = 0) As List(Of PessoaEndereco)
			Dim R As List(Of PessoaEndereco) = Nothing

			RPessoasEnderecos.LimparParametros()
			If IDPessoa > 0 Then
				RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
				LPessoasEnderecos = RPessoasEnderecos.Obter
			Else
				LPessoasEnderecos = RPessoasEnderecos.ObterTodos
			End If


			If LPessoasEnderecos.Count > 0 Then

				R = New List(Of PessoaEndereco)

				For Each PT As Modelos.PessoasEnderecos In LPessoasEnderecos
					Dim Dado As New PessoaEndereco
					Popular(PT, Dado)
					R.Add(Dado)
				Next

			End If

			Return R
		End Function

		Public Function ObterIDsEnderecos(Optional IDPessoa As Int64 = 0) As List(Of Int64)
			Dim TP As List(Of Int64) = Nothing

			RPessoasEnderecos.LimparParametros()
			If IDPessoa = 0 Then
				LPessoasEnderecos = RPessoasEnderecos.ObterTodos
			Else
				RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
				LPessoasEnderecos = RPessoasEnderecos.Obter
			End If

			If LPessoasEnderecos.Count > 0 Then

				TP = New List(Of Int64)

				For X As Int16 = 0 To LPessoasEnderecos.Count - 1
					TP.Add(LPessoasEnderecos(X).IDEndereco)
				Next
			End If

			Return TP

		End Function

		Public Function ObterIDsPessoas(IDEndereco As Int64) As List(Of Int64)
			Dim TP As List(Of Int64) = Nothing

			RPessoasEnderecos.LimparParametros()
			RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDEndereco.ToString, CompareType.Igual, IDEndereco)
			LPessoasEnderecos = RPessoasEnderecos.Obter

			If LPessoasEnderecos.Count > 0 Then

				TP = New List(Of Int64)

				For X As Int16 = 0 To LPessoasEnderecos.Count - 1
					TP.Add(LPessoasEnderecos(X).IDEndereco)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(IDPessoa As Int64, IDEndereco As Int64) As PessoaEndereco
			Dim R As PessoaEndereco = Nothing

			RPessoasEnderecos.LimparParametros()
			RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
			RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDEndereco.ToString, CompareType.Igual, IDEndereco)
			LPessoasEnderecos = RPessoasEnderecos.Obter

			If LPessoasEnderecos.Count > 0 Then

				R = New PessoaEndereco

				Popular(LPessoasEnderecos(0), R)
			End If

			Return R
		End Function

		Public Function Obter(IDPessoa As Int64) As PessoaEndereco
			Dim R As PessoaEndereco = Nothing

			RPessoasEnderecos.LimparParametros()
			RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
			LPessoasEnderecos = RPessoasEnderecos.Obter

			If LPessoasEnderecos.Count > 0 Then

				R = New PessoaEndereco

				Popular(LPessoasEnderecos(0), R)
			End If

			Return R
		End Function

		Public Function InserirNovo(Dados As PessoaEndereco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.PessoasEnderecos

				Popular(Dados, B)

				RPessoasEnderecos.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As PessoaEndereco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.PessoasEnderecos

				Popular(Dados, B)

				RPessoasEnderecos.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As PessoaEndereco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.PessoasEnderecos

				Popular(Dados, B)

				RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.ID.ToString, CompareType.Igual, B.ID)
				LPessoasEnderecos = RPessoasEnderecos.Obter
				B = LPessoasEnderecos(0)

				B.DataDesativacao = Now
				B.MotivoDesativacao = Dados.MotivoDesativacao

				RPessoasEnderecos.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace