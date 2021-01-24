Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class Funcionario
		Public Property ID As Long
		<Display(Name:="CPF ou CNPJ")>
		Public Property CPFCNPJ As Long
		Public Property Nome As String
		<Display(Name:="Data de Admissão")>
		Public Property DataAdmissao As DateTime
		<Display(Name:="Data de Desligamento")>
		Public Property DataDesligamento As DateTime
		Public Property RG As Long
		<Display(Name:="Tipo de Funcionário")>
		Public Property TipoFuncionario As Componentes.TipoPessoa
		<Display(Name:="Estado Civil")>
		Public Property EstadoCivil As String
		Public Property Ativo As Boolean
		Public Property Senha As String
		Public Property IDResponsavelCadastro As Long
		<Display(Name:="Endereços")>
		Public Property Enderecos As List(Of Componentes.Endereco)
		Public Property Telefones As List(Of Componentes.Telefone)
		Public Property IDPessoa As Int64
	End Class

	Public Class Funcionarios

		Private RFuncionarios As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Funcionarios)
		Private LFuncionarios As List(Of DAL.Modelos.Funcionarios)
		Private RPessoas As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Pessoas)
		Private LPessoas As List(Of DAL.Modelos.Pessoas)

		Private Pessoas As Componentes.Pessoas
		Private Tipos As Componentes.TiposPessoas
		Private Ender As Componentes.Enderecos
		Private EC As Componentes.EstadosCivis
		Private Tel As Componentes.Telefones

		Public Sub New(Conexao As String)
			RFuncionarios = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Funcionarios)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
			RPessoas = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Pessoas)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)

			Pessoas = New Pessoas(Conexao)
			Tipos = New TiposPessoas(Conexao)
			Ender = New Componentes.Enderecos(Conexao)
			EC = New EstadosCivis(Conexao)
			Tel = New Telefones(Conexao)
		End Sub

		Public Function ValidarUsuario(Chave As String, Senha As String) As Boolean
			Dim Resp As Boolean = False

			RPessoas.LimparParametros()
			RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.CPFCNPJ.ToString, CompareType.Igual, Chave)
			LPessoas = RPessoas.Obter
			'LFuncionarios.Clear()

			If LPessoas.Count > 0 Then
				RFuncionarios.LimparParametros()
				RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.IDPessoa.ToString, CompareType.Igual, LPessoas(0).ID)
				RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.Senha.ToString, CompareType.Igual, Senha)
				LFuncionarios = RFuncionarios.Obter

				Resp = (LFuncionarios.Count > 0)
			End If

			Return Resp

		End Function

		Public Function ObterTodos() As List(Of Funcionario)
			Dim TP As List(Of Funcionario) = Nothing

			RFuncionarios.LimparParametros()
			LFuncionarios = RFuncionarios.ObterTodos

			If LFuncionarios.Count > 0 Then

				TP = New List(Of Funcionario)

				For X As Int16 = 0 To LFuncionarios.Count - 1
					Dim T As New Funcionario

					Popular(LFuncionarios(X), T)
					'T.ID = LFuncionarios(X).ID
					'T.Funcionario = LFuncionarios(X).Funcionario
					'T.Alias = LFuncionarios(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(ID As Int64) As Funcionario
			Dim F As Funcionario = Nothing

			RFuncionarios.LimparParametros()
			RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.ID.ToString, CompareType.Igual, ID)
			LFuncionarios = RFuncionarios.Obter

			If LFuncionarios.Count > 0 Then

				RPessoas.LimparParametros()
				RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.ID.ToString, CompareType.Igual, LFuncionarios(0).IDPessoa)
				LPessoas = RPessoas.Obter

				Dim LF As DAL.Modelos.Funcionarios = LFuncionarios(0)

				F = New Funcionario
				F.ID = LF.ID
				F.Ativo = LF.Ativo
				F.CPFCNPJ = LPessoas(0).CPFCNPJ
				F.DataAdmissao = LF.DataAdmissao
				F.DataDesligamento = LF.DataDesligamento
				F.TipoFuncionario = Tipos.Obter(LF.IDTipoFuncionario)
				F.Enderecos = Ender.Obter(LF.IDPessoa)
				F.EstadoCivil = EC.Obter(LPessoas(0).IDEstadoCivil)
				F.IDResponsavelCadastro = LF.IDResponsavelCadastro
				F.Nome = LPessoas(0).Nome
				F.Telefones = Tel.ObterTodos(LF.IDPessoa)
				F.RG = LF.RG
				F.Senha = LF.Senha
			End If

			Return F

		End Function

		Public Function InserirNovo(Dados As Funcionario) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Funcionarios

				Popular(Dados, B)

				RFuncionarios.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Funcionario) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Funcionarios

				Popular(Dados, B)

				RFuncionarios.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function AlterarSenha(CPF As String, SenhaAntiga As String, SenhaNova As String) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Funcionarios
				Dim IDPessoa As Int64

				RPessoas.LimparParametros()
				RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.CPFCNPJ.ToString, CompareType.Igual, CPF)
				LPessoas = RPessoas.Obter

				If LPessoas.Count > 0 Then
					IDPessoa = LPessoas(0).ID

					RFuncionarios.LimparParametros()
					RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
					RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.Senha.ToString, CompareType.Igual, SenhaAntiga)
					LFuncionarios = RFuncionarios.Obter

					If LFuncionarios.Count > 0 Then
						LFuncionarios(0).Senha = SenhaNova
						RFuncionarios.Atualizar(LFuncionarios(0))

						Executou = True
					End If
				End If
            Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Funcionario) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Funcionarios

				Popular(Dados, B)

				RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.ID.ToString, CompareType.Igual, B.ID)
				RFuncionarios.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace