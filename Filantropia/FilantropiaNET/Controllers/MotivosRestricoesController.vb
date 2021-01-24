Imports System.Web.Mvc

Namespace Controllers
    Public Class MotivosRestricoesController
        Inherits Controller

        ' GET: MotivosRestricoes
        <Route("MotivosRestricoes/MotivosRestricoes")>
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: MotivosRestricoes/Create
        Function NovoMotivoRestricao() As ActionResult
            Return View()
        End Function

        ' POST: MotivosRestricoes/Create
        <HttpPost()>
        Function NovoMotivoRestricao(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: MotivosRestricoes/Edit/5
        Function AlterarMotivoRestricao(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: MotivosRestricoes/Edit/5
        <HttpPost()>
        Function AlterarMotivoRestricao(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: MotivosRestricoes/Delete/5
        Function ExcluirMotivoRestricao(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: MotivosRestricoes/Delete/5
        <HttpPost()>
        Function ExcluirMotivoRestricao(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace