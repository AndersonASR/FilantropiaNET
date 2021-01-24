@ModelType FilantropiaDLL.Modelos.MotivosRestricoes
@Code
    ViewData("Title") = "ExcluirMotivosRestricoes"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Motivos Restrições</h2>

<h3>Deseja realmente remover este Motivo de Restri;áo?</h3>
<div>
    <h4>MotivosRestricoes</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Motivo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Motivo)
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
