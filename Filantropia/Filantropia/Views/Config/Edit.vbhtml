@ModelType FilantropiaDLL.Componentes.Config
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
End Code

<h2>Configurações</h2>

@Using (Html.BeginForm("Permissoes", "Config"))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Permissões</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            <div class="row">
                @Html.LabelFor(Function(model) model.TipoPessoa, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <select name="Tipos" id="Tipos" onchange="AtualizarLista()">
                    @For Each Tipo In Model.TiposPessoas
                        @<option value="@Tipo.ID">@Tipo.Tipo </option>
                    Next
                </select>
                </div>
                <div class="row">
                    @For X As Int16 = 0 To Model.Paginas.Count - 1
                        @code
                            Dim IDPagina As Int64 = Model.Paginas(X).ID
                            Dim Marcar As Boolean = False
                            If Not Model.TiposPessoasPaginas Is Nothing Then
                                For Y As Int64 = 0 To Model.TiposPessoasPaginas.Count - 1
                                    If Model.TiposPessoasPaginas(Y).IDPagina = IDPagina And Model.TiposPessoasPaginas(Y).Permissao Then
                                        Marcar = True
                                        Exit For
                                    End If
                                Next
                            End If
                        End Code
                        @<input type="checkbox" name="@Model.Paginas(X).ID" id="@Model.Paginas(X).ID" @IIf(Marcar, "checked", "") /> @Model.Paginas(X).Descricao  @<BR />
                            Next
                </div>
            </div>

        <div Class="form-group">
            <div Class="col-md-offset-2 col-md-10">
                <input type = "submit" value="Gravar" Class="btn btn-default" />
            </div>
        </div>
    </div>
                            End Using

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
<script type="text/javascript">
    function AtualizarLista() {
        var _id = $("#Tipos").children("option:selected").val();
        $.ajax({
            method: 'GET',
            url: '/Config/Permissoes?id=' + _id
        }
        );
    }
</script>