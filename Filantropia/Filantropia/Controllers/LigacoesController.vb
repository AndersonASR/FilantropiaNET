Imports System.Web.Mvc

Namespace Controllers
    Public Class LigacoesController
        Inherits Controller

        ' GET: Ligacoes
        <Route("Ligacoes/Ligacoes")>
        Function Index() As ActionResult
            Return View(Filantropia.HistoricoChamadas.ObterTodos(Now.AddMonths(-1)))
        End Function

        ' GET: Ligacoes/Create
        Function NovaLigacao() As ActionResult
            Dim Tels As List(Of FilantropiaDLL.Componentes.Telefone) = Filantropia.Telefones.ObterTodos
            If Tels Is Nothing Then Tels = New List(Of FilantropiaDLL.Componentes.Telefone)
            Dim ListItem As List(Of SelectListItem) = New List(Of SelectListItem)
            For Each T In Tels
                ListItem.Add(New SelectListItem With {.Text = T.Telefone, .Value = T.ID})
            Next
            ListItem.Insert(0, New SelectListItem With {.Text = "Novo Telefone", .Value = 0})
            ViewBag.Telefones = New SelectList(ListItem, "Value", "Text", "")

            Dim Inst As List(Of FilantropiaDLL.Componentes.Instituto) = Filantropia.Institutos.ObterTodos
            If Inst Is Nothing Then Inst = New List(Of FilantropiaDLL.Componentes.Instituto)
            ListItem = New List(Of SelectListItem)
            For Each I In Inst
                ListItem.Add(New SelectListItem With {.Text = I.Nome, .Value = I.ID})
            Next
            ListItem.Insert(0, New SelectListItem With {.Text = "Novo Instituto", .Value = 0})
            ViewBag.Institutos = New SelectList(ListItem, "Value", "Text", "")

            Dim Camp As List(Of FilantropiaDLL.Componentes.Campanha) = Filantropia.Campanhas.ObterTodos
            If Camp Is Nothing Then Camp = New List(Of FilantropiaDLL.Componentes.Campanha)
            ListItem = New List(Of SelectListItem)
            For Each Cmp In Camp
                ListItem.Add(New SelectListItem With {.Text = Cmp.Campanha, .Value = Cmp.ID})
            Next
            ListItem.Insert(0, New SelectListItem With {.Text = "Nova Campanha", .Value = 0})
            ViewBag.Campanhas = New SelectList(ListItem, "Value", "Text", "")

            Dim Colab As List(Of FilantropiaDLL.Componentes.Colaborador) = Filantropia.Colaboradores.ObterTodos
            If Colab Is Nothing Then Colab = New List(Of FilantropiaDLL.Componentes.Colaborador)
            ListItem = New List(Of SelectListItem)
            For Each Clb In Colab
                ListItem.Add(New SelectListItem With {.Text = Clb.Nome, .Value = Clb.ID})
            Next
            ListItem.Insert(0, New SelectListItem With {.Text = "Novo Colaborador", .Value = 0})
            ViewBag.Colaboradores = Colab

            Return View()
        End Function

        ' POST: Ligacoes/Create
        <HttpPost()>
        Function NovaLigacao(Dados As FilantropiaDLL.Componentes.HistoricoChamada) As ActionResult
            Try
                Filantropia.HistoricoChamadas.InserirNovo(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Ligacoes/Edit/5
        Function AlterarLigacao(ByVal id As Integer) As ActionResult
            ViewBag.Telefones = Filantropia.Telefones.ObterTodos
            ViewBag.Institutos = Filantropia.Institutos.ObterTodos
            ViewBag.Campanhas = Filantropia.Campanhas.ObterTodos
            Dim Colab As New List(Of FilantropiaDLL.Componentes.Colaborador)
            Colab = Filantropia.Colaboradores.ObterTodos
            Dim C As New FilantropiaDLL.Componentes.Colaborador
            C.ID = 0
            C.Nome = "Novo Colabrador"
            Colab.Insert(0, C)
            ViewBag.Colaboradores = Colab
            Return View(Filantropia.HistoricoChamadas.Obter(id))
        End Function

        ' POST: Ligacoes/Edit/5
        <HttpPost()>
        Function AlterarLigacao(Dados As FilantropiaDLL.Componentes.HistoricoChamada) As ActionResult
            Try
                Filantropia.HistoricoChamadas.Atualizar(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Ligacoes/Delete/5
        Function ExcluirLigacao(ByVal id As Integer) As ActionResult
            Return View(Filantropia.HistoricoChamadas.Obter(id))
        End Function

        ' POST: Ligacoes/Delete/5
        <HttpPost()>
        Function ExcluirLigacao(Dados As FilantropiaDLL.Componentes.HistoricoChamada) As ActionResult
            Try
                Filantropia.HistoricoChamadas.Excluir(Dados)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace