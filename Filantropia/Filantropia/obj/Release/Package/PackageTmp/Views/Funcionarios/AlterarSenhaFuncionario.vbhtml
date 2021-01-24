@ModelType FilantropiaDLL.Componentes.Funcionario
@Code
    ViewData("Title") = "AlterarSenhaFuncionario"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Alterar Senha de Funcionario</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
    <h4>Funcionario</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.ID)

    <div class="form-group">
        @Html.LabelFor(Function(model) model.CPFCNPJ, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.CPFCNPJ, New With {.htmlAttributes = New With {.class = "form-control"}})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Nome, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Nome, New With {.htmlAttributes = New With {.class = "form-control"}})
        </div>
    </div>

    <div class="form-group">
        Senha Atual: 
        <div class="col-md-10">
            @Html.TextBoxFor(Function(model) model.RG, New With {.htmlAttributes = New With {.class = "form-control", .PlaceHolder = "Password"}})
            @Html.ValidationMessageFor(Function(model) model.RG, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        Nova Senha: 
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Senha, New With {.htmlAttributes = New With {.class = "form-control", .PlaceHolder = "Password"}})
            @Html.ValidationMessageFor(Function(model) model.Senha, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Gravar" class="btn btn-default" />
        </div>
    </div>
</div>
End Using

<div>
    @Html.ActionLink("Voltar para a Lista", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
