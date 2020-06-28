Imports System.IO


Module mdlBase
#Region "Variables Pribadas Estructura Sesion"
    Private _MsgError As String = "", _id_sesion As Int64 = 0, _IdUsuario As Integer = 0, _RutUsuario As String = "", _nombres As String = "", _ap_paterno As String = "", _ap_materno As String = "", _NombreCompleto As String = "", _nombre_usuario As String = "", _estado As Integer = 0, _equipo As String = ""
#End Region
#Region "Aplicacion"
    Public Structure App
        Public Structure Directorios
            Public Shared ReadOnly Property Aplicacion
                Get
                    Return Application.StartupPath & "\"
                End Get
            End Property
            Public Shared ReadOnly Property Stic
                Get
                    Dim R As String = Aplicacion & "Stic\"
                    If Not IO.Directory.Exists(R) Then
                        IO.Directory.CreateDirectory(R)
                    End If
                    Return R
                End Get
            End Property
            Public Shared ReadOnly Property Imagenes
                Get
                    Dim R As String = Stic & "Img\"
                    If Not IO.Directory.Exists(R) Then
                        IO.Directory.CreateDirectory(R)
                    End If
                    Return R
                End Get
            End Property
            Public Shared ReadOnly Property App
                Get
                    Dim R As String = Stic & "App\"
                    If Not IO.Directory.Exists(R) Then
                        IO.Directory.CreateDirectory(R)
                    End If
                    Return R
                End Get
            End Property
        End Structure

        Public Structure Sesion
            Public Shared Property MsgError As String
                Get
                    Return _MsgError
                End Get
                Set(value As String)
                    _MsgError = value
                End Set
            End Property
            Public Shared Property RutUsuario As String
                Get
                    Return _RutUsuario
                End Get
                Set(value As String)
                    _RutUsuario = value
                End Set
            End Property
            Public Shared Property Nombres As String
                Get
                    Return _nombres
                End Get
                Set(value As String)
                    _nombres = value
                End Set
            End Property
            Public Shared Property ApPaterno As String
                Get
                    Return _ap_paterno
                End Get
                Set(value As String)
                    _ap_paterno = value
                End Set
            End Property
            Public Shared Property ApMaterno As String
                Get
                    Return _ap_materno
                End Get
                Set(value As String)
                    _ap_materno = value
                End Set
            End Property
            Public Shared Property NombreCompleto As String
                Get
                    Return _NombreCompleto
                End Get
                Set(value As String)
                    _NombreCompleto = value
                End Set
            End Property
            Public Shared Property NombreUsuario As String
                Get
                    Return _nombre_usuario
                End Get
                Set(value As String)
                    _nombre_usuario = value
                End Set
            End Property
            Public Shared Property Equipo As String
                Get
                    Return _equipo
                End Get
                Set(value As String)
                    _equipo = value
                End Set
            End Property
            Public Shared Property IdUsuario As Integer
                Get
                    Return _IdUsuario
                End Get
                Set(value As Integer)
                    _IdUsuario = value
                End Set
            End Property
            Public Shared Property Estado As Integer
                Get
                    Return _estado
                End Get
                Set(value As Integer)
                    _estado = value
                End Set
            End Property
            Public Shared Property IdSesion As Int64
                Get
                    Return _id_sesion
                End Get
                Set(value As Int64)
                    _id_sesion = value
                End Set
            End Property
        End Structure
        Public Shared Sub LeerArchivoConf()
            Try
#Region "Configuracion de la Aplicacion"
                dllFunciones.clsConfJson.ArchivoConf = App.Directorios.App & "App.conf"
                dllFunciones.clsConfJson.AgregarConf("HostServidor", dllFunciones.Erik.CifrarBase64("179.4.188.141,1002"))
                dllFunciones.clsConfJson.AgregarConf("NombreBaseDatos", "GES_GyR")
                dllFunciones.clsConfJson.AgregarConf("UsuarioBD", "sa")
                dllFunciones.clsConfJson.AgregarConf("ClaveUsuario", dllFunciones.Erik.CifrarBaseEmb("Stic2019"))
                dllFunciones.clsConfJson.AgregarConf("TituloAplicacion", "VGR Camión")
                dllFunciones.clsConfJson.AgregarConf("Equipo", "Camion")
                dllFunciones.clsConfJson.AgregarConf("DatosLocal", "bdCamion.emb")
                dllFunciones.clsConfJson.AgregarConf("Impresora", "EPSON TM-T20II Receipt")
                dllFunciones.clsConfJson.AgregarConf("CerrarExplorer", "0")
#Region "Impresora Fislca"
                dllFunciones.clsConfJson.AgregarConf("PuertoCom", "2")
                dllFunciones.clsConfJson.AgregarConf("Baudios", "3")
#End Region

#Region "Identificacion de la Empresa"
                dllFunciones.clsConfJson.AgregarConf("AmbienteProduccion", "0")
                dllFunciones.clsConfJson.AgregarConf("idEmisor", "76564313")
                dllFunciones.clsConfJson.AgregarConf("RazonSocial", "Sociedad Garcia y Ruiz Limitada")
                dllFunciones.clsConfJson.AgregarConf("Giro", "Compra, venta al por mayor de combustibles, trasporte de carga por carretera y Estacionamientos")
                dllFunciones.clsConfJson.AgregarConf("BoletaRazonSocial", "Sociedad Garcia y Ruiz Limitada")
                dllFunciones.clsConfJson.AgregarConf("BoletaGiro", "Compra, venta al por mayor de combustibles, trasporte de carga por carretera y Estacionamientos")
                dllFunciones.clsConfJson.AgregarConf("Direccion", "Bulnes 217")
                dllFunciones.clsConfJson.AgregarConf("Comuna", "Los Angeles")
                dllFunciones.clsConfJson.AgregarConf("Ciudad", "Los Angeles")
                dllFunciones.clsConfJson.AgregarConf("AbrevEmpresa", "SGR")
                dllFunciones.clsConfJson.AgregarConf("CodigosActividades", "466100, 492300, 522120")
#End Region



                dllFunciones.clsConfJson.LeerConf()

                dllFunciones.cnxSqlServer.HostServidor = dllFunciones.Erik.DesCifrarBase64(dllFunciones.clsConfJson.Valors("HostServidor"))
                dllFunciones.cnxSqlServer.NombreBaseDatos = dllFunciones.clsConfJson.Valors("NombreBaseDatos")
                dllFunciones.cnxSqlServer.UsuarioBD = dllFunciones.clsConfJson.Valors("UsuarioBD")
                dllFunciones.cnxSqlServer.ClaveUsuario = dllFunciones.Erik.DesCifrarBaseEmb(dllFunciones.clsConfJson.Valors("ClaveUsuario"))
                dllFunciones.cnxSqlServer.TituloAplicacion = dllFunciones.clsConfJson.Valors("TituloAplicacion")

                'dllFunciones.cnxAccess.BaseDatos = App.Directorios.App & dllFunciones.clsConfJson.Valors("DatosLocal")
                'If Not File.Exists(dllFunciones.cnxAccess.BaseDatos) Then
                '    System.IO.File.WriteAllBytes(dllFunciones.cnxAccess.BaseDatos, My.Resources.bdCamion)
                'End If
#End Region
            Catch ex As Exception
                Throw
            End Try
        End Sub
        Public Shared ReadOnly Property Nombre As String
            Get
                Return dllFunciones.clsConfJson.Valors("TituloAplicacion")
            End Get
        End Property

    End Structure

#End Region
#Region "Facturacion Electronica"
    Public Class Directorio
        Private Shared _DirectorioFacturacionElectronica As String = App.Directorios.Stic & "FactElect"
        Private Const _DirectorioCAF As String = "CAFs"
        Private Const _DirectorioTMP As String = "Temp"
        Private Const _DirectorioDTE As String = "DTEs"
        Private Const _DirectorioRCOF As String = "RCOFs"
        Private Const _DirectorioEnviosSII As String = "EnviosSII"
        Private Const _DirectorioEnviosSIIPendiente As String = "EnviosSIIPendiente"
        Private Const _DirectorioLibroBol As String = "LibBol"
        Private Const _DirectorioPDFs As String = "PDFs"
        Private Shared ReadOnly Property DirectorioFacturacionElectronica As String
            Get
                Return _DirectorioFacturacionElectronica & "_" & dllFunciones.clsConfJson.Valors("AbrevEmpresa")
            End Get
        End Property
        Public Shared ReadOnly Property CAF As String
            Get
                Dim R As String = DirectorioFacturacionElectronica & "\" & _DirectorioCAF & "\"
                If Not Directory.Exists(R) Then
                    Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property Temporal As String
            Get
                Dim R As String = DirectorioFacturacionElectronica & "\" & _DirectorioTMP & "\"
                If Not Directory.Exists(R) Then
                    Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property DTE As String
            Get
                Dim R As String = DirectorioFacturacionElectronica & "\" & _DirectorioDTE & "\"
                If Not Directory.Exists(R) Then
                    Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property RCOF As String
            Get
                Dim R As String = DirectorioFacturacionElectronica & "\" & _DirectorioRCOF & "\"
                If Not Directory.Exists(R) Then
                    Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property LibroBoletas As String
            Get
                Dim R As String = DirectorioFacturacionElectronica & "\" & _DirectorioLibroBol & "\"
                If Not Directory.Exists(R) Then
                    Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property PDFs As String
            Get
                Dim R As String = DirectorioFacturacionElectronica & "\" & _DirectorioPDFs & "\"
                If Not Directory.Exists(R) Then
                    Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property EnviosSII As String
            Get
                Dim R As String = DirectorioFacturacionElectronica & "\" & _DirectorioEnviosSII & "\"
                If Not Directory.Exists(R) Then
                    Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
        Public Shared ReadOnly Property EnviosSIIPendiente As String
            Get
                Dim R As String = DirectorioFacturacionElectronica & "\" & _DirectorioEnviosSIIPendiente & "\"
                If Not Directory.Exists(R) Then
                    Directory.CreateDirectory(R)
                End If
                Return R
            End Get
        End Property
    End Class

    Public Class Mensajes
        Public Structure Preguntas
            Public Const deseaCorregir As String = vbNewLine & vbNewLine & "¿Desea Corregir?"
            Public Const SolicitudFoliosOK As String = "Se Obtubieron Folios Correctamente"
        End Structure
        Public Structure Correctos
            Public Const TodoOK As String = "Termino Correctamente"
            Public Const SolicitudFoliosOK As String = "Se Obtubieron Folios Correctamente"
        End Structure
        Public Structure Advertencias
            Public Const IEVarAlto As String = "el Componente variable del IE es muy alto"
            Public Const DifLitros As String = "La diferencia de litros supera el 10%"
            Public Const ContactarAdministradorSistema As String = "Contactese con el administrador de Sistemas"
            Public Const AvisarAdministradorSistema As String = "Avisar de inmediato al administrador de Sistemas"

        End Structure
        Public Structure Errores
            Public Const sinFoliosDisponibles As String = "NO HAY UN CÓDIGO DE AUTORIZACIÓN DE FOLIOS (CAF) ASIGNADO PARA ESTE TIPO DE DOCUMENTO (·tipoDTE·) QUE INCLUYA EL FOLIO REQUERIDO (·Folio·)."
            Public Const noGuardoXMLenBaseDatos As String = "No se pudo guardar el Archivo XML"
            Public Const BaseDatosInaxesible As String = "No se pudo establecer coneccion con la base de datos"
            Public Const SinDatosParaMostrar As String = "No se pudieron obtener datos para mostrar"
            Public Const NoGuardo As String = "No se pudo guardar los datos"
            Public Const TipoDTENoSoportado As String = "No se Reconose el Tipo de DTE"
            Public Const RutInvalido As String = "El Rut no es correcto"
            Public Const DatosRequeridos As String = "Debe completar todos los datos"
            Public Const TotalesRequeridos As String = "Los Valores de Precio Neto, Neto, Especifico, I.V.A. o Total no puede ser cero (0)"
            Public Const ErrUTM As String = "La UTM no puede ser 0"
            Public Const ErrPrecio As String = "El Precio no puede ser 0"
            Public Const ErrVtaCantidad As String = "la cantidad no puede ser inferior a 1"
            Public Const ErrVtaPrecio As String = "El precio no puede ser inferior a 1"
            Public Const ErrVtaDescuento As String = "El descuento es superior a la venta"
            Public Const ErrMiterOdo As String = "El Odometro final del Miter No puede menor al odometro inicial"
            Public Const ErrMiterOdoVacio As String = "El Odometro del Miter No puede quedar en 0"
            Public Const ErrDTEExisteEnServidor As String = "El Dte ya existe en en servidor"
            Public Const ErrDTEAunQuedanFolios As String = "Aun tiene folios disponibles"

        End Structure
    End Class




    Public Class Empresa



        '        #Region "Identificacion de la Empresa"
        '                dllFunciones.clsConfJson.AgregarConf("AmbienteProduccion", "0")
        '                dllFunciones.clsConfJson.AgregarConf("idEmisor", "76564313")
        '                dllFunciones.clsConfJson.AgregarConf("RazonSocial", "Sociedad Garcia y Ruiz Limitada")
        '                dllFunciones.clsConfJson.AgregarConf("Giro", "Compra, venta al por mayor de combustibles, trasporte de carga por carretera y Estacionamientos")
        '                dllFunciones.clsConfJson.AgregarConf("BoletaRazonSocial", "Sociedad Garcia y Ruiz Limitada")
        '                dllFunciones.clsConfJson.AgregarConf("BoletaGiro", "Compra, venta al por mayor de combustibles, trasporte de carga por carretera y Estacionamientos")
        '                dllFunciones.clsConfJson.AgregarConf("Direccion", "Bulnes 217")
        '                dllFunciones.clsConfJson.AgregarConf("Comuna", "Los Angeles")
        '                dllFunciones.clsConfJson.AgregarConf("Ciudad", "Los Angeles")
        '                dllFunciones.clsConfJson.AgregarConf("AbrevEmpresa", "SGR")
        '                dllFunciones.clsConfJson.AgregarConf("CodigosActividades", "466100, 492300, 522120")
        '#End Region



        '              dllFunciones.clsConfJson.Valors("DatosLocal")





        Public Shared AmbienteProduccion As Boolean = CBool(Val(dllFunciones.clsConfJson.Valors("AmbienteProduccion"))) ' True
        Public Shared ReadOnly idEmisor As Integer = dllFunciones.clsConfJson.Valors("idEmisor") ' 76564313 '-9
        Public Shared ReadOnly RazonSocial As String = dllFunciones.clsConfJson.Valors("RazonSocial") ' "Sociedad Garcia y Ruiz Limitada"
        Public Shared ReadOnly Giro As String = dllFunciones.clsConfJson.Valors("Giro") '  "Compra, venta al por mayor de combustibles, trasporte de carga por carretera y Estacionamientos"
        Public Shared ReadOnly BoletaRazonSocial As String = dllFunciones.clsConfJson.Valors("BoletaRazonSocial") '  "Sociedad Garcia y Ruiz Limitada"
        Public Shared ReadOnly BoletaGiro As String = dllFunciones.clsConfJson.Valors("BoletaGiro") ' "Compra, venta al por mayor de combustibles, trasporte de carga por carretera y Estacionamientos"
        Public Shared ReadOnly Direccion As String = dllFunciones.clsConfJson.Valors("Direccion") '  "Bulnes 217"
        Public Shared ReadOnly Comuna As String = dllFunciones.clsConfJson.Valors("Comuna") ' "Los Angeles"
        Public Shared ReadOnly Ciudad As String = dllFunciones.clsConfJson.Valors("Ciudad") '  "Los Angeles"
        Public Shared ReadOnly AbrevEmpresa As String = dllFunciones.clsConfJson.Valors("AbrevEmpresa") ' "SGR" 'debe ser alfanumerico. Remitirse a letras y números
        'Public Shared CodigosActividades = New List(Of Int32) From {466100, 492300, 522120}
        Public Shared ReadOnly Property CodigosActividades As IList(Of Int32)
            Get
                Dim CodAct As String() = dllFunciones.clsConfJson.Valors("CodigosActividades").Split(",")
                Dim R As New List(Of Int32)
                For i As Integer = 0 To CodAct.LongCount - 1
                    R.Add(CodAct(i))
                Next
                Return R
            End Get
        End Property
        Public Structure SII
            Public Const SIIRut As String = "60803000-K"
            Public Const SIICiudad As String = "LOS ANGELES"
            'estos datos se obtienen del SII --> Servicios online --> Factura electrónica --> Sistema de facturación de mercado --> Actualización de datos empresa autorizada (*) --> Actualizar datos empresa 
            Public Const FechaResolucion As Date = #2014-08-22#
            Public Const NumeroResolucion As Integer = 80
        End Structure
        Public Structure Certificado
            Public Const RutCertificado As String = "5244731-3"
            Public Const NombreDescriptivo As String = "ID E-Sign S.A. de Eugenio Jesus Garcia Jimenez"
        End Structure
        Public Structure Sucursal
            Public Const EmpSucCodigo As Integer = 0
            Public Const EmpSucDireccion As String = "Bulnes 217"
            Public Const EmpSucComuna As String = "Los Angeles"
            Public Const EmpSucCiudad As String = "Los Angeles"
        End Structure

        Public Shared ReadOnly Property RutEmpresa As String
            Get
                Dim R As String = idEmisor & "-" & dllFunciones.Erik.ObtenerDigitoVerificadorDelRut(idEmisor)
                Return R
            End Get
        End Property
    End Class
#End Region


End Module

