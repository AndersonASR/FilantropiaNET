Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Boletos
    Public Property ID As Long

    Public Property IDSERVICO As Long

    Public Property IDCedente As Long

    Public Property IDSacado As Long

    Public Property IDRemessa As Long?

    Public Property IDRetorno As Long?

    <Required>
    <StringLength(1)>
    Public Property EspecieDocumento As String

    <Required>
    <StringLength(1)>
    Public Property NumeroDocumento As String

    <Required>
    <StringLength(1)>
    Public Property NossoNumero As String

    <Required>
    <StringLength(1)>
    Public Property DataGeracao As String

    <Required>
    <StringLength(1)>
    Public Property DataProcessamento As String

    <Required>
    <StringLength(1)>
    Public Property DataEmissao As String

    <Required>
    <StringLength(1)>
    Public Property DataVencimento As String

    Public Property Valor As Single

    <StringLength(1)>
    Public Property DataPagamento As String

    Public Property ValorPago As Single?

    <StringLength(1)>
    Public Property NumeroControle As String

    <StringLength(1)>
    Public Property Aceite As String

    Public Property PercentualMulta As Single?

    Public Property PercentualJurosDia As Single?

    <StringLength(1)>
    Public Property DataDesconto As String

    Public Property ValorDesconto As Single?

    <StringLength(1)>
    Public Property MensagemInstrucaoCaixa As String

    <StringLength(1)>
    Public Property MensagemRemessa As String

    <StringLength(1)>
    Public Property Instrucao1 As String

    <StringLength(1)>
    Public Property InstrucaoAux1 As String

    <StringLength(1)>
    Public Property Instrucao2 As String

    <StringLength(1)>
    Public Property InstrucaoAux2 As String

    <StringLength(1)>
    Public Property Instrucao3 As String

    <StringLength(1)>
    Public Property InstrucaoAux3 As String

    Public Property ImprimirValoresAuxiliares As Integer?

    <Required>
    <StringLength(1)>
    Public Property NomeArquivo As String

    <Required>
    <MaxLength(1)>
    Public Property Arquivo As Byte()

    Public Property IDStatus As Long

    Public Overridable Property AplicativosBancos As AplicativosBancos

    Public Overridable Property Pessoas As Pessoas

    Public Overridable Property Pessoas1 As Pessoas
End Class
