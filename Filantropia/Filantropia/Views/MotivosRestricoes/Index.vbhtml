@ModelType IEnumerable(Of FilantropiaDLL.Componentes.MotivoRestricao)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Motivos das Restrições</h2>

<p>
    @Html.ActionLink("Novo Motivo de Restrição", "NovoMotivoRestricao")
</p>

@If Not Model Is Nothing Then

    @<table class="table">
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
                    @Html.ActionLink("Alterar", "AlterarMotivoRestricao", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirMotivoRestricao", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
End If