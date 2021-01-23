Imports DALGenerica

Module Module1

	Sub Main()

		Dim Conexao As String

		'Oracle
		'Conexao = "Data Source=oragridp-scan.cenpes.petrobras.com.br/p01;User Id=ud01_consulta;Password=aulrse"
		'SQLServer
		'Conexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TesteAJAX;Data Source=MI00200858"
		'Access
		'Conexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Sistema de Boletos\Dados.mdb;Persist Security Info=True"
		'SQLite
		Conexao = "Data Source=c:\sistema de Boletos\Dados.db;Version=3;"

		'Para utilizar basta criar uma variável do tipo RepositórioGenérico indicando o classe POCO que se deseja utilizar como seu tipo de dados básico
		'Dim RepositorioControlesDados As New DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.ControleDados)(DAL.Repositorio.enumBD.ORACLE, Conexao)
		'Dim RepositorioPeople As New DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.People)(DAL.Repositorio.enumBD.SQLSERVER, Conexao)
		'Dim RepositorioBancos As New DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.Banco)(DAL.Repositorio.enumBD.ACCESS, Conexao)
		Dim RepositorioBancos As New DAL.Repositorio.RepositorioGenerico(Of DAL.Modelos.AplicativosBancos)(DAL.Repositorio.enumBD.SQLITE, Conexao)

		'Daí pra frente basta obter os dados e/ou realizar as demais operações de CRUD desejadas (Insert, Update, Delete)
		'Dim ControlesDados As List(Of DAL.Modelos.ControleDados) = RepositorioControlesDados.Obter("Select Mnemonico, Descricao From ControleDados")
		Dim Bancos As List(Of DAL.Modelos.AplicativosBancos) = RepositorioBancos.Obter("Select IDSistema, IDBanco From AplicativosBancos")
		'Dim Pessoas As List(Of DAL.Modelos.People) = RepositorioPeople.Obter("Select Name, SurName From People")
		Stop

	End Sub

	Private Sub TesteEF()

	End Sub
End Module
