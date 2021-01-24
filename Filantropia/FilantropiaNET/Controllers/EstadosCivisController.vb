Imports System.Web.Mvc

Namespace Controllers
    Public Class EstadosCivisController
        Inherits Controller

        ' GET: EstadosCivis
        <Route("EstadosCivis/EstadosCivis")>
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: EstadosCivis/Create
        Function NovoEstadoCivil() As ActionResult
            Return View()
        End Function

        ' POST: EstadosCivis/Create
        <HttpPost()>
        Function NovoEstadoCivil(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: EstadosCivis/Edit/5
        Function AlterarEstadoCivil(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: EstadosCivis/Edit/5
        <HttpPost()>
        Function AlterarEstadoCivil(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: EstadosCivis/Delete/5
        Function ExcluirEstadoCivil(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: EstadosCivis/Delete/5
        <HttpPost()>
        Function ExcluirEstadoCivil(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace