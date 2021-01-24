Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Endereco
		Public Property ID As Long
		Public Property IDPessoa As Int64
		Public Property Logradouro As String
		Public Property Numero As String
		Public Property Complemento As String
		Public Property Bairro As String
		Public Property Cidade As String
		Public Property UF As String
		Public Property CEP As Int64
		Public Property OBS As String
		Public Property IDResponsavelCadastro As Int64
		Public Property TipoEndereco As TipoReferencia
		Public Property DataRegistro As DateTime
	End Class

	Public Class Enderecos

		Private REnderecos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Enderecos)
		Private LEnderecos As List(Of DAL.Modelos.Enderecos)
		Private PE As PessoasEnderecos
		Private TiposRef As TiposReferencias

		Public Sub New(Conexao As String)
			REnderecos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Enderecos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
			PE = New PessoasEnderecos(Conexao)
			TiposRef = New TiposReferencias(Conexao)
		End Sub

		Public Function Obter(IDPessoa As Int64) As List(Of Endereco)
			Dim TP As List(Of Endereco) = Nothing

			Dim _Enderecos As List(Of Long) = PE.ObterPorIDPessoa(IDPessoa)

			If _Enderecos.Count > 0 Then
				For X As Int16 = 0 To _Enderecos.Count - 1
					REnderecos.LimparParametros()
					REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.ID.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, _Enderecos(X))

					LEnderecos = REnderecos.Obter

					If LEnderecos.Count > 0 Then

						TP = New List(Of Endereco)

						For Y As Int16 = 0 To LEnderecos.Count - 1
							Dim Tel As New Endereco

							Popular(LEnderecos(Y), Tel)
							Tel.IDPessoa = IDPessoa

							TP.Add(Tel)
						Next

					End If
				Next
			End If

			Return TP
		End Function

		Public Function Obter(Optional Logradouro As String = "", Optional Numero As String = "", Optional Complemento As String = "", Optional Bairro As String = "", Optional Cidade As String = "", Optional UF As String = "", Optional CEP As Int64 = 0) As Endereco
			Dim TP As Endereco = Nothing

			REnderecos.LimparParametros()
			If Logradouro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Logradouro.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Logradouro)
			If Logradouro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Numero.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Numero)
			If Logradouro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Complemento.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Complemento)
			If Logradouro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Bairro.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Bairro)
			If Logradouro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Cidade.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Cidade)
			If Logradouro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.UF.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, UF)
			If Logradouro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.CEP.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Igual, CEP)
			LEnderecos = REnderecos.Obter

			If LEnderecos.Count > 0 Then

				TP = New Endereco

				Popular(LEnderecos(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Endereco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Enderecos

				Popular(Dados, B)

				REnderecos.Inserir(B)

				Dim PEnd As New PessoaEndereco
				PEnd.IDPEssoa = Dados.IDPessoa
				PEnd.IDEndereco = B.ID
				PEnd.IDResponsavelCadastro = Dados.IDResponsavelCadastro
				PEnd.IDTipoEndereco = Dados.TipoEndereco.ID
				PEnd.DataRegistro = Now

				PE.InserirNovo(PEnd)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Endereco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Enderecos

				Popular(Dados, B)

				REnderecos.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Endereco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Enderecos

				Popular(Dados, B)

				REnderecos.AdicionarParametro(DAL.Modelos.Enderecos.Campos.ID.ToString, CompareType.Igual, B.ID)
				REnderecos.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace