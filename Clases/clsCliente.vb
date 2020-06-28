Imports System.Data.SqlClient

Public Class clsCliente
    Public Class dtCliente
        Public Property IdCliente As Integer
        Public Property RazonSocial As String
        Public Property Direccion As String
        Public Property Comuna As String
        Public Property Ciudad As String
        Public Property Giro As String
        Public ReadOnly Property RutCliente As String
            Get
                If IdCliente = 0 Then
                    Return ""
                Else
                    Return IdCliente & "-" & dllFunciones.Erik.ObtenerDigitoVerificadorDelRut(IdCliente)
                End If
            End Get
        End Property
    End Class
    Public Function ClienteExiste(rutCliente As Integer) As Boolean
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "select * from Adic.Cliente where rutCliente = @rut"
                Cn.AgregarParametro("@rut", SqlDbType.Int, 0, rutCliente)
                Cn.getData()
                If Cn.Count > 0 Then Return True
            End If
            Return False
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try
    End Function
    Public Function MostrarCliente(ByVal RutCliente As String) As dtCliente
        Dim Cn As New dllFunciones.cnxSqlServer

        Try
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "select * from Adic.Cliente where rutCliente = @rut"
                Cn.AgregarParametro("@rut", SqlDbType.Int, 0, IdRut(RutCliente))
                Using Rs As DataTableReader = Cn.getData().CreateDataReader
                    If Rs.Read() Then
                        Dim R As New dtCliente
                        R.IdCliente = Rs("rutCliente")
                        R.RazonSocial = Rs("razonSocial")
                        R.Giro = Rs("giro")
                        R.Direccion = Rs("direccion")
                        R.Comuna = Rs("comuna")
                        R.Ciudad = Rs("ciudad")
                        Return R
                    Else
                        Dim R As New dtCliente
                        Return R
                    End If
                End Using
            Else
                Throw New System.Exception(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try
    End Function

    Public Function GuardarCliente(rut As String, razonSocial As String, giro As String, direccion As String, comuna As String, ciudad As String)
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If rut.Trim.Length = 0 Or razonSocial.Trim.Length = 0 Or giro.Trim.Length = 0 Or direccion.Trim.Length = 0 Or comuna.Trim.Length = 0 Or ciudad.Trim.Length = 0 Then Err(Mensajes.Errores.DatosRequeridos)
            If Cn.conectarServidorSQLServer Then
                If ClienteExiste(IdRut(rut)) Then
                    'update
                    Cn.SentenciaSQL = "update Adic.Cliente set razonSocial = @razonSocial, direccion = @direccion, comuna = @comuna, ciudad = @ciudad, giro = @giro where rutCliente = @rut"

                    Cn.AgregarParametro("@razonSocial", SqlDbType.VarChar, razonSocial.Length, razonSocial.ToUpper)
                    Cn.AgregarParametro("@direccion", SqlDbType.VarChar, direccion.Length, direccion.ToUpper)
                    Cn.AgregarParametro("@comuna", SqlDbType.VarChar, comuna.Length, comuna.ToUpper)
                    Cn.AgregarParametro("@ciudad", SqlDbType.VarChar, ciudad.Length, ciudad.ToUpper)
                    Cn.AgregarParametro("@giro", SqlDbType.VarChar, giro.Length, giro.ToUpper)
                    Cn.AgregarParametro("@rut", SqlDbType.Int, 0, IdRut(rut))
                Else
                    'insert
                    Cn.SentenciaSQL = "insert into Adic.Cliente values (@rut, @razonSocial, @direccion, @comuna, @ciudad, @giro)"
                    Cn.AgregarParametro("@rut", SqlDbType.Int, 0, IdRut(rut))
                    Cn.AgregarParametro("@razonSocial", SqlDbType.VarChar, razonSocial.Length, razonSocial.ToUpper)
                    Cn.AgregarParametro("@direccion", SqlDbType.VarChar, direccion.Length, direccion.ToUpper)
                    Cn.AgregarParametro("@comuna", SqlDbType.VarChar, comuna.Length, comuna.ToUpper)
                    Cn.AgregarParametro("@ciudad", SqlDbType.VarChar, ciudad.Length, ciudad.ToUpper)
                    Cn.AgregarParametro("@giro", SqlDbType.VarChar, giro.Length, giro.ToUpper)
                End If

                Cn.setDatos()
                If Cn.Count > 0 Then Return True
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
            Return False
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try
    End Function

#Region "Precio"
    Public Shared Function Precio(idCliente As Integer) As Integer
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "select * from Adic.PrecioCliente where rutCliente = @rut and fechaCrea = (select max(fechaCrea) from Adic.PrecioCliente where rutCliente = @rut)"
                Cn.AgregarParametro("@rut", SqlDbType.Int, 0, idCliente)
                Using Rs As DataTableReader = Cn.getData().CreateDataReader
                    If Rs.Read() Then
                        Dim days As Long = DateDiff(DateInterval.Day, Now(), Rs("fechaCrea"))
                        Return Rs("PrecioPublico")
                    Else
                        Return 0
                    End If

                End Using
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
            Return False
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try

    End Function
    Public Shared Sub GuardarPrecio(idCliente As Integer, ByVal Precio As Integer)
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If Precio = 0 Then Exit Sub
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "insert into Adic.PrecioCliente values (@rut, GETDATE(), @PrecioPublico)"
                Cn.AgregarParametro("@rut", SqlDbType.Int, 0, idCliente)
                Cn.AgregarParametro("@PrecioPublico", SqlDbType.Int, 0, Precio)
                Cn.setDatos()
            Else
                Throw New System.Exception(Mensajes.Errores.BaseDatosInaxesible)
            End If

        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try

    End Sub
#End Region
    Public Sub GuardarFacturaEmitida(DTE As ChileSystems.DTE.Engine.Documento.DTE, TrackId As String, MontoIE As Integer, PreioPublico As Integer, IEComBase As Double, IEComVar As Double, UTM As Integer, RutaXML As String)
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If Cn.conectarServidorSQLServer Then
                Dim Clie As New clsCliente
                If Not Clie.ClienteExiste(IdRut(DTE.Documento.Encabezado.Receptor.Rut)) Then
                    Clie.GuardarCliente(IdRut(DTE.Documento.Encabezado.Receptor.Rut), DTE.Documento.Encabezado.Receptor.RazonSocial, DTE.Documento.Encabezado.Receptor.Giro, DTE.Documento.Encabezado.Receptor.Direccion, DTE.Documento.Encabezado.Receptor.Comuna, DTE.Documento.Encabezado.Receptor.Ciudad)
                End If
                'Guardo los Datos de la factura (Encabesado)
                Dim tipoDTE As Integer = DTE.Documento.Encabezado.IdentificacionDTE.TipoDTE,
                    folioDTE As Integer = DTE.Documento.Encabezado.IdentificacionDTE.Folio
                Cn.SentenciaSQL = "insert into Adic.DslDTE (tipoDTE, folioDTE, fechaEmision, rutCliente, montoNeto, montoEsp, montoIVA, montoTotal, trackId, patente, precio, IEBase, IEVar, UTM, fechaCrea)
                                                    values (@tipoDTE, @folioDTE, @fechaEmision, @rutCliente, @montoNeto, @montoEsp, @montoIVA, @montoTotal, @trackId, @patente, @precio, @IEBase, @IEVar, @UTM, GETDATE())"
                Cn.AgregarParametro("@tipoDTE", SqlDbType.Int, 0, tipoDTE)
                Cn.AgregarParametro("@folioDTE", SqlDbType.Int, 0, folioDTE)
                Cn.AgregarParametro("@fechaEmision", SqlDbType.Date, 0, Format(DTE.Documento.Encabezado.IdentificacionDTE.FechaEmision, "yyyy-MM-dd HH:mm:ss"))
                Cn.AgregarParametro("@rutCliente", SqlDbType.Int, 0, IdRut(DTE.Documento.Encabezado.Receptor.Rut))
                Cn.AgregarParametro("@montoNeto", SqlDbType.Int, 0, DTE.Documento.Encabezado.Totales.MontoNeto)
                Cn.AgregarParametro("@montoEsp", SqlDbType.Int, 0, MontoIE)
                Cn.AgregarParametro("@montoIVA", SqlDbType.Int, 0, DTE.Documento.Encabezado.Totales.IVA)
                Cn.AgregarParametro("@montoTotal", SqlDbType.Int, 0, DTE.Documento.Encabezado.Totales.MontoTotal)
                Cn.AgregarParametro("@trackId", SqlDbType.VarChar, TrackId.Length, TrackId)
                Dim PTT As String = Patente.ToUpper
                Cn.AgregarParametro("@Patente", SqlDbType.VarChar, PTT.Length, PTT)
                Cn.AgregarParametro("@Precio", SqlDbType.Int, 0, PreioPublico)
                Cn.AgregarParametro("@IEBase", SqlDbType.Float, 0, IEComBase)
                Cn.AgregarParametro("@IEVar", SqlDbType.Float, 0, IEComVar)
                Cn.AgregarParametro("@UTM", SqlDbType.Int, 0, UTM)
                Cn.setDatos()
                Dim C As Integer = 0
                'Guardo los Datos de la factura (Detalles)
                For Each Det As ChileSystems.DTE.Engine.Documento.Detalle In DTE.Documento.Detalles
                    Dim TipoImpAdd As Integer = 0
                    If Not IsNothing(Det.CodigoImpuestoAdicional) Then
                        Select Case Val(Det.CodigoImpuestoAdicional)
                            Case 28 : TipoImpAdd = 28
                            Case Else : TipoImpAdd = 0
                        End Select
                    End If

                    C += 1
                    Cn.SentenciaSQL = "insert into Adic.DslDTEDetalle (tipoDTE, folioDTE, nroLinea, DescripcionProducto, cantidad, precio, undMedida, tipoImpuesto, afecto) 
                                                    values (@tipoDTE, @folioDTE, @nroLinea, @DescripcionProducto, @cantidad, @precio, @undMedida, @tipoImpuesto, @afecto)"
                    Cn.AgregarParametro("@tipoDTE", SqlDbType.Int, 0, tipoDTE)
                    Cn.AgregarParametro("@folioDTE", SqlDbType.Int, 0, folioDTE)
                    Cn.AgregarParametro("@nroLinea", SqlDbType.Int, 0, C)
                    Cn.AgregarParametro("@DescripcionProducto", SqlDbType.VarChar, Det.Nombre.Length, Det.Nombre)
                    Cn.AgregarParametro("@cantidad", SqlDbType.Float, 0, Det.Cantidad)
                    Cn.AgregarParametro("@precio", SqlDbType.Float, 0, Det.Precio)
                    Cn.AgregarParametro("@undMedida", SqlDbType.VarChar, Det.UnidadMedida.Length, Det.UnidadMedida)
                    Cn.AgregarParametro("@tipoImpuesto", SqlDbType.Int, 0, TipoImpAdd) 'Det.CodigoImpuestoAdicional.ToString)
                    Cn.AgregarParametro("@afecto", SqlDbType.Bit, 0, IIf(Det.ShouldSerializeIndicadorExento = False, True, False))
                    Cn.setDatos()
                Next
                GuardarXmlEnBaseDatos(tipoDTE, folioDTE, RutaXML)
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try
    End Sub

    Public Sub ListarClientes(ByRef cmb As ComboBox)
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "select rutCliente, razonSocial from DslCliente order by razonSocial"
                cmb.DataSource = Cn.getData()
                cmb.DisplayMember = "razonSocial"
                cmb.ValueMember = "rutCliente"
                cmb.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GuardarTrackID(ByVal TipoDTE As Integer, ByVal FolioDTE As Integer, ByVal TrackID As String)
        Dim Cn As New dllFunciones.cnxSqlServer
        Try
            If Cn.conectarServidorSQLServer Then
                Cn.SentenciaSQL = "update Adic.DslDTE set trackId = @trackId where tipoDTE = @tipoDTE and folioDTE = @folioDTE"
                Cn.AgregarParametro("@trackId", SqlDbType.VarChar, TrackID.Trim.Length, TrackID.Trim)
                Cn.AgregarParametro("@tipoDTE", SqlDbType.Int, 0, TipoDTE)
                Cn.AgregarParametro("@folioDTE", SqlDbType.Int, 0, FolioDTE)
                Dim R As Integer = Cn.setDatos()
                If R = 0 Then
                    Dim Msg As String = Mensajes.Errores.NoGuardo & vbNewLine &
                                        Mensajes.Advertencias.ContactarAdministradorSistema & vbNewLine & vbNewLine &
                                        "Tipo DTE: " & TipoDTE & vbNewLine &
                                        "Folio DTE: " & FolioDTE & vbNewLine &
                                        "Track ID: " & TrackID & vbNewLine
                    MsgBox(Msg, MsgBoxStyle.Exclamation)
                End If
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function GuardarXmlEnBaseDatos(tipoDTE As Integer, folioDTE As Integer, RutaArchivo As String) As Boolean
        Try
            ' Leer el archivo binario especificado en el control TextBox.
            '
            'Dim blob As Byte() = ReadBinaryFile(RutaArchivo)
            Dim archivoXML As Byte() = ReadBinaryFile(RutaArchivo)

            ' Establecemos una conexión para conectarnos
            ' a la base de datos de SQL Server, utilizando
            ' la seguridad integrada de Windows NT.
            '
            'Using cnn As New SqlConnection("Data Source=(local);" &
            '                               "Initial Catalog=NombreBaseSQLServer;" &
            '                               "Integrated Security=SSPI")
            Dim Servidor As String = dllFunciones.cnxSqlServer.HostServidor ' sServidor
            Dim Usuario As String = dllFunciones.cnxSqlServer.UsuarioBD  ' = sUsuario
            Dim Clave As String = dllFunciones.cnxSqlServer.ClaveUsuario  ' = sClave
            Dim BaseDatos As String = dllFunciones.cnxSqlServer.NombreBaseDatos  ' = sBaseDatos

            Using cnn As New SqlConnection("Persist Security Info=False;" &
                                            "data source=" & Servidor & ";" &
                                            "Initial Catalog=" & BaseDatos & ";" &
                                            "User Id=" & Usuario & ";" &
                                            "Password=" & Clave & ";")
                'conexion.ConnectionString =
                '    "Persist Security Info=False;" &
                '    "data source=" & Servidor & ";" &
                '    "Initial Catalog=" & BaseDatos & ";" &
                '    "User Id=" & Usuario & ";" &
                '    "Password=" & Clave & ";"

                Dim cmd As SqlCommand = cnn.CreateCommand()

                ' Crear la consulta T-SQL para insertar un nuevo registro.
                '
                cmd.CommandText = "INSERT INTO Adic.DslDTEXml (tipoDTE, folioDTE, archivoXml) VALUES (@tipoDTE, @folioDTE, @archivoXML)"

                ' Añadir el único parámetro de entrada existente.
                '
                cmd.Parameters.AddWithValue("@tipoDTE", tipoDTE)
                cmd.Parameters.AddWithValue("@folioDTE", folioDTE)

                ' La función ReadBinaryFile tal cual se encuentra implementada no devolverá un valor Nothing,
                ' pero muestro cómo especificar un valor NULL al parámetro de entrada si el valor del campo
                ' binario fuese Nothing. Para insertar un valor NULL, el campo de la tabla lo tiene que permitir.
                '
                cmd.Parameters.AddWithValue("@archivoXML", If(archivoXML IsNot Nothing, archivoXML, CObj(DBNull.Value)))

                cnn.Open()

                Dim n As Integer = cmd.ExecuteNonQuery()

                If (n > 0) Then
                    'MessageBox.Show("Se ha grabado el documento satisfactoriamente.")
                    Return True
                Else
                    'MessageBox.Show("No se ha guardado ningún documento.")
                    Return False
                End If

            End Using
            Return False
        Catch ex As Exception
            ' Se ha producido un error.
            Err(ex.Message)
        End Try
    End Function
End Class
