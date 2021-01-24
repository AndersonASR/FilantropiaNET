Imports System.Web.Mvc

Namespace Controllers
    Public Class AgendamentosController
        Inherits Controller

        ' GET: Agendamentos
        <Route("Agendamentos/Agendamentos")>
        Function Index() As ActionResult
            Return View(Filantropia.Agendamentos.ObterTodos)
        End Function

        ' GET: Agendamentos/Create
        Function NovoAgendamento() As ActionResult
            Return View()
        End Function

        ' POST: Agendamentos/Create
        <HttpPost()>
        Function NovoAgendamento(Dados As FilantropiaDLL.Componentes.Agendamento) As ActionResult
            Try
                Filantropia.Agendamentos.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Agendamentos/Edit/5
        Function AlterarAgendamento(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Agendamentos.Obter(id))
        End Function

        ' POST: Agendamentos/Edit/5
        <HttpPost()>
        Function AlterarAgendamento(Dados As FilantropiaDLL.Componentes.Agendamento) As ActionResult
            Try
                Filantropia.Agendamentos.Atualizar(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Agendamentos/Delete/5
        Function ExcluirAgendamento(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Agendamentos.Obter(id))
        End Function

        ' POST: Agendamentos/Delete/5
        <HttpPost()>
        Function ExcluirAgendamento(Dados As FilantropiaDLL.Componentes.Agendamento) As ActionResult
            Try
                Filantropia.Agendamentos.Excluir(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace