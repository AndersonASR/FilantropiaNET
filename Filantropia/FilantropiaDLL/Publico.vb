Module Publico
	Public Sub Popular(ByRef Origem As Object, ByRef Destino As Object)
		Dim TOrigem As Type = Origem.GetType
		Dim InfoOrigem() As System.Reflection.PropertyInfo = TOrigem.GetProperties
		Dim TDestino As Type = Destino.GetType
		Dim InfoDestino() As System.Reflection.PropertyInfo = TDestino.GetProperties

		For Each P1 As System.Reflection.PropertyInfo In InfoOrigem
			For Each P2 As System.Reflection.PropertyInfo In InfoDestino
				If P1.Name = P2.Name And P1.PropertyType.Name = P2.PropertyType.Name Then
					P2.SetValue(Destino, P1.GetValue(Origem), Nothing)
					Exit For
				End If
			Next
		Next
	End Sub
End Module
