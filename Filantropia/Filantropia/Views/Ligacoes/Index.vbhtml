@ModelType IEnumerable(Of FilantropiaDLL.Componentes.HistoricoChamada)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Liga;óes</h2>

<p>
    @Html.ActionLink("Nova Liga;áo", "NovaLigacao")
</p>

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.DataHora)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Atendeu)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.NumeroTentativas)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DataHora)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Atendeu)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.NumeroTentativas)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarLigacao", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirLigacao", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
 End if