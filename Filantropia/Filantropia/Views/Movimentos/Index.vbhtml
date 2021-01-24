@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Movimento)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Movimentos</h2>

<p>
    @Html.ActionLink("Novo Movimento", "NovoMovimento")
</p>

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.DataHoraAgendada)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Agencia)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Conta)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.DigitoConta)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.DataHoraConfirmacao)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ValorPrevisto)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ValorRecebido)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.NumeroRecibo)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DataHoraAgendada)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Agencia)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Conta)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DigitoConta)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DataHoraConfirmacao)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.ValorPrevisto)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.ValorRecebido)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.NumeroRecibo)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarMovimento", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirMovimento", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
 End if