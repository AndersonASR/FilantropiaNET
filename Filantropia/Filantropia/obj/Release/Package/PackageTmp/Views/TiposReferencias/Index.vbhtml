@ModelType IEnumerable(Of FilantropiaDLL.Componentes.TipoReferencia)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Tipos de Referências</h2>

<p>
    @Html.ActionLink("Novo Tipo de Referência", "NovoTipoReferencia")
</p>

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Referencia)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Referencia)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarTipoReferencia", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirTipoReferencia", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
 End if