Imports System.Web.Mvc

Namespace Controllers
    Public Class ColaboradoresController
        Inherits Controller

        ' GET: Colaboradores
        <Route("Colaboradores/Colaboradores")>
        Function Index() As ActionResult
            Return View(Filantropia.Colaboradores.ObterTodos)
        End Function

        ' GET: Colaboradores/Details/5
        Function DetalhesColaborador(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Colaboradores.Obter(id))
        End Function

        ' GET: Colaboradores/Create
        Function NovoColaborador() As ActionResult
            Return View()
        End Function

        ' POST: Colaboradores/Create
        <HttpPost()>
        Function NovoColaborador(Dados As FilantropiaDLL.Componentes.Colaborador) As ActionResult
            Try
                ' TODO: Add insert logic here
                Filantropia.Colaboradores.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Colaboradores/Edit/5
        Function AlterarColaborador(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Colaboradores.Obter(id))
        End Function

        ' POST: Colaboradores/Edit/5
        <HttpPost()>
        Function AlterarColaborador(Dados As FilantropiaDLL.Componentes.Colaborador) As ActionResult
            Try
                ' TODO: Add update logic here
                Filantropia.Colaboradores.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Colaboradores/Delete/5
        Function ExcluirColaborador(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Colaboradores.Obter(id))
        End Function

        ' POST: Colaboradores/Delete/5
        <HttpPost()>
        Function ExcluirColaborador(Dados As FilantropiaDLL.Componentes.Colaborador) As ActionResult
            Try
                ' TODO: Add delete logic here
                Filantropia.Colaboradores.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace