@ModelType IEnumerable(Of FilantropiaDLL.Componentes.Endereco)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Endereços</h2>

<p>
    @Html.ActionLink("Novo Endereço", "NovoEndereco")
</p>
@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.IDPessoa)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Logradouro)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Numero)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Complemento)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Bairro)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Cidade)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.UF)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.CEP)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.OBS)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.IDResponsavelCadastro)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.DataRegistro)
            </th>
            <th></th>
        </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.IDPessoa)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Logradouro)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Numero)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Complemento)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Bairro)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Cidade)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.UF)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CEP)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.OBS)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.IDResponsavelCadastro)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.DataRegistro)
            </td>
            <td>
                @Html.ActionLink("Alterar", "AlterarEndereco", New With {.id = item.ID}) |
                @Html.ActionLink("Excluir", "ExcluirEndereco", New With {.id = item.ID})
            </td>
        </tr>   Next

    </table>
end if
