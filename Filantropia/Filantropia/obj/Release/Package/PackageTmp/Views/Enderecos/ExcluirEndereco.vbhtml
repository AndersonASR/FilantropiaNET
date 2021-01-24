@ModelType FilantropiaDLL.Componentes.Endereco
@Code
    ViewData("Title") = "ExcluirEndereco"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Excluir Endereço</h2>

<h3>Deseja realmente remover este Endereço?</h3>
<div>
    <h4>Endereço</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.IDPessoa)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IDPessoa)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Logradouro)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Logradouro)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Numero)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Numero)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Complemento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Complemento)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Bairro)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Bairro)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cidade)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cidade)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UF)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UF)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CEP)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CEP)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.OBS)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.OBS)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IDResponsavelCadastro)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IDResponsavelCadastro)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DataRegistro)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataRegistro)
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
