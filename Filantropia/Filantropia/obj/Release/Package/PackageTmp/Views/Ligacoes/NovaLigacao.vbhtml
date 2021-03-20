@ModelType FilantropiaDLL.Componentes.HistoricoChamada
@Code
    ViewData("Title") = "NovaLigacao"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Nova Ligação</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
         <h4>Ligação</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Telefone, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Telefone.Telefone, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Telefone, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Atendeu, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="checkbox">
                    @Html.EditorFor(Function(model) model.Atendeu)
                    @Html.ValidationMessageFor(Function(model) model.Atendeu, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.NumeroTentativas, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NumeroTentativas, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.NumeroTentativas, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Instituto, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Instituto.Nome, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Instituto, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Campanha, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Campanha.Campanha, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Campanha, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Colaborador, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Colaborador.Nome, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Colaborador, "", New With {.class = "text-danger"})
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

    <script type="text/javascript">
    $(document).ready(function () {
        $('#Telefone_Telefone').autocomplete({
            source: '/Telefones/ObterTelefones',
            select: function (event, ui) {
                //set tagids to save
                $("#Telefones").val(ui.item.id);

                //Tags for display
                this.value = ui.item.value;
                return false;
            }
        });

        $('#Campanhas_Campanha').autocomplete({
            source: '/Campanhas/ObterCampanhas',
            select: function (event, ui) {
                //set tagids to save
                $("#Campanhas").val(ui.item.id);

                //Tags for display
                this.value = ui.item.value;
                return false;
            }
        });

        $('#Institutos_Nome').autocomplete({
            source: '/Institutos/ObterInstitutos',
            select: function (event, ui) {
                //set tagids to save
                $("#Institutos").val(ui.item.id);

                //Tags for display
                this.value = ui.item.value;
                return false;
            }
        });

        $('#Colaborador_Nome').autocomplete({
            source: '/Colaboradores/ObterColaboradores',
            select: function (event, ui) {
                //set tagids to save
                $("#Colaboradores").val(ui.item.id);

                //Tags for display
                this.value = ui.item.value;
                return false;
            }
        });
    });
    </script>
End Section
