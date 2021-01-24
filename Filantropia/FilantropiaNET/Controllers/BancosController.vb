Imports System.Web.Mvc

Namespace Controllers
    Public Class BancosController
        Inherits Controller

        ' GET: Bancos
        <Route("Bancos/Bancos")>
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Bancos/Create
        Function NovoBanco() As ActionResult
            Return View()
        End Function

        ' POST: Bancos/Create
        <HttpPost()>
        Function NovoBanco(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Bancos/Edit/5
        Function AlterarBanco(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Bancos/Edit/5
        <HttpPost()>
        Function AlterarBanco(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Bancos/Delete/5
        Function ExcluirBanco(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Bancos/Delete/5
        <HttpPost()>
        Function ExcluirBanco(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace