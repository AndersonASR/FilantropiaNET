Imports System.Web.Mvc

Namespace Controllers
    Public Class LogsController
        Inherits Controller

        ' GET: Logs
        Function Index() As ActionResult

            Return View()
        End Function

        Function Index(Log As ParametrosLog) As ActionResult
            'Dim U As FilantropiaDLL.Modelos.Pessoa = Filantropia.ObterPessoa(Log.idpe)
            'Filantropia.Logs.Obter(Log.Inicio, Log.Fim, Log.Acao, Log.IDUsuario)
            Return View()
        End Function

    End Class
End Namespace