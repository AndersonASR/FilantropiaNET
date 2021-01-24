Imports System.Web.Optimization

Public Class MvcApplication
	Inherits System.Web.HttpApplication

	Protected Sub Application_Start()
		AreaRegistration.RegisterAllAreas()
		FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
		RouteConfig.RegisterRoutes(RouteTable.Routes)
		BundleConfig.RegisterBundles(BundleTable.Bundles)
	End Sub

	Sub Application_AcquireRequestState(sender As Object, e As EventArgs)
		If Not sender.context.Session Is Nothing And Not Request.UrlReferrer Is Nothing Then
			Dim Usuario As FilantropiaDLL.Modelos.Pessoas = Session("Usuario")
			Dim Pagina As String = Context.Request.Url.Segments(Context.Request.Url.Segments.Count - 1)

			If Usuario Is Nothing Then
				If Not Filantropia.PaginaPublica(Pagina) Then Context.Response.Redirect(Request.UrlReferrer.ToString())
			Else
				If Not Filantropia.UsuarioPodeAcessar(Usuario, Pagina) Then Context.Response.Redirect(Request.UrlReferrer.ToString())
			End If
		End If
	End Sub

	Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado quando a sessão é iniciada
#If DEBUG Then
		Filantropia = New FilantropiaDLL.Filantropia(ConfigurationManager.ConnectionStrings("FilantropiaNET.My.MySettings.BDLocal").ConnectionString)
#Else
		Filantropia = New FilantropiaDLL.Filantropia(ConfigurationManager.ConnectionStrings("FilantropiaNET.My.MySettings.BD").ConnectionString)
#End If
		Session("Usuario") = Nothing
		Session("Config") = Filantropia.CarregarConfig
	End Sub
End Class
