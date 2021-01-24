@ModelType IEnumerable(Of FilantropiaDLL.Componentes.FormaPagamento)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Formas de Pagamentos</h2>

<p>
    @Html.ActionLink("Nova Forma de Pagamento", "NovaFormaPagamento")
</p>

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.FormaPagamento)
            </th>
            <th></th>
        </tr>

        @If Not Model Is Nothing Then
            @For Each item In Model
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.FormaPagamento)
                    </td>
                    <td>
                        @Html.ActionLink("Edit", "Edit", New With {.id = item.ID}) |
                        @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
                    </td>
                </tr>
            Next
        End IF
    </table>
 End if