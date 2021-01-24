@ModelType FilantropiaDLL.Componentes.Telefone
@Code
    ViewData("Title") = "ExcluitTelefone"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluit Telefone</h2>

<h3>Deseja realmente remover este registro?</h3>
<div>
    <h4>Telefone</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.IDPessoa)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IDPessoa)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DDD)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DDD)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Prefixo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Prefixo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sulfixo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sulfixo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Telefone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Telefone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SMS)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SMS)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.WhatsApp)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.WhatsApp)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DataRegistro)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataRegistro)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IDResponsavelCadastro)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IDResponsavelCadastro)
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
