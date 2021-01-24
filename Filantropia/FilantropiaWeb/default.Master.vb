Public Class _default
	Inherits System.Web.UI.MasterPage

	Protected Sub lgnLogin_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles lgnLogin.Authenticate
		e.Authenticated = Filantropia.ValidarUsuario(lgnLogin.UserName, lgnLogin.Password)
	End Sub

End Class