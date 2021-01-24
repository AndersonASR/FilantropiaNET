@ModelType FilantropiaDLL.Componentes.FormaPagamento
@Code
    ViewData("Title") = "ExcluirFormaPagamento"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Forma de Pagamento</h2>

<h3>Deseja realmente excluir este ítem?</h3>
<div>
    <h4>Forma de Pagamento</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.FormaPagamento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FormaPagamento)
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
