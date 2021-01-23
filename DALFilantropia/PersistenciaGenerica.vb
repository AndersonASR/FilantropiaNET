Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
'Imports Oracle.DataAccess.Client
Imports System.Data
Imports System.Reflection
Imports System.Web
Imports System.Collections
Imports System.Configuration

Namespace DAL

	Public Module Enumeradores
		Public Enum CompareType
			Igual
			NaoIgual
			NaoE
			Como
			Diferente
			MaiorQue
			MaiorOuIgualA
			MenorQue
			MenorOuIgualA
			Entre
			[IN]
		End Enum

		Public Enum enumBD
			ACCESS
			ORACLE
			SQLITE
			SQLSERVER
		End Enum
	End Module

	Module PersistenciaGenerica

		'Private oradb As String = "Data Source=oragridp-scan.cenpes.petrobras.com.br/p01;User Id=ud01_consulta;Password=aulrse;"
		'//private static string oradb = "Data Source=oragridd-scan.cenpes.petrobras.com.br/d02;User Id=ud01;Password=ud0100;";

		'Private _oConnection As New OracleConnection(oradb)
		'Private _oCommand As OracleCommand = Nothing
		'Private _oReader As OracleDataReader = Nothing

		'Private lista As New List(Of String)

		'Public Function [Select](Of T)(p_Select As String) As List(Of T)
		'	Dim lista As List(Of T)

		'	Try
		'		'//Seta a query no command
		'		_oCommand = New OracleCommand(p_Select)
		'		_oCommand.Connection = _oConnection

		'		'//Seta o tipo de comando
		'		_oCommand.CommandType = CommandType.Text

		'		OpenConnection()

		'		Using _oReader = _oCommand.ExecuteReader()
		'			lista = InstanciarClasse(Of T)(GetType(T).Assembly.GetName().Name, GetType(T).Name, _oReader)
		'		End Using
		'	Catch ex As Exception
		'		Throw New Exception(ex.Message)
		'	Finally
		'		CloseConnection()
		'	End Try
		'	Return lista
		'End Function

		'Public Sub [Select](p_Select As String, p_Type As System.Data.CommandType?)
		'	Try
		'		'//Seta a query no command
		'		_oCommand = New OracleCommand(p_Select)
		'		_oCommand.Connection = _oConnection

		'		'/Seta o tipo de comando
		'		'//Caso o parâmetro seja nulo, set como TEXT
		'		Dim _commandType As CommandType = New CommandType()
		'		If (p_Type Is Nothing) Then _commandType = CommandType.Text
		'		_oCommand.CommandType = _commandType

		'		OpenConnection()
		'		Using oReader = _oCommand.ExecuteReader()
		'			'InstanciarClasse<Documento>(_assembly, "Documento", _oReader)
		'		End Using
		'	Catch ex As Exception
		'		Throw New Exception(ex.Message)
		'	Finally
		'		CloseConnection()
		'	End Try
		'End Sub

		'Public Function Insert(p_Insert As String) As Boolean
		'	Return ExecuteCommand(p_Insert)
		'End Function

		'Public Function Insert(p_Inserts As List(Of String)) As Boolean
		'	Return ExecuteCommands(p_Inserts)
		'End Function

		'Public Function Insert(p_Insert As String, p_Parameters As List(Of String), p_Values As List(Of String)) As Boolean
		'	Return ExecuteCommand(p_Insert, p_Parameters, p_Values)
		'End Function

		'Public Function Update(p_Update As String) As Boolean
		'	Return ExecuteCommand(p_Update)
		'End Function

		'Public Function Update(p_Update As String, p_Parameters As List(Of String), p_Values As List(Of String))
		'	Return ExecuteCommand(p_Update, p_Parameters, p_Values)
		'End Function

		'Public Function Delete(p_Delete As String) As Boolean
		'	Return ExecuteCommand(p_Delete)
		'End Function

		'Public Function Execute(p_Execute As String) As Boolean
		'	Return ExecuteCommand(p_Execute)
		'End Function

		'Private Function ExecuteCommand(p_Command As String) As Boolean
		'	Dim result As Int16 = 0

		'	Try
		'		_oCommand = New OracleCommand(p_Command)

		'		_oCommand.Connection = _oConnection
		'		OpenConnection()

		'		result = _oCommand.ExecuteNonQuery()
		'	Catch ex As Exception
		'		Throw New Exception(ex.Message)
		'	Finally
		'		CloseConnection()
		'	End Try
		'	Return result > 0
		'End Function

		'Private Function ExecuteCommands(p_Commands As List(Of String)) As Boolean
		'	Dim result As Int16 = 0
		'	Try
		'		_oCommand.Connection = _oConnection
		'		OpenConnection()

		'		For Each _command In p_Commands
		'			_oCommand = New OracleCommand(_command)
		'			_oCommand.Connection = _oConnection

		'			If (_oConnection.State <> ConnectionState.Open) Then OpenConnection()

		'			result = _oCommand.ExecuteNonQuery()
		'		Next
		'	Catch ex As Exception
		'		Throw New Exception(ex.Message)
		'	Finally
		'		CloseConnection()
		'	End Try
		'	Return result > 0
		'End Function

		'Private Function ExecuteCommand(p_Command As String, p_Parameters As List(Of String), p_Values As List(Of String)) As Boolean
		'	Dim result As Int16 = 0

		'	Try
		'		_oCommand = New OracleCommand(p_Command)

		'		Dim tamanho As Int16 = p_Values.Count
		'		For i As Int16 = 0 To tamanho - 1
		'			_oCommand.Parameters.Add(New OracleParameter(p_Parameters(i), p_Values(i)))
		'		Next

		'		_oCommand.Connection = _oConnection

		'		OpenConnection()

		'		result = _oCommand.ExecuteNonQuery()
		'	Catch ex As Exception
		'		Throw New Exception(ex.Message)
		'	Finally
		'		CloseConnection()
		'	End Try
		'	Return result > 0
		'End Function

		'Private Function InstanciarClasse(Of T)(p_assembly As String, p_className As String, p_reader As OracleDataReader) As List(Of T)
		'	Dim t_assembly As Assembly = Assembly.Load(p_assembly)
		'	If (Not t_assembly Is Nothing) Then
		'		'Dim t_classe = t_assembly.GetTypes().Where(w >= w.Name.ToUpper() = p_className.ToUpper()).FirstOrDefault()
		'		Dim t_classe = t_assembly.GetTypes().Where(Function(w) w.Name.ToUpper() = p_className.ToUpper()).FirstOrDefault()
		'		If (Not t_classe Is Nothing) Then
		'			Dim objeto = Activator.CreateInstance(t_classe)

		'			Dim genericListType As Type = GetType(List(Of))
		'			Dim concreteListType As Type = genericListType.MakeGenericType(t_classe)
		'			Dim List As IList = CType(Activator.CreateInstance(concreteListType), IList)

		'			Dim properties As PropertyInfo() = t_classe.GetProperties()

		'			Do While (p_reader.Read())

		'				Dim instance = System.Activator.CreateInstance(t_classe)

		'				'Dim colunas = Enumerable.Range(0, p_reader.FieldCount).Select(p_reader.GetName(Nothing)).ToList()
		'				Dim colunas = Enumerable.Range(0, p_reader.FieldCount).Select(Function(x) p_reader.GetName(x)).ToList()

		'				For Each coluna In colunas

		'					Dim tipo As String = p_reader(coluna).GetType().Name
		'					If (tipo <> "DBNull") Then

		'						'Dim prop As PropertyInfo = properties.Where(w >= w.Name.ToUpper() = coluna.ToUpper()).FirstOrDefault()
		'						Dim prop As PropertyInfo = properties.Where(Function(w) w.Name.ToUpper() = coluna.ToUpper()).FirstOrDefault()

		'						If (Not prop Is Nothing) Then
		'							Select Case (p_reader(coluna).GetType().Name)
		'								Case "Decimal"
		'									prop.SetValue(instance, Convert.ToInt32(p_reader(coluna)), Nothing)
		'								Case Else
		'									prop.SetValue(instance, p_reader(coluna), Nothing)
		'							End Select
		'						End If
		'					End If
		'				Next

		'				List.Add(instance)
		'			Loop
		'			Return CType(List, List(Of T))
		'		End If
		'	End If
		'	Return New List(Of T)()
		'End Function

		'Private Sub OpenConnection()
		'	If (_oConnection.State = ConnectionState.Closed) Then
		'		_oConnection.Open()
		'	End If
		'End Sub

		'Private Sub CloseConnection()
		'	_oConnection.Close()
		'End Sub

		'Private Sub DisposeConnection()
		'	_oConnection.Dispose()
		'End Sub

	End Module
End Namespace