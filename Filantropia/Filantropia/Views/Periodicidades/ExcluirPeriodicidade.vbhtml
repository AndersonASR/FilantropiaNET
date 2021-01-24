@ModelType FilantropiaDLL.Componentes.Periodicidade
@Code
    ViewData("Title") = "ExcluirPeriodicidade"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Periodicidade</h2>

<h3>Tem certeza de que deseja excluir este registro?</h3>
<div>
    <h4>Periodicidade</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Periodo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Periodo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Meses)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Meses)
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
