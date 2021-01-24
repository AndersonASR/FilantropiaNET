Imports System.Web.Mvc

Namespace Controllers
    Public Class PeriodicidadesController
        Inherits Controller

        ' GET: Periodicidades
        <Route("Periodicidades/Periodicidades")>
        Function Index() As ActionResult
            Return View(Filantropia.Periodicidades.ObterTodos)
        End Function

        ' GET: Periodicidades/Create
        Function NovaPeriodicidade() As ActionResult
            Return View()
        End Function

        ' POST: Periodicidades/Create
        <HttpPost()>
        Function NovaPeriodicidade(Dados As FilantropiaDLL.Componentes.Periodicidade) As ActionResult
            Try
                Filantropia.Periodicidades.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Periodicidades/Edit/5
        Function AlterarPeriodicidade(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Periodicidades.Obter(id))
        End Function

        ' POST: Periodicidades/Edit/5
        <HttpPost()>
        Function AlterarPeriodicidade(Dados As FilantropiaDLL.Componentes.Periodicidade) As ActionResult
            Try
                Filantropia.Periodicidades.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Periodicidades/Delete/5
        Function ExcluirPeriodicidade(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Periodicidades.Obter(id))
        End Function

        ' POST: Periodicidades/Delete/5
        <HttpPost()>
        Function ExcluirPeriodicidade(Dados As FilantropiaDLL.Componentes.Periodicidade) As ActionResult
            Try
                Filantropia.Periodicidades.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace