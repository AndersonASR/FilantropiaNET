Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Enumeradores

Namespace Componentes

	Partial Public Class TipoPessoa
		Public Property ID As Long
		Public Property Tipo As String
		Public Property Funcionario As Boolean
		Public Paginas As List(Of Componentes.Pagina)
	End Class

	Public Class TiposPessoas
		Private RTiposPessoas As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.TiposPessoas)
		Private Paginas As Componentes.Paginas
		Private TiposPessoasPaginas As Componentes.TiposPessoasPaginas
		Private LTiposPessoas As List(Of DALFilantropia.DAL.Modelos.TiposPessoas)

		Public Sub New(Conexao As String)
			RTiposPessoas = New DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.TiposPessoas)(DALFilantropia.DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
			Paginas = New Componentes.Paginas(Conexao)
			TiposPessoasPaginas = New Componentes.TiposPessoasPaginas(Conexao)
		End Sub

		Public Function ObterTodos() As List(Of TipoPessoa)
			Dim TP As List(Of TipoPessoa) = Nothing

			RTiposPessoas.LimparParametros()
			LTiposPessoas = RTiposPessoas.ObterTodos

			If LTiposPessoas.Count > 0 Then

				TP = New List(Of TipoPessoa)

				For X As Int16 = 0 To LTiposPessoas.Count - 1
					Dim T As New TipoPessoa
					Popular(LTiposPessoas(X), T)
					'T.ID = LTiposPessoas(X).ID
					'T.Tipo = LTiposPessoas(X).Tipo
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(ID As Int64) As Componentes.TipoPessoa
			Dim TP As TipoPessoa = Nothing

			RTiposPessoas.LimparParametros()
			RTiposPessoas.AdicionarParametro(DAL.Modelos.TiposPessoas.Campos.ID.ToString, CompareType.Igual, ID)
			LTiposPessoas = RTiposPessoas.Obter

			If LTiposPessoas.Count > 0 Then
				TP = New Componentes.TipoPessoa
				Popular(LTiposPessoas(0), TP)
				'TP.ID = LTiposPessoas(0).ID
				'TP.Tipo = LTiposPessoas(0).Tipo
			End If

			Return TP
		End Function

		Public Function Obter(Tipo As String) As Componentes.TipoPessoa
			Dim TP As TipoPessoa = Nothing

			RTiposPessoas.LimparParametros()
			RTiposPessoas.AdicionarParametro(DAL.Modelos.TiposPessoas.Campos.Tipo.ToString, CompareType.Igual, Tipo)
			LTiposPessoas = RTiposPessoas.Obter

			If LTiposPessoas.Count > 0 Then
				TP = New Componentes.TipoPessoa
				Popular(LTiposPessoas(0), TP)
				'TP.ID = LTiposPessoas(0).ID
				'TP.Tipo = LTiposPessoas(0).Tipo
			End If

			Return TP
		End Function

		Public Function InserirNovo(Dados As TipoPessoa) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.TiposPessoas

				Popular(Dados, B)

				RTiposPessoas.Inserir(B)

				RTiposPessoas.LimparParametros()
				RTiposPessoas.AdicionarParametro(DAL.Modelos.TiposPessoas.Campos.Tipo.ToString, CompareType.Igual, Dados.Tipo)
				LTiposPessoas = RTiposPessoas.Obter

				Popular(LTiposPessoas(0), Dados)

				Dim Pag As List(Of Pagina) = Paginas.ObterTodos
				For Each P As Pagina In Pag
					If Not P.Publica Then
						Dim TP As New TipoPessoaPagina
						TP.IDPagina = P.ID
						TP.IDTipoPessoa = Dados.ID
						TP.Permissao = False
						TiposPessoasPaginas.InserirNovo(TP)
					End If
				Next

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As TipoPessoa) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.TiposPessoas

				Popular(Dados, B)

				RTiposPessoas.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As TipoPessoa) As Boolean
			Dim Executou As Boolean = False

			Try
				TiposPessoasPaginas.Excluir(Dados.ID)

				Dim B As New DAL.Modelos.TiposPessoas

				Popular(Dados, B)

				RTiposPessoas.AdicionarParametro(DAL.Modelos.TiposPessoas.Campos.ID.ToString, CompareType.Igual, B.ID)
				RTiposPessoas.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class
End Namespace