@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Funcionario)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Funcionários</h2>

<p>
    @Html.ActionLink("Novo Funcionário", "NovoFuncionario")
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
                @Html.DisplayNameFor(Function(model) model.DataAdmissao)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.DataDesligamento)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.RG)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.EstadoCivil)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Ativo)
            </th>
            <th>
            </th>
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
                    @Html.DisplayFor(Function(modelItem) item.DataAdmissao)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DataDesligamento)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.RG)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.EstadoCivil)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Ativo)
                </td>
                <td>
                    @Html.ActionLink("Endereços", actionName:="Enderecos", controllerName:="Enderecos", routeValues:=New With {.id = item.IDPessoa}, htmlAttributes:=Nothing) |
                    @Html.ActionLink("Telefones", actionName:="Telefones", controllerName:="Telefones", routeValues:=New With {.id = item.IDPessoa}, htmlAttributes:=Nothing)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarFuncionario", New With {.id = item.ID}) |
                    @Html.ActionLink("Detalhes", "DetalhesFuncionario", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirFuncionario", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
 End if