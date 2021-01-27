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
		If Not sender.context.Session Is Nothing Then
			Dim Usuario As FilantropiaDLL.Componentes.Pessoa = Session("Usuario")
			Dim Cont As Int16 = 1
			Dim Pagina As String = Context.Request.Url.Segments(Context.Request.Url.Segments.Count - Cont)
			Dim EnderecoFalha As String = ""

			If Request.UrlReferrer Is Nothing Then
				EnderecoFalha = "/"
			Else
				Request.UrlReferrer.ToString()
			End If

			If Pagina.ToUpper <> "SAIR" Then
				While IsNumeric(Pagina)
					Cont += 1
					Pagina = Context.Request.Url.Segments(Context.Request.Url.Segments.Count - Cont)
				End While
				'Pagina = IIf(Pagina.Length > 2, Pagina.Replace("/", ""), Pagina)
				Pagina = Pagina.Replace("/", "")

				If Usuario Is Nothing Then
					If Not Filantropia.Paginas.PaginaPublica(Pagina) Then Context.Response.Redirect(EnderecoFalha)
				Else
					If Not Filantropia.Paginas.UsuarioPodeAcessar(Usuario, Pagina) Then Context.Response.Redirect(EnderecoFalha)
				End If
			End If
		End If
	End Sub

	Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		' É acionado quando a sessão é iniciada

		If Context.Request.Url.Host.ToUpper.Contains("LOCALHOST") Then
			Filantropia = New FilantropiaDLL.Filantropia(ConfigurationManager.ConnectionStrings("Filantropia.My.MySettings.BDLocal").ConnectionString)
		Else
			Filantropia = New FilantropiaDLL.Filantropia(ConfigurationManager.ConnectionStrings("Filantropia.My.MySettings.BD").ConnectionString)
		End If
		Session("Usuario") = Nothing
		'Session("Config") = Filantropia.CarregarConfig
	End Sub
End Class
