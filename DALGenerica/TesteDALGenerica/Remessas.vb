Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Remessas
    Public Property ID As Long

    <Key>
    Public Property Lote As Integer

    <Required>
    <StringLength(1)>
    Public Property DataGravacao As String

    <Required>
    <StringLength(1)>
    Public Property NomeArquivo As String

    <Required>
    <MaxLength(1)>
    Public Property Arquivo As Byte()
End Class
