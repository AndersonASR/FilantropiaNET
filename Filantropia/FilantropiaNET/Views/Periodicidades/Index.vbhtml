@ModelType IEnumerable(Of FilantropiaDLL.Modelos.Periodicidades)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Periodicidades</h2>

<p>
    @Html.ActionLink("Nova", "NovaPEriodicidade")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Periodo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Meses)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Periodo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Meses)
        </td>
        <td>
            @Html.ActionLink("Edit", "AlterarPeriodicidade", New With {.id = item.ID}) |
            @Html.ActionLink("Delete", "ExcluirPeriodicidade", New With {.id = item.ID})
        </td>
    </tr>
Next

</table>
