Imports System.Web.Mvc

Namespace Controllers
    Public Class TelefonesController
        Inherits Controller

        ' GET: Telefones
        <Route("Telefones/Telefones")>
        Function Index(id As Int64) As ActionResult
            Return View(Filantropia.Telefones.ObterTodos(id))
        End Function

        ' GET: Telefones/Create
        Function NovoTelefone() As ActionResult
            Return View()
        End Function

        ' POST: Telefones/Create
        <HttpPost()>
        Function NovoTelefone(Dados As FilantropiaDLL.Componentes.Telefone) As ActionResult
            Try
                Filantropia.Telefones.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Telefones/Edit/5
        Function AlterarTelefone(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Telefones.Obter(id))
        End Function

        ' POST: Telefones/Edit/5
        <HttpPost()>
        Function AlterarTelefone(Dados As FilantropiaDLL.Componentes.Telefone) As ActionResult
            Try
                Filantropia.Telefones.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Telefones/Delete/5
        Function ExcluitTelefone(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Telefones.Obter(id))
        End Function

        ' POST: Telefones/Delete/5
        <HttpPost()>
        Function ExcluitTelefone(Dados As FilantropiaDLL.Componentes.Telefone) As ActionResult
            Try
                Filantropia.Telefones.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace