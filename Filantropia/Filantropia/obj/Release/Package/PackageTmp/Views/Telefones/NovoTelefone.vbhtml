@ModelType FilantropiaDLL.Componentes.Telefone
@Code
    ViewData("Title") = "NovoTelefone"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Novo Telefone</h2>

@Using (Html.BeginForm("NovoTelefone", "Telefones", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>Telefone</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

    <div class="form-group">
        @Html.LabelFor(Function(model) model.DDD, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.DDD, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.DDD, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Prefixo, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Prefixo, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Prefixo, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Sulfixo, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Sulfixo, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Sulfixo, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Telefone, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Telefone, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Telefone, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.SMS, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <div class="checkbox">
                @Html.EditorFor(Function(model) model.SMS)
                @Html.ValidationMessageFor(Function(model) model.SMS, "", New With {.class = "text-danger"})
            </div>
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.WhatsApp, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <div class="checkbox">
                @Html.EditorFor(Function(model) model.WhatsApp)
                @Html.ValidationMessageFor(Function(model) model.WhatsApp, "", New With {.class = "text-danger"})
            </div>
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.TipoReferencia, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.DropDownListFor(Function(model) model.TipoReferencia.ID, ViewBag.Tipos)
            @Html.ValidationMessageFor(Function(model) model.TipoReferencia, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Gravar" class="btn btn-default" />
        </div>
    </div>
</div>  End Using

<div>
    @Html.ActionLink("Volta para a Lista", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
