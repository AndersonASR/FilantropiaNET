Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos
Imports System.ComponentModel.DataAnnotations

Namespace Componentes

	Partial Public Class PessoaTelefone
		Public Property ID As Long
		Public Property IDPessoa As Long
		Public Property IDTelefone As Long
		Public Property IDTipoTelefone As Long
		Public Property IDContato As Long
		Public Property IDResponsavelCadastro As Long
		Public Property SMS As Boolean
		Public Property WhatsApp As Boolean
		Public Property Padrao As Boolean
		<Display(Name:="Data de Registro")>
		Public Property DataRegistro As DateTime
		<Display(Name:="Data da Desativação")>
		Public Property DataDesativacao As DateTime
		<Display(Name:="Motivo da Desativação")>
		Public Property MotivoDesativacao As String
	End Class

	Public Class PessoasTelefones

		Private RPessoasTelefones As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.PessoasTelefones)
		Private LPessoasTelefones As List(Of DAL.Modelos.PessoasTelefones)

		Public Sub New(Conexao As String)
			RPessoasTelefones = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.PessoasTelefones)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos(Optional IDPessoa As Int64 = 0) As List(Of PessoaTelefone)
			Dim R As List(Of PessoaTelefone) = Nothing

			RPessoasTelefones.LimparParametros()
			If IDPessoa > 0 Then
				RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
				LPessoasTelefones = RPessoasTelefones.Obter
			Else
				LPessoasTelefones = RPessoasTelefones.ObterTodos
			End If


			If LPessoasTelefones.Count > 0 Then

				R = New List(Of PessoaTelefone)

				For Each PT As Modelos.PessoasTelefones In LPessoasTelefones
					Dim Dado As New PessoaTelefone
					Popular(PT, Dado)
					R.Add(Dado)
				Next

			End If

			Return R
		End Function

		Public Function ObterIDsTelefones(Optional IDPessoa As Int64 = 0) As List(Of Int64)
			Dim TP As List(Of Int64) = Nothing

			RPessoasTelefones.LimparParametros()
			If IDPessoa = 0 Then
				LPessoasTelefones = RPessoasTelefones.ObterTodos
			Else
				RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
				LPessoasTelefones = RPessoasTelefones.Obter
			End If

			If LPessoasTelefones.Count > 0 Then

				TP = New List(Of Int64)

				For X As Int16 = 0 To LPessoasTelefones.Count - 1
					TP.Add(LPessoasTelefones(X).IDTelefone)
				Next
			End If

			Return TP

		End Function

		Public Function ObterIDsPessoas(IDTelefone As Int64) As List(Of Int64)
			Dim TP As List(Of Int64) = Nothing

			RPessoasTelefones.LimparParametros()
			RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDTelefone.ToString, CompareType.Igual, IDTelefone)
			LPessoasTelefones = RPessoasTelefones.Obter

			If LPessoasTelefones.Count > 0 Then

				TP = New List(Of Int64)

				For X As Int16 = 0 To LPessoasTelefones.Count - 1
					TP.Add(LPessoasTelefones(X).IDTelefone)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(IDPessoa As Int64, IDTelefone As Int64) As PessoaTelefone
			Dim R As PessoaTelefone = Nothing

			RPessoasTelefones.LimparParametros()
			If IDPessoa > 0 Then RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
			RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDTelefone.ToString, CompareType.Igual, IDTelefone)
			LPessoasTelefones = RPessoasTelefones.Obter

			If LPessoasTelefones.Count > 0 Then

				R = New PessoaTelefone

				Popular(LPessoasTelefones(0), R)
			End If

			Return R
		End Function

		Public Function Obter(IDPessoa As Int64) As PessoaTelefone
			Dim R As PessoaTelefone = Nothing

			RPessoasTelefones.LimparParametros()
			RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
			LPessoasTelefones = RPessoasTelefones.Obter

			If LPessoasTelefones.Count > 0 Then

				R = New PessoaTelefone

				Popular(LPessoasTelefones(0), R)
			End If

			Return R
		End Function

		Public Function InserirNovo(Dados As PessoaTelefone) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.PessoasTelefones

				Popular(Dados, B)

				RPessoasTelefones.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As PessoaTelefone) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.PessoasTelefones

				Popular(Dados, B)

				RPessoasTelefones.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As PessoaTelefone) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.PessoasTelefones

				Popular(Dados, B)

				RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.ID.ToString, CompareType.Igual, B.ID)
				LPessoasTelefones = RPessoasTelefones.Obter
				B = LPessoasTelefones(0)
				B.DataDesativacao = Now
				B.MotivoDesativacao = Dados.MotivoDesativacao
				RPessoasTelefones.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace