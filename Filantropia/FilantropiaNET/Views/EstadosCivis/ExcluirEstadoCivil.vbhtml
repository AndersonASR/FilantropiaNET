﻿@ModelType FilantropiaDLL.Modelos.EstadosCivis
@Code
    ViewData("Title") = "ExcluirEstadoCivil"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Estado Civil</h2>

<h3>Deseja realmente excluir este registro de Estado Civil?</h3>
<div>
    <h4>Estados Civis</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.EstadoCivil)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EstadoCivil)
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
