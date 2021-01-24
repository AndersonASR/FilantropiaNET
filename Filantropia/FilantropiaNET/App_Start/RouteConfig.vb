Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
	Public Sub RegisterRoutes(ByVal routes As RouteCollection)
		routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

		routes.MapMvcAttributeRoutes 'Este comando permite que cada Action possa ter sua rota específica através de um atributo adicionado acima dela
		'Ex.: <Route("a rota desejada/{atributos}">
		'Vale lembrar que as rotas podem utilizar-se de expressões RegEx para estipular limites

		routes.MapRoute(
			name:="Default",
			url:="{controller}/{action}/{id}",
			defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
		)
	End Sub
End Module