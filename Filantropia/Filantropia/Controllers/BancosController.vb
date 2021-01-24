Imports System.Web.Mvc

Namespace Controllers
    Public Class BancosController
        Inherits Controller

        ' GET: Bancos
        <Route("Bancos/Bancos")>
        Function Index() As ActionResult
            Return View(Filantropia.Bancos.ObterTodos)
        End Function

        ' GET: Bancos/Create
        Function NovoBanco() As ActionResult
            Return View()
        End Function

        ' POST: Bancos/Create
        <HttpPost()>
        Function NovoBanco(ByVal Dados As FilantropiaDLL.Componentes.Banco) As ActionResult
            Try
                ' TODO: Add insert logic here

                Filantropia.Bancos.InserirNovo(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Bancos/Edit/5
        Function AlterarBanco(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Bancos.Obter(id))
        End Function

        ' POST: Bancos/Edit/5
        <HttpPost()>
        Function AlterarBanco(Dados As FilantropiaDLL.Componentes.Banco) As ActionResult
            Try

                Filantropia.Bancos.Atualizar(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Bancos/Delete/5
        Function ExcluirBanco(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Bancos.Obter(id))
        End Function

        ' POST: Bancos/Delete/5
        <HttpPost()>
        Function ExcluirBanco(Dados As FilantropiaDLL.Componentes.Banco) As ActionResult
            Try

                Filantropia.Bancos.Excluir(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace