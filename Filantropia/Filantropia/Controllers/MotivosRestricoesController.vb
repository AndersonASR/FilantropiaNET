Imports System.Web.Mvc

Namespace Controllers
    Public Class MotivosRestricoesController
        Inherits Controller

        ' GET: MotivosRestricoes
        <Route("MotivosRestricoes/MotivosRestricoes")>
        Function Index() As ActionResult
            Return View(Filantropia.MotivosRestricoes.ObterTodos)
        End Function

        ' GET: MotivosRestricoes/Create
        Function NovoMotivoRestricao() As ActionResult
            Return View()
        End Function

        ' POST: MotivosRestricoes/Create
        <HttpPost()>
        Function NovoMotivoRestricao(Dados As FilantropiaDLL.Componentes.MotivoRestricao) As ActionResult
            Try
                Filantropia.MotivosRestricoes.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: MotivosRestricoes/Edit/5
        Function AlterarMotivoRestricao(ByVal id As Integer) As ActionResult
            Return View(Filantropia.MotivosRestricoes.Obter(id))
        End Function

        ' POST: MotivosRestricoes/Edit/5
        <HttpPost()>
        Function AlterarMotivoRestricao(Dados As FilantropiaDLL.Componentes.MotivoRestricao) As ActionResult
            Try
                Filantropia.MotivosRestricoes.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: MotivosRestricoes/Delete/5
        Function ExcluirMotivoRestricao(ByVal id As Integer) As ActionResult
            Return View(Filantropia.MotivosRestricoes.Obter(id))
        End Function

        ' POST: MotivosRestricoes/Delete/5
        <HttpPost()>
        Function ExcluirMotivoRestricao(Dados As FilantropiaDLL.Componentes.MotivoRestricao) As ActionResult
            Try
                Filantropia.MotivosRestricoes.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace