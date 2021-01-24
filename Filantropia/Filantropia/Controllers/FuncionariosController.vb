Imports System.Web.Mvc

Namespace Controllers
    Public Class FuncionariosController
        Inherits Controller

        ' GET: Funcionarios
        <Route("Funcionarios/Funcionarios")>
        Function Index() As ActionResult
            Return View(Filantropia.Funcionarios.ObterTodos)
        End Function

        ' GET: Funcionarios/Details/5
        Function DetalhesFuncionario(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Funcionarios.Obter(id))
        End Function

        ' GET: Funcionarios/Create
        Function NovoFuncionario() As ActionResult
            Return View()
        End Function

        ' POST: Funcionarios/Create
        <HttpPost()>
        Function NovoFuncionario(Dados As FilantropiaDLL.Componentes.Funcionario) As ActionResult
            Try

                Dados.IDResponsavelCadastro = CType(Session("Usuario"), FilantropiaDLL.Componentes.Funcionario).ID
                Filantropia.Funcionarios.InserirNovo(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Funcionarios/Edit/5
        Function AlterarFuncionario(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Funcionarios.Obter(id))
        End Function

        ' POST: Funcionarios/Edit/5
        <HttpPost()>
        Function AlterarFuncionario(Dados As FilantropiaDLL.Componentes.Funcionario) As ActionResult
            Try

                Filantropia.Funcionarios.Atualizar(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Funcionarios/Edit/5
        Function AlterarSenhaFuncionario(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Funcionarios.Obter(id))
        End Function

        ' POST: Funcionarios/Edit/5
        <HttpPost()>
        Function AlterarSenhaFuncionario(Dados As FilantropiaDLL.Componentes.Funcionario) As ActionResult
            Try

                If Filantropia.Funcionarios.AlterarSenha(Dados.CPFCNPJ, Dados.RG, Dados.Senha) Then
                    Return RedirectToAction("Index")
                Else
                    Return RedirectToAction("Index")
                End If
            Catch
                Return View()
            End Try
        End Function

        ' GET: Funcionarios/Delete/5
        Function ExcluirFuncionario(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Funcionarios.Obter(id))
        End Function

        ' POST: Funcionarios/Delete/5
        <HttpPost()>
        Function ExcluirFuncionario(Dados As FilantropiaDLL.Componentes.Funcionario) As ActionResult
            Try

                Filantropia.Funcionarios.Excluir(Dados)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace