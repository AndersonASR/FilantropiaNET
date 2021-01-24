@ModelType IEnumerable(Of FilantropiaDLL.Modelos.MotivosRestricoes)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Motivos Utilizados Pelos Colaboradores como Restrições de Chamadas</h2>

<p>
    @Html.ActionLink("Nova Restrição", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Motivo)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Motivo)
        </td>
        <td>
            @Html.ActionLink("Alterar Motivo", "AlterarMotivoRestricao", New With {.id = item.ID}) |
            @Html.ActionLink("Excluir Motivo", "ExcluirMotivoRestricao", New With {.id = item.ID})
        </td>
    </tr>
Next

</table>
