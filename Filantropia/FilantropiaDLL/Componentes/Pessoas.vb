Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class Pessoa
		Public Property ID As Long
		Public Property TipoPessoa As Componentes.TipoPessoa
		<Display(Name:="Estado Civil")>
		Public Property EstadoCivil As String
		<Display(Name:="Motivo da Restrição")>
		Public Property MotivoRestricao As String
		<Display(Name:="Responsável pelo Cadastro")>
		Public Property ResponsavelCadastro As Funcionario
		<Display(Name:="CPF ou CNPJ")>
		Public Property CPFCNPJ As String
		Public Property Nome As String
		<Display(Name:="Data de Registro da Restrição")>
		Public Property DataRestricao As DateTime
		Public Property Enderecos As List(Of Componentes.Endereco)
		Public Property Telefones As List(Of Componentes.Telefone)
	End Class

	Public Class Pessoas

		Private RPessoas As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Pessoas)
		Private LPessoas As List(Of DAL.Modelos.Pessoas)
		Private Tipos As TiposPessoas

		Public Sub New(Conexao As String)
			RPessoas = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Pessoas)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
			Tipos = New TiposPessoas(Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Pessoa)
			Dim TP As List(Of Pessoa) = Nothing

			RPessoas.LimparParametros()
			LPessoas = RPessoas.ObterTodos

			If LPessoas.Count > 0 Then

				TP = New List(Of Pessoa)

				For X As Int16 = 0 To LPessoas.Count - 1
					Dim T As New Pessoa

					Popular(LPessoas(X), T)
					T.TipoPessoa = Tipos.Obter(LPessoas(X).IDTipoPessoa)

					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(CPFCNPJ As String) As Pessoa
			Dim TP As Pessoa = Nothing

			RPessoas.LimparParametros()
			RPessoas.AdicionarParametro(DALFilantropia.DAL.Modelos.Pessoas.Campos.CPFCNPJ.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, CPFCNPJ)
			LPessoas = RPessoas.Obter

			If LPessoas.Count > 0 Then

				TP = New Pessoa

				Popular(LPessoas(0), TP)
				TP.TipoPessoa = Tipos.Obter(LPessoas(0).IDTipoPessoa)

			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Pessoa) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Pessoas

				Popular(Dados, B)
				B.IDTipoPessoa = Dados.TipoPessoa.ID

				RPessoas.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Pessoa) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Pessoas

				Popular(Dados, B)
				B.IDTipoPessoa = Dados.TipoPessoa.ID

				RPessoas.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Pessoa) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Pessoas

				Popular(Dados, B)
				B.IDTipoPessoa = Dados.TipoPessoa.ID

				RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.ID.ToString, CompareType.Igual, B.ID)
				RPessoas.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace