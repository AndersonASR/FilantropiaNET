﻿@ModelType IEnumerable(Of FilantropiaDLL.Modelos.EstadosCivis)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Estados Civis</h2>

<p>
    @Html.ActionLink("Novo Estado Civil", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.EstadoCivil)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EstadoCivil)
        </td>
        <td>
            @Html.ActionLink("Alterar", "AlterarEstadoCivil", New With {.id = item.ID}) |
            @Html.ActionLink("Excluir", "ExcluirEstadoCivil", New With {.id = item.ID})
        </td>
    </tr>
Next

</table>
