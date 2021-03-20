@ModelType FilantropiaDLL.Componentes.Funcionario
@Code
    ViewData("Title") = "DetalhesFuncionario"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Detalhes do Funcionario</h2>

<div>
    <h4>Funcionario</h4>
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
            @Html.DisplayNameFor(Function(model) model.DataAdmissao)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataAdmissao)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DataDesligamento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataDesligamento)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RG)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RG)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.EstadoCivil)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EstadoCivil)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Ativo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Ativo)
        </dd>

    </dl>
</div>

@If Not Model.Telefones Is Nothing Then
    @<p>
        <Table Class="table">
            <tr>
                <th>
                    DDD
                </th>
                <th>
                    Telefone
                </th>
                <th>
                    Padrao
                </th>
                <th>@Html.ActionLink("Incluir Novo Telefone", "NovoTelefone", "Telefones", New With {.IDPessoa = Model.IDPessoa})</th>
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
                        @Html.DisplayFor(Function(modelItem) item.Padrao)
                    </td>
                    <td>
                        @Html.ActionLink("Alterar", "AlterarTelefone", "Telefones", New With {.id = item.IDPessoa, .idtelefone = item.ID}) |
                        @Html.ActionLink("Excluir", "ExcluirTelefone", "Telefones", New With {.id = item.IDPessoa, .idtelefone = item.ID})
                    </td>
                </tr>
            Next

        </Table>
    </p>
Else
    @Html.ActionLink("Incluir Telefone", "NovoTelefone", "Telefones", New With {.id = Model.IDPessoa}, Nothing)
End If

@If Not Model.Enderecos Is Nothing Then
    @<p>
        <Table Class="table">
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
                <th>
                    Padrão
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
                        @Html.DisplayFor(Function(modelItem) item.Padrao)
                    </td>
                    <td>
                        @Html.ActionLink("Alterar", "AlterarEndereco", "Enderecos", New With {.id = item.ID}) |
                        @Html.ActionLink("Excluir", "ExcluirEndereco", "Enderecos", New With {.id = item.ID})
                    </td>
                </tr>
            Next
        </Table>
    </p>
Else
    @Html.ActionLink("Incluir Endereço", "NovoEndereco", "Enderecos", New With {.id = Model.IDPessoa}, Nothing)
End If

<p>
    @Html.ActionLink("Alterar", "AlterarFuncionario", New With {.id = Model.ID}) |
    @Html.ActionLink("Voltar para a Lista", "Index")
</p>
