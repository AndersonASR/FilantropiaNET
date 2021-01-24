@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Telefone)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Telefones</h2>

<p>
    @Html.ActionLink("Novo Telefone", "NovoTelefone")
</p>

@If Not Model Is Nothing Then
    @<Table Class="table">
        <tr>
        <th>
                @Html.DisplayNameFor(Function(model) model.IDPessoa)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.DDD)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Prefixo)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Sulfixo)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Telefone)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.SMS)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.WhatsApp)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.DataRegistro)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.IDResponsavelCadastro)
            </th>
            <th></th>
        </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.IDPessoa)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.DDD)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Prefixo)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Sulfixo)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Telefone)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.SMS)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.WhatsApp)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.DataRegistro)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.IDResponsavelCadastro)
            </td>
            <td>
                @Html.ActionLink("Alterar", "AlterarTelefone", New With {.id = item.ID}) |
                @Html.ActionLink("Excluir", "ExcluirTelefone", New With {.id = item.ID})
            </td>
        </tr>
    Next

    </table>
 End if