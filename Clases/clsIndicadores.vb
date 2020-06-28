Public Class clsIndicadores
    Public Shared ReadOnly Property IEComponenteBase As Double
        Get
            Dim Cn As New dllFunciones.cnxSqlServer
            Try
                If Cn.conectarServidorSQLServer Then
                    Cn.SentenciaSQL = "select IEComBase from DslIE where fechaCrea = (select max(fechaCrea) from DslIE)"
                    Using Rs As DataTableReader = Cn.getData().CreateDataReader
                        If Rs.Read() Then
                            Return Rs("IEComBase")
                        Else
                            Return 1.5
                        End If
                    End Using
                End If
                Return False
            Catch ex As Exception
                Throw
            Finally
                Cn.Desconectar()
            End Try
        End Get
    End Property
    Public Shared ReadOnly Property IEComponenteVariable As Double
        Get
            Dim Cn As New dllFunciones.cnxSqlServer
            Try
                If Cn.conectarServidorSQLServer Then
                    Cn.SentenciaSQL = "select IEComVar from DslIE where fechaCrea = (select max(fechaCrea) from DslIE)"
                    Using Rs As DataTableReader = Cn.getData().CreateDataReader
                        If Rs.Read() Then
                            Return Rs("IEComVar")
                        Else
                            Return 0
                        End If
                    End Using
                End If
                Return False
            Catch ex As Exception
                Throw
            Finally
                Cn.Desconectar()
            End Try
        End Get
    End Property
    Public Shared ReadOnly Property UTMActual As Double
        Get
            Dim Cn As New dllFunciones.cnxSqlServer
            Try
                If Cn.conectarServidorSQLServer Then
                    Cn.SentenciaSQL = "select valor from UTM where mes = format(GETDATE(), 'yyyy-MM-01')"
                    Using rs As DataTableReader = Cn.getData().CreateDataReader
                        If rs.Read() Then
                            Return rs(0)
                        End If
                    End Using
                End If
                Return 0
            Catch ex As Exception
                Throw
            Finally
                Cn.Desconectar()
            End Try
        End Get
    End Property
    Public Shared Sub GuardarIE(ByVal ComBase As Double, ByVal ComVar As Double)
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "select * from DslIE where IEComBase = @Base and IEComVar = @Var and fechaCrea = (select max(fechaCrea) from DslIE)"
                Cn.AgregarParametro("@Base", SqlDbType.Float, 0, ComBase)
                Cn.AgregarParametro("@Var", SqlDbType.Float, 0, ComVar)
                Cn.getData()
                If Cn.Count = 0 Then
                    'insert
                    Cn.SentenciaSQL = "insert into DslIE values(GETDATE(), @Base, @Var)"
                    Cn.AgregarParametro("@Base", SqlDbType.Float, 0, ComBase)
                    Cn.AgregarParametro("@Var", SqlDbType.Float, 0, ComVar)
                    Cn.setDatos()
                End If
            End If

        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try
    End Sub
    Public Shared Function GuardarUTM(mes As Integer, año As Integer, valor As Integer) As Boolean
        Dim Cn As New dllFunciones.cnxSqlServer
        Try

            If valor = 0 Then Return False
            Dim Fecha As Date = CDate("1-" & mes & "-" & año)
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "insert into UTM values (@Mes, @valor)"
                Cn.AgregarParametro("@Mes", SqlDbType.Date, 0, Fecha)
                Cn.AgregarParametro("@valor", SqlDbType.Int, 0, valor)
                Dim r As Integer = Cn.setDatos()
                If r > 0 Then Return True
            End If
            Return False
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try

    End Function
    Public Shared Function GuardarUTM(valor As Integer) As Boolean

        Try
            'Dim Fecha As Date = CDate(Format(Now(), "01-mm-yyyy").ToString)
            Return GuardarUTM(Val(Format(Now(), "MM")), Val(Format(Now(), "yyyy")), valor)
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class
