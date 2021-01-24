@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Agendamento)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Agendamentos</h2>

<p>
    @Html.ActionLink("Novo Agendamento", "NovoAgendamento")
</p>

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Inicio)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Valor)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.UltimaContribuicao)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Inicio)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Valor)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.UltimaContribuicao)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarAgendamento", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirAgendamento", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
 End if