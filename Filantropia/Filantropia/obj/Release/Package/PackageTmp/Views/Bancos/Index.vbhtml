@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Banco)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Bancos</h2>

<p>
    @Html.ActionLink("Novo Banco", "NovoBanco")
</p>

@If Not Model Is Nothing Then
    @<Table Class="table">
        <tr>
        <th>
                @Html.DisplayNameFor(Function(model) model.Numero)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Banco)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Apelido)
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
                @Html.DisplayFor(Function(modelItem) item.Apelido)
            </td>
            <td>
                @Html.ActionLink("Alterar", "AlterarBanco", New With {.id = item.ID}) |
                @Html.ActionLink("Excluir", "ExcluirBanco", New With {.id = item.ID})
            </td>
        </tr>   Next

    </table>
End If