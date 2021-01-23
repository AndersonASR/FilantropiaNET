Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Enderecos
    Public Property ID As Long

    Public Property IDPessoa As Long

    <Required>
    <StringLength(1)>
    Public Property Logradouro As String

    Public Property Numero As Integer

    <StringLength(1)>
    Public Property Complemento As String

    <Required>
    <StringLength(1)>
    Public Property Bairro As String

    <Required>
    <StringLength(1)>
    Public Property Cidade As String

    <Required>
    <StringLength(1)>
    Public Property UF As String

    Public Property CEP As Integer

    <StringLength(1)>
    Public Property OBS As String
End Class
