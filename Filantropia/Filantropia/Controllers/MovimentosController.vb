Imports System.Web.Mvc

Namespace Controllers
    Public Class MovimentosController
        Inherits Controller

        ' GET: Movimentos
        <Route("Movimentos/Movimentos")>
        Function Index() As ActionResult
            Return View(Filantropia.Movimentos.ObterTodos)
        End Function

        ' GET: Movimentos/Create
        Function NovoMovimento() As ActionResult
            Return View()
        End Function

        ' POST: Movimentos/Create
        <HttpPost()>
        Function NovoMovimento(Dados As FilantropiaDLL.Componentes.Movimento) As ActionResult
            Try
                Filantropia.Movimentos.InserirNovo(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Movimentos/Edit/5
        Function AlterarMovimento(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Movimentos.Obter(id))
        End Function

        ' POST: Movimentos/Edit/5
        <HttpPost()>
        Function AlterarMovimento(Dados As FilantropiaDLL.Componentes.Movimento) As ActionResult
            Try
                Filantropia.Movimentos.Atualizar(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Movimentos/Delete/5
        Function ExcluirMovimento(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Movimentos.Obter(id))
        End Function

        ' POST: Movimentos/Delete/5
        <HttpPost()>
        Function ExcluirMovimento(Dados As FilantropiaDLL.Componentes.Movimento) As ActionResult
            Try
                Filantropia.Movimentos.Excluir(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace