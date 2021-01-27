Imports System.ComponentModel.DataAnnotations

Namespace DAL.Modelos
	Partial Public Class Enderecos
		Public Enum Campos
			ID
			Logradouro
			Numero
			Complemento
			Bairro
			Cidade
			UF
			CEP
			OBS
		End Enum

		<Required>
		Public Property ID As Int64
		<Required>
		Public Property Logradouro As String
		Public Property Numero As Integer
		Public Property Complemento As String
		<Required>
		Public Property Bairro As String
		<Required>
		Public Property Cidade As String
		<Required>
		Public Property UF As String
		<Required>
		Public Property CEP As String
		Public Property OBS As String
	End Class
End Namespace