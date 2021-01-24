@ModelType FilantropiaDLL.Componentes.Movimento
@Code
    ViewData("Title") = "ExcluirMovimento"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Movimento</h2>

<h3>Deseja realmente excluir este movimento financeiro?</h3>
<div>
    <h4>Movimento</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.DataHoraAgendada)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataHoraAgendada)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Agencia)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Agencia)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Conta)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Conta)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DigitoConta)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DigitoConta)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DataHoraConfirmacao)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataHoraConfirmacao)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ValorPrevisto)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ValorPrevisto)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ValorRecebido)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ValorRecebido)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NumeroRecibo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NumeroRecibo)
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
