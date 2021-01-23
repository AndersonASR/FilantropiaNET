Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class TiposPessoasPaginas
		Public Enum Campos
			ID
			IDTipoPessoa
			IDPagina
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDPagina As Long
		<Required>
		Public Property IDTipoPessoaPagina As Long
	End Class
End Namespace