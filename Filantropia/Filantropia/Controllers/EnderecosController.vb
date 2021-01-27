Imports System.Web.Mvc

Namespace Controllers
    Public Class EnderecosController
        Inherits Controller

        ' GET: Enderecos
        <Route("Enderecos/Enderecos/{IDPessoa}")>
        Function Index(IDPessoa As Int64) As ActionResult
            Return View(Filantropia.Enderecos.ObterTodos(IDPessoa))
        End Function

        ' GET: Enderecos/Create
        <Route("Enderecos/NovoEndereco/{IDPessoa}")>
        Function NovoEndereco(IDPessoa As Int64) As ActionResult
            TempData("IDPessoa") = IDPessoa

            Dim Tipos As List(Of FilantropiaDLL.Componentes.TipoReferencia) = Filantropia.TiposReferencias.ObterTodos
            Dim ListItem As List(Of SelectListItem) = New List(Of SelectListItem)
            For Each T In Tipos
                ListItem.Add(New SelectListItem With {.Text = T.Referencia, .Value = T.ID})
            Next
            ViewBag.Tipos = New SelectList(ListItem, "Value", "Text", "")

            Return View()
        End Function

        ' POST: Enderecos/Create
        <HttpPost()>
        <Route("Enderecos/NovoEndereco/{IDPessoa}")>
        Function NovoEndereco(IDPessoa As Int64, Dados As FilantropiaDLL.Componentes.Endereco) As ActionResult
            Try
                Dados.IDResponsavelCadastro = CType(Session("Usuario"), FilantropiaDLL.Componentes.Pessoa).ID
                Dados.IDPessoa = TempData("IDPessoa")
                Dados.TipoEndereco = Filantropia.TiposReferencias.Obter(Convert.ToInt64(Request("TipoEndereco.ID")))
                Filantropia.Enderecos.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Enderecos/Edit/5
        <Route("Enderecos/AlterarEndereco/{IDPessoa}/{IDEndereco}")>
        Function AlterarEndereco(ByVal IDPessoa As Integer, IDEndereco As Integer) As ActionResult
            TempData("IDPessoa") = IDPessoa
            TempData("IDEndereco") = IDEndereco
            Return View(Filantropia.Enderecos.Obter(IDPessoa, IDEndereco))
        End Function

        ' POST: Enderecos/Edit/5
        <HttpPost()>
        <Route("Enderecos/AlterarEndereco/{IDPessoa}/{IDEndereco}")>
        Function AlterarEndereco(ByVal IDPessoa As Integer, IDEndereco As Integer, Dados As FilantropiaDLL.Componentes.Endereco) As ActionResult
            Try
                Dados.IDPessoa = TempData("IDPessoa")
                Dados.ID = TempData("IDEndereco")
                Filantropia.Enderecos.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Enderecos/Delete/5
        <Route("Enderecos/ExcluirEndereco/{IDPessoa}/{IDEndereco}")>
        Function ExcluitEndereco(ByVal IDPessoa As Integer, IDEndereco As Integer) As ActionResult
            TempData("IDPessoa") = IDPessoa
            TempData("IDEndereco") = IDEndereco
            Return View(Filantropia.Enderecos.Obter(IDPessoa, IDEndereco))
        End Function

        ' POST: Enderecos/Delete/5
        <HttpPost()>
        <Route("Enderecos/ExcluirEndereco/{IDPessoa}/{IDEndereco}")>
        Function ExcluitEndereco(ByVal IDPessoa As Integer, IDEndereco As Integer, Dados As FilantropiaDLL.Componentes.Endereco) As ActionResult
            Try
                Dados.IDPessoa = TempData("IDPessoa")
                Dados.ID = TempData("IDEndereco")
                Filantropia.Enderecos.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace