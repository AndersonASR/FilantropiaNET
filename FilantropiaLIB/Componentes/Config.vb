Namespace Modelos
	Partial Public Class Config
		Public Enum Campos
			TiposPessoas
			PAginas
			TiposPessoasPaginas
		End Enum

		Public Property TiposPessoas As List(Of TiposPessoas)
		Public Property Paginas As List(Of Paginas)
		Public Property TiposPessoasPAginas As List(Of TiposPessoasPaginas)
	End Class
End Namespace