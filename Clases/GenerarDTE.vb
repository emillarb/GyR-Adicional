Imports System.IO
Imports System.Text
Public Class GenerarDTE
    Public Class MensajesFE
        Public Structure Correctos
            Public Const TodoOK As String = "Termino Correctamente"
        End Structure
        Public Structure Errores
            Public Const sinFoliosDisponibles As String = "NO HAY UN CÓDIGO DE AUTORIZACIÓN DE FOLIOS (CAF) ASIGNADO PARA ESTE TIPO DE DOCUMENTO (|tipoDTE|) QUE INCLUYA EL FOLIO REQUERIDO (|Folio|)."
            Public Const ErrFirmaEnvio As String = "NO SE HA PODIDO VERIFICAR LA FIRMA DEL ENVÍO"
        End Structure
    End Class
#Region "Declaraciones"
    Private _nroCasoPrueba As String = ""
    Private _Folio As Int64 = 0
    Private _TipoDTE As ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica
    Private _FechaEmision As DateTime = Now
    Private _IdDTE As String = Empresa.AbrevEmpresa & TipoDTE & Folio & Format(FechaEmision, "yyyyMMddHHmmss")


    Private _RespEnvioDTE As ChileSystems.DTE.WS.EnvioDTE.EnvioDTEResult

    Private _ReceptorRut As String = "66666666-6"
    Private _ReceptorRazonSocial As String = "Razon Social de Cliente"
    Private _ReceptorDireccion As String = "Dirección de cliente"
    Private _ReceptorComuna As String = "Comuna de cliente"
    Private _ReceptorCiudad As String = "Ciudad de cliente"
    Private _ReceptorGiro As String = "Giro de cliente"
    Private _Items As New List(Of Millar.Stic.ItemDTE)
    Private _LstReferencias As New List(Of ChileSystems.DTE.Engine.Documento.Referencia)
    Private _dte = New ChileSystems.DTE.Engine.Documento.DTE()
    Private _path As String = ""
    Private _formaPago As Integer = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.Contado

    Private _MontoIEDiesel As Double = 0
    Private _IEBase As Double = 0
    Private _IEVar As Double = 0
#End Region
#Region "Propiedades"
    Public Property PrecioPublico As Integer
    Public Property IEComBase As Double
    Public Property IEComVariable As Double
    Public Property UTM As Integer
    Public Property OdoMiterMin As Integer
    Public Property OdoMiterMax As Integer

    Public Property FormaPago As Integer
        Get
            Return _formaPago
        End Get
        Set(value As Integer)
            _formaPago = value
        End Set
    End Property
    Public Property MontoIEDiesel As Double
        Get
            Return _MontoIEDiesel
        End Get
        Set(value As Double)
            _MontoIEDiesel = value
        End Set
    End Property
    Public Property NroCasoPrueba As String
        Get
            Return _nroCasoPrueba
        End Get
        Set(value As String)
            _nroCasoPrueba = value
        End Set
    End Property
    Public Property Folio As Int64
        Get
            Return _Folio
        End Get
        Set(value As Int64)
            _Folio = value
        End Set
    End Property
    Public Property TipoDTE As ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType
        Get
            Return _TipoDTE
        End Get
        Set(value As ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType)
            _TipoDTE = value
        End Set
    End Property
    Public Property FechaEmision As DateTime
        Get
            Return _FechaEmision
        End Get
        Set(value As DateTime)
            _FechaEmision = value
        End Set
    End Property
    Public Property IdDTE As String
        Get
            _IdDTE = Empresa.AbrevEmpresa & TipoDTE & Folio & Format(FechaEmision, "yyyyMMddHHmmss")
            Return _IdDTE
        End Get
        Set(value As String)
            _IdDTE = value
        End Set
    End Property
    Public ReadOnly Property RespuestaEnvioDTE As ChileSystems.DTE.WS.EnvioDTE.EnvioDTEResult
        Get
            Return _RespEnvioDTE
        End Get
    End Property
    Public Property ReceptorRut As String
        Get
            Return _ReceptorRut
        End Get
        Set(value As String)
            _ReceptorRut = value
        End Set
    End Property
    Public Property ReceptorRazonSocial As String
        Get
            Return _ReceptorRazonSocial
        End Get
        Set(value As String)
            _ReceptorRazonSocial = value
        End Set
    End Property
    Public Property ReceptorDireccion As String
        Get
            Return _ReceptorDireccion
        End Get
        Set(value As String)
            _ReceptorDireccion = value
        End Set
    End Property
    Public Property ReceptorComuna As String
        Get
            Return _ReceptorComuna
        End Get
        Set(value As String)
            _ReceptorComuna = value
        End Set
    End Property
    Public Property ReceptorCiudad As String
        Get
            Return _ReceptorCiudad
        End Get
        Set(value As String)
            _ReceptorCiudad = value
        End Set
    End Property
    Public Property ReceptorGiro As String
        Get
            Return _ReceptorGiro
        End Get
        Set(value As String)
            _ReceptorGiro = value
        End Set
    End Property
    Public ReadOnly Property PathDte As String
        Get
            Return _path
        End Get
    End Property
    Public ReadOnly Property MontoNeto As Integer
        Get
            'Dim _dte = New ChileSystems.DTE.Engine.Documento.DTE()
            Return _dte.Documento.Encabezado.Totales.MontoNeto
        End Get
    End Property
    Public ReadOnly Property MontoIVA As Integer
        Get
            'Dim _dte = New ChileSystems.DTE.Engine.Documento.DTE()
            Return _dte.Documento.Encabezado.Totales.IVA
        End Get
    End Property
    Public ReadOnly Property MontoTotal As Integer
        Get
            'Dim _dte = New ChileSystems.DTE.Engine.Documento.DTE()
            Return _dte.Documento.Encabezado.Totales.MontoTotal
        End Get
    End Property
    Public Property IEBase As Double
        Get
            Return _IEBase
        End Get
        Set(value As Double)
            _IEBase = value
        End Set
    End Property
    Public Property IEVariable As Double
        Get
            Return _IEVar
        End Get
        Set(value As Double)
            _IEVar = value
        End Set
    End Property
#End Region
#Region "Item DTE"
#Region "Propiedades"
    Public Property Items As Millar.Stic.ItemDTE
        Get
            Return _Items.Last
        End Get
        Set(value As Millar.Stic.ItemDTE)
            _Items.Add(value)
        End Set
    End Property
    Public ReadOnly Property CantidadItems As Integer
        Get
            Return _Items.Count
        End Get
    End Property
    Public ReadOnly Property ListaItems As List(Of Millar.Stic.ItemDTE)
        Get
            Return _Items
        End Get
    End Property
    Public ReadOnly Property TieneItems As Boolean
        Get
            If _Items.Count = 0 Then Return False Else Return True
        End Get
    End Property
#End Region
#Region "Metodos"
    Public Sub AddItemDTE(ByVal item As Millar.Stic.ItemDTE)
        _Items.Add(item)
    End Sub
    Public Sub RemoverItemDTE(ByVal item As Millar.Stic.ItemDTE)
        _Items.Remove(item)
    End Sub
    Public Sub LimpiarItemDTE()
        _Items.Clear()
    End Sub
#End Region
#End Region
#Region "Referencias"
#Region "Propiedades"
    Public ReadOnly Property CountReferencia As Integer
        Get
            Return _LstReferencias.Count
        End Get
    End Property
    Public Property Referencia As ChileSystems.DTE.Engine.Documento.Referencia
        Get
            Return _LstReferencias.Last
        End Get
        Set(value As ChileSystems.DTE.Engine.Documento.Referencia)
            _LstReferencias.Add(value)
        End Set
    End Property
    Public ReadOnly Property ListaReferencias As List(Of ChileSystems.DTE.Engine.Documento.Referencia)
        Get
            Return _LstReferencias
        End Get
    End Property
    Public ReadOnly Property UsaReferencia As Boolean
        Get
            If _LstReferencias.Count = 0 Then Return False Else Return True
        End Get
    End Property
#End Region
#Region "Metodos Referencias"
    Public Sub AddReferencia(ByVal R As ChileSystems.DTE.Engine.Documento.Referencia)
        _LstReferencias.Add(R)
    End Sub
    Public Sub RemoverReferencia(ByVal R As ChileSystems.DTE.Engine.Documento.Referencia)
        _LstReferencias.Remove(R)
    End Sub
    Public Sub LimpiarReferencias()
        _LstReferencias.Clear()
    End Sub
    Public Sub AddCasoPrueba()
        Dim Ref As New ChileSystems.DTE.Engine.Documento.Referencia()
        Ref.CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet
        Ref.FechaDocumentoReferencia = FechaEmision
        Ref.FolioReferencia = Folio.ToString()
        Ref.IndicadorGlobal = 0
        Ref.Numero = CountReferencia + 1
        Ref.RazonReferencia = NroCasoPrueba
        Ref.TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.SetPruebas
        AddReferencia(Ref)
    End Sub
#End Region
#End Region
#Region "Metodos"
    Public Sub New()
        _dte = New ChileSystems.DTE.Engine.Documento.DTE()
    End Sub
    Public Function GenerarDTE() As String
        Try
#Region "GenerateDTE"
            '// DOCUMENTO

            '//
            '// DOCUMENTO - ENCABEZADO - CAMPO OBLIGATORIO
            '//Id = puede ser compuesto según tus propios requerimientos pero debe ser único         
            _dte.Documento.Id = IdDTE

            '// DOCUMENTO - ENCABEZADO - IDENTIFICADOR DEL DOCUMENTO - CAMPOS OBLIGATORIOS
            '//TipoDTE = Se indica el tipo de documento. Este SDK soporta
            _dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = TipoDTE
            _dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = FechaEmision
            _dte.Documento.Encabezado.IdentificacionDTE.Folio = Folio
            '//Para boletas electrónicas
            If TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica Then
                _dte.Documento.Encabezado.IdentificacionDTE.IndicadorServicio = ChileSystems.DTE.Engine.Enum.IndicadorServicio.IndicadorServicioEnum.BoletaVentasYServicios
                _dte.Documento.Encabezado.Emisor.RazonSocialBoleta = Empresa.BoletaRazonSocial ' "TRANSPORTE DISTRIBUCION Y COMERCIALIZACION DE PRODUCTOS D&V LIMITADA";
                _dte.Documento.Encabezado.Emisor.GiroBoleta = Empresa.BoletaGiro ' "VENTA AL POR MAYOR DE CONFITES";
            End If


            '//DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            _dte.Documento.Encabezado.Emisor.Rut = Empresa.RutEmpresa
            _dte.Documento.Encabezado.Emisor.RazonSocial = Empresa.RazonSocial
            _dte.Documento.Encabezado.Emisor.Giro = Empresa.Giro
            _dte.Documento.Encabezado.Emisor.DireccionOrigen = Empresa.Direccion
            _dte.Documento.Encabezado.Emisor.ComunaOrigen = Empresa.Comuna

            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = FormaPago

            '//dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(107300);
            '//dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(463020);
            _dte.Documento.Encabezado.Emisor.ActividadEconomica = Empresa.CodigosActividades

            '//DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

            _dte.Documento.Encabezado.Receptor.Rut = ReceptorRut
            _dte.Documento.Encabezado.Receptor.RazonSocial = ReceptorRazonSocial
            _dte.Documento.Encabezado.Receptor.Direccion = ReceptorDireccion
            _dte.Documento.Encabezado.Receptor.Comuna = ReceptorComuna
            _dte.Documento.Encabezado.Receptor.Ciudad = ReceptorCiudad
            _dte.Documento.Encabezado.Receptor.Giro = ReceptorGiro
#End Region
            '#Region "Recargos"
            '            'Dim _dte As New ChileSystems.DTE.Engine.Documento.DTE()
            '            _dte.Documento.DescuentosRecargos = New List(Of ChileSystems.DTE.Engine.Documento.DescuentosRecargos)
            '            Dim Recargos As New ChileSystems.DTE.Engine.Documento.DescuentosRecargos()
            '            Recargos.Descripcion = "Impuesto Espesifico"
            '            Recargos.Numero = 1
            '            Recargos.TipoMovimiento = ChileSystems.DTE.Engine.Enum.TipoMovimiento.TipoMovimientoEnum.Recargo
            '            Recargos.TipoValor = ChileSystems.DTE.Engine.Enum.ExpresionDinero.ExpresionDineroEnum.Pesos
            '            Recargos.Valor = MontoIEDiesel
            '            _dte.Documento.DescuentosRecargos.Add(Recargos)
            '#End Region
#Region "GenerateDetails"
            '//DOCUMENTO - DETALLES
            _dte.Documento.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.Detalle)


            Dim NroItem As Integer = 0
            For Each Prod As Millar.Stic.ItemDTE In ListaItems
                Dim detalle = New ChileSystems.DTE.Engine.Documento.Detalle()
                NroItem += 1
                detalle.NumeroLinea = NroItem
                If Not Prod.Afecto Then detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento
                detalle.Nombre = Prod.Nombre
                detalle.Descripcion = Prod.Descripcion
                detalle.Cantidad = Prod.Cantidad
                detalle.Precio = Prod.Precio
                detalle.Descuento = Prod.Descuento
                detalle.MontoItem = Prod.Total - Prod.Descuento
                detalle.UnidadMedida = Prod.UnidadMedida
                _dte.Documento.Detalles.Add(detalle)
            Next

            '//DOCUMENTO - ENCABEZADO - TOTALES - CAMPOS OBLIGATORIOS
            'Millar.Stic.Documento.calculosTotales(_dte)
            Millar.Stic.Documento.calculosTotales(_dte, MontoIEDiesel)

#End Region
#Region "Impuestos Especifico Diesel"
            If Not MontoIEDiesel = 0 Then
                _dte.Documento.Encabezado.Totales.ImpuestosRetenciones = New List(Of ChileSystems.DTE.Engine.Documento.ImpuestosRetenciones)
                Dim IEDiesel As New ChileSystems.DTE.Engine.Documento.ImpuestosRetenciones
                IEDiesel.MontoImpuesto = MontoIEDiesel
                IEDiesel.TasaImpuesto = (MontoIEDiesel / _dte.Documento.Encabezado.Totales.MontoTotal)
                IEDiesel.TipoImpuesto = ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.ImpuestoEspecificoDiesel
                _dte.Documento.Encabezado.Totales.ImpuestosRetenciones.Add(IEDiesel)

            End If
#End Region

#Region "Referencias"
            If UsaReferencia Then
                _dte.Documento.Referencias = ListaReferencias
            End If
#End Region
#Region "TimbrarYFirmarXMLDTE"
            _path = TimbrarYFirmarXMLDTE(_dte, Directorio.Temporal, Directorio.CAF)
#End Region
#Region "Validate"
            If Millar.Stic.Documento.ValidateXML(_path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE) Then
                Dim Archivo As String() = _path.Split("\")
                Dim Destino As String = Directorio.DTE & "" & Archivo(Archivo.Length - 1)
                Dim Pendiente As String = Directorio.EnviosSIIPendiente & "" & Archivo(Archivo.Length - 1)
                File.Copy(_path, Destino, True)
                File.Copy(_path, Pendiente, True)
                File.Delete(_path)
                _path = Destino
            End If
#End Region
#Region "Generar Sobre de Envio"
            '==========================================================================================
            '==========================================================================================
            '=============                      I M P O R T A N T E                       =============
            '==========================================================================================
            '==========================================================================================
            ' este programa no necesita enviar los documentos al momento de generarlos, ya que se 
            ' encuentra en terreno done no tiene cobertura de internet
            '==========================================================================================
            '==========================================================================================
            If TipoDTE <> ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica Then
                Threading.Thread.Sleep(1000)
                Dim PathXML As String() = {"" & _path & ""}
                _RespEnvioDTE = EnviarAlSII(PathXML, "DTE_" & IdDTE)
            ElseIf TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica And Not Empresa.AmbienteProduccion Then
                Dim PathXML As String() = {"" & _path & ""}
                Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)
                Dim xmlDtes As List(Of String) = New List(Of String)
                For Each pathFile As String In PathXML
                    Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
                    Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
                    dtes.Add(dte)
                    xmlDtes.Add(xml)
                Next
                Dim EnvioSII = Millar.Stic.Documento.GenerarEnvioBoletaDTEToSII(dtes, xmlDtes, Empresa.SII.FechaResolucion, Empresa.SII.NumeroResolucion, Empresa.RutEmpresa, Empresa.Certificado.RutCertificado, IdDTE, Empresa.SII.SIIRut)
                Dim filePath = EnvioSII.Firmar(Empresa.Certificado.NombreDescriptivo, True, Directorio.Temporal)
                Try
                    Millar.Stic.Documento.ValidateXML(filePath, SIMPLE_SDK.Security.Firma.Firma.TipoXML.EnvioBoleta, ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta)

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If

#End Region

            Dim TrackID As Int64 = 0 'IIf(IsNothing(_RespEnvioDTE), 0, _RespEnvioDTE.TrackId)
            If Not IsNothing(_RespEnvioDTE) Then
                TrackID = _RespEnvioDTE.TrackId

            End If

            Dim Fact As New clsCliente
            Fact.GuardarFacturaEmitida(_dte, TrackID, MontoIEDiesel, PrecioPublico, IEComBase, IEComVariable, UTM, _path)
            'GenerarFacturaPDF_Termica(_path, MontoIEDiesel, IEBase, IEVariable)
            'aqui debo poner el if del track id

            Return _path
        Catch ex As Exception
            Throw
        Finally
            'LimpiarItemDTE()
            'LimpiarReferencias()
        End Try

    End Function
    Public Sub EmitirGuiaTraslado(Folio As Integer)

        Try
            'Dim F1 As Integer = 19, F2 As Integer = 20, F3 As Integer = 21

            'Dim Guias(2) As String




            'Dim CasoPrueba As String = "1286876"
            '==========================================================================================
            '==========================================================================================
            '=============  G u i a     1     d e l     c a s o     d e     p r u e b a s =============
            '==========================================================================================
            '==========================================================================================

            Dim _dte = New ChileSystems.DTE.Engine.Documento.DTE()

            _dte.Documento.Id = Empresa.AbrevEmpresa & Format(Now, "yyyyMMddHHmmss")
            '//DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            _dte.Documento.Encabezado.Emisor.Rut = Empresa.RutEmpresa
            _dte.Documento.Encabezado.Emisor.RazonSocial = Empresa.RazonSocial
            _dte.Documento.Encabezado.Emisor.Giro = Empresa.Giro
            _dte.Documento.Encabezado.Emisor.DireccionOrigen = Empresa.Direccion
            _dte.Documento.Encabezado.Emisor.ComunaOrigen = Empresa.Comuna
            _dte.Documento.Encabezado.Emisor.ActividadEconomica = Empresa.CodigosActividades

            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.SinCosto

            _dte.Documento.Encabezado.IdentificacionDTE.Folio = Folio 'Guia Numero 1
            _dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.GuiaDespachoElectronica 'tipo de DTE
            _dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = Now 'fecha de emision
            _dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OtrosTrasladosNoVenta
            _dte.Documento.Encabezado.IdentificacionDTE.TipoDespacho = ChileSystems.DTE.Engine.Enum.TipoDespacho.TipoDespachoEnum.EmisorACliente

            _dte.Documento.Encabezado.Receptor.Rut = ":76173152-1"
            _dte.Documento.Encabezado.Receptor.RazonSocial = "INVERSIONES ESCORPION LIMITADA"
            _dte.Documento.Encabezado.Receptor.Direccion = "Ruta Q 180 KM 10.2"
            _dte.Documento.Encabezado.Receptor.Comuna = "Los Angeles"
            _dte.Documento.Encabezado.Receptor.Ciudad = "Los Angeles"
            _dte.Documento.Encabezado.Receptor.Giro = "VENTA AL POR MENOR DE COMBUSTIBLE PARA AUTOMOTORES"



            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.NotSet

            '=== ingresgar item ===

            'instancia del detalle 
            _dte.Documento.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.Detalle)
            Dim detalle = New ChileSystems.DTE.Engine.Documento.Detalle()

            'Item 1
            detalle.NumeroLinea = 1
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet
            detalle.Nombre = "Petroleo Diesel"
            detalle.Cantidad = 11000
            _dte.Documento.Detalles.Add(detalle)


            Millar.Stic.Documento.calculosTotales(_dte)

            ''referencia al caso de pruebas
            '_dte.Documento.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)
            'Dim Ref As New ChileSystems.DTE.Engine.Documento.Referencia()
            'Ref.CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet
            'Ref.FechaDocumentoReferencia = DateTime.Now
            'Ref.FolioReferencia = _dte.Documento.Encabezado.IdentificacionDTE.Folio
            'Ref.IndicadorGlobal = 0
            'Ref.Numero = 1
            'Ref.RazonReferencia = "Solo Traslado, No constituye venta"
            'Ref.TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.Obs
            '_dte.Documento.Referencias.Add(Ref)


#Region "TimbrarYFirmarXMLDTE"
            _path = TimbrarYFirmarXMLDTE(_dte, Directorio.Temporal, Directorio.CAF)
#End Region
#Region "Validate"
            If Millar.Stic.Documento.ValidateXML(_path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE) Then
                Dim Archivo As String() = _path.Split("\")
                Dim Destino As String = Directorio.DTE & "" & Archivo(Archivo.Length - 1)
                Dim Pendiente As String = Directorio.EnviosSIIPendiente & "" & Archivo(Archivo.Length - 1)
                File.Copy(_path, Destino, True)
                File.Copy(_path, Pendiente, True)
                File.Delete(_path)
                _path = Destino
            End If
#End Region
            'Guias(0) = _path
            'Threading.Thread.Sleep(2000)





#Region "Generar Sobre de Envio"
            ''==========================================================================================
            ''==========================================================================================
            ''=============                      I M P O R T A N T E                       =============
            ''==========================================================================================
            ''==========================================================================================
            ''==========================================================================================
            ''==========================================================================================
            'If TipoDTE <> ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica Then
            '    Dim PathXML As String() = {"" & _path & ""} 'Guias 
            '    _RespEnvioDTE = EnviarAlSII(PathXML, "DTE_" & IdDTE)
            'ElseIf TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica And Not Empresa.AmbienteProduccion Then
            '    Dim PathXML As String() = {"" & _path & ""}
            '    Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)
            '    Dim xmlDtes As List(Of String) = New List(Of String)
            '    For Each pathFile As String In PathXML
            '        Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            '        Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
            '        dtes.Add(dte)
            '        xmlDtes.Add(xml)
            '    Next
            '    Dim EnvioSII = Millar.Stic.Documento.GenerarEnvioBoletaDTEToSII(dtes, xmlDtes, Empresa.SII.FechaResolucion, Empresa.SII.NumeroResolucion, Empresa.RutEmpresa, Empresa.Certificado.RutCertificado, IdDTE, Empresa.SII.SIIRut)
            '    Dim filePath = EnvioSII.Firmar(Empresa.Certificado.NombreDescriptivo, True, Directorio.Temporal)
            '    Try
            '        Millar.Stic.Documento.ValidateXML(filePath, SIMPLE_SDK.Security.Firma.Firma.TipoXML.EnvioBoleta, ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta)

            '    Catch ex As Exception
            '        MsgBox(ex.Message, MsgBoxStyle.Critical)
            '    End Try
            'End If

#End Region

            Dim TrackID As Int64 = 0 'IIf(IsNothing(_RespEnvioDTE), 0, _RespEnvioDTE.TrackId)
            If Not IsNothing(_RespEnvioDTE) Then
                TrackID = _RespEnvioDTE.TrackId
                Dim ErrorMSG As String = _RespEnvioDTE.Errores
                Dim estado As String = _RespEnvioDTE.Estado
                Dim ResponseXML As String = _RespEnvioDTE.ResponseXml
                Dim OK As String = _RespEnvioDTE.Ok
            End If














            '=================================================================
            '=================================================================
            'Guia de Venta
            '=================================================================
            '=================================================================
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try


    End Sub
    Public Sub SetPruebasGuias()
        Dim Ambiente As Boolean = Empresa.AmbienteProduccion
        Try
            Dim Guias(2) As String



            Empresa.AmbienteProduccion = False

            Dim CasoPrueba As String = "1286876"
            '==========================================================================================
            '==========================================================================================
            '=============  G u i a     1     d e l     c a s o     d e     p r u e b a s =============
            '==========================================================================================
            '==========================================================================================

            Dim _dte = New ChileSystems.DTE.Engine.Documento.DTE()

            _dte.Documento.Id = Empresa.AbrevEmpresa & Format(Now, "yyyyMMddHHmmss")
            '//DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            _dte.Documento.Encabezado.Emisor.Rut = Empresa.RutEmpresa
            _dte.Documento.Encabezado.Emisor.RazonSocial = Empresa.RazonSocial
            _dte.Documento.Encabezado.Emisor.Giro = Empresa.Giro
            _dte.Documento.Encabezado.Emisor.DireccionOrigen = Empresa.Direccion
            _dte.Documento.Encabezado.Emisor.ComunaOrigen = Empresa.Comuna
            _dte.Documento.Encabezado.Emisor.ActividadEconomica = Empresa.CodigosActividades

            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.SinCosto

            _dte.Documento.Encabezado.IdentificacionDTE.Folio = 7 'Guia Numero 1
            _dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.GuiaDespachoElectronica 'tipo de DTE
            _dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = Now 'fecha de emision
            _dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.TrasladosInternos

            _dte.Documento.Encabezado.Receptor.Rut = "76564313-9"
            _dte.Documento.Encabezado.Receptor.RazonSocial = "Sociedad Garcia y Ruiz Limitada"
            _dte.Documento.Encabezado.Receptor.Direccion = "Bulnes 217"
            _dte.Documento.Encabezado.Receptor.Comuna = "Los Angeles"
            _dte.Documento.Encabezado.Receptor.Ciudad = "Los Angeles"
            _dte.Documento.Encabezado.Receptor.Giro = "VENTA AL POR MAYOR DE COMBUSTIBLES SOLIDOS, LIQUIDOS Y GASEOSOS Y PROD"



            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.NotSet

            '=== ingresgar item ===

            'instancia del detalle 
            _dte.Documento.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.Detalle)
            Dim detalle = New ChileSystems.DTE.Engine.Documento.Detalle()

            'Item 1
            detalle.NumeroLinea = 1
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet
            detalle.Nombre = "ITEM 1"
            detalle.Cantidad = 76
            _dte.Documento.Detalles.Add(detalle)

            'Item 2
            detalle = New ChileSystems.DTE.Engine.Documento.Detalle()
            detalle.NumeroLinea = 2
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet
            detalle.Nombre = "ITEM 2"
            detalle.Cantidad = 114
            _dte.Documento.Detalles.Add(detalle)

            'Item 3
            detalle = New ChileSystems.DTE.Engine.Documento.Detalle()
            detalle.NumeroLinea = 3
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet
            detalle.Nombre = "ITEM 3"
            detalle.Cantidad = 76
            _dte.Documento.Detalles.Add(detalle)


            Millar.Stic.Documento.calculosTotales(_dte)

            'referencia al caso de pruebas
            _dte.Documento.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)
            Dim Ref As New ChileSystems.DTE.Engine.Documento.Referencia()
            Ref.CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet
            Ref.FechaDocumentoReferencia = DateTime.Now
            Ref.FolioReferencia = _dte.Documento.Encabezado.IdentificacionDTE.Folio
            Ref.IndicadorGlobal = 0
            Ref.Numero = 1
            Ref.RazonReferencia = "CASO " & CasoPrueba & "-1"
            Ref.TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.SetPruebas
            _dte.Documento.Referencias.Add(Ref)


#Region "TimbrarYFirmarXMLDTE"
            _path = TimbrarYFirmarXMLDTE(_dte, Directorio.Temporal, Directorio.CAF)
#End Region
#Region "Validate"
            If Millar.Stic.Documento.ValidateXML(_path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE) Then
                Dim Archivo As String() = _path.Split("\")
                Dim Destino As String = Directorio.DTE & "" & Archivo(Archivo.Length - 1)
                Dim Pendiente As String = Directorio.EnviosSIIPendiente & "" & Archivo(Archivo.Length - 1)
                File.Copy(_path, Destino, True)
                File.Copy(_path, Pendiente, True)
                File.Delete(_path)
                _path = Destino
            End If
#End Region
            Guias(0) = _path

            '==========================================================================================
            '==========================================================================================
            '=============  G u i a     2     d e l     c a s o     d e     p r u e b a s =============
            '==========================================================================================
            '==========================================================================================
            _dte = Nothing
            _dte = New ChileSystems.DTE.Engine.Documento.DTE()

            _dte.Documento.Id = Empresa.AbrevEmpresa & Format(Now, "yyyyMMddHHmmss")
            '//DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            _dte.Documento.Encabezado.Emisor.Rut = Empresa.RutEmpresa
            _dte.Documento.Encabezado.Emisor.RazonSocial = Empresa.RazonSocial
            _dte.Documento.Encabezado.Emisor.Giro = Empresa.Giro
            _dte.Documento.Encabezado.Emisor.DireccionOrigen = Empresa.Direccion
            _dte.Documento.Encabezado.Emisor.ComunaOrigen = Empresa.Comuna
            _dte.Documento.Encabezado.Emisor.ActividadEconomica = Empresa.CodigosActividades

            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.NotSet

            _dte.Documento.Encabezado.IdentificacionDTE.Folio = 8 'Guia Numero 1
            _dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.GuiaDespachoElectronica 'tipo de DTE
            _dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = Now 'fecha de emision
            _dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta

            _dte.Documento.Encabezado.Receptor.Rut = "66666666-6"
            _dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente"
            _dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente"
            _dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente"
            _dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente"
            _dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente"

            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.NotSet

            '=== ingresgar item ===

            'instancia del detalle 
            _dte.Documento.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.Detalle)
            'detalle = New ChileSystems.DTE.Engine.Documento.Detalle()

            'Item 1
            detalle = New ChileSystems.DTE.Engine.Documento.Detalle()
            detalle.NumeroLinea = 1
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet
            detalle.Nombre = "ITEM 1"
            detalle.Cantidad = 312
            detalle.Precio = 6452
            detalle.MontoItem = 312 * 6452
            _dte.Documento.Detalles.Add(detalle)

            'Item 2
            detalle = New ChileSystems.DTE.Engine.Documento.Detalle()
            detalle.NumeroLinea = 2
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet
            detalle.Nombre = "ITEM 2"
            detalle.Cantidad = 601
            detalle.Precio = 1539
            detalle.MontoItem = 601 * 1539
            _dte.Documento.Detalles.Add(detalle)


            Millar.Stic.Documento.calculosTotales(_dte)

            'referencia al caso de pruebas
            _dte.Documento.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)
            Ref = New ChileSystems.DTE.Engine.Documento.Referencia()
            Ref.CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet
            Ref.FechaDocumentoReferencia = DateTime.Now
            Ref.FolioReferencia = _dte.Documento.Encabezado.IdentificacionDTE.Folio
            Ref.IndicadorGlobal = 0
            Ref.Numero = 1
            Ref.RazonReferencia = "CASO " & CasoPrueba & "-2"

            Ref.TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.SetPruebas
            _dte.Documento.Referencias.Add(Ref)

            Ref = New ChileSystems.DTE.Engine.Documento.Referencia()
            Ref.CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet
            Ref.FechaDocumentoReferencia = DateTime.Now
            Ref.FolioReferencia = _dte.Documento.Encabezado.IdentificacionDTE.Folio
            Ref.IndicadorGlobal = 0
            Ref.Numero = 2
            Ref.RazonReferencia = "TRASLADO POR: 	EMISOR DEL DOCUMENTO AL LOCAL DEL CLIENTE"

            Ref.TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.Obs
            _dte.Documento.Referencias.Add(Ref)

#Region "TimbrarYFirmarXMLDTE"
            _path = TimbrarYFirmarXMLDTE(_dte, Directorio.Temporal, Directorio.CAF)
#End Region
#Region "Validate"
            If Millar.Stic.Documento.ValidateXML(_path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE) Then
                Dim Archivo As String() = _path.Split("\")
                Dim Destino As String = Directorio.DTE & "" & Archivo(Archivo.Length - 1)
                Dim Pendiente As String = Directorio.EnviosSIIPendiente & "" & Archivo(Archivo.Length - 1)
                File.Copy(_path, Destino, True)
                File.Copy(_path, Pendiente, True)
                File.Delete(_path)
                _path = Destino
            End If
#End Region
            Guias(1) = _path

            '==========================================================================================
            '==========================================================================================
            '=============  G u i a     3     d e l     c a s o     d e     p r u e b a s =============
            '==========================================================================================
            '==========================================================================================

            _dte = New ChileSystems.DTE.Engine.Documento.DTE()

            _dte.Documento.Id = Empresa.AbrevEmpresa & Format(Now, "yyyyMMddHHmmss")
            '//DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            _dte.Documento.Encabezado.Emisor.Rut = Empresa.RutEmpresa
            _dte.Documento.Encabezado.Emisor.RazonSocial = Empresa.RazonSocial
            _dte.Documento.Encabezado.Emisor.Giro = Empresa.Giro
            _dte.Documento.Encabezado.Emisor.DireccionOrigen = Empresa.Direccion
            _dte.Documento.Encabezado.Emisor.ComunaOrigen = Empresa.Comuna
            _dte.Documento.Encabezado.Emisor.ActividadEconomica = Empresa.CodigosActividades

            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.NotSet

            _dte.Documento.Encabezado.IdentificacionDTE.Folio = 9 'Guia Numero 1
            _dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.GuiaDespachoElectronica 'tipo de DTE
            _dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = Now 'fecha de emision
            _dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta
            ' _dte.Documento.Encabezado.IdentificacionDTE.TipoDespacho = ChileSystems.DTE.Engine.Enum.TipoDespacho.TipoDespachoEnum.EmisorACliente

            _dte.Documento.Encabezado.Receptor.Rut = "66666666-6"
            _dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente"
            _dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente"
            _dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente"
            _dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente"
            _dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente"

            _dte.Documento.Encabezado.IdentificacionDTE.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.NotSet

            '=== ingresgar item ===

            'instancia del detalle 
            _dte.Documento.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.Detalle)
            detalle = New ChileSystems.DTE.Engine.Documento.Detalle()

            'Item 1
            detalle = New ChileSystems.DTE.Engine.Documento.Detalle()
            detalle.NumeroLinea = 1
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet
            detalle.Nombre = "ITEM 1"
            detalle.Cantidad = 158
            detalle.Precio = 1847
            detalle.MontoItem = 158 * 1847
            _dte.Documento.Detalles.Add(detalle)

            'Item 2
            detalle = New ChileSystems.DTE.Engine.Documento.Detalle()
            detalle.NumeroLinea = 2
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet
            detalle.Nombre = "ITEM 2"
            detalle.Cantidad = 374
            detalle.Precio = 5050
            detalle.MontoItem = 374 * 5050
            _dte.Documento.Detalles.Add(detalle)


            Millar.Stic.Documento.calculosTotales(_dte)

            'referencia al caso de pruebas
            _dte.Documento.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)
            Ref = New ChileSystems.DTE.Engine.Documento.Referencia()
            Ref.CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet
            Ref.FechaDocumentoReferencia = DateTime.Now
            Ref.FolioReferencia = _dte.Documento.Encabezado.IdentificacionDTE.Folio
            Ref.IndicadorGlobal = 0
            Ref.Numero = 1
            Ref.RazonReferencia = "CASO " & CasoPrueba & "-3"

            Ref.TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.SetPruebas
            _dte.Documento.Referencias.Add(Ref)

            Ref = New ChileSystems.DTE.Engine.Documento.Referencia()
            Ref.CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet
            Ref.FechaDocumentoReferencia = DateTime.Now
            Ref.FolioReferencia = _dte.Documento.Encabezado.IdentificacionDTE.Folio
            Ref.IndicadorGlobal = 0
            Ref.Numero = 2
            Ref.RazonReferencia = "TRASLADO POR: 	CLIENTE"

            Ref.TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.Obs
            _dte.Documento.Referencias.Add(Ref)



#Region "TimbrarYFirmarXMLDTE"
            _path = TimbrarYFirmarXMLDTE(_dte, Directorio.Temporal, Directorio.CAF)
#End Region
#Region "Validate"
            If Millar.Stic.Documento.ValidateXML(_path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE) Then
                Dim Archivo As String() = _path.Split("\")
                Dim Destino As String = Directorio.DTE & "" & Archivo(Archivo.Length - 1)
                Dim Pendiente As String = Directorio.EnviosSIIPendiente & "" & Archivo(Archivo.Length - 1)
                File.Copy(_path, Destino, True)
                File.Copy(_path, Pendiente, True)
                File.Delete(_path)
                _path = Destino
            End If
#End Region
            Guias(2) = _path













#Region "Generar Sobre de Envio"
            '==========================================================================================
            '==========================================================================================
            '=============                      I M P O R T A N T E                       =============
            '==========================================================================================
            '==========================================================================================
            '==========================================================================================
            '==========================================================================================
            If TipoDTE <> ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica Then
                Dim PathXML As String() = Guias ' {"" & _path & ""}
                _RespEnvioDTE = EnviarAlSII(PathXML, "DTE_" & IdDTE)
            ElseIf TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica And Not Empresa.AmbienteProduccion Then
                Dim PathXML As String() = {"" & _path & ""}
                Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)
                Dim xmlDtes As List(Of String) = New List(Of String)
                For Each pathFile As String In PathXML
                    Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
                    Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
                    dtes.Add(dte)
                    xmlDtes.Add(xml)
                Next
                Dim EnvioSII = Millar.Stic.Documento.GenerarEnvioBoletaDTEToSII(dtes, xmlDtes, Empresa.SII.FechaResolucion, Empresa.SII.NumeroResolucion, Empresa.RutEmpresa, Empresa.Certificado.RutCertificado, IdDTE, Empresa.SII.SIIRut)
                Dim filePath = EnvioSII.Firmar(Empresa.Certificado.NombreDescriptivo, True, Directorio.Temporal)
                Try
                    Millar.Stic.Documento.ValidateXML(filePath, SIMPLE_SDK.Security.Firma.Firma.TipoXML.EnvioBoleta, ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta)

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If

#End Region

            Dim TrackID As Int64 = 0 'IIf(IsNothing(_RespEnvioDTE), 0, _RespEnvioDTE.TrackId)
            If Not IsNothing(_RespEnvioDTE) Then
                TrackID = _RespEnvioDTE.TrackId
                Dim ErrorMSG As String = _RespEnvioDTE.Errores
                Dim estado As String = _RespEnvioDTE.Estado
                Dim ResponseXML As String = _RespEnvioDTE.ResponseXml
                Dim OK As String = _RespEnvioDTE.Ok
            End If














            '=================================================================
            '=================================================================
            'Guia de Venta
            '=================================================================
            '=================================================================
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Empresa.AmbienteProduccion = Ambiente
        End Try


    End Sub
    Public Function GenerarSobreEnvioDTE(PathXML As String()) As String
        Try
            If TipoDTE <> ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica Then
                'Dim PathXML As String() = {"" & _path & ""}
                _RespEnvioDTE = EnviarAlSII(PathXML, "DTE_" & IdDTE)
            ElseIf TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica And Not Empresa.AmbienteProduccion Then
                'Dim PathXML As String() = {"" & _path & ""}
                Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)
                Dim xmlDtes As List(Of String) = New List(Of String)
                For Each pathFile As String In PathXML
                    Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
                    Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
                    dtes.Add(dte)
                    xmlDtes.Add(xml)
                Next
                Dim EnvioSII = Millar.Stic.Documento.GenerarEnvioBoletaDTEToSII(dtes, xmlDtes, Empresa.SII.FechaResolucion, Empresa.SII.NumeroResolucion, Empresa.RutEmpresa, Empresa.Certificado.RutCertificado, IdDTE, Empresa.SII.SIIRut)
                Dim filePath = EnvioSII.Firmar(Empresa.Certificado.NombreDescriptivo, True, Directorio.Temporal)
                Try
                    Millar.Stic.Documento.ValidateXML(filePath, SIMPLE_SDK.Security.Firma.Firma.TipoXML.EnvioBoleta, ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta)

                Catch ex As Exception
                    Throw ' MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function
    Private Function TimbrarYFirmarXMLDTE(dte As ChileSystems.DTE.Engine.Documento.DTE, pathResult As String, pathCaf As String) As String
        '/*En primer lugar, el documento debe timbrarse con el CAF que descargas desde el SII, es simular
        '    * cuando antes debías ir con las facturas en papel para que te las timbraran */
        Dim messageOut As String = String.Empty

        dte.Documento.Timbrar(EnsureExists(CInt(dte.Documento.Encabezado.IdentificacionDTE.TipoDTE), dte.Documento.Encabezado.IdentificacionDTE.Folio, pathCaf), messageOut)

        'Cual es el pathResult?????????


        '/*El documento timbrado se guarda en la variable pathResult*/

        '/*Finalmente, el documento timbrado debe firmarse con el certificado digital*/
        '/*Se debe entregar en el argumento del método Firmar, el "FriendlyName" o Nombre descriptivo del certificado*/
        '/*Retorna el filePath donde estará el archivo XML timbrado y firmado, listo para ser enviado al SII*/
        Return dte.Firmar(Empresa.Certificado.NombreDescriptivo, messageOut, Directorio.Temporal)
    End Function

    Private Function EnsureExists(tipoDTE As Integer, Folio As Integer, pathCaf As String) As String
        Dim cafFile = String.Empty
        For Each file In System.IO.Directory.GetFiles(pathCaf)
            If ParseName((New FileInfo(file)).Name, tipoDTE, Folio) Then
                cafFile = file
            End If
        Next
        If String.IsNullOrEmpty(cafFile) Then
            Throw New Exception(MensajesFE.Errores.sinFoliosDisponibles.Replace("|tipoDTE|", tipoDTE).Replace("|Folio|", Folio)) ' "NO HAY UN CÓDIGO DE AUTORIZACIÓN DE FOLIOS (CAF) ASIGNADO PARA ESTE TIPO DE DOCUMENTO (" + tipoDTE + ") QUE INCLUYA EL FOLIO REQUERIDO (" + Folio + ").")
        End If
        Return cafFile

    End Function
    Private Function ParseName(name As String, tipoDTE As Integer, Folio As Integer) As Boolean
        Try
            Dim values = name.Substring(0, name.IndexOf(".")).Split("_")
            Dim tipo As Integer = Convert.ToInt32(values(0))
            Dim desde As Integer = Convert.ToInt32(values(2))
            Dim hasta As Integer = Convert.ToInt32(values(3))
            Return tipoDTE = tipo And desde <= Folio And Folio <= hasta

        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
    Public Function EnviarAlSII(ByVal pathFiles As String(), Optional ByVal IdSet As String = "FENV010") As ChileSystems.DTE.WS.EnvioDTE.EnvioDTEResult
        'OpenFileDialog1.Multiselect = True
        'OpenFileDialog1.ShowDialog()
        'Dim pathFiles As String() = {""} ' OpenFileDialog1.FileNames
        Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)
        Dim xmlDtes As List(Of String) = New List(Of String)
        For Each pathFile As String In pathFiles
            Dim Xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(Xml)
            '/*Generar envio para el SII
            'Un envío puede contener 1 o varios DTE. No es necesario que sean del mismo tipo,
            'es decir, en un envío pueden ir facturas electrónicas afectas, notas de crédito, guias de despacho,
            'etc. */
            dtes.Add(dte)
            xmlDtes.Add(Xml)
        Next


        'Dim IdSet As String = "FENV010",
        '    FechaResolucion As DateTime = Now,
        '    NumeroResolucion As Integer = 15695

        Dim EnvioSII = Millar.Stic.Documento.GenerarEnvioDTEToSII(dtes, xmlDtes, IdSet, Empresa.SII.FechaResolucion, Empresa.SII.NumeroResolucion, Empresa.RutEmpresa, Empresa.Certificado.RutCertificado, Empresa.SII.SIIRut)
        '/*Generar envio para el cliente
        'En esencia es lo mismo que para el SII */
        '//var EnvioCliente = GenerarEnvioCliente(dte, xml);
        'Dim EnvioCliente = Millar.Stic.Documento.GenerarEnvioCliente(dte, xmlDtes, FechaResolucion, NumeroResolucion, Empresa.RutEmpresa, Empresa.Certificado.RutCertificado, Now)
        For Each pathFile As String In pathFiles
            Dim Xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(Xml)
            Dim EnvioCliente = Millar.Stic.Documento.GenerarEnvioCliente(dte, Xml, Empresa.SII.FechaResolucion, Empresa.SII.NumeroResolucion, Empresa.RutEmpresa, Empresa.Certificado.RutCertificado, Now)

        Next


        '/*Puede ser el EnvioSII o EnvioCliente, pues es el mismo tipo de objeto*/
        Dim filePath = EnvioSII.Firmar(Empresa.Certificado.NombreDescriptivo, True, Directorio.Temporal)


        Dim Archivo As String() = filePath.Split("\")
        Dim Destino As String = Directorio.EnviosSII & "" & Archivo(Archivo.Length - 1)
        File.Copy(filePath, Destino, True)
        File.Delete(filePath)
        filePath = Destino



        If Millar.Stic.Documento.ValidateXML(filePath, SIMPLE_SDK.Security.Firma.Firma.TipoXML.Envio, ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE) Then
            'MessageBox.Show("Envío generado exitosamente en " + filePath)
            ' /*Procedemos a enviar el 'Envío' al SII, que no es otra cosa que simular un upload vía browser*/
            Dim Resp As ChileSystems.DTE.WS.EnvioDTE.EnvioDTEResult = Millar.Stic.Documento.EnviarEnvioDTEToSII(filePath, Empresa.AmbienteProduccion, Empresa.RutEmpresa, Empresa.Certificado.NombreDescriptivo, Directorio.Temporal)
            'MessageBox.Show("Sobre enviado correctamente. TrackID: " + Resp.TrackId.ToString())
            Return Resp
        Else
            Return Nothing
        End If




    End Function
    Public Shared Sub GenerarFacturaPDF_Termica(pathFile As String, MontoIEDiesel As Double, IEBase As Double, IEVariable As Double)
        Dim outMessage As String = ""
        'Dim pathFile As String = dllFunciones.Erik.DialogoAbrir("Seleccione un DTE", "Archivo DTE|*.xml")
        Dim Xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))

        Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(Xml)
        'Dim Img As System.Drawing.Image = dte.Documento.TimbrePDF417(outMessage)

        Dim bytes As Byte() = CType((New ImageConverter()).ConvertTo(dte.Documento.TimbrePDF417(outMessage), GetType(Byte())), Byte())

        'Dim PDF As New clsReportesPDFs
        'PDF.generarFacturaPDF(dte, MontoIEDiesel, IEBase, IEVariable)
    End Sub
End Class
