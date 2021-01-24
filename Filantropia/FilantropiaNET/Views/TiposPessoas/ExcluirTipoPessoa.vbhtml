@ModelType FilantropiaDLL.Modelos.TiposPessoas
@Code
    ViewData("Title") = "ExcluirTipoPessoa"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Tipo de Pessoa</h2>

<h3>Deseja realmente excluir este Tipo de Pessoa do sistema?</h3>
<div>
    <h4>Tipo de Pessoa</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Tipo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tipo)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Excluir" class="btn btn-default" /> |
            @Html.ActionLink("Voltar para a  Lista", "Index")
        </div>
    End Using
</div>
