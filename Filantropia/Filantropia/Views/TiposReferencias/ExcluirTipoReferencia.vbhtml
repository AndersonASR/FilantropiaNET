@ModelType FilantropiaDLL.Componentes.TipoReferencia
@Code
    ViewData("Title") = "ExcluirTipoReferencia"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Tipo de Referência</h2>

<h3>Deseja realmente remover este Tipo de Referência?</h3>
<div>
    <h4>Tipo de Referência</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Referencia)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Referencia)
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
