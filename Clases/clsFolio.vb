Public Class clsFolio
    Public Sub SolicitarFolios(ByVal TipoDTE As Integer)
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            Dim ProximoFolio As Integer = 0, RangoFolios As tdFolio = MostrarFolios(TipoDTE)
            Select Case TipoDTE
                Case 33 : ProximoFolio = NroProximaFactura
                Case 52 : ProximoFolio = NroProximaGuia
                Case Else : Err(Mensajes.Errores.TipoDTENoSoportado & vbNewLine & Mensajes.Advertencias.AvisarAdministradorSistema)
            End Select
            If (ProximoFolio <> 0) And ProximoFolio <= RangoFolios.rHasta Then Err(Mensajes.Errores.ErrDTEAunQuedanFolios)



            Dim Pat As String = Patente
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "EXECUTE [dbo].[PrFoliosAsignar] @tipoDte, @Patente"
                Cn.AgregarParametro("@tipoDte", SqlDbType.Int, 0, TipoDTE)
                Cn.AgregarParametro("@Patente", SqlDbType.VarChar, Pat.Length, Pat)
                Using Rs As DataTableReader = Cn.getData().CreateDataReader
                    If Rs.Read() Then
                        If Rs("MsgError").ToString.Trim.Length <= 0 Then
                            GuardaFolios(Rs("PATENTE"), Rs("tipoDte"), Rs("FechaCAF"), Rs("Fecha"), Rs("RangoDesde"), Rs("RangoHasta"))
                            'guardo el XML del CAF en la carpeta local  33_FacturaElectronica_13_82.dat
                            Dim NArchivo As String = TipoDTE & "_" & dllFunciones.Erik.TipoTitulo(TipoDocumento(TipoDTE).ToLower).Replace(" ", "") & "_" & Rs("RangoDesde") & "_" & Rs("RangoHasta") & ".dat"
                            WriteBinaryFile(Directorio.CAF & NArchivo, Rs("fileXml"))
                        Else
                            Err(Rs(0))
                        End If
                    Else
                        Err(Mensajes.Errores.SinDatosParaMostrar)
                    End If
                End Using
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()

        End Try
    End Sub

    ''' <summary>
    ''' Guarda los Folios Obtenidos en la Base de datos Local
    ''' </summary>
    ''' <param name="Patente">Patente del Camion.</param>
    ''' <param name="TipoDTE">Tipo de Documento Electronico (DTE).</param>
    ''' <param name="FechaCAF">Fecha del CAF.</param>
    ''' <param name="FechaObtencion">Fecha en la que se asignaron los folios.</param>
    ''' <param name="RangoDesde">nro folio inicial.</param>
    ''' <param name="RangoHasta">nro folio final.</param>
    ''' <remarks></remarks>
    Private Sub GuardaFolios(ByVal Patente As String, ByVal TipoDTE As Integer, ByVal FechaCAF As Date, ByVal FechaObtencion As Date, ByVal RangoDesde As Integer, ByVal RangoHasta As Integer)
        Dim Cn As New Stic.SQLite
        Try
            If Cn.AbrirBaseDatos Then
                Cn.SentenciaSQL = "insert into ConsumoFolio values ('" & Patente & "', " & TipoDTE & ", '" & FechaCAF & "', '" & FechaObtencion & "', " & RangoDesde & ", " & RangoHasta & ")"
                'Cn.AgregarParametro("@Patente", OleDb.OleDbType.VarChar, Patente.Length, Patente)
                'Cn.AgregarParametro("@TipoDTE", OleDb.OleDbType.Integer, 0, TipoDTE)
                'Cn.AgregarParametro("@FechaCAF", OleDb.OleDbType.Date, 0, FechaCAF)
                'Cn.AgregarParametro("@FechaObtencion", OleDb.OleDbType.Date, 0, FechaObtencion)
                'Cn.AgregarParametro("@RangoDesde", OleDb.OleDbType.Integer, 0, RangoDesde)
                'Cn.AgregarParametro("@RangoHasta", OleDb.OleDbType.Integer, 0, RangoHasta)
                Dim R As Integer = Cn.GuardarDatos()
                If R = 0 Then
                    Err(Mensajes.Errores.NoGuardo)
                End If
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception
            Throw
        Finally
            Cn.CerrarBaseDatos()
        End Try
    End Sub

    Friend Shared Function MostrarFolios(ByVal TipoDte As Integer) As tdFolio
        Dim Cn As New Stic.SQLite
        Try
            If Cn.AbrirBaseDatos Then
                Cn.SentenciaSQL = "select fecha, rangoDesde, rangoHasta from ConsumoFolio where cafTipoDte = " & TipoDte & " and fecha = (select max(fecha) from ConsumoFolio where cafTipoDte = " & TipoDte & ")"
                'Cn.AgregarParametro("@TipoDTE", OleDb.OleDbType.Integer, 0, TipoDte)
                Using Rs As DataTableReader = Cn.LeerDatos().CreateDataReader
                    If Rs.Read() Then
                        Dim R As New tdFolio
                        R.fecha = Rs("fecha")
                        R.rDesde = Rs("rangoDesde")
                        R.rHasta = Rs("rangoHasta")
                        Return R
                    Else
                        'Err(Mensajes.Errores.SinDatosParaMostrar)
                        Dim R As New tdFolio
                        'R.fecha = ""
                        'R.rDesde = Rs("rangoDesde")
                        'R.rHasta = Rs("rangoHasta")
                        Return R
                    End If
                End Using
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception
            Throw
        Finally
            Cn.CerrarBaseDatos()
        End Try
    End Function


    Public Shared ReadOnly Property NroProximaGuia As Integer
        Get
            Dim TipoDTE As Integer = 52
            Dim Cn As New dllFunciones.cnxSqlServer
            Try
                If Cn.conectarServidorSQLServer Then
                    Cn.SentenciaSQL = "select isnull(max(folioDTE),0)+1 from Adic.DslDTE where tipoDTE = " & TipoDTE
                    Using Rs As DataTableReader = Cn.getData().CreateDataReader
                        If Rs.Read() Then
                            Dim Folio As Integer = Rs(0)
                            Dim Resp As tdFolio = MostrarFolios(TipoDTE)
                            If Folio < Resp.rDesde Then Folio = Resp.rDesde
                            If Folio > Resp.rHasta Then Folio = 0

                            Return Folio
                        Else
                            Err(Mensajes.Errores.SinDatosParaMostrar)
                        End If
                    End Using
                Else
                    Err(Mensajes.Errores.BaseDatosInaxesible)
                End If
            Catch ex As Exception
                Throw
            End Try
        End Get
    End Property
    Public Shared ReadOnly Property NroProximaFactura As Integer
        Get
            Dim TipoDTE As Integer = 33
            Dim Cn As New dllFunciones.cnxSqlServer
            Try
                If Cn.conectarServidorSQLServer Then
                    Cn.SentenciaSQL = "select isnull(max(folioDTE),0)+1 from Adic.DslDTE where tipoDTE = " & TipoDTE
                    Using Rs As DataTableReader = Cn.getData().CreateDataReader
                        If Rs.Read() Then
                            Dim Folio As Integer = Rs(0)
                            Dim Resp As tdFolio = MostrarFolios(TipoDTE)
                            If Folio < Resp.rDesde Then Folio = Resp.rDesde
                            If Folio > Resp.rHasta Then Folio = 0

                            Return Folio
                        Else
                            Err(Mensajes.Errores.SinDatosParaMostrar)
                        End If
                    End Using
                Else
                    Err(Mensajes.Errores.BaseDatosInaxesible)
                End If
            Catch ex As Exception
                Throw
            End Try
        End Get
    End Property
End Class