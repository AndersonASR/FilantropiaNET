Public Class HomeController
	Inherits System.Web.Mvc.Controller

	Function Index() As ActionResult
		Return View()
	End Function

	Function About() As ActionResult
		ViewData("Message") = "Your application description page."

		Return View()
	End Function

	Function Contact() As ActionResult
		ViewData("Message") = "Your contact page."

		Return View()
	End Function

	<HttpPost>
	Function Login(Dados As FormCollection) As ActionResult
		If Filantropia.ValidarUsuario(Dados(0).ToString, Dados(1).ToString) Then
			Session("Usuario") = Filantropia.ObterPessoa(Dados(0).ToString)
			Return View("Menu")
		Else
			RedirectToAction("Index")
		End If
	End Function

	Function Menu() As ActionResult
		ViewData("Message") = "Página principal da aplicação Filantropia"

		Return View()
	End Function

	Function Colaboradores() As ActionResult
		ViewData("Message") = "Página principal da aplicação Filantropia"

		Return View()
	End Function

	Function Funcionarios() As ActionResult
		ViewData("Message") = "Página principal da aplicação Filantropia"

		Return View()
	End Function

	Function Movimentos() As ActionResult
		ViewData("Message") = "Página principal da aplicação Filantropia"

		Return View()
	End Function

	Function Config() As ActionResult
		ViewData("Message") = "Página principal da aplicação Filantropia"

		Return View()
	End Function
End Class
