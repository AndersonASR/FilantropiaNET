Namespace Componentes
	Public Class TesteFuncionarios
		Inherits Pessoas

		Public Class TesteFuncionario
			Inherits Pessoa

		End Class

		Public Sub New(Conexao As String)
			MyBase.New(Conexao)
		End Sub

	End Class
End Namespace