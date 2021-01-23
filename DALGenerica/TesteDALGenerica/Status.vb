Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Status
    Public Property ID As Long

    <Column("Status")>
    <Required>
    <StringLength(1)>
    Public Property Status1 As String
End Class
