Imports System.Web.Mvc

Namespace Controllers
    Public Class TiposPessoasController
        Inherits Controller

        ' GET: TiposPessoas
        <Route("TiposPessoas/TiposPessoas")>
        Function Index() As ActionResult
            Return View(Filantropia.TiposPEssoas.ObterTodos)
        End Function

        ' GET: TiposPessoas/Create
        Function NovoTipoPessoa() As ActionResult
            Return View()
        End Function

        ' POST: TiposPessoas/Create
        <HttpPost()>
        Function NovoTipoPessoa(Dados As FilantropiaDLL.Componentes.TipoPessoa) As ActionResult
            Try
                Filantropia.TiposPEssoas.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: TiposPessoas/Edit/5
        Function AlterarTipoPessoa(ByVal id As Integer) As ActionResult
            Return View(Filantropia.TiposPessoas.Obter(id))
        End Function

        ' POST: TiposPessoas/Edit/5
        <HttpPost()>
        Function AlterarTipoPessoa(Dados As FilantropiaDLL.Componentes.TipoPessoa) As ActionResult
            Try
                Filantropia.TiposPEssoas.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: TiposPessoas/Delete/5
        Function ExcluirTipoPessoa(ByVal id As Integer) As ActionResult
            Return View(Filantropia.TiposPessoas.Obter(id))
        End Function

        ' POST: TiposPessoas/Delete/5
        <HttpPost()>
        Function ExcluirTipoPessoa(Dados As FilantropiaDLL.Componentes.TipoPessoa) As ActionResult
            Try
                Filantropia.TiposPEssoas.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace