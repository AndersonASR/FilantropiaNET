Imports System.Web.Mvc

Namespace Controllers
    Public Class TelefonesController
        Inherits Controller

        ' GET: Telefones
        <Route("Telefones/Telefones/{IDPessoa}")>
        Function Index(IDPessoa As Int64) As ActionResult
            Return View(Filantropia.Telefones.ObterTodos(IDPessoa))
        End Function

        ' GET: Telefones/Create
        <Route("Telefones/NovoTelefone/{IDPessoa}")>
        Function NovoTelefone(IDPessoa As Int64) As ActionResult
            TempData("IDPessoa") = IDPessoa

            Dim Tipos As List(Of FilantropiaDLL.Componentes.TipoReferencia) = Filantropia.TiposReferencias.ObterTodos
            Dim ListItem As List(Of SelectListItem) = New List(Of SelectListItem)
            For Each T In Tipos
                ListItem.Add(New SelectListItem With {.Text = T.Referencia, .Value = T.ID})
            Next
            ViewBag.Tipos = New SelectList(ListItem, "Value", "Text", "")

            Return View()
        End Function

        ' POST: Telefones/Create
        <HttpPost()>
        <Route("Telefones/NovoTelefone/{IDPessoa}")>
        Function NovoTelefone(IDPessoa As Int64, Dados As FilantropiaDLL.Componentes.Telefone) As ActionResult
            Try
                Dados.IDResponsavelCadastro = CType(Session("Usuario"), FilantropiaDLL.Componentes.Pessoa).ID
                Dados.IDPessoa = TempData("IDPessoa")
                Dados.TipoReferencia = Filantropia.TiposReferencias.Obter(Convert.ToInt64(Request("TipoReferencia.ID")))
                Filantropia.Telefones.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Telefones/Edit/5
        <Route("Telefones/AlterarTelefone/{IDPessoa}/{IDTelefone}")>
        Function AlterarTelefone(ByVal IDPessoa As Integer, IDTelefone As Integer) As ActionResult
            TempData("IDPessoa") = IDPessoa
            TempData("IDTelefone") = IDTelefone
            Return View(Filantropia.Telefones.Obter(IDPessoa, IDTelefone))
        End Function

        ' POST: Telefones/Edit/5
        <HttpPost()>
        <Route("Telefones/AlterarTelefone/{IDPessoa}/{IDTelefone}")>
        Function AlterarTelefone(ByVal IDPessoa As Integer, IDTelefone As Integer, Dados As FilantropiaDLL.Componentes.Telefone) As ActionResult
            Try
                Dados.IDPessoa = TempData("IDPessoa")
                Dados.ID = TempData("IDTelefone")
                Filantropia.Telefones.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Telefones/Delete/5
        <Route("Telefones/ExcluirTelefone/{IDPessoa}/{IDTelefone}")>
        Function ExcluitTelefone(ByVal IDPessoa As Integer, IDTelefone As Integer) As ActionResult
            TempData("IDPessoa") = IDPessoa
            TempData("IDTelefone") = IDTelefone
            Return View(Filantropia.Telefones.Obter(IDPessoa, IDTelefone))
        End Function

        ' POST: Telefones/Delete/5
        <HttpPost()>
        <Route("Telefones/ExcluirTelefone/{IDPessoa}/{IDTelefone}")>
        Function ExcluitTelefone(ByVal IDPessoa As Integer, IDTelefone As Integer, Dados As FilantropiaDLL.Componentes.Telefone) As ActionResult
            Try
                Dados.IDPessoa = TempData("IDPessoa")
                Dados.ID = TempData("IDTelefone")
                Filantropia.Telefones.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        Public Function ObterTelefones(termo As String) As ActionResult
            Return Json(Filantropia.Telefones.ObterTodos().Where(Function(c) c.Telefone.StartsWith(termo)).Select(Function(a) New With {.label = a.Telefone, .id = a.ID}), JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace