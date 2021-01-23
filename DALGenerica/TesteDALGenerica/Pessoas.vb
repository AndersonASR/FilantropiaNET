Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Pessoas
    Public Sub New()
        Boletos = New HashSet(Of Boletos)()
        Boletos1 = New HashSet(Of Boletos)()
    End Sub

    Public Property ID As Long

    Public Property CPFCNPJ As Integer

    Public Property IDTipoPessoa As Long

    <Required>
    <StringLength(1)>
    Public Property Nome As String

    <StringLength(1)>
    Public Property Obs As String

    Public Overridable Property Boletos As ICollection(Of Boletos)

    Public Overridable Property Boletos1 As ICollection(Of Boletos)

    Public Overridable Property TiposPessoas As TiposPessoas
End Class
