Public Class clsVistas
    Public Function VistaEntregas() As DataTable
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "select idCliente, rutCliente, nombre, razonSocial, direccion, comuna, ciudad, giro, FORMAT(CantLtr,'##,###') as CantLtr, FORMAT(Meta,'##,###') as Meta, FORMAT(Lleva,'##,###') as Lleva from Adic.vEntregas where meta > lleva"
                Return Cn.getData()
            Else
                Throw New System.Exception(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try
    End Function
End Class
