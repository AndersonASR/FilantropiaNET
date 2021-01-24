Imports System.Web.Mvc

Namespace Controllers
    Public Class FormasPagamentosController
        Inherits Controller

        ' GET: FormasPagamentos
        <Route("FormasPagamentos/FormasPagamentos")>
        Function Index() As ActionResult
            Return View(Filantropia.FormasPagamentos.ObterTodos)
        End Function

        ' GET: FormaPagamentos/Create
        Function NovaFormaPagamento() As ActionResult
            Return View()
        End Function

        ' POST: FormaPagamentos/Create
        <HttpPost()>
        Function NovaFormaPagamento(ByVal Dados As FilantropiaDLL.Componentes.FormaPagamento) As ActionResult
            Try
                ' TODO: Add insert logic here

                Filantropia.FormasPagamentos.InserirNovo(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: FormaPagamentos/Edit/5
        Function AlterarFormaPagamento(ByVal id As Integer) As ActionResult
            Return View(Filantropia.FormasPagamentos.Obter(id))
        End Function

        ' POST: FormaPagamentos/Edit/5
        <HttpPost()>
        Function AlterarFormaPagamento(Dados As FilantropiaDLL.Componentes.FormaPagamento) As ActionResult
            Try

                Filantropia.FormasPagamentos.Atualizar(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: FormaPagamentos/Delete/5
        Function ExcluirFormaPagamento(ByVal id As Integer) As ActionResult
            Return View(Filantropia.FormasPagamentos.Obter(id))
        End Function

        ' POST: FormaPagamentos/Delete/5
        <HttpPost()>
        Function ExcluirFormaPagamento(Dados As FilantropiaDLL.Componentes.FormaPagamento) As ActionResult
            Try

                Filantropia.FormasPagamentos.Excluir(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace