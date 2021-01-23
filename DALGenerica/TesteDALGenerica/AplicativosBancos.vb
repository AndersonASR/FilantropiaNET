Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class AplicativosBancos
    Public Sub New()
        Boletos = New HashSet(Of Boletos)()
    End Sub

    Public Property ID As Long

    Public Property IDSISTEMA As Long

    Public Property IDBanco As Long

    Public Overridable Property Bancos As Bancos

    Public Overridable Property Boletos As ICollection(Of Boletos)
End Class
