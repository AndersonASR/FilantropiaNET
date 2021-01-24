@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Log)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Log</h2>

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.DataHora)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Acao)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Descricao)
            </th>
        </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.DataHora)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Acao)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Descricao)
            </td>
        </tr>
    Next

    </table>
end if