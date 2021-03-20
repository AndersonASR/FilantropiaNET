Imports System.Web.Mvc

Namespace Controllers
    Public Class ConfigController
        Inherits Controller

        ' GET: Config
        <Route("Config/Permissoes")>
        <OutputCache(Duration:=1)>
        Function Edit(Optional ByVal id As Int64 = Nothing) As ActionResult
            Return View(Filantropia.Config.Obter(id))
        End Function

        ' POST: Config/Edit/5
        <HttpPost()>
        <Route("Config/Permissoes")>
        Function Edit(ByVal collection As FormCollection) As ActionResult
            Dim IDTipo As Int64
            Dim IDPagina As Int64
            Dim Permissao As Boolean

            Try
                For X As Int16 = 0 To collection.Count - 1
                    If collection.Keys(X).ToString.Contains("Tipo") Then
                        IDTipo = collection.GetValue(collection.Keys(X)).AttemptedValue
                        Exit For
                    End If
                Next

                For X As Int16 = 0 To collection.Count - 1
                    If IsNumeric(collection.Keys(X)) Then
                        IDPagina = Convert.ToInt64(collection.Keys(X))
                        Permissao = collection.GetValue(collection.Keys(X)).AttemptedValue.Contains("on")
                        Filantropia.TiposPessoasPaginas.Atualizar(IDTipo, IDPagina, Permissao, True)
                    End If
                Next
                Return RedirectToAction("Edit")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace