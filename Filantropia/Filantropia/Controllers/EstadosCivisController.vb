Imports System.Web.Mvc

Namespace Controllers
    Public Class EstadosCivisController
        Inherits Controller

        ' GET: EstadosCivis
        <Route("EstadosCivis/EstadosCivis")>
        Function Index() As ActionResult
            Return View(Filantropia.EstadosCivis.ObterTodos)
        End Function

        ' GET: EstadosCivis/Create
        Function NovoEstadoCivil() As ActionResult
            Return View()
        End Function

        ' POST: EstadosCivis/Create
        <HttpPost()>
        Function NovoEstadoCivil(Dados As FilantropiaDLL.Componentes.EstadoCivil) As ActionResult
            Try
                Filantropia.EstadosCivis.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: EstadosCivis/Edit/5
        Function AlterarEstadoCivil(ByVal id As Integer) As ActionResult
            Return View(Filantropia.EstadosCivis.Obter(id))
        End Function

        ' POST: EstadosCivis/Edit/5
        <HttpPost()>
        Function AlterarEstadoCivil(Dados As FilantropiaDLL.Componentes.EstadoCivil) As ActionResult
            Try
                Filantropia.EstadosCivis.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: EstadosCivis/Delete/5
        Function ExcluirEstadoCivil(ByVal id As Integer) As ActionResult
            Return View(Filantropia.EstadosCivis.Obter(id))
        End Function

        ' POST: EstadosCivis/Delete/5
        <HttpPost()>
        Function ExcluirEstadoCivil(Dados As FilantropiaDLL.Componentes.EstadoCivil) As ActionResult
            Try
                Filantropia.EstadosCivis.Excluir(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace