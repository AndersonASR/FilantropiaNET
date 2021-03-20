Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Reflection
Imports System.Text

Namespace DAL.Repositorio

	Public Class RepositorioGenerico(Of T As Class)

		Private Persist As Persistencia
		Private PlicDH As String
		Private plicLike As String
		Private formatoDH As String

		Public Sub New(TipoBD As enumBD, StringConexao As String)

			plicLike = "%"
			PlicDH = "'"
			formatoDH = "yyyy-MM-dd HH:mm:ss"

			If TipoBD = enumBD.ACCESS Then
				formatoDH = "MM/dd/yyyy HH:mm:ss"
				PlicDH = "#"
			ElseIf TipoBD = enumBD.SQLSERVER Then
				formatoDH = "dd/MM/yyyy HH:mm:ss"
				PlicDH = "'"
			ElseIf TipoBD <> enumBD.SQLITE And TipoBD <> enumBD.ORACLE Then
				plicLike = "*"
			End If

			Persist = New Persistencia(TipoBD, StringConexao, formatoDH, PlicDH)

			_insertFields = New List(Of String)
			_insertParameters = New List(Of String)
			_insertValues = New List(Of Object)

			_updateValues = New List(Of Object)

			_order = String.Empty
			_where = String.Empty
			_whereIsEmpty = True
		End Sub

#Region "Propriedades"

		Private ReadOnly Property _selectAll As String
			Get
				Return String.Format("SELECT * FROM {0} ", _className)
			End Get
		End Property

		Private ReadOnly Property _insert As String
			Get
				Return String.Format("INSERT INTO {0}", _className)
			End Get
		End Property

		Private ReadOnly Property _update As String
			Get
				Return String.Format("UPDATE {0} SET", _className)
			End Get
		End Property

		Private ReadOnly Property _delete As String
			Get
				Return String.Format("DELETE FROM {0}", _className)
			End Get
		End Property

		Private Property _Vetor() As Byte

		Private Property _insertFields As List(Of String)

		Private Property _insertParameters As List(Of String)

		Private Property _insertValues As List(Of Object)

		Private Property _updateFields As List(Of String)

		Private Property _updateParameters As List(Of String)

		Private Property _updateValues As List(Of Object)

		Private Property _where As String

		Private Property _whereIsEmpty As Boolean

		Private Property _order As String

		Private ReadOnly Property _className As String
			Get
				Return GetType(T).Name.ToUpper()
			End Get
		End Property

		Private ReadOnly Property _classAssembly As Assembly
			Get
				Return Assembly.Load(Me._className)
			End Get
		End Property

#End Region

#Region "Métodos Públicos"

		Public Sub AdicionarParametro(Coluna As String, Operador As CompareType, Valor As String, Optional Valor2 As String = "", Optional UtilizarOu As Boolean = False)
			Dim _stringClause As String = String.Empty
			Dim _clause As String = ""

			Valor = Valor.Replace(",", ".")
			Valor2 = Valor2.Replace(",", ".")

			Coluna = Coluna.Trim.ToUpper

			If Operador = CompareType.IN Then
				_stringClause = "{0} In ({1})"
				_clause = String.Format(_stringClause, Coluna, IIf(Not Valor Is Nothing, Valor, "NULL"))
			Else
				Dim Tipo As Type = GetType(T)
				Dim properties As PropertyInfo() = Tipo.GetProperties()
				For Each P In properties
					If P.Name.Trim.ToUpper = Coluna.Trim.ToUpper Then
						If P.PropertyType = Type.GetType("System.DateTime") Or P.PropertyType = Type.GetType("System.Date") Then
							Valor = PlicDH & Convert.ToDateTime(Valor).ToString(formatoDH) & PlicDH
							If Valor2 <> "" Then Valor2 = PlicDH & Convert.ToDateTime(Valor2).ToString(formatoDH) & PlicDH
						ElseIf P.PropertyType = Type.GetType("System.String") Then
							Valor = IIf(Operador = CompareType.Como, "'" & plicLike & Valor & plicLike & "'", "'" & Valor & "'")
							If Valor2 <> "" Then Valor2 = IIf(Operador = CompareType.Como, "'" & plicLike & Valor2 & plicLike & "'", "'" & Valor2 & "'")
						End If
						Exit For
					End If
				Next

				Select Case Operador
					Case CompareType.Igual
						_stringClause = "{0} = {1}"
					Case CompareType.NaoIgual
						_stringClause = "{0} <> {1}"
					Case CompareType.NaoE
						_stringClause = "not {0} is {1}"
					Case CompareType.Diferente
						_stringClause = "{0} <> {1}"
					Case CompareType.Como
						_stringClause = "{0} like {1}"
					Case CompareType.MaiorQue
						_stringClause = "{0} > {1}"
					Case CompareType.MaiorOuIgualA
						_stringClause = "{0} >= {1}"
					Case CompareType.MenorQue
						_stringClause = "{0} < {1}"
					Case CompareType.MenorOuIgualA
						_stringClause = "{0} <= {1}"
					Case CompareType.Entre
						_stringClause = "{0} Between {1} And {2}"
					Case Else
						_stringClause = "{0} = {1}"
				End Select

				If Valor2 <> "" Then
					_clause = String.Format(_stringClause, Coluna, Valor, Valor2)
				Else
					_clause = String.Format(_stringClause, Coluna, IIf(Not Valor Is Nothing, Valor, "NULL"))
				End If

				If (_clause.Contains("'NULL'")) Then _clause = _clause.Replace("'NULL'", "NULL")
			End If

			If (_whereIsEmpty) Then
				_whereIsEmpty = False
			Else
				_where += IIf(UtilizarOu, " OR ", " AND ")
			End If
			_where += _clause
		End Sub

		Public Sub AdicionarCampoOrdenacao(Campo As String, Optional Ascendente As Boolean = True)
			_order &= IIf(_order.Trim.Length > 0, ", ", "") & Campo & IIf(Not Ascendente, " DESC", "")
		End Sub

		Public Function ObterTodos() As List(Of T)
			Return Persist.Select(Of T)(_selectAll)
		End Function

		Public Function Obter() As List(Of T)
			Dim _list As List(Of T)
			Dim aux As String = ""
			If _where <> "" Then
				aux = String.Format("{0} WHERE {1}", _selectAll, _where)
			Else
				aux = String.Format("{0}", _selectAll)
			End If
			If _order <> "" Then aux &= " Order By " & _order
			_list = Persist.Select(Of T)(aux)
			_where = String.Empty
			_order = ""
			_whereIsEmpty = True
			Return _list
		End Function

		Public Function Obter(p_select As String) As List(Of T)
			Return Persist.Select(Of T)(p_select)
		End Function

		Public Sub LimparOrdernacao()
			_order = ""
		End Sub

		Public Sub LimparParametros()
			_where = ""
			_whereIsEmpty = True
		End Sub

		Public Function Inserir(_object As T) As Boolean
			Dim _type As Type = _object.GetType()
			Dim properties As PropertyInfo() = _type.GetProperties()
			Dim isValid As Boolean
			Dim date_format As String = "alter session set nls_date_format = 'dd/mm/yy'"

			_insertFields = New List(Of String)
			_insertParameters = New List(Of String)
			_insertValues = New List(Of Object)

			'Dim _currentValue As String = String.Empty
			Dim _currentValue As Object = String.Empty
			For Each _property In properties

				_currentValue = IIf(Not _property.GetValue(_object, Nothing) Is Nothing, _property.GetValue(_object, Nothing), Nothing)

				If Not _currentValue Is Nothing Then

					isValid = True

					If (_property.PropertyType Is GetType(System.DateTime) Or _property.PropertyType Is GetType(System.DateTime?)) Then
						If (_currentValue = DateTime.MinValue.ToString(formatoDH)) Or _currentValue = "00:00:00" Then
							isValid = False
						Else
							_currentValue = Convert.ToDateTime(_currentValue).ToString(formatoDH)
						End If
					ElseIf _property.PropertyType Is GetType(System.String) Then
						_currentValue = _currentValue.ToString.Trim.ToUpper
					End If

					If _property.Name.Trim.ToUpper = "ID" AndAlso _property.GetValue(_object, Nothing) = 0 Then isValid = False

					If (isValid) Then
						_insertFields.Add(_property.Name.ToUpper())
						_insertParameters.Add(String.Format("@{0}", _property.Name.ToUpper()))
						_insertValues.Add(_currentValue)
					End If
				End If
			Next

			'//AJUSTA FORMATO DE DATA
			'Persist.Insert(date_format)

			'//MONTA A STRING DE INSERT COM OS PARAMETROS
			Dim cmdinsert As String = String.Format("{0} ({1}) VALUES ({2})", _insert, String.Join(",", _insertFields), String.Join(",", _insertParameters))

			'//EXECUTA O COMANDO
			Return Persist.Insert(cmdinsert, _insertParameters, _insertValues)
		End Function

		Public Function Atualizar(_object As T, Optional Condicao As String = "") As Boolean
			Dim _type As Type = _object.GetType()
			Dim properties As PropertyInfo() = _type.GetProperties()
			Dim isValid As Boolean
			Dim Comando As String = _update & " "

			_updateParameters = New List(Of String)
			_updateValues = New List(Of Object)

			Dim _currentValue As Object = Nothing
			For Each _property In properties

				_currentValue = IIf(Not _property.GetValue(_object, Nothing) Is Nothing, _property.GetValue(_object, Nothing), Nothing)

				If Not _currentValue Is Nothing Then

					isValid = True

					If (_property.PropertyType Is GetType(System.DateTime) Or _property.PropertyType Is GetType(System.DateTime?)) Then
						If (_currentValue = DateTime.MinValue.ToString(formatoDH)) Or _currentValue = "00:00:00" Then
							isValid = False
						Else
							_currentValue = Convert.ToDateTime(_currentValue).ToString(formatoDH)
						End If
					ElseIf _property.PropertyType Is GetType(System.String) Then
						_currentValue = _currentValue.ToString.Trim.ToUpper
					End If

					If _property.Name.Trim.ToUpper = "ID" AndAlso Convert.ToInt64(_currentValue) > 0 Then
						Condicao = "ID = " & _currentValue.ToString.Trim
						isValid = False
					End If

					If (isValid) Then
						Comando &= _property.Name & " = @" & _property.Name & ", "
						'_updateFields.Add(_property.Name & " = @" & _property.Name)
						_updateParameters.Add("@" & _property.Name.Trim.ToUpper)
						_updateValues.Add(_currentValue)
					End If
				End If
			Next
			If Comando.Contains(",") Then Comando = Comando.Substring(0, Comando.Length - 2)

			Comando &= " Where " & IIf(Condicao <> "", Condicao, _where)

			Return Persist.Update(Comando, _updateParameters, _updateValues)
		End Function

		'Public Function Atualizar(_object As T, novo As Boolean) As Boolean
		'	Dim _type As Type = _object.GetType()
		'	Dim properties As PropertyInfo() = _type.GetProperties()
		'	Dim isValid As Boolean

		'	_updateFields = New List(Of String)
		'	_updateParameters = New List(Of String)
		'	_updateValues = New List(Of String)
		'	Dim date_format As String = "alter session set nls_date_format = 'dd/mm/yy'"

		'	Dim _currentValue As String = String.Empty
		'	For Each _property In properties
		'		_currentValue = IIf(_property.GetValue(_object, Nothing) Is Nothing, _property.GetValue(_object, Nothing).ToString(), String.Empty)
		'		If (Not String.IsNullOrWhiteSpace(_currentValue)) Then
		'			isValid = True

		'			If (_property.PropertyType = GetType(System.DateTime) Or _property.PropertyType = GetType(System.DateTime?)) Then
		'				_currentValue = Convert.ToDateTime(_currentValue).ToString(formatoDH)
		'				'//_currentValue = DateTime.ParseExact(_currentValue, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToShortDateString();

		'				'If (Convert.ToDateTime(_currentValue).TimeOfDay.ToString() <> "00:00:00") Then date_format = "alter session set nls_date_format = 'dd/mm/yy hh24:mi:ss'"

		'				If (_currentValue = DateTime.MinValue.ToString(formatoDH)) Then isValid = False
		'			End If

		'			If (isValid) Then
		'				_updateFields.Add(String.Format("{0}=@{0}", _property.Name))
		'				_updateParameters.Add(String.Format("@{0}", _property.Name))
		'				_updateValues.Add(_currentValue)
		'			End If
		'		End If
		'	Next

		'	'//AJUSTA FORMATO DE DATA
		'	'Persist.Insert(date_format)

		'	'//MONTA A STRING DE INSERT COM OS PARAMETROS
		'	Dim cmdUpdate As String = String.Format("{0} {1} WHERE {2}", _update, String.Join(",", _updateFields), _where)

		'	'//EXECUTA O COMANDO
		'	Return Persist.Update(cmdUpdate, _updateParameters, _updateValues)
		'End Function

		Public Function Atualizar(_objects As List(Of T)) As Boolean
			Dim resposta As Boolean = True
			For Each _object In _objects
				resposta = Me.Atualizar(_object)

				If (Not resposta) Then Exit For
			Next
			Return resposta
		End Function

		Public Function Inserir(_objects As List(Of T)) As Boolean
			Dim resposta As Boolean = True
			For Each _object In _objects
				resposta = Me.Inserir(_object)

				If (Not resposta) Then Exit For
			Next
			Return resposta
		End Function

		Public Function Excluir() As Boolean
			If (Not String.IsNullOrWhiteSpace(_where)) Then
				Dim result As Boolean = Persist.Delete(String.Format("{0} WHERE {1}", _delete, _where))
				_where = String.Empty
				Return result
			Else
				Throw New Exception("Por motivos de segurança, é necessário informar um cláusula where para realizar a exclusão!")
			End If
		End Function

		Public Function Excluir(Condicao As String) As Boolean
			If (Not String.IsNullOrWhiteSpace(Condicao)) Then
				Dim result As Boolean = Persist.Delete(String.Format("{0} WHERE {1}", _delete, Condicao))
				_where = String.Empty
				Return result
			Else
				Throw New Exception("Por motivos de segurança, é necessário informar um cláusula where para realizar a exclusão!")
			End If
		End Function

#End Region

	End Class

End Namespace
