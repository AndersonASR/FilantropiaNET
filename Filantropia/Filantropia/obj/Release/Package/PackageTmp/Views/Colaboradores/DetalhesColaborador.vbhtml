@ModelType FilantropiaDLL.Componentes.Colaborador
@Code
    ViewData("Title") = "DetalhesColaborador"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Detalhes do Colaborador</h2>

<div>
    <h4>Colaborador</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.CPFCNPJ)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CPFCNPJ)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nome)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nome)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DataRestricao)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataRestricao)
        </dd>

    </dl>
</div>

<p>
    <table class="table">
        <tr>
            <th>
                DDD
            </th>
            <th>
                Telefone
            </th>
            <th>@Html.ActionLink("Incluir Novo Telefone", "NovoTelefone", "Telefones", New With {.id = Model.IDPessoa})</th>
        </tr>

        @For Each item In Model.Telefones
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DDD)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Telefone)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarTelefone", "Telefones", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirTelefone", "Telefones", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
</p>

<p>
    <table class="table">
        <tr>
            <th>
                Logradouro
            </th>
            <th>
                Número
            </th>
            <th>
                Complemento
            </th>
            <th>
                Bairro
            </th>
            <th>
                Cidade
            </th>
            <th>
                Estado
            </th>
            <th>
                CEP
            </th>
            <th>
                Observações
            </th>
            <th>@Html.ActionLink("Incluir Novo Endereço", "NovoEndereco", "Enderecos", New With {.id = Model.IDPessoa})</th>
        </tr>

        @For Each item In Model.Enderecos
            @<tr>
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
                    @Html.ActionLink("Alterar", "AlterarEndereco", "Enderecos", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirEndereco", "Enderecos", New With {.id = item.ID})
                </td>
            </tr>
        Next
    </table>
</p>

<p>
    @Html.ActionLink("Alterar", "AlterarColaborador", New With {.id = Model.ID}) |
    @Html.ActionLink("Voltar para a Lista", "Index")
</p>
