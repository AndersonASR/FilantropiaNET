Imports DALFilantropia
Imports DALFilantropia.DAL
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class Colaborador
		Public Property ID As Long
		<Display(Name:="CPF ou CNPJ")>
		Public Property CPFCNPJ As Long
		Public Property Nome As String
		<Display(Name:="Data de Restrição")>
		Public Property DataRestricao As DateTime
		<Display(Name:="Motivo da Restrição")>
		Public Property MotivoRestricao As Componentes.MotivoRestricao
		<Display(Name:="Estado Civil")>
		Public Property EstadoCivil As Componentes.EstadoCivil
		<Display(Name:="Endereços")>
		Public Property Enderecos As List(Of Componentes.Endereco)
		<Display(Name:="Telefones")>
		Public Property Telefones As List(Of Componentes.Telefone)
		Public Property Chamadas As List(Of Componentes.HistoricosChamadas)
		<Display(Name:="Contribuições")>
		Public Property Contribuicoes As List(Of Componentes.Movimento)
		Public Property Agendamentos As List(Of Componentes.Agendamento)
		Public Property IDPessoa As Int64
	End Class

	Public Class Colaboradores

		Private RColaboradores As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Colaboradores)
		Private LColaboradores As List(Of DAL.Modelos.Colaboradores)

		Private Pessoas As Componentes.Pessoas

		Public Sub New(Conexao As String)
			RColaboradores = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Colaboradores)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)

			Pessoas = New Pessoas(Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Colaborador)
			Dim TP As List(Of Colaborador) = Nothing

			RColaboradores.LimparParametros()
			LColaboradores = RColaboradores.ObterTodos

			If LColaboradores.Count > 0 Then

				TP = New List(Of Colaborador)

				For X As Int16 = 0 To LColaboradores.Count - 1
					Dim T As New Colaborador

					Popular(LColaboradores(X), T)
					'T.ID = LColaboradores(X).ID
					'T.Colaborador = LColaboradores(X).Colaborador
					'T.Alias = LColaboradores(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(CPFCNPJ As String) As Colaborador
			Dim TP As Colaborador = Nothing

			RColaboradores.LimparParametros()

			Dim P As Pessoa = Pessoas.Obter(CPFCNPJ)

			If Not P Is Nothing Then
				RColaboradores.AdicionarParametro(DAL.Modelos.Colaboradores.Campos.IDPessoa.ToString, CompareType.Igual, P.ID)
				LColaboradores = RColaboradores.Obter

				If LColaboradores.Count > 0 Then

					TP = New Colaborador

					Popular(LColaboradores(0), TP)
				End If
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Colaborador) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Colaboradores

				Popular(Dados, B)

				B.DataCadastro = Now

				RColaboradores.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Colaborador) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Colaboradores

				Popular(Dados, B)

				RColaboradores.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Colaborador) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Colaboradores

				Popular(Dados, B)

				RColaboradores.AdicionarParametro(DAL.Modelos.Colaboradores.Campos.ID.ToString, CompareType.Igual, B.ID)
				RColaboradores.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace