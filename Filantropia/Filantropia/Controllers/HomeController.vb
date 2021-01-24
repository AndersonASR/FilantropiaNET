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
		If Filantropia.Funcionarios.ValidarUsuario(Dados(0).ToString, Dados(1).ToString) Then
			Session("Usuario") = Filantropia.Pessoas.Obter(Dados(0).ToString)
			'Filantropia.Logs.InserirNovo(Now, "Login", Session("Usuario").ID, "Acesso ao Sistema")
			Return View("Menu")
		Else
			ModelState.AddModelError("Senha", "Usuário ou senha inválidos. Por favor, tente novamente.")
			Return View("Index")
		End If
	End Function

	Function Sair() As ActionResult
		Session("Usuario") = Nothing
		Session.Abandon()

		Return View("Index")
	End Function

	Function Menu() As ActionResult
		ViewData("Message") = "Página principal da aplicação Filantropia"

		Return View()
	End Function

	Function Config() As ActionResult
		ViewData("Message") = "Página principal da aplicação Filantropia"

		Return View()
	End Function
End Class
