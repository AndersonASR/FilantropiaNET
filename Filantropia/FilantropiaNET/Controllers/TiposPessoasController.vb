Imports System.Web.Mvc

Namespace Controllers
    Public Class TiposPessoasController
        Inherits Controller

        ' GET: TiposPessoas
        <Route("TiposPessoas/TiposPessoas")>
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: TiposPessoas/Create
        Function NovoTipoPessoa() As ActionResult
            Return View()
        End Function

        ' POST: TiposPessoas/Create
        <HttpPost()>
        Function NovoTipoPessoa(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: TiposPessoas/Edit/5
        Function AlterarTipoPessoa(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: TiposPessoas/Edit/5
        <HttpPost()>
        Function AlterarTipoPessoa(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: TiposPessoas/Delete/5
        Function ExcluirTipoPessoa(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: TiposPessoas/Delete/5
        <HttpPost()>
        Function ExcluirTipoPessoa(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace