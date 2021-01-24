@ModelType FilantropiaDLL.Componentes.Banco
@Code
    ViewData("Title") = "ExcluirBanco"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Banco</h2>

<h3>Tem certeza de que deseja excluir este registro?</h3>
<div>
    <h4>Banco</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Numero)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Numero)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Banco)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Banco)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Apelido)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Apelido)
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
