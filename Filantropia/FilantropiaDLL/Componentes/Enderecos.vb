Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Endereco
		Public Property ID As Long
		Public Property IDPessoa As Int64
		Public Property Logradouro As String
		Public Property Numero As Integer
		Public Property Complemento As String
		Public Property Bairro As String
		Public Property Cidade As String
		Public Property UF As String
		Public Property CEP As String
		Public Property OBS As String
		Public Property IDResponsavelCadastro As Int64
		Public Property TipoEndereco As TipoReferencia
		Public Property DataRegistro As DateTime
	End Class

	Public Class Enderecos

		Private REnderecos As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Enderecos)
		Private LEnderecos As List(Of DAL.Modelos.Enderecos)
		Private PT As PessoasEnderecos
		Private Tipos As TiposReferencias

		Public Sub New(Conexao As String)
			REnderecos = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Enderecos)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
			PT = New PessoasEnderecos(Conexao)
			Tipos = New TiposReferencias(Conexao)
		End Sub

		Public Function ObterTodos(Optional IDPessoa As Int64 = 0) As List(Of Endereco)
			Dim Tel As List(Of Endereco) = Nothing

			Dim LPT As New List(Of PessoaEndereco)

			LPT = PT.ObterTodos(IDPessoa)

			If Not LPT Is Nothing Then
				If LPT.Count > 0 Then
					Tel = New List(Of Endereco)

					For X As Int16 = 0 To LPT.Count - 1
						Dim T As Endereco = Obter(IDPessoa, LPT(X).IDEndereco)

						T.TipoEndereco = Tipos.Obter(LPT(X).IDTipoEndereco)

						Tel.Add(T)
					Next
				End If
			End If

			Return Tel

		End Function

		Public Function Obter(Optional Logradouro As String = "", Optional Numero As Int16 = 0, Optional Complemento As String = "", Optional Bairro As String = "", Optional Cidade As String = "", Optional UF As String = "", Optional CEP As String = "", Optional OBS As String = "") As Endereco
			Dim TP As Endereco = Nothing

			REnderecos.LimparParametros()
			If Logradouro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Logradouro.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Logradouro)
			If Numero <> 0 Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Numero.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Igual, Numero)
			If Complemento <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Complemento.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Complemento)
			If Bairro <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Bairro.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Bairro)
			If Cidade <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.Cidade.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Cidade)
			If UF <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.UF.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, UF)
			If CEP <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.CEP.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, CEP)
			If OBS <> "" Then REnderecos.AdicionarParametro(DALFilantropia.DAL.Modelos.Enderecos.Campos.OBS.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, OBS)
			LEnderecos = REnderecos.Obter

			If LEnderecos.Count > 0 Then

				TP = New Endereco

				Popular(LEnderecos(0), TP)
			End If

			Return TP

		End Function

		Public Function Obter(IDPessoa As Int64, IDEndereco As Int64) As Endereco
			Dim TP As Endereco = Nothing

			Dim RPT As PessoaEndereco = PT.Obter(IDPessoa, IDEndereco)

			If Not RPT Is Nothing Then
				TP = New Endereco
				Popular(RPT, TP)
				REnderecos.LimparParametros()
				REnderecos.AdicionarParametro(DAL.Modelos.Enderecos.Campos.ID.ToString, CompareType.Igual, IDEndereco)
				LEnderecos = REnderecos.Obter
				If LEnderecos.Count > 0 Then
					Popular(LEnderecos(0), TP)
					TP.TipoEndereco = Tipos.Obter(RPT.IDTipoEndereco)
				End If
			End If

			Return TP

		End Function

		Public Function Obter(IDEndereco As Int64) As Endereco
			Dim TP As Endereco = Nothing

			REnderecos.LimparParametros()
			REnderecos.AdicionarParametro(DAL.Modelos.Enderecos.Campos.ID.ToString, CompareType.Igual, IDEndereco)
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
				Dim Teste As Endereco = Obter(Dados.Logradouro, Dados.Numero, Dados.Complemento, Dados.Bairro, Dados.Cidade, Dados.UF, Dados.CEP, Dados.OBS)

				If Teste Is Nothing Then

					Popular(Dados, B)

					REnderecos.Inserir(B)
					Dados = Obter(B.Logradouro, B.Numero, B.Complemento, B.Bairro, B.Cidade, B.UF, B.CEP, B.OBS)
				Else
					Dados.ID = Teste.ID
				End If

				Dim _PT As New PessoaEndereco
				_PT = PT.Obter(Dados.IDPessoa, Dados.ID)
				If _PT Is Nothing Then
					_PT = New PessoaEndereco
					_PT.DataRegistro = Now
					_PT.IDEndereco = Dados.ID
					_PT.IDPEssoa = Dados.IDPessoa
					_PT.IDResponsavelCadastro = Dados.IDResponsavelCadastro
					_PT.IDTipoEndereco = Dados.TipoEndereco.ID
					PT.InserirNovo(_PT)
				End If

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

				Dim _PT As New PessoaEndereco

				Popular(Dados, _PT)

				_PT.IDTipoEndereco = Dados.TipoEndereco.ID

				PT.Atualizar(_PT)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Endereco) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Enderecos
				'TODO: Énecessário excluir o relacionamento PessoasEnderecos e só então verificar se devemos excluir o Endereco
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