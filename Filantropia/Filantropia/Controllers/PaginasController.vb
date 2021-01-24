Imports System.Web.Mvc

Namespace Controllers
    Public Class PaginasController
        Inherits Controller

        ' GET: Paginas
        <Route("Paginas/Paginas")>
        Function Index() As ActionResult
            Return View(Filantropia.Paginas.ObterTodos)
        End Function

        ' GET: Paginas/Create
        Function NovaPagina() As ActionResult
            Return View()
        End Function

        ' POST: Paginas/Create
        <HttpPost()>
        Function NovaPagina(Dados As FilantropiaDLL.Componentes.Pagina) As ActionResult
            Try
                Filantropia.Paginas.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Paginas/Edit/5
        Function AlterarPagina(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Paginas.Obter(id))
        End Function

        ' POST: Paginas/Edit/5
        <HttpPost()>
        Function AlterarPagina(Dados As FilantropiaDLL.Componentes.Pagina) As ActionResult
            Try
                Filantropia.Paginas.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Paginas/Delete/5
        Function ExcluirPagina(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Paginas.Obter(id))
        End Function

        ' POST: Paginas/Delete/5
        <HttpPost()>
        Function ExcluirPagina(Dados As FilantropiaDLL.Componentes.Pagina) As ActionResult
            Try
                Filantropia.Paginas.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace