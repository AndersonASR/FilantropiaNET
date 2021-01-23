Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class TiposPessoas
    Public Sub New()
        Pessoas = New HashSet(Of Pessoas)()
    End Sub

    Public Property ID As Long

    <Required>
    <StringLength(1)>
    Public Property Tipo As String

    Public Overridable Property Pessoas As ICollection(Of Pessoas)
End Class
