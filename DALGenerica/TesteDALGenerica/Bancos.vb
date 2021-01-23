Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Bancos
    Public Sub New()
        AplicativosBancos = New HashSet(Of AplicativosBancos)()
    End Sub

    Public Property ID As Long

    Public Property Codigo As Integer

    <Required>
    <StringLength(1)>
    Public Property BANCO As String

    <Column("Alias")>
    <StringLength(1)>
    Public Property _Alias As String

    Public Overridable Property AplicativosBancos As ICollection(Of AplicativosBancos)
End Class
