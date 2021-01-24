Imports System.Web.Mvc

Namespace Controllers
    Public Class TiposReferenciasController
        Inherits Controller

        ' GET: TiposReferencias
        <Route("TiposReferencias/TiposReferencias")>
        Function Index() As ActionResult
            Return View(Filantropia.TiposReferencias.ObterTodos)
        End Function

        ' GET: TiposReferencias/Create
        Function NovoTipoReferencia() As ActionResult
            Return View()
        End Function

        ' POST: TiposReferencias/Create
        <HttpPost()>
        Function NovoTipoReferencia(Dados As FilantropiaDLL.Componentes.TipoReferencia) As ActionResult
            Try
                ' TODO: Add insert logic here
                Filantropia.TiposReferencias.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: TiposReferencias/Edit/5
        Function AlterarTipoReferencia(ByVal id As Integer) As ActionResult
            Return View(Filantropia.TiposReferencias.Obter(id))
        End Function

        ' POST: TiposReferencias/Edit/5
        <HttpPost()>
        Function AlterarTipoReferencia(Dados As FilantropiaDLL.Componentes.TipoReferencia) As ActionResult
            Try
                ' TODO: Add update logic here
                Filantropia.TiposReferencias.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: TiposReferencias/Delete/5
        Function ExcluirTipoReferencia(ByVal id As Integer) As ActionResult
            Return View(Filantropia.TiposReferencias.Obter(id))
        End Function

        ' POST: TiposReferencias/Delete/5
        <HttpPost()>
        Function ExcluirTipoReferencia(Dados As FilantropiaDLL.Componentes.TipoReferencia) As ActionResult
            Try
                ' TODO: Add delete logic here
                Filantropia.TiposReferencias.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace