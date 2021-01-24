@ModelType IEnumerable(Of FilantropiaDLL.Modelos.Bancos)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Bancos</h2>

<p>
    @Html.ActionLink("Novo Banco", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Numero)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Banco)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.[Alias])
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Numero)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Banco)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.[Alias])
        </td>
        <td>
            @Html.ActionLink("Alterar", "EditarBanco", New With {.id = item.ID}) |
            @Html.ActionLink("Excluir", "ExcluirBanco", New With {.id = item.ID})
        </td>
    </tr>
Next

</table>
