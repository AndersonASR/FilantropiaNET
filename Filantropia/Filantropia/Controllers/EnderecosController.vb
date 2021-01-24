Imports System.Web.Mvc

Namespace Controllers
    Public Class EnderecosController
        Inherits Controller

        ' GET: Enderecos
        <Route("Enderecos/Enderecos")>
        Function Index(IDPessoa As Int64) As ActionResult
            Return View(Filantropia.Enderecos.Obter(IDPessoa))
        End Function

        ' GET: Enderecos/Create
        Function NovoEndereco() As ActionResult
            Return View()
        End Function

        ' POST: Enderecos/Create
        <HttpPost()>
        Function NovoEndereco(Dados As FilantropiaDLL.Componentes.Endereco) As ActionResult
            Try
                ' TODO: Add insert logic here
                Filantropia.Enderecos.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Enderecos/Edit/5
        Function AlterarEndereco(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Enderecos.Obter(id))
        End Function

        ' POST: Enderecos/Edit/5
        <HttpPost()>
        Function AlterarEndereco(Dados As FilantropiaDLL.Componentes.Endereco) As ActionResult
            Try
                ' TODO: Add update logic here
                Filantropia.Enderecos.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Enderecos/Delete/5
        Function ExcluirEndereco(ByVal id As Integer) As ActionResult
            Return View(Filantropia.Enderecos.Obter(id))
        End Function

        ' POST: Enderecos/Delete/5
        <HttpPost()>
        Function ExcluirEndereco(Dados As FilantropiaDLL.Componentes.Endereco) As ActionResult
            Try
                ' TODO: Add delete logic here
                Filantropia.Enderecos.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace