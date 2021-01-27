<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            @Html.ActionLink("FilantropiaNET", "Menu", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Cadastros<span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>@Html.ActionLink("Colaboradores", "Colaboradores", "Colaboradores")</li>
                        <li>@Html.ActionLink("Chamadas Telefonicas", "Ligacoes", "Ligacoes")</li>
                        <li class="nav-divider"></li>
                        <li>@Html.ActionLink("Telefones", actionName:="Telefones", controllerName:="Telefones", routeValues:=New With {.id = 0}, htmlAttributes:=Nothing)</li>
                        <li class="nav-divider"></li>
                        <li>@Html.ActionLink("Funcionários", "Funcionarios", "Funcionarios")</li>
                        <li class="nav-divider"></li>
                        <li>@Html.ActionLink("Tipos de Pessoas", "TiposPessoas", "TiposPessoas")</li>
                        <li>@Html.ActionLink("Estados Civis", "EstadosCivis", "EstadosCivis")</li>
                        <li>@Html.ActionLink("Bancos", "Bancos", "Bancos")</li>
                        <li>@Html.ActionLink("Motivos de Restrições", "MotivosRestricoes", "MotivosRestricoes")</li>
                        <li>@Html.ActionLink("Periodicidades", "Periodicidades", "Periodicidades")</li>
                        <li>@Html.ActionLink("Formas de Pagamentos", "FormasPagamentos", "FormasPagamentos")</li>
                        <li>@Html.ActionLink("Tipos de Referências", "TiposReferencias", "TiposReferencias")</li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Movimento<span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>@Html.ActionLink("Agendamentos", "Agendamentos", "Agendamentos")</li>
                        <li>@Html.ActionLink("Movimentos Financeiros", "Movimentos", "Movimentos")</li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Ferramentas<span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li>@Html.ActionLink("Permissões de Acesso", "Permissoes", "Config")</li>
                        <li class="nav-divider"></li>
                        <li>@Html.ActionLink("Log", "Log", "Logs")</li>
                    </ul>
                </li>
            </ul>
            <ul class="nav navbar-nav navbar-right text-primary">
                @If Not Session("Usuario") Is Nothing Then
                    @<li>@Session("Usuario").Nome (@Session("Usuario").TipoPessoa.Tipo) @Html.ActionLink("Sair", "Sair", "Home", Nothing, New With {.class = "btn"}) </li>
                End If
            </ul>
        </div>
    </div>
</div>