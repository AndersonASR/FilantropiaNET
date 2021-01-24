Public Class Filantropia
	Public Property Bancos As Componentes.Bancos
	Public Property EstadosCivis As Componentes.EstadosCivis
	Public Property FormasPagamentos As Componentes.FormasPagamentos
	Public Property Funcionarios As Componentes.Funcionarios
	Public Property MotivosRestricoes As Componentes.MotivosRestricoes
	Public Property Paginas As Componentes.Paginas
	Public Property Periodicidades As Componentes.Periodicidades
	Public Property Pessoas As Componentes.Pessoas
	Public Property TiposPessoas As Componentes.TiposPessoas
	Public Property TiposReferencias As Componentes.TiposReferencias
	Public Property TiposPessoasPaginas As Componentes.TiposPessoasPaginas
	Public Property Telefones As Componentes.Telefones
	Public Property Enderecos As Componentes.Enderecos
	Public Property Colaboradores As Componentes.Colaboradores
	Public Property HistoricoChamadas As Componentes.HistoricosChamadas
	Public Property Agendamentos As Componentes.Agendamentos
	Public Property Movimentos As Componentes.Movimentos
	Public Property Institutos As Componentes.Institutos
	Public Property Campanhas As Componentes.Campanhas
	Public Property Config As Componentes.Configs
	Public Property Logs As Componentes.Logs

	Public Sub New(Conexao As String)
		Pessoas = New Componentes.Pessoas(Conexao)
		Bancos = New Componentes.Bancos(Conexao)
		EstadosCivis = New Componentes.EstadosCivis(Conexao)
		MotivosRestricoes = New Componentes.MotivosRestricoes(Conexao)
		Periodicidades = New Componentes.Periodicidades(Conexao)
		TiposPessoas = New Componentes.TiposPessoas(Conexao)
		TiposReferencias = New Componentes.TiposReferencias(Conexao)
		TiposPessoasPaginas = New Componentes.TiposPessoasPaginas(Conexao)
		Paginas = New Componentes.Paginas(Conexao)
		FormasPagamentos = New Componentes.FormasPagamentos(Conexao)
		Funcionarios = New Componentes.Funcionarios(Conexao)
		Enderecos = New Componentes.Enderecos(Conexao)
		Telefones = New Componentes.Telefones(Conexao)
		Colaboradores = New Componentes.Colaboradores(Conexao)
		HistoricoChamadas = New Componentes.HistoricosChamadas(Conexao)
		Agendamentos = New Componentes.Agendamentos(Conexao)
		Movimentos = New Componentes.Movimentos(Conexao)
		Institutos = New Componentes.Institutos(Conexao)
		Campanhas = New Componentes.Campanhas(Conexao)
		Config = New Componentes.Configs(Conexao)
		Logs = New Componentes.Logs(Conexao)
	End Sub
End Class
