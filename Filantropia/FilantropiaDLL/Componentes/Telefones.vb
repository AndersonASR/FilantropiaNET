Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Telefone
		Public Property ID As Int64
		Public Property IDPessoa As Int64
		Public Property DDD As Int16
		Public Property Prefixo As String
		Public Property Sulfixo As String
		Public Property Telefone As String
			Get
				Dim Valor As String = ""
				If Not (Prefixo Is Nothing And Sulfixo Is Nothing) Then Valor = Prefixo.ToString + "-" + Sulfixo.ToString
				Return Valor
			End Get
			Set(Tel As String)
				If Not Tel Is Nothing Then
					If Tel.Trim.Length >= 7 Then
						Prefixo = Tel.Substring(0, Tel.IndexOf("-") - 1)
						Sulfixo = Tel.Substring(Tel.IndexOf("-") + 1)
					End If
				End If
			End Set
		End Property
		Public Property TipoReferencia As TipoReferencia
		Public Property SMS As Boolean
		Public Property WhatsApp As Boolean
		Public Property DataRegistro As DateTime
		Public Property IDResponsavelCadastro As Int64
	End Class

	Public Class Telefones

		Private RTelefones As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Telefones)
		Private LTelefones As List(Of DAL.Modelos.Telefones)
		Private PT As PessoasTelefones
		Private Tipos As TiposReferencias

		Public Sub New(Conexao As String)
			RTelefones = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Telefones)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
			PT = New PessoasTelefones(Conexao)
			Tipos = New TiposReferencias(Conexao)
		End Sub

		Public Function ObterTodos(Optional IDPessoa As Int64 = 0) As List(Of Telefone)
			Dim Tel As List(Of Telefone) = Nothing

			Dim LPT As New List(Of PessoaTelefone)

			LPT = PT.ObterTodos(IDPessoa)

			If Not LPT Is Nothing Then
				If LPT.Count > 0 Then
					Tel = New List(Of Telefone)

					For X As Int16 = 0 To LPT.Count - 1
						Dim T As Telefone = Obter(IDPessoa, LPT(X).IDTelefone)

						T.TipoReferencia = Tipos.Obter(LPT(X).IDTipoTelefone)

						Tel.Add(T)
					Next
				End If
			End If

			Return Tel

		End Function

		Public Function Obter(Optional DDD As String = "", Optional Prefixo As String = "", Optional Sulfixo As String = "") As Telefone
			Dim TP As Telefone = Nothing

			RTelefones.LimparParametros()
			If DDD <> "" Then RTelefones.AdicionarParametro(DALFilantropia.DAL.Modelos.Telefones.Campos.DDD.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Igual, DDD)
			If Prefixo <> "" Then RTelefones.AdicionarParametro(DALFilantropia.DAL.Modelos.Telefones.Campos.Prefixo.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Igual, Prefixo)
			If Sulfixo <> "" Then RTelefones.AdicionarParametro(DALFilantropia.DAL.Modelos.Telefones.Campos.Sulfixo.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Igual, Sulfixo)
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
					TP.TipoReferencia = Tipos.Obter(RPT.IDTipoTelefone)
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
				TP = New Telefone
				Popular(LTelefones(0), TP)
			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As Telefone) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Telefones
				Dim Teste As Telefone = Obter(Dados.DDD, Dados.Prefixo, Dados.Sulfixo)

				If Teste Is Nothing Then

					Popular(Dados, B)

					RTelefones.Inserir(B)
					Dados = Obter(B.DDD, B.Prefixo, B.Sulfixo)
				Else
					Dados.ID = Teste.ID
				End If

				Dim _PT As New PessoaTelefone
				_PT = PT.Obter(Dados.IDPessoa, Dados.ID)
				If _PT Is Nothing Then
					_PT = New PessoaTelefone
					_PT.DataRegistro = Now
					_PT.SMS = Dados.SMS
					_PT.WhatsApp = Dados.WhatsApp
					_PT.IDTelefone = Dados.ID
					_PT.IDPessoa = Dados.IDPessoa
					_PT.IDResponsavelCadastro = Dados.IDResponsavelCadastro
					_PT.IDTipoTelefone = Dados.TipoReferencia.ID
					PT.InserirNovo(_PT)
				End If

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

				_PT.IDTipoTelefone = Dados.TipoReferencia.ID

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