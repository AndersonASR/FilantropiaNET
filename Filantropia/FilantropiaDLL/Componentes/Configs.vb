Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Modelos

Namespace Componentes

	Partial Public Class Config
		Public Property TiposPessoas As List(Of Componentes.TipoPessoa)
		Public Property TipoPessoa As Componentes.TipoPessoa
		Public Property Paginas As List(Of Pagina)
		Public Property TiposPessoasPaginas As List(Of TipoPessoaPagina)
		Public Property ValorCombustivel As Single
	End Class

	Public Class Configs

		Private TiposPessoas As Componentes.TiposPessoas
		Private Paginas As Componentes.Paginas
		Private TiposPessoasPaginas As Componentes.TiposPessoasPaginas

		Public Sub New(Conexao As String)
			Paginas = New Componentes.Paginas(Conexao)
			TiposPessoas = New Componentes.TiposPessoas(Conexao)
			TiposPessoasPaginas = New TiposPessoasPaginas(Conexao)
		End Sub

		Public Function Obter(IDTipoPessoa As Int64) As Config
			Dim TP As New Config

			TP.Paginas = Paginas.ObterTodos
			TP.TiposPessoas = TiposPessoas.ObterTodos

			If IDTipoPessoa = 0 And TP.TiposPessoas.Count > 0 Then IDTipoPessoa = 1

			TP.TiposPessoasPaginas = TiposPessoasPaginas.Obter(IDTipoPessoa)
			If IDTipoPessoa > 0 Then
				For Each T As TipoPessoa In TP.TiposPessoas
					If T.ID = IDTipoPessoa Then
						TP.TipoPessoa = T
						Exit For
					End If
				Next
			End If
			Return TP

		End Function

		Public Function Atualizar(Dados As Config) As Boolean
			Dim Executou As Boolean = False

			Try

				For Each TP As Componentes.TipoPessoaPagina In Dados.TiposPessoasPaginas
					TiposPessoasPaginas.Atualizar(TP)
				Next

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		'Public Function Excluir(Dados As Config) As Boolean
		'	Dim Executou As Boolean = False

		'	Try
		'		Dim B As New DAL.Modelos.Configs

		'		Popular(Dados, B)

		'		RConfigs.AdicionarParametro(DAL.Modelos.Configs.Campos.ID.ToString, CompareType.Igual, B.ID)
		'		RConfigs.Excluir()

		'		Executou = True
		'	Catch ex As Exception

		'	End Try

		'	Return Executou
		'End Function
	End Class

End Namespace