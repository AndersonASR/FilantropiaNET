@ModelType IEnumerable(Of FilantropiaDLL.Componentes.TipoPessoa)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Tipos de Pessoas</h2>

<p>
    @Html.ActionLink("Novo Tipo de Pessoa", "NovoTipoPessoa")
</p>

@If Not Model Is Nothing Then

    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Tipo)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Tipo)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarTipoPessoa", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirTipoPessoa", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
End If