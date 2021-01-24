Imports System.Web.Mvc

Namespace Controllers
    Public Class PeriodicidadesController
        Inherits Controller

        ' GET: Periodicidades
        <Route("Periodicidades/Periodicidades")>
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Periodicidades/Create
        Function NovaPeriodicidade() As ActionResult
            Return View()
        End Function

        ' POST: Periodicidades/Create
        <HttpPost()>
        Function NovaPeriodicidade(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Periodicidades/Edit/5
        Function AlterarPeriodicidade(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Periodicidades/Edit/5
        <HttpPost()>
        Function AlterarPeriodicidade(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Periodicidades/Delete/5
        Function ExcluirPeriodicidade(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Periodicidades/Delete/5
        <HttpPost()>
        Function ExcluirPeriodicidade(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace