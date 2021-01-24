Imports System.Web.SessionState

Public Class Global_asax
	Inherits System.Web.HttpApplication

	Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado quando o aplicativo é iniciado
	End Sub

	Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado quando a sessão é iniciada
		Filantropia = New FilantropiaLIB.Filantropia(ConfigurationManager.ConnectionStrings("BD").ConnectionString)
		Session("Usuario") = Nothing
	End Sub

	Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado no início de cada solicitação
		'If Session("Usuario") Is Nothing Then
		'	Response.Redirect("default.aspx")
		'End If
		Stop
	End Sub

	Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado ao tentar autenticar o uso
	End Sub

	Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado quando ocorre um erro
	End Sub

	Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado quando a sessão termina
	End Sub

	Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado quando o aplicativo termina
	End Sub

End Class