Imports DALFilantropia
Imports DALFilantropia.DAL
Imports DALFilantropia.DAL.Enumeradores

Namespace Componentes

	Partial Public Class TipoReferencia
		Public Property ID As Long
		Public Property Referencia As String
	End Class

	Public Class TiposReferencias
		Private RTiposReferencias As DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.TiposReferencias)
		Private LTiposReferencias As List(Of DALFilantropia.DAL.Modelos.TiposReferencias)

		Public Sub New(Conexao As String)
			RTiposReferencias = New DALFilantropia.DAL.Repositorio.RepositorioGenerico(Of DALFilantropia.DAL.Modelos.TiposReferencias)(DALFilantropia.DAL.Enumeradores.enumBD.SQLSERVER, Conexao)
		End Sub

		Public Function ObterTodos() As List(Of TipoReferencia)
			Dim TP As List(Of TipoReferencia) = Nothing

			RTiposReferencias.LimparParametros()
			LTiposReferencias = RTiposReferencias.ObterTodos

			If LTiposReferencias.Count > 0 Then

				TP = New List(Of TipoReferencia)

				For X As Int16 = 0 To LTiposReferencias.Count - 1
					Dim T As New TipoReferencia
					Popular(LTiposReferencias(X), T)
					'T.ID = LTiposReferencias(X).ID
					'T.Tipo = LTiposReferencias(X).Tipo
					TP.Add(T)
				Next
			End If

			Return TP

		End Function

		Public Function Obter(ID As Int64) As Componentes.TipoReferencia
			Dim TP As TipoReferencia = Nothing

			RTiposReferencias.LimparParametros()
			RTiposReferencias.AdicionarParametro(DAL.Modelos.TiposReferencias.Campos.ID.ToString, CompareType.Igual, ID)
			LTiposReferencias = RTiposReferencias.Obter

			If LTiposReferencias.Count > 0 Then
				TP = New Componentes.TipoReferencia
				Popular(LTiposReferencias(0), TP)
				'TP.ID = LTiposReferencias(0).ID
				'TP.Tipo = LTiposReferencias(0).Tipo
			End If

			Return TP
		End Function

		Public Function Obter(Referencia As String) As Componentes.TipoReferencia
			Dim TP As TipoReferencia = Nothing

			RTiposReferencias.LimparParametros()
			RTiposReferencias.AdicionarParametro(DAL.Modelos.TiposReferencias.Campos.Referencia.ToString, CompareType.Como, Referencia)
			LTiposReferencias = RTiposReferencias.Obter

			If LTiposReferencias.Count > 0 Then
				TP = New Componentes.TipoReferencia
				Popular(LTiposReferencias(0), TP)
				'TP.ID = LTiposReferencias(0).ID
				'TP.Tipo = LTiposReferencias(0).Tipo
			End If

			Return TP
		End Function

		Public Function InserirNovo(Dados As TipoReferencia) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.TiposReferencias

				Popular(Dados, B)

				RTiposReferencias.Inserir(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Atualizar(Dados As TipoReferencia) As Boolean
			Dim Executou As Boolean = False

			Try
				Dim B As New DAL.Modelos.TiposReferencias

				Popular(Dados, B)

				RTiposReferencias.Atualizar(B)

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function

		Public Function Excluir(Dados As TipoReferencia) As Boolean
			Dim Executou As Boolean = False

			Try

				RTiposReferencias.AdicionarParametro(DAL.Modelos.TiposReferencias.Campos.ID.ToString, CompareType.Igual, Dados.ID)
				RTiposReferencias.Excluir()

				Executou = True
			Catch ex As Exception

			End Try

			Return Executou
		End Function
	End Class
End Namespace