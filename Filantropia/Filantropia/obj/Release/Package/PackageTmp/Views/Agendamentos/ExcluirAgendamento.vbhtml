@ModelType FilantropiaDLL.Componentes.Agendamento
@Code
    ViewData("Title") = "ExcluirAgendamento"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Agendamento</h2>

<h3>Deseja realmente remover este Agendamento dos registros?</h3>
<div>
    <h4>Agendamento</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Inicio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Inicio)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Valor)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Valor)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UltimaContribuicao)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UltimaContribuicao)
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
