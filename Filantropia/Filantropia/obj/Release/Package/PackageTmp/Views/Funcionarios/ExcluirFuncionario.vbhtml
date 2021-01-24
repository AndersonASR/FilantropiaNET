@ModelType FilantropiaDLL.Componentes.Funcionario
@Code
    ViewData("Title") = "ExcluirFuncionario"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Funcionario</h2>

<h3>Deseja realmente remover este funcionário do sistema?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Excluir" class="btn btn-default" /> |
            @Html.ActionLink("Voltar para a Lista", "Index")
        </div>
    End Using
</div>
