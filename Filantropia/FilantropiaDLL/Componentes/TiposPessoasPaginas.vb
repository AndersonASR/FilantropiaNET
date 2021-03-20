Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class TipoPessoaPagina
		Public Property ID As Long
		Public Property IDPagina As Int64
		Public Property IDTipoPessoa As Int64
		Public Property Permissao As Boolean
	End Class

	Public Class TiposPessoasPaginas

		Private RTiposPessoasPaginas As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.TiposPessoasPaginas)
		Private LTiposPessoasPaginas As List(Of DAL.Modelos.TiposPessoasPaginas)

		Public Sub New(Conexao As String)
			RTiposPessoasPaginas = New DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.TiposPessoasPaginas)(DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of TipoPessoaPagina)
			Dim TP As List(Of TipoPessoaPagina) = Nothing

			RTiposPessoasPaginas.LimparParametros()
			LTiposPessoasPaginas = RTiposPessoasPaginas.ObterTodos

			If LTiposPessoasPaginas.Count > 0 Then

				TP = New List(Of TipoPessoaPagina)

				For X As Int16 = 0 To LTiposPessoasPaginas.Count - 1
					Dim T As New TipoPessoaPagina

					Popular(LTiposPessoasPaginas(X), T)
					'T.ID = LTiposPessoasPaginas(X).ID
					'T.TipoPessoaPagina = LTiposPessoasPaginas(X).TipoPessoaPagina
					'T.Alias = LTiposPessoasPaginas(X).Alias
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(IDTipoPessoa As Int64) As List(Of TipoPessoaPagina)
			Dim TP As List(Of TipoPessoaPagina) = Nothing

			RTiposPessoasPaginas.LimparParametros()
			RTiposPessoasPaginas.AdicionarParametro(DALFilantropia.DAL.Modelos.TiposPessoasPaginas.Campos.IDTipoPessoa.ToString, DALFilantropia.DAL.Enumeradores.CompareType.Igual, IDTipoPessoa)
			LTiposPessoasPaginas = RTiposPessoasPaginas.Obter

			If LTiposPessoasPaginas.Count > 0 Then

				TP = New List(Of TipoPessoaPagina)

				For Each TPP As DAL.Modelos.TiposPessoasPaginas In LTiposPessoasPaginas
					Dim T As New TipoPessoaPagina

					Popular(TPP, T)
					T.Permissao = TPP.Permissao

					TP.Add(T)
				Next

			End If

			Return TP

		End Function

		Public Function InserirNovo(Dados As TipoPessoaPagina) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.TiposPessoasPaginas

				Popular(Dados, B)

				RTiposPessoasPaginas.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As TipoPessoaPagina) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.TiposPessoasPaginas

				Popular(Dados, B)

				RTiposPessoasPaginas.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(IDTipo As Int64, IDPagina As Int64, Permissao As Boolean, Optional CadastrarNovo As Boolean = False) As Boolean
			Dim Executou As Boolean = False

			Try

				RTiposPessoasPaginas.LimparParametros()
				RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.IDTipoPessoa.ToString, CompareType.Igual, IDTipo)
				RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.IDPagina.ToString, CompareType.Igual, IDPagina)
				LTiposPessoasPaginas = RTiposPessoasPaginas.Obter

				If LTiposPessoasPaginas.Count > 0 Then
					Dim B As DAL.Modelos.TiposPessoasPaginas = LTiposPessoasPaginas(0)
					B.Permissao = Permissao

					RTiposPessoasPaginas.Atualizar(B)

					Executou = True
				ElseIf CadastrarNovo Then
					Dim B As New DAL.Modelos.TiposPessoasPaginas
					B.IDPagina = IDPagina
					B.IDTipoPessoa = IDTipo
					B.Permissao = Permissao

					RTiposPessoasPaginas.Inserir(B)

					Executou = True
				End If

			Catch ex As Exception
				Stop
			End Try

			Return Executou

		End Function

		Public Function Excluir(Dados As TipoPessoaPagina) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.TiposPessoasPaginas

				Popular(Dados, B)

				RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.ID.ToString, CompareType.Igual, B.ID)
				RTiposPessoasPaginas.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(IDTipoPessoa As Int64) As Boolean
			Dim Executou As Boolean = False

			Try
				RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.IDTipoPessoa.ToString, CompareType.Igual, IDTipoPessoa)
				RTiposPessoasPaginas.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class

End Namespace