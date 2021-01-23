Imports DALGenerica
Imports DALGenerica.DAL
Imports FilantropiaLIB.Modelos

Public Class Filantropia
	Private RAgendamentos As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Agendamentos)
	Private RBancos As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Bancos)
	Private RCampanhas As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Campanhas)
	Private RColaboradores As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Colaboradores)
	Private REnderecos As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Enderecos)
	Private REstadosCivis As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.EstadosCivis)
	Private RFormasPagamentos As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.FormasPagamentos)
	Private RFuncionarios As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Funcionarios)
	Private RHistoricoChamadas As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.HistoricoChamadas)
	Private RInstitutos As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Institutos)
	Private RMotivosRestricoes As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.MotivosRestricoes)
	Private RMovimentos As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Movimentos)
	Private RPeriodicidades As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Periodicidades)
	Private RPessoas As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Pessoas)
	Private RPessoasEnderecos As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.PessoasEnderecos)
	Private RPessoasTelefones As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.PessoasTelefones)
	Private RTelefones As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Telefones)
	Private RTiposPessoas As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.TiposPessoas)
	Private RTiposReferencias As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.TiposReferencias)
	Private RPaginas As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Paginas)
	Private RTiposPessoasPaginas As Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.TiposPessoasPaginas)

	Private LAgendamentos As List(Of DALGenerica.DAL.Modelos.Agendamentos)
	Private LBancos As List(Of DALGenerica.DAL.Modelos.Bancos)
	Private LCampanhas As List(Of DALGenerica.DAL.Modelos.Campanhas)
	Private LColaboradores As List(Of DALGenerica.DAL.Modelos.Colaboradores)
	Private LEnderecos As List(Of DALGenerica.DAL.Modelos.Enderecos)
	Private LEstadosCivis As List(Of DALGenerica.DAL.Modelos.EstadosCivis)
	Private LFormasPagamentos As List(Of DALGenerica.DAL.Modelos.FormasPagamentos)
	Private LFuncionarios As List(Of DALGenerica.DAL.Modelos.Funcionarios)
	Private LHistoricoChamadas As List(Of DALGenerica.DAL.Modelos.HistoricoChamadas)
	Private LInstitutos As List(Of DALGenerica.DAL.Modelos.Institutos)
	Private LMotivosRestricoes As List(Of DALGenerica.DAL.Modelos.MotivosRestricoes)
	Private LMovimentos As List(Of DALGenerica.DAL.Modelos.Movimentos)
	Private LPeriodicidades As List(Of DALGenerica.DAL.Modelos.Periodicidades)
	Private LPessoas As List(Of DALGenerica.DAL.Modelos.Pessoas)
	Private LPessoasEnderecos As List(Of DALGenerica.DAL.Modelos.PessoasEnderecos)
	Private LPessoasTelefones As List(Of DALGenerica.DAL.Modelos.PessoasTelefones)
	Private LTelefones As List(Of DALGenerica.DAL.Modelos.Telefones)
	Private LTiposPessoas As List(Of DALGenerica.DAL.Modelos.TiposPessoas)
	Private LTiposReferencias As List(Of DALGenerica.DAL.Modelos.TiposReferencias)
	Private LPaginas As List(Of DALGenerica.DAL.Modelos.Paginas)
	Private LTiposPessoasPaginas As List(Of DALGenerica.DAL.Modelos.TiposPessoasPaginas)



	Public Sub New(Conexao As String)

		RAgendamentos = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Agendamentos)(enumBD.SQLSERVER, Conexao)
		RBancos = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Bancos)(enumBD.SQLSERVER, Conexao)
		RCampanhas = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Campanhas)(enumBD.SQLSERVER, Conexao)
		RColaboradores = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Colaboradores)(enumBD.SQLSERVER, Conexao)
		REnderecos = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Enderecos)(enumBD.SQLSERVER, Conexao)
		REstadosCivis = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.EstadosCivis)(enumBD.SQLSERVER, Conexao)
		RFormasPagamentos = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.FormasPagamentos)(enumBD.SQLSERVER, Conexao)
		RFuncionarios = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Funcionarios)(enumBD.SQLSERVER, Conexao)
		RHistoricoChamadas = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.HistoricoChamadas)(enumBD.SQLSERVER, Conexao)
		RInstitutos = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Institutos)(enumBD.SQLSERVER, Conexao)
		RMotivosRestricoes = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.MotivosRestricoes)(enumBD.SQLSERVER, Conexao)
		RMovimentos = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Movimentos)(enumBD.SQLSERVER, Conexao)
		RPeriodicidades = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Periodicidades)(enumBD.SQLSERVER, Conexao)
		RPessoas = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Pessoas)(enumBD.SQLSERVER, Conexao)
		RPessoasEnderecos = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.PessoasEnderecos)(enumBD.SQLSERVER, Conexao)
		RPessoasTelefones = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.PessoasTelefones)(enumBD.SQLSERVER, Conexao)
		RTelefones = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Telefones)(enumBD.SQLSERVER, Conexao)
		RTiposPessoas = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.TiposPessoas)(enumBD.SQLSERVER, Conexao)
		RTiposReferencias = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.TiposReferencias)(enumBD.SQLSERVER, Conexao)
		RPaginas = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.Paginas)(enumBD.SQLSERVER, Conexao)
		RTiposPessoasPaginas = New Repositorio.RepositorioGenerico(Of DALGenerica.DAL.Modelos.TiposPessoasPaginas)(enumBD.SQLSERVER, Conexao)

	End Sub



	'TODO: Tratar Colaboradorador
	'Nesta sessão deverão estar funções como crud de telefones, endereços e contatos
	'aléms de CRUD de agendamentos e doações
	Public Function ObterColaboradorador(Nome As String) As Colaborador
		Dim Retorno As Colaborador = Nothing

		RTiposPessoas.LimparParametros()
		RPessoas.AdicionarParametro(DAL.Modelos.TiposPessoas.Campos.Tipo.ToString, CompareType.Igual, "COLABORADOR")
		LTiposPessoas = RTiposPessoas.Obter()

		RPessoas.LimparParametros()
		RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.Nome.ToString, CompareType.Igual, Nome)
		RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.IDTipoPessoa.ToString, CompareType.Igual, LTiposPessoas(0).ID)
		LPessoas = RPessoas.Obter()

		RColaboradores.LimparParametros()
		RColaboradores.AdicionarParametro(DAL.Modelos.Colaboradores.Campos.IDPessoa.ToString, CompareType.Igual, LPessoas(0).ID)
		LColaboradores = RColaboradores.Obter()

		Retorno.ID = LColaboradores(0).ID
		Retorno.Nome = LPessoas(0).Nome
		Retorno.CPFCNPJ = LPessoas(0).CPFCNPJ
		Retorno.DataRestricao = LPessoas(0).DataRestricao
		Retorno.Enderecos = ObterEnderecos(Retorno.ID)
		Retorno.Telefones = ObterTelefones(Retorno.ID)
		Retorno.Chamadas = ObterChamadas(Retorno.ID)
		Retorno.Contribuicoes = ObterContribuicoes(Retorno.ID)
		Retorno.Agendamentos = ObterAgendamentos(Retorno.ID)

		Return Retorno
	End Function

	Public Function ObterColaboradores(Campos As List(Of Colaborador.Campos), Valores As List(Of String)) As List(Of Colaborador)
		Dim Retorno As List(Of Colaborador) = Nothing

		RColaboradores.LimparParametros()
		For X As Int16 = 0 To Campos.Count - 1
			RColaboradores.AdicionarParametro(Campos(X), CompareType.Igual, Valores(X))
		Next
		LColaboradores = RColaboradores.Obter()

		For Each C As DAL.Modelos.Colaboradores In LColaboradores
			Dim Colab As New Colaborador
			Colab.ID = C.ID

			RPessoas.LimparParametros()
			RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.ID.ToString, CompareType.Igual, C.IDPessoa)
			LPessoas = RPessoas.Obter

			Colab.CPFCNPJ = LPessoas(0).CPFCNPJ
			Colab.Nome = LPessoas(0).Nome
			Colab.Enderecos = ObterEnderecos(Colab.ID)
			Colab.Telefones = ObterTelefones(Colab.ID)
			Colab.Chamadas = ObterChamadas(Colab.ID)
			Colab.Contribuicoes = ObterContribuicoes(Colab.ID)
			Colab.Agendamentos = ObterAgendamentos(Colab.ID)

			Retorno.Add(Colab)
		Next

		Return Retorno
	End Function

	Public Function ObterEnderecos(IDPessoa As Int64) As List(Of Enderecos)
		Dim Retorno As List(Of Enderecos) = Nothing

		RPessoasEnderecos.LimparParametros()
		RPessoasEnderecos.AdicionarParametro(DAL.Modelos.PessoasEnderecos.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
		LPessoasEnderecos = RPessoasEnderecos.Obter

		For Each LP As DAL.Modelos.PessoasEnderecos In LPessoasEnderecos
			REnderecos.LimparParametros()
			REnderecos.AdicionarParametro(DAL.Modelos.Enderecos.Campos.ID.ToString, CompareType.Igual, LP.IDEndereco)
			LEnderecos = REnderecos.Obter

			Dim E As New Enderecos
			E.ID = LEnderecos(0).ID
			E.Logradouro = LEnderecos(0).Logradouro
			E.Numero = LEnderecos(0).Numero
			E.Complemento = LEnderecos(0).Complemento
			E.Bairro = LEnderecos(0).Bairro
			E.Cidade = LEnderecos(0).Cidade
			E.UF = LEnderecos(0).UF
			E.CEP = LEnderecos(0).CEP
			E.OBS = LEnderecos(0).OBS
			Retorno.Add(E)
		Next

		Return Retorno
	End Function

	Public Function ObterTelefones(IDPessoa As Int64) As List(Of Telefones)
		Dim Retorno As List(Of Telefones) = Nothing

		RPessoasTelefones.LimparParametros()
		RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
		LPessoasTelefones = RPessoasTelefones.Obter

		For Each LP As DAL.Modelos.PessoasTelefones In LPessoasTelefones
			RTelefones.LimparParametros()
			RTelefones.AdicionarParametro(DAL.Modelos.Telefones.Campos.ID.ToString, CompareType.Igual, LP.IDTelefone)
			LTelefones = RTelefones.Obter

			Dim E As New Telefones
			E.ID = LTelefones(0).ID
			E.DDD = LTelefones(0).DDD
			E.Prefixo = LTelefones(0).Prefixo
			E.Sulfixo = LTelefones(0).Sulfixo
			Retorno.Add(E)
		Next

		Return Retorno
	End Function

	Public Function ObterChamadas(IDPessoa As Int64) As List(Of HistoricoChamadas)
		Dim Retorno As List(Of HistoricoChamadas) = Nothing

		RPessoasTelefones.LimparParametros()
		RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
		LPessoasTelefones = RPessoasTelefones.Obter

		RHistoricoChamadas.LimparParametros()
		For Each L As DAL.Modelos.PessoasTelefones In LPessoasTelefones
			RHistoricoChamadas.AdicionarParametro(DAL.Modelos.HistoricoChamadas.Campos.IDPessoaTelefone.ToString, CompareType.Igual, L.ID,, True)
		Next
		LHistoricoChamadas = RHistoricoChamadas.Obter

		For Each HC As DAL.Modelos.HistoricoChamadas In LHistoricoChamadas
			Dim H As New HistoricoChamadas
			H.Atendeu = HC.Atendeu
			H.DataHora = HC.DataHora
			H.NumeroTentativas = HC.NumeroTentativas
			H.IDCampanha = 0
			H.IDFuncionario = 0
			H.IDInstituto = 0
			H.IDPessoaTelefone = 0
			Retorno.Add(H)
		Next

		Return Retorno
	End Function

	Public Function ObterContribuicoes(IDPessoa As Int64) As List(Of Modelos.Movimentos)
		Dim Retorno As List(Of Movimentos) = Nothing

		RPessoasTelefones.LimparParametros()
		RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
		LPessoasTelefones = RPessoasTelefones.Obter

		RMovimentos.LimparParametros()
		For Each L As DAL.Modelos.PessoasTelefones In LPessoasTelefones
			RMovimentos.AdicionarParametro(DAL.Modelos.Movimentos.Campos.IDPessoaTelefone.ToString, CompareType.Igual, L.ID,, True)
		Next
		LMovimentos = RMovimentos.Obter

		For Each MV As DAL.Modelos.Movimentos In LMovimentos
			Dim M As New Movimentos

			M.ID = MV.ID
			M.Agencia = MV.Agencia
			M.Conta = MV.Conta
			M.DataHoraAgendada = MV.DataHoraAgendada
			M.DataHoraConfirmacao = MV.DataHoraConfirmacao
			M.DigitoConta = MV.DigitoConta
			M.IDAgendamento = MV.IDAgendamento
			M.IDApanhador = MV.IDApanhador
			M.IDBanco = MV.IDBanco
			M.IDFormaPagamento = MV.IDFormaPagamento
			M.IDInstituto = MV.IDInstituto
			M.IDPessoaTelefone = MV.IDPessoaTelefone
			M.IDPessoaTelefone = MV.IDPessoaTelefone
			M.IDTelefonista = MV.IDTelefonista
			M.NumeroRecibo = MV.NumeroRecibo
			M.ValorPrevisto = MV.ValorPrevisto
			M.ValorRecebido = MV.ValorRecebido

			Retorno.Add(M)
		Next

		Return Retorno
	End Function

	Public Function ObterAgendamentos(IDPessoa As Int64) As List(Of Modelos.Agendamentos)
		Dim Retorno As List(Of Agendamentos ) = Nothing

		RPessoasTelefones.LimparParametros()
		RPessoasTelefones.AdicionarParametro(DAL.Modelos.PessoasTelefones.Campos.IDPessoa.ToString, CompareType.Igual, IDPessoa)
		LPessoasTelefones = RPessoasTelefones.Obter

		RAgendamentos.LimparParametros()
		For Each L As DAL.Modelos.PessoasTelefones In LPessoasTelefones
			RAgendamentos.AdicionarParametro(DAL.Modelos.Agendamentos.Campos.IDPessoaTelefone.ToString, CompareType.Igual, L.ID,, True)
		Next
		LAgendamentos = RAgendamentos.Obter

		For Each Ag As DAL.Modelos.Agendamentos In LAgendamentos
			Dim A As New Agendamentos

			A.ID = Ag.ID
			A.IDChamada = Ag.IDChamada
			A.IDInstituto = Ag.IDInstituto
			A.IDPessoaTelefone = Ag.IDPessoaTelefone
			A.IDTelefonista = Ag.IDTelefonista
			'A.Inicio = Ag.Inicio
			'A.UltimaContribuicao = Ag.UltimaContribuicao
			A.Valor = Ag.Valor

			Retorno.Add(A)
		Next

		Return Retorno
	End Function

	Public Function SalvarColaborador(Colaborador As Colaborador, Optional Atualizar As Boolean = True) As Boolean
		Dim Fez As Boolean = False

		Return Fez
	End Function


	Public Function ObterPessoa(CPF As String) As Pessoas
		Dim P As Pessoas = Nothing

		RPessoas.LimparParametros()
		RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.CPFCNPJ.ToString, CompareType.Igual, CPF)
		LPessoas = RPessoas.Obter

		If LPessoas.Count > 0 Then
			Dim PE As DAL.Modelos.Pessoas = LPessoas(0)

			P = New Modelos.Pessoas
			P.ID = PE.ID
			P.CPFCNPJ = LPessoas(0).CPFCNPJ
			P.Enderecos = ObterEnderecos(LPessoas(0).ID)
			P.EstadoCivil = ObterEstadoCivil(LPessoas(0).IDEstadoCivil)
			P.ResponsavelCadastro = ObterFuncionario(LPessoas(0).IDResponsavelCadastro)
			P.Nome = LPessoas(0).Nome
			P.Telefones = ObterTelefones(LPessoas(0).ID)
			P.DataRestricao = LPessoas(0).DataRestricao
			P.TipoPessoa = ObterTipoPessoa(LPessoas(0).IDTipoPessoa)
		End If

		Return P
	End Function

	'TODO: Tratar Funcionários
	'Nesta sessão deverão estar funções como crud de dados pessoais, logins
	'aléms de CRUD de agendamentos e doações
	Public Function ObterFuncionario(CPF As String) As Funcionario
		Dim F As Funcionario = Nothing

		RPessoas.LimparParametros()
		RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.CPFCNPJ.ToString, CompareType.Igual, CPF)
		LPessoas = RPessoas.Obter

		If LPessoas.Count > 0 Then

			RFuncionarios.LimparParametros()
			RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.IDPessoa.ToString, CompareType.Igual, LPessoas(0).ID)
			LFuncionarios = RFuncionarios.Obter

			If LFuncionarios.Count > 0 Then
				Dim LF As DAL.Modelos.Funcionarios = LFuncionarios(0)

				F = New Modelos.Funcionario
				F.ID = LF.ID
				F.Ativo = LF.Ativo
				F.CPFCNPJ = LPessoas(0).CPFCNPJ
				F.DataAdmissao = LF.DataAdmissao
				F.DataDesligamento = LF.DataDesligamento
				F.IDTipoFuncionario = LF.IDTipoFuncionario
				F.Enderecos = ObterEnderecos(LF.IDPessoa)
				F.EstadoCivil = ObterEstadoCivil(LPessoas(0).IDEstadoCivil)
				F.IDResponsavelCadastro = 0
				F.Nome = LPessoas(0).Nome
				F.Telefones = ObterTelefones(LF.IDPessoa)
				F.RG = LF.RG
				F.Senha = LF.Senha
			End If
		End If

		Return F

	End Function

	Public Function ObterFuncionario(ID As Int64) As Funcionario
		Dim F As Funcionario = Nothing

		RFuncionarios.LimparParametros()
		RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.ID.ToString, CompareType.Igual, ID)
		LFuncionarios = RFuncionarios.Obter

		If LFuncionarios.Count > 0 Then

			RPessoas.LimparParametros()
			RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.ID.ToString, CompareType.Igual, LFuncionarios(0).IDPessoa)
			LPessoas = RPessoas.Obter

			Dim LF As DAL.Modelos.Funcionarios = LFuncionarios(0)

			F = New Modelos.Funcionario
			F.ID = LF.ID
			F.Ativo = LF.Ativo
			F.CPFCNPJ = LPessoas(0).CPFCNPJ
			F.DataAdmissao = LF.DataAdmissao
			F.DataDesligamento = LF.DataDesligamento
			F.IDTipoFuncionario = LF.IDTipoFuncionario
			F.Enderecos = ObterEnderecos(LF.IDPessoa)
			F.EstadoCivil = ObterEstadoCivil(LPessoas(0).IDEstadoCivil)
			F.IDResponsavelCadastro = 0
			F.Nome = LPessoas(0).Nome
			F.Telefones = ObterTelefones(LF.IDPessoa)
			F.RG = LF.RG
			F.Senha = LF.Senha
		End If

		Return F
	End Function
	Public Function ObterFuncionarios(Campos As List(Of Funcionario.Campos), Valores As List(Of String)) As List(Of Funcionario)
		Dim F As List(Of Funcionario) = Nothing

		Return F
	End Function

	Public Function SalvarFuncionario(Funcionario As Funcionario, Optional Atualizar As Boolean = True) As Boolean
		Dim Fez As Boolean = False

		Return Fez
	End Function


	Public Function ObterEstadoCivil(ID As Int64) As String
		Dim EstadoCivil As String = ""

		REstadosCivis.LimparParametros()
		REstadosCivis.AdicionarParametro(DAL.Modelos.EstadosCivis.Campos.ID.ToString, CompareType.Igual, ID)
		LEstadosCivis = REstadosCivis.Obter

		If LEstadosCivis.Count > 0 Then EstadoCivil = LEstadosCivis(0).EstadoCivil

		Return EstadoCivil
	End Function

	Public Function ObterTipoPessoa(ID As Int64) As Modelos.TiposPessoas
		Dim TP As TiposPessoas = Nothing

		RTiposPessoas.LimparParametros()
		RTiposPessoas.AdicionarParametro(DAL.Modelos.TiposPessoas.Campos.ID.ToString, CompareType.Igual, ID)
		LTiposPessoas = RTiposPessoas.Obter

		If LTiposPessoas.Count > 0 Then
			TP = New Modelos.TiposPessoas
			TP.ID = LTiposPessoas(0).ID
			TP.Tipo = LTiposPessoas(0).Tipo
		End If

		Return TP
	End Function

	Public Function ValidarUsuario(Chave As String, Senha As String) As Boolean
		Dim Resp As Boolean = False

		RPessoas.LimparParametros()
		RPessoas.AdicionarParametro(DAL.Modelos.Pessoas.Campos.CPFCNPJ.ToString, CompareType.Igual, Chave)
		LPessoas = RPessoas.Obter
		'LFuncionarios.Clear()

		If LPessoas.Count > 0 Then
			RFuncionarios.LimparParametros()
			RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.IDPessoa.ToString, CompareType.Igual, LPessoas(0).ID)
			RFuncionarios.AdicionarParametro(DAL.Modelos.Funcionarios.Campos.Senha.ToString, CompareType.Igual, Senha)
			LFuncionarios = RFuncionarios.Obter

			Resp = (LFuncionarios.Count > 0)
		End If

		Return Resp

	End Function

	Public Function PaginaPublica(Pagina As String) As Boolean
		Dim Resp As Boolean = False
		RPaginas.LimparParametros()
		RPaginas.AdicionarParametro(DAL.Modelos.Paginas.Campos.Pagina.ToString, CompareType.Como, Pagina.ToUpper)
		LPaginas = RPaginas.Obter
		If LPaginas.Count > 0 Then
			If LPaginas(0).Publica Then Resp = True
		End If
		Return Resp
	End Function

	Public Function UsuarioPodeAcessar(Usuario As Pessoas, Pagina As String) As Boolean
		Dim Resp As Boolean = False
		Dim IDTipo As Int64 = Usuario.TipoPessoa.ID
		Dim IDPagina As Int64

		RPaginas.LimparParametros()
		RPaginas.AdicionarParametro(DAL.Modelos.Paginas.Campos.Pagina.ToString, CompareType.Como, Pagina)
		LPaginas = RPaginas.Obter
		If LPaginas.Count > 0 Then IDPagina = LPaginas(0).ID

		If IDPagina > 0 And IDTipo > 0 Then
			RTiposPessoasPaginas.LimparParametros()
			RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.IDPagina.ToString, CompareType.Igual, IDPagina)
			RTiposPessoasPaginas.AdicionarParametro(DAL.Modelos.TiposPessoasPaginas.Campos.IDTipoPessoa.ToString, CompareType.Igual, IDTipo)
			LTiposPessoasPaginas = RTiposPessoasPaginas.Obter

			If LTiposPessoasPaginas.Count > 0 Then Resp = True
		End If

		Return Resp
	End Function

	Public Function CarregarConfig() As Modelos.Config
		RPaginas.LimparParametros()
		LPaginas = RPaginas.ObterTodos

		RTiposPessoas.LimparParametros()
		LTiposPessoas = RTiposPessoas.ObterTodos

		RTiposPessoasPaginas.LimparParametros()
		LTiposPessoasPaginas = RTiposPessoasPaginas.ObterTodos

		Dim C As New Modelos.Config
		C.Paginas = New List(Of Paginas)
		For Each P As DAL.Modelos.Paginas In LPaginas
			Dim Pag As New Modelos.Paginas
			Pag.ID = P.ID
			Pag.Pagina = P.Pagina
			Pag.Publica = P.Publica
			C.Paginas.Add(Pag)
		Next
		C.TiposPessoas = New List(Of TiposPessoas)
		For Each T As DAL.Modelos.TiposPessoas In LTiposPessoas
			Dim Tipo As New Modelos.TiposPessoas
			Tipo.ID = T.ID
			Tipo.Tipo = T.Tipo
			C.TiposPessoas.Add(Tipo)
		Next
		C.TiposPessoasPAginas = New List(Of TiposPessoasPaginas)
		For Each T As DAL.Modelos.TiposPessoasPaginas In LTiposPessoasPaginas
			Dim Tipo As New Modelos.TiposPessoasPaginas
			Tipo.ID = T.ID
			Tipo.IDPagina = T.IDPagina
			Tipo.IDTipoPessoaPagina = T.IDTipoPessoaPagina
			C.TiposPessoasPAginas.Add(Tipo)
		Next

		Return C

	End Function
End Class
