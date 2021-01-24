@ModelType FilantropiaDLL.Componentes.MotivoRestricao
@Code
    ViewData("Title") = "ExcluirMotivoRestricao"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Motivo de Restrição</h2>

<h3>Tem certeza de que deseja excluir este registro?</h3>
<div>
    <h4>Motivo de Restrição</h4>
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
