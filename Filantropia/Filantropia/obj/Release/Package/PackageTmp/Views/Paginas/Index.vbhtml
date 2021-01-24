@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Pagina)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Páginas</h2>

<p>
    @Html.ActionLink("Nova Página", "NovaPagina")
</p>

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Pagina)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Descricao)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Publica)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Pagina)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Descricao)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Publica)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlteraPagina", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirPagina", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
 End if