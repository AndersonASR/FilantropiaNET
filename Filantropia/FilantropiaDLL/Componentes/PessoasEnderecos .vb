﻿Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class PessoaEndereco
		Public Property ID As Long
		Public Property IDPEssoa As Long
		Public Property IDEndereco As Long
		Public Property IDTipoEndereco As Long
		Public Property IDResponsavelCadastro As Long
		Public Property DataRegistro As DateTime
	End Class

	Public Class PessoasEnderecos

		Private RPessoasEnderecos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.PessoasEnderecos)
		Private LPessoasEnderecos As List(Of DAL.Modelos.PessoasEnderecos)

		Public Sub New(Conexao As String)
			RPessoasEnderecos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.PessoasEnderecos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function Obter(IDPessoa As Int64, IDEndereco As Int64) As List(Of Int64)
			Dim TP As List(Of Int64) = Nothing

			RPessoasEnderecos.LimparParametros()
			RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
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

		Public Function ObterPorIDPessoa(IDPessoa As Int64) As List(Of Int64)
			Dim TP As List(Of Int64) = Nothing

			RPessoasEnderecos.LimparParametros()
			RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
			LPessoasEnderecos = RPessoasEnderecos.Obter

			If LPessoasEnderecos.Count > 0 Then

				TP = New List(Of Int64)

				For X As Int16 = 0 To LPessoasEnderecos.Count - 1
					TP.Add(LPessoasEnderecos(X).IDEndereco)
				Next
			End If

			Return TP

		End Function

		Public Function ObterPorIDEndereco(IDEndereco As Int64) As List(Of Int64)
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

				RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.ID.ToString, CompareType.Igual, Dados.ID)
				RPessoasEnderecos.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace