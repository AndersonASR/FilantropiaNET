Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class TiposPessoasPaginas
		Public Enum Campos
			ID
			IDTipoPessoa
			IDPagina
			Permissao
		End Enum

		<Required>
		Public Property ID As Long
		<Required>
		Public Property IDPagina As Long
		<Required>
		Public Property IDTipoPessoa As Long
		<Required>
		Public Property Permissao As Boolean
	End Class
End Namespace