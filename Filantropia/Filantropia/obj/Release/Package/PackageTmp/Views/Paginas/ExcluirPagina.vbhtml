@ModelType FilantropiaDLL.Componentes.Pagina
@Code
    ViewData("Title") = "ExcluirPagina"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Pagina</h2>

<h3>Deseja realmente excluir esta Página do sistema?</h3>
<div>
    <h4>Página</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Pagina)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Pagina)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Descricao)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Descricao)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Publica)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Publica)
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
