Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class EMails
    Public Property ID As Long

    Public Property IDPessoa As Long

    <Required>
    <StringLength(1)>
    Public Property EMail As String
End Class
