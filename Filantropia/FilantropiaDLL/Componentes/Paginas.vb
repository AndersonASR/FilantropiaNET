Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Pagina
		Public Property ID As Long
		Public Property Pagina As String
		Public Property Descricao As String
		Public Property Publica As Boolean
	End Class

	Public Class Paginas

		Private RPaginas As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Paginas)
		Private RTiposPessoasPaginas As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.TiposPessoasPaginas)
		Private LPaginas As List(Of DAL.Modelos.Paginas)
		Private LTiposPessoasPaginas As List(Of DAL.Modelos.TiposPessoasPaginas)

		Public Sub New(Conexao As String)
			RPaginas = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.Paginas)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
			RTiposPessoasPaginas = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.TiposPessoasPaginas)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of Pagina)
			Dim TP As List(Of Pagina) = Nothing

			RPaginas.LimparParametros()
			LPaginas = RPaginas.ObterTodos

			If LPaginas.Count > 0 Then

				TP = New List(Of Pagina)

				For X As Int16 = 0 To LPaginas.Count - 1
					Dim T As New Pagina

					Popular(LPaginas(X), T)
					'T.ID = LPaginas(X).ID
					'T.Pagina = LPaginas(X).Pagina
					'T.Alias = LPaginas(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(Pagina As String) As Pagina
			Dim TP As Pagina = Nothing

			RPaginas.LimparParametros()
			RPaginas.AdicionarParametro(DALFilantropia.DAL.Modelos.Paginas.Campos.Pagina.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Como, Pagina)
			LPaginas = RPaginas.Obter

			If LPaginas.Count > 0 Then

				TP = New Pagina

				Popular(LPaginas(0), TP)
			End If

			Return TP

		End Function

		Public Function UsuarioPodeAcessar(Usuario As Componentes.Pessoa, Pagina As String) As Boolean
			Dim Resp As Boolean = False
			Dim IDTipo As Int64 = Usuario.TipoPessoa.ID
			Dim IDPagina As Int64

			RPaginas.LimparParametros()
			RPaginas.AdicionarParametro(DAL.Modelos.Paginas.Campos.Pagina.ToString, CompareType.Como, Pagina)
			LPaginas = RPaginas.Obter
			If LPaginas.Count > 0 Then IDPagina = LPaginas(0).ID

			If IDPagina > 0 And IDTipo > 0 Then
				RTiposPessoasPaginas.LimparParametros()
				RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.IDPagina.ToString, CompareType.Igual, IDPagina)
				RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.IDTipoPessoa.ToString, CompareType.Igual, IDTipo)
				RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.Permissao.ToString, CompareType.Diferente, 0)
				LTiposPessoasPaginas = RTiposPessoasPaginas.Obter

				If LTiposPessoasPaginas.Count > 0 Then Resp = True
			End If

			Return Resp
		End Function

		Public Function PaginaPublica(Pagina As String) As Boolean
			Dim Resp As Boolean = False

			Dim P As Componentes.Pagina = Obter(Pagina)

			If Not P Is Nothing Then
				If P.Publica Then Resp = True
			End If

			Return Resp
		End Function

		Public Function InserirNovo(Dados As Pagina) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Paginas

				Popular(Dados, B)

				RPaginas.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As Pagina) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Paginas

				Popular(Dados, B)

				RPaginas.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As Pagina) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.Paginas

				Popular(Dados, B)

				RPaginas.AdicionarParametro(DAL.Modelos.Paginas.Campos.ID.ToString, CompareType.Igual, B.ID)
				RPaginas.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace