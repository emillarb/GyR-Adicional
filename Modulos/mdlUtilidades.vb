Module mdlUtilidades
    Public Structure tdFolio
        Dim Patente As String
        Dim TipoDTE As Integer
        Dim FechaCaf As Date
        Dim fecha As DateTime
        Dim rDesde As Integer
        Dim rHasta As Integer
    End Structure
    Public Structure tdArchivosDTE_PDF
        Dim Folio As Integer
        Dim TipoDTE As String
        Dim Archivo As String
    End Structure
    Public Class VisualizarDTE
        Public Property TipoDTE As Integer
        Public Property FolioDTE As Integer
        Public Property FechaEmision As Date
        Public Property RznSocial As String
        Public Property Litros As Integer
        Public Property Neto As Integer
        Public Property IVA As Integer
        Public Property Especifico As Integer
        Public Property Total As Integer
        Public ReadOnly Property StrTipoDocumento As String
            Get
                Return TipoDocumento(TipoDTE)
            End Get
        End Property
    End Class

    Public ReadOnly Property Patente As String
        Get
            Return Stic.Config.LeerParametroLocal("Patente")
        End Get
        'Get
        '    Dim Cn As New dllFunciones.cnxAccess
        '    Try
        '        If Cn.ConectarAccess Then
        '            Cn.SentenciaSQL = "SELECT patente from dslCamion"
        '            Using Rs As DataTableReader = Cn.GetDatos().CreateDataReader
        '                If Rs.Read() Then
        '                    Return Rs(0)
        '                Else
        '                    Err(Mensajes.Errores.SinDatosParaMostrar)
        '                End If
        '            End Using
        '        Else
        '            Err(Mensajes.Errores.BaseDatosInaxesible)
        '        End If
        '    Catch ex As Exception
        '        Throw
        '    Finally
        '        Cn.Desconectar()
        '    End Try
        'End Get
    End Property
    Public ReadOnly Property FolioMinimoGuia As Integer
        Get
            Try
                Return RangosDTEs(52, True)
            Catch ex As Exception
                Throw
            End Try
        End Get
    End Property
    Public ReadOnly Property FolioMaximoGuia As Integer
        Get
            Try
                Return RangosDTEs(52)
            Catch ex As Exception
                Throw
            End Try
        End Get
    End Property
    Public ReadOnly Property FolioMinimoFactura As Integer
        Get
            Try
                Return RangosDTEs(33, True)
            Catch ex As Exception
                Throw
            End Try
        End Get
    End Property
    Public ReadOnly Property FolioMaximoFactura As Integer
        Get
            Try
                Return RangosDTEs(33)
            Catch ex As Exception
                Throw
            End Try
        End Get
    End Property

    Private Function RangosDTEs(ByVal TipoDTE As Integer, Optional ByVal Minimo As Boolean = False)
        Dim Cn As New dllFunciones.cnxAccess
        Try 'rangoDesde rangoHasta
            If Cn.ConectarAccess Then
                Dim Min As Integer = 0, Max As Integer = 0
                Cn.SentenciaSQL = "SELECT rangoDesde, rangoHasta from ConsumoFolio where cafTipoDte = @TipoDte and fecha = (select max(fecha) from ConsumoFolio where cafTipoDte = @TipoDte)"
                Cn.AgregarParametro("@TipoDte", OleDb.OleDbType.Integer, 0, TipoDTE)
                Using Rs As DataTableReader = Cn.GetDatos().CreateDataReader
                    If Rs.Read() Then
                        Min = Rs("rangoDesde")
                        Max = Rs("rangoHasta")
                    Else
                        Err(Mensajes.Errores.SinDatosParaMostrar)
                    End If
                End Using
                If Minimo Then
                    Return Min
                Else
                    Return Max
                End If
            Else
                Err(Mensajes.Errores.BaseDatosInaxesible)
            End If
        Catch ex As Exception
            Throw
        Finally
            Cn.Desconectar()
        End Try
    End Function
    Public Function CalculaIE(UTM As Integer, CompIE As Double)
        Try
            Return (UTM * CompIE) / 1000
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function MontoIE(ByVal Litros As Double, ByVal IEComBase As Double, ByVal IEComVar As Double, ByVal UTM As Integer) As Integer
        Try
            Dim IEBase As Double = CalculaIE(UTM, IEComBase)
            Dim IEVar As Double = CalculaIE(UTM, IEComVar)
            Dim R As Double = Litros * (IEBase + IEVar)
            Return R
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function PrecioNeto(ByVal Precio As Integer, ByVal IEComBase As Double, ByVal IEComVar As Double, ByVal UTM As Integer) As Double
        Try
            Dim IEBase As Double = CalculaIE(UTM, IEComBase)
            Dim IEVar As Double = CalculaIE(UTM, IEComVar)
            Dim R As Double = dllFunciones.Erik.Redondear((Precio - (IEBase + IEVar)) / 1.19, 0) ' este Iva deberia estar en la base de datos, se mostrara sin decimales
            Return IIf(R < 0, 0, R)
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function IdRut(rutConDigitoVerificador As String) As Integer
        Try
            Dim Rut As String = rutConDigitoVerificador.Replace(".", "")
            Rut = Rut.Replace(",", "")
            Rut = Rut.Replace("-", "")
            'Dim sss As String = Rut.Substring(0, Rut.Length - 1)
            Return Rut.Substring(0, Rut.Length - 1)
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function DiferenciaListros(DifMiter As Integer, Litros As Integer) As Boolean
        Try
            If DifMiter = 0 Then Err("")
            Dim R As Boolean = False
            Dim _10PorCientoLitros As Integer = Litros * 0.1
            Dim Dif As Integer = Litros - DifMiter
            If Dif > _10PorCientoLitros Then
                If MsgBox(Mensajes.Advertencias.DifLitros & Mensajes.Preguntas.deseaCorregir, MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, App.Nombre) = MsgBoxResult.Yes Then
                    R = True
                End If
            End If
            Return R
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub Imprimir(RutaArchivoPDF As String, Optional ByVal Impresora As String = "")
        'Dim Imp As String = IIf(Impresora.Trim.Length = 0, dllFunciones.clsConfJson.Valors("Impresora"), Impresora)
        'Using p As New Process

        '    p.StartInfo.FileName = RutaArchivoPDF
        '    p.StartInfo.Verb = "PrintTo"
        '    'p.StartInfo.Arguments = Chr(34) & Imp & Chr(34)
        '    p.StartInfo.CreateNoWindow = True
        '    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        '    p.Start()
        '    p.WaitForExit(2000)
        '    p.CloseMainWindow()
        '    p.Kill()
        '    p.Close()

        'End Using
        Try
            Dim printPDF As New Process
            Dim objProcess = New System.Diagnostics.Process
            With printPDF
                .StartInfo.FileName = RutaArchivoPDF 'dllFunciones.Erik.DialogoAbrir("Seleccionar ARchivo PDF")
                .StartInfo.Verb = "PrintTo"
                .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                .StartInfo.CreateNoWindow = True
                .Start()
                .WaitForExit(3000)
                .CloseMainWindow()
                .Kill()
                .Close()
            End With
            objProcess = printPDF
            Try
                objProcess.Kill()  'Cerramos el pdf.
            Catch ex As Exception

            End Try
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Err(ByVal Msg As String, Optional ByVal Mostrar As Boolean = False)
        Try
            If Mostrar Then
                MsgBox(Msg, MsgBoxStyle.Critical, App.Nombre)
            Else
                Throw New System.Exception(Msg)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERR: " & App.Nombre)
        End Try

    End Sub

    Public Function TipoDocumento(Tp As Integer) As String
        Try
            Dim TpDocumento As String = ""
            Select Case Tp
                Case 33 : TpDocumento = "FACTURA ELECTROICA"
                Case 56 : TpDocumento = "NOTA DE DEBITO ELECTROICA"
                Case 61 : TpDocumento = "NOTA DE CREDITO ELECTROICA"
                Case 52 : TpDocumento = "GUIA DESPACHO ELECTROICA"
                Case Else : Err(Mensajes.Errores.TipoDTENoSoportado)
            End Select
            Return TpDocumento
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function TipoDocumento(Tp As String) As Integer
        Try
            Dim TpDocumento As Integer = 0
            Select Case Tp
                Case "FACTURA ELECTRONICA" : TpDocumento = 33
                Case "NOTA DE DEBITO ELECTRONICA" : TpDocumento = 56
                Case "NOTA DE CREDITO ELECTRONICA" : TpDocumento = 61
                Case "GUIA DESPACHO ELECTRONICA" : TpDocumento = 52
                Case Else : Err(Mensajes.Errores.TipoDTENoSoportado)
            End Select
            Return TpDocumento
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function TipoDocumentoFile(Tp As String) As Integer
        Try
            Tp = Tp.ToUpper
            Dim TpDocumento As Integer = 0
            Select Case Tp
                Case "FacturaElectronica".ToUpper : TpDocumento = 33
                Case "NotaDebitoElectronica".ToUpper : TpDocumento = 56
                Case "NotaCreditoElectronica".ToUpper : TpDocumento = 61
                Case "GuiaDespachoElectronica".ToUpper : TpDocumento = 52
                Case Else : Err(Mensajes.Errores.TipoDTENoSoportado)
            End Select
            Return TpDocumento
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function DTEs() As DataTable
        Try
            Dim Td As New DataTable
            Dim Columna As New DataColumn
            Dim Fila As DataRow
            Dim idDte As Integer = 0

            Columna.DataType = System.Type.GetType("System.Int32")
            Columna.ColumnName = "id"
            Td.Columns.Add(Columna)

            Columna = New DataColumn
            Columna.DataType = System.Type.GetType("System.String")
            Columna.ColumnName = "DTE"
            Td.Columns.Add(Columna)


            idDte = 52
            Fila = Td.NewRow
            Fila("id") = idDte
            Fila("DTE") = TipoDocumento(idDte)
            Td.Rows.Add(Fila)

            idDte = 33
            Fila = Td.NewRow
            Fila("id") = idDte
            Fila("DTE") = TipoDocumento(idDte)
            Td.Rows.Add(Fila)

            'idDte = 61
            'Fila = Td.NewRow
            'Fila("id") = idDte
            'Fila("DTE") = TipoDocumento(idDte)
            'Td.Rows.Add(Fila)

            'idDte = 56
            'Fila = Td.NewRow
            'Fila("id") = idDte
            'Fila("DTE") = TipoDocumento(idDte)
            'Td.Rows.Add(Fila)

            Return Td

        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "GuardarDatosSQL"
    ''' <summary>
    ''' Devuelve una matriz de bytes con los datos del archivo especificado.
    ''' </summary>
    ''' <param name="fileName">Ruta completa del archivo que se desea leer.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function ReadBinaryFile(ByVal fileName As String) As Byte()

        ' Generar una excepción si no existe el archivo.
        '
        If (Not IO.File.Exists(fileName)) Then
            Throw New IO.FileNotFoundException("No existe el archivo especificado.")
        End If

        ' Leer el archivo especificado devolviendo una matriz de bytes con su contenido.
        '
        Return IO.File.ReadAllBytes(fileName)

    End Function
    ''' <summary>
    ''' Crea un archivo con la secuencia de bytes especificada.
    ''' </summary>
    ''' <param name="fileName">Ruta completa del archivo de destino.</param>
    ''' <param name="data">Matriz de bytes con los que se desea crear el archivo.</param>
    ''' <remarks></remarks>
    Friend Sub WriteBinaryFile(ByVal fileName As String, ByVal data As Byte())

        ' Comprobación de los valores de los parámetros.
        '
        If (String.IsNullOrEmpty(fileName)) Then _
        Throw New ArgumentException("No se ha especificado el archivo de destino.", "fileName")

        If (data Is Nothing) Then _
        Throw New ArgumentException("Los datos no son válidos para crear un archivo.", "data")

        ' Crear el archivo. Se producirá una excepción si ya existe
        ' un archivo con el mismo nombre.
        Using fs As New IO.FileStream(fileName, IO.FileMode.CreateNew, IO.FileAccess.Write)

            ' Crea el escritor para la secuencia.
            Dim bw As New IO.BinaryWriter(fs)

            ' Escribir los datos en la secuencia.
            bw.Write(data)

        End Using

    End Sub
#End Region
End Module
