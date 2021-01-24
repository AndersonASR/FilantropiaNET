Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Telefone
		Public Property ID As Long
		Public Property IDPessoa As Long
		Public Property DDD As Integer
		Public Property Prefixo As Integer
		Public Property Sulfixo As Integer
		Public Property Telefone As String
			Get
				Return Prefixo + "-" + Sulfixo
			End Get
			Set(Tel As String)
				Prefixo = Tel.Substring(0, Tel.IndexOf("-") - 1)
				Sulfixo = Tel.Substring(Tel.IndexOf("-") + 1)
			End Set
		End Property
		Public Property SMS As Boolean
		Public Property WhatsApp As Boolean
		Public Property DataRegistro As DateTime
		Public Property IDResponsavelCadastro As Long
	End Class

	Public Class Telefones

		Private RTelefones As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Telefones)
		Private LTelefones As List(Of DAL.Modelos.Telefones)
		Private PT As PessoasTelefones '

		Public Sub New(Conexao As String)
			RTelefones = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Telefones)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
			PT = New PessoasTelefones(Conexao)
		End Sub

		Public Function ObterTodos(IDPessoa As Int64) As List(Of Telefone)
			Dim TP As List(Of Telefone) = Nothing

			Dim LPT As New List(Of Int64)
			LPT = PT.ObterIDsTelefones(IDPessoa)

			If LPT.Count > 0 Then

				TP = New List(Of Telefone)

				For X As Int16 = 0 To LPT.Count - 1
					Dim T As Telefone = Obter(IDPessoa, LPT(X))

					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Optional DDD As String = "", Optional Prefixo As String = "", Optional Sulfixo As String = "") As Telefone
			Dim TP As Telefone = Nothing

			RTelefones.LimparParametros()
			If DDD <> "" Then RTelefones.AdicionarParametro(DALFilantropia.DAL.Modelos.Telefones.Campos.DDD.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, DDD)
			If Prefixo <> "" Then RTelefones.AdicionarParametro(DALFilantropia.DAL.Modelos.Telefones.Campos.Prefixo.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Prefixo)
			If Sulfixo <> "" Then RTelefones.AdicionarParametro(DALFilantropia.DAL.Modelos.Telefones.Campos.Sulfixo.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Sulfixo)
			LTelefones = RTelefones.Obter

			If LTelefones.Count > 0 Then

				TP = New Telefone

				Popular(LTelefones(0), TP)
			End If

			Return TP

		End Function

		Public Function Obter(IDPessoa As Int64, IDTelefone As Int64) As Telefone
			Dim TP As Telefone = Nothing

			Dim RPT As PessoaTelefone = PT.Obter(IDPessoa, IDTelefone)

			If Not RPT Is Nothing Then
				TP = New Telefone
				Popular(RPT, TP)
				RTelefones.LimparParametros()
				RTelefones.AdicionarParametro(DAL.Modelos.Telefones.Campos.ID.ToString, CompareType.Igual, IDTelefone)
				LTelefones = RTelefones.Obter
				If LTelefones.Count > 0 Then
					Popular(LTelefones(0), TP)
				End If
			End If

			Return TP

		End Function

		Public Function Obter(IDTelefone As Int64) As Telefone
			Dim TP As Telefone = Nothing

			RTelefones.LimparParametros()
			RTelefones.AdicionarParametro(DAL.Modelos.Telefones.Campos.ID.ToString, CompareType.Igual, IDTelefone)
			LTelefones = RTelefones.Obter

			If LTelefones.Count > 0 Then
				Popular(LTelefones(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Telefone) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Telefones

				Popular(Dados, B)

				RTelefones.Inserir(B)
				Dados = Obter(B.DDD, B.Prefixo, B.Sulfixo)

				Dim _PT As New PessoaTelefone
				_PT.DataRegistro = Now
				_PT.SMS = Dados.SMS
				_PT.WhatsApp = Dados.WhatsApp
				_PT.IDTelefone = Dados.ID
				_PT.IDPessoa = Dados.IDPessoa
				_PT.IDResponsavelCadastro = Dados.IDResponsavelCadastro

				PT.InserirNovo(_PT)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Telefone) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Telefones

				Popular(Dados, B)

				RTelefones.Atualizar(B)

				Dim _PT As New PessoaTelefone
				Popular(Dados, _PT)
				PT.Atualizar(_PT)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Telefone) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Telefones
				'TODO: Énecessário excluir o relacionamento PessoasTelefones e só então verificar se devemos excluir o telefone
				Popular(Dados, B)

				RTelefones.AdicionarParametro(DAL.Modelos.Telefones.Campos.ID.ToString, CompareType.Igual, B.ID)
				RTelefones.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace