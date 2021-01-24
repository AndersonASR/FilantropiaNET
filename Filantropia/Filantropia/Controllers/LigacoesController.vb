Imports System.Web.Mvc

Namespace Controllers
    Public Class LigacoesController
        Inherits Controller

        ' GET: Ligacoes
        <Route("Ligacoes/Ligacoes")>
        Function Index() As ActionResult
            Return View(Filantropia.HistoricoChamadas.ObterTodos)
        End Function

        ' GET: Ligacoes/Create
        Function NovaLigacao() As ActionResult
            Return View()
        End Function

        ' POST: Ligacoes/Create
        <HttpPost()>
        Function NovaLigacao(Dados As FilantropiaDLL.Componentes.HistoricoChamada) As ActionResult
            Try
                Filantropia.HistoricoChamadas.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Ligacoes/Edit/5
        Function AlterarLigacao(ByVal id As Integer) As ActionResult
            Return View(Filantropia.HistoricoChamadas.Obter(id))
        End Function

        ' POST: Ligacoes/Edit/5
        <HttpPost()>
        Function AlterarLigacao(Dados As FilantropiaDLL.Componentes.HistoricoChamada) As ActionResult
            Try
                Filantropia.HistoricoChamadas.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Ligacoes/Delete/5
        Function ExcluirLigacao(ByVal id As Integer) As ActionResult
            Return View(Filantropia.HistoricoChamadas.Obter(id))
        End Function

        ' POST: Ligacoes/Delete/5
        <HttpPost()>
        Function ExcluirLigacao(Dados As FilantropiaDLL.Componentes.HistoricoChamada) As ActionResult
            Try
                Filantropia.HistoricoChamadas.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace