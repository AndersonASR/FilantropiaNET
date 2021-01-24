@ModelType FilantropiaDLL.Componentes.Colaborador
@Code
    ViewData("Title") = "ExcluirColaborador"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Colaborador</h2>

<h3>Deseja realmente excluir este colocaborador dos registros?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Excluir" class="btn btn-default" /> |
            @Html.ActionLink("Voltar para a Lista", "Index")
        </div>
    End Using
</div>
