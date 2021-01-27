@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Colaborador)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Colaboradores</h2>

<p>
    @Html.ActionLink("Novo Colaborador", "NovoColaborador")
</p>

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.CPFCNPJ)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Nome)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.DataRestricao)
            </th>
            <th></th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.CPFCNPJ)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Nome)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DataRestricao)
                </td>
                <td>
                    @Html.ActionLink("Endereços", actionName:="Enderecos", controllerName:="Enderecos", routeValues:=New With {.id = item.IDPessoa}, htmlAttributes:=Nothing) |
                    @Html.ActionLink("Telefones", actionName:="Telefones", controllerName:="Telefones", routeValues:=New With {.id = item.IDPessoa}, htmlAttributes:=Nothing)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarColaborador", New With {.id = item.ID}) |
                    @Html.ActionLink("Detalhes", "DetalhesColaborador", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirColaborador", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
 End if