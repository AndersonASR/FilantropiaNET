<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            @Html.ActionLink("FilantropiaNET", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Cadastros<span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>@Html.ActionLink("Colaboradores", "Colaboradores", "Colaboradores")</li>
                        <li>@Html.ActionLink("Histórico de Chamadas", "HistoricoChamadas", "HistoricoChamadas")</li>
                        <li class="nav-divider"></li>
                        <li>@Html.ActionLink("Funcionários", "Funcionarios", "Funcionarios")</li>
                        <li class="nav-divider"></li>
                        <li>@Html.ActionLink("Tipos de Pessoas", "TiposPessoas", "TiposPessoas")</li>
                        <li>@Html.ActionLink("Estados Civis", "EstadosCivis", "EstadosCivis")</li>
                        <li>@Html.ActionLink("Bancos", "Bancos", "Bancos")</li>
                        <li>@Html.ActionLink("Motivos de Restrições", "MotivosRestricoes", "MotivosRestricoes")</li>
                        <li>@Html.ActionLink("Periodicidades", "Periodicidades", "Periodicidades")</li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Movimento<span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>@Html.ActionLink("Agendamentos", "Agendamentos", "Agendamentos")</li>
                        <li>@Html.ActionLink("Movimentos", "Movimentos", "Movimentos")</li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Relatórios <span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>@Html.ActionLink("Só para constar", "Sobre", "Grafico")</li>
                        <li>@Html.ActionLink("E Deixar Claro a Viabilidade", "Sobre", "Grafico")</li>
                    </ul>
                </li>
                <li>
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Gráficos<span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu">
                        <li>@Html.ActionLink("Idem ao Menu Anterior", "Sobre", "Grafico")</li>
                    </ul>
                </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li>@Session("Usuario").Nome</li>
            </ul>
        </div>
    </div>
</div>