@ModelType IEnumerable(Of FilantropiaDLL.Componentes.TipoReferencia)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout_Principal .vbhtml"
    Dim webGrid As New WebGrid(Model, canPage:=True, canSort:=True)
End Code

<h2>Tipos de Referências</h2>

<p>
    @Html.ActionLink("Novo Tipo de Referência", "NovoTipoReferencia")
</p>

@webGrid.GetHtml(
                                        htmlAttributes:=New With {.id = "WebGrid", .class = "Grid"},
                                        columns:=webGrid.Columns(
                                            webGrid.Column(header:="ID", format:=@@<span class="label">@item.ID</span>, style:="ID"),
webGrid.Column(header:="Referencia", format:=@@<span><span class="label">@item.referencia</span><input Class="text" type="text" value="@item.Referencia" style="display:none" /></span>, style:="Referencia"),
webGrid.Column(format:=@@<span Class="link"><a Class="Edit" href="javascript:;">Alterar</a><a Class="Update" href="javascript:;" style="display:none">Gravar</a><a Class="Cancel" href="javascript:;" style="display:none">Cancelar</a></span>)
)
)

@If Not Model Is Nothing Then
    @<table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Referencia)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Referencia)
                </td>
                <td>
                    @Html.ActionLink("Alterar", "AlterarTipoReferencia", New With {.id = item.ID}) |
                    @Html.ActionLink("Excluir", "ExcluirTipoReferencia", New With {.id = item.ID})
                </td>
            </tr>Next

    </table>
End if
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://ajax.cdnjs.com/ajax/libs/json2/20110223/json2.js"></script>
<script type="text/javascript">
    //Edit event handler.
    $("body").on("click", "#WebGrid TBODY .Edit", function () {
        var row = $(this).closest("tr");
        $("td", row).each(function () {
            if ($(this).find(".text").length > 0) {
                $(this).find(".text").show();
                $(this).find(".label").hide();
            }
        });
        row.find(".Update").show();
        row.find(".Cancel").show();
        $(this).hide();
    });

    //Update event handler.
    $("body").on("click", "#WebGrid TBODY .Update", function () {
        var row = $(this).closest("tr");
        $("td", row).each(function () {
            if ($(this).find(".text").length > 0) {
                var span = $(this).find(".label");
                var input = $(this).find(".text");
                span.html(input.val());
                span.show();
                input.hide();
            }
        });
        row.find(".Edit").show();
        row.find(".Cancel").hide();
        $(this).hide();

        var Tipo = {};
        Tipo.ID = row.find(".ID").find(".label").html();
        Tipo.Referencia = row.find(".Referencia").find(".label").html();
        $.ajax({
            type: "POST",
            url: "/TiposReferencias/AlterarTipoReferencia",
            data: '{Dados:' + JSON.stringify(Tipo) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        });
    });

    //Cancel event handler.
    $("body").on("click", "#WebGrid TBODY .Cancel", function () {
        var row = $(this).closest("tr");
        $("td", row).each(function () {
            if ($(this).find(".text").length > 0) {
                var span = $(this).find(".label");
                var input = $(this).find(".text");
                input.val(span.html());
                span.show();
                input.hide();
            }
        });
        row.find(".Edit").show();
        row.find(".Update").hide();
        $(this).hide();
    });
</script>