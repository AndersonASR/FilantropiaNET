Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

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
		Public Property DataRegistro As DateTime
	End Class

	Public Class PessoasTelefones

		Private RPessoasTelefones As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.PessoasTelefones)
		Private LPessoasTelefones As List(Of DAL.Modelos.PessoasTelefones)

		Public Sub New(Conexao As String)
			RPessoasTelefones = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.PessoasTelefones)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterIDsTelefones(IDPessoa As Int64) As List(Of Int64)
			Dim TP As List(Of Int64) = Nothing

			RPessoasTelefones.LimparParametros()
			RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
			LPessoasTelefones = RPessoasTelefones.Obter

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
			RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
			RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDTelefone.ToString, CompareType.Igual, IDTelefone)
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
				RPessoasTelefones.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace