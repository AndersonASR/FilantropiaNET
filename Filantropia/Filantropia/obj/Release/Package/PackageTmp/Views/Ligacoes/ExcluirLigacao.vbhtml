@ModelType FilantropiaDLL.Componentes.HistoricoChamada
@Code
    ViewData("Title") = "ExcluirLigacao"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Ligacao</h2>

<h3>Deseja realmente excluir este registro de ligação?</h3>
<div>
    <h4>Ligação</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.DataHora)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataHora)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Atendeu)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Atendeu)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NumeroTentativas)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NumeroTentativas)
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
