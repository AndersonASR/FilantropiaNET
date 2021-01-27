Imports System.Data.OleDb
Imports System.Data.SqlClient
'Imports Oracle.DataAccess.Client
'Imports System.Data.SQLite
Imports System.Reflection

Namespace DAL

	Class Persistencia

		Private BD As enumBD
		Private IConn As IDbConnection
		Private ICom As IDbCommand
		'Private IDR As IDataReader
		Private FormatoDataHora As String
		Private PlicDataHora As String

		Private lista As New List(Of String)

		Public Sub New(TipoBD As enumBD, Conexao As String, Optional FormatoData As String = "yyyy-MM-dd HH:mm:ss", Optional PlicData As String = "'")

			BD = TipoBD
			Conexao = Conexao.Trim '.ToUpper

			PlicDataHora = PlicData
			FormatoDataHora = FormatoData

			If BD = enumBD.ACCESS Then 'ACCESS

				IConn = New OleDbConnection(Conexao)
				ICom = New OleDbCommand("", IConn)
				If PlicDataHora = "" Or PlicDataHora = "'" Then PlicDataHora = "#"
				If FormatoDataHora = "" Or FormatoDataHora = "'" Then FormatoDataHora = "MM/dd/yyyy HH:mm:ss"

			ElseIf BD = enumBD.ORACLE Then 'ORACLE

				'IConn = New OracleConnection(Conexao)
				'ICom = New OracleCommand("", IConn)

			ElseIf BD = enumBD.SQLITE Then 'SQLite

				'IConn = New SQLiteConnection(Conexao)
				'ICom = New SQLiteCommand("", IConn)

			ElseIf BD = enumBD.SQLSERVER Then 'SQLServer, Express ou LocalDB

				IConn = New SqlConnection(Conexao)
				ICom = New SqlCommand("", IConn)

			End If
		End Sub

		Public Function [Select](Of T)(p_Select As String) As List(Of T)
			Dim lista As List(Of T) = Nothing

			Try
				'//Seta a query no command
				ICom.CommandText = p_Select

				'//Seta o tipo de comando
				ICom.CommandType = CommandType.Text

				OpenConnection()

				Using IDR As IDataReader = ICom.ExecuteReader()
					lista = InstanciarClasse(Of T)(GetType(T).Assembly.GetName().Name, GetType(T).Name, IDR)
				End Using
			Catch ex As Exception
				Stop 'Throw New Exception(ex.Message)
			Finally
				CloseConnection()
			End Try
			Return lista
		End Function

		Public Function Insert(p_Insert As String) As Boolean
			Return ExecuteCommand(p_Insert)
		End Function

		Public Function Insert(p_Inserts As List(Of String)) As Boolean
			Return ExecuteCommands(p_Inserts)
		End Function

		Public Function Insert(p_Insert As String, p_Parameters As List(Of String), p_Values As List(Of Object)) As Boolean
			Return ExecuteCommand(p_Insert, p_Parameters, p_Values)
		End Function

		Public Function Update(p_Update As String) As Boolean
			Return ExecuteCommand(p_Update)
		End Function

		Public Function Update(p_Update As String, p_Parameters As List(Of String), p_Values As List(Of Object))
			Return ExecuteCommand(p_Update, p_Parameters, p_Values)
		End Function

		Public Function Delete(p_Delete As String) As Boolean
			Return ExecuteCommand(p_Delete)
		End Function

		Public Function Execute(p_Execute As String) As Boolean
			Return ExecuteCommand(p_Execute)
		End Function

		Private Function ExecuteCommand(p_Command As String) As Boolean
			Dim result As Int16 = 0

			Try
				ICom.CommandText = p_Command

				OpenConnection()

				result = ICom.ExecuteNonQuery()
			Catch ex As Exception
				Throw New Exception(ex.Message)
			Finally
				CloseConnection()
			End Try
			Return result > 0
		End Function

		Private Function ExecuteCommands(p_Commands As List(Of String)) As Boolean
			Dim result As Int16 = 0
			Try

				OpenConnection()

				For Each _command As String In p_Commands
					ICom.CommandText = _command

					If (IConn.State <> ConnectionState.Open) Then OpenConnection()

					result = ICom.ExecuteNonQuery()
				Next
			Catch ex As Exception
				Throw New Exception(ex.Message)
			Finally
				CloseConnection()
			End Try
			Return result > 0
		End Function

		Private Function ExecuteCommand(p_Command As String, p_Parameters As List(Of String), p_Values As List(Of Object)) As Boolean
			Dim result As Int16 = 0

			Try

				Dim tamanho As Int16 = p_Values.Count

				If BD = enumBD.ORACLE Then p_Command = p_Command.Replace("@", ":p")

				ICom.CommandText = p_Command
				ICom.Parameters.Clear()

				For i As Int16 = 0 To tamanho - 1
					Dim P As IDataParameter = Nothing
					Select Case BD
						Case enumBD.ACCESS
							P = New OleDbParameter(p_Parameters(i), p_Values(i))
						Case enumBD.ORACLE
							'P = New OracleParameter(p_Parameters(i).Replace("@", ":p"), p_Values(i))
							'Case enumBD.SQLITE
							'P = New SQLiteParameter(p_Parameters(i), p_Values(i))
						Case enumBD.SQLSERVER
							P = New SqlParameter(p_Parameters(i), p_Values(i))
					End Select
					ICom.Parameters.Add(P)
				Next

				OpenConnection()

				result = ICom.ExecuteNonQuery()
			Catch ex As Exception
				Throw New Exception(ex.Message)
			Finally
				CloseConnection()
			End Try
			Return result > 0
		End Function

		Private Function InstanciarClasse(Of T)(p_assembly As String, p_className As String, p_reader As IDataReader) As List(Of T)
			Dim t_assembly As Assembly = Assembly.Load(p_assembly)
			If (Not t_assembly Is Nothing) Then
				Dim t_classe = t_assembly.GetTypes().Where(Function(w) w.Name.ToUpper() = p_className.ToUpper()).FirstOrDefault()
				If (Not t_classe Is Nothing) Then
					Dim objeto = Activator.CreateInstance(t_classe)

					Dim genericListType As Type = GetType(List(Of))
					Dim concreteListType As Type = genericListType.MakeGenericType(t_classe)
					Dim List As IList = CType(Activator.CreateInstance(concreteListType), IList)

					Dim properties As PropertyInfo() = t_classe.GetProperties()

					Do While (p_reader.Read())

						Dim instance = System.Activator.CreateInstance(t_classe)

						Dim colunas = Enumerable.Range(0, p_reader.FieldCount).Select(Function(x) p_reader.GetName(x)).ToList()

						For Each coluna In colunas

							Windows.Forms.Application.DoEvents()

							Dim tipo As String = p_reader(coluna).GetType().Name
							If (tipo <> "DBNull") Then

								'Dim prop As PropertyInfo = properties.Where(w >= w.Name.ToUpper() = coluna.ToUpper()).FirstOrDefault()
								Dim prop As PropertyInfo = properties.Where(Function(w) w.Name.ToUpper() = coluna.ToUpper()).FirstOrDefault()

								If (Not prop Is Nothing) Then
									If tipo.Trim.ToUpper.Contains("DECIMAL") Or tipo.Trim.ToUpper.Contains("FLOAT") Or tipo.Trim.ToUpper.Contains("DOUBLE") Then
										prop.SetValue(instance, Convert.ToDouble(p_reader(coluna)), Nothing)
									ElseIf tipo.ToUpper.Contains("INT64") Then
										prop.SetValue(instance, Convert.ToInt64(p_reader(coluna)), Nothing)
									ElseIf tipo.ToUpper.Contains("INT32") Then
										prop.SetValue(instance, Convert.ToInt32(p_reader(coluna)), Nothing)
									ElseIf tipo.ToUpper.Contains("INT16") Then
										prop.SetValue(instance, Convert.ToInt16(p_reader(coluna)), Nothing)
									ElseIf prop.PropertyType.Name.ToUpper.Contains("DATE") Then
										If IsDate(p_reader(coluna)) Then
											prop.SetValue(instance, Convert.ToDateTime(p_reader(coluna)), Nothing)
										Else
											prop.SetValue(instance, Nothing, Nothing)
										End If
									ElseIf tipo.ToUpper.Contains("BYTE") Or tipo.ToUpper.Contains("BOOLEAN") Then
										prop.SetValue(instance, p_reader(coluna), Nothing)
									Else
										prop.SetValue(instance, p_reader(coluna).ToString, Nothing)
									End If
								End If
							End If
						Next

						List.Add(instance)
					Loop
					Return CType(List, List(Of T))
				End If
			End If
			Return New List(Of T)()
		End Function

		Private Sub OpenConnection()
			If (IConn.State = ConnectionState.Closed) Then
				IConn.Open()
				If BD = enumBD.ORACLE Then
					Dim Formato As String = FormatoDataHora.ToUpper
					'Formato = Formato.Replace(":MM", ":MI").Replace("HH", "HH24")
					'Dim Cmd As New OracleCommand("Alter Session Set Nls_Date_Format = '" & Formato & "'", IConn)
					'Cmd.ExecuteNonQuery()
				End If
			End If
		End Sub

		Private Sub CloseConnection()
			IConn.Close()
		End Sub

		Private Sub DisposeConnection()
			IConn.Dispose()
		End Sub

	End Class

End Namespace