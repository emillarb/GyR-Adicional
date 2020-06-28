Imports System.IO

Namespace Stic
	Public Class Config
		Public Shared Function LeerParametroLocal(ByVal IdParametroLocal As String) As String
			Dim Cn As New Stic.SQLite
			Dim R As String = ""
			Try
				If Cn.AbrirBaseDatos Then
					Cn.SentenciaSQL = "Select Valor from Parametros where IdParametro = '" & IdParametroLocal & "' "
					Using RsDl As DataTableReader = Cn.LeerDatos().CreateDataReader
						If RsDl.Read Then
							R = RsDl(0)
						End If
					End Using
				End If
			Catch ex As Exception
				Throw
			Finally
				Cn.CerrarBaseDatos()
			End Try
			Return R
		End Function


		Public Shared Sub LeerArchivoConf()
			Try
#Region "Configuracion de la Aplicacion"
				dllFunciones.clsConfJson.ArchivoConf = App.Directorios.Stic & "App.conf"
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

				dllFunciones.cnxAccess.BaseDatos = App.Directorios.Stic & dllFunciones.clsConfJson.Valors("DatosLocal")
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

		Public Sub CrearBaseDatosSQLite()
#Region "Estructuras CreateTable pra las base datos local"
			Dim CreateTableConsumoFolio As String = "create table ConsumoFolio (
	                                                    patente text not null,
	                                                    cafTipoDte integer not null,
	                                                    cafFecha text not null,
	                                                    fecha text not null,
	                                                    rangoDesde integer not null,
	                                                    rangoHasta integer not null,
	                                                    primary key(patente, cafTipoDte, cafFecha, fecha)
                                                    );"
			Dim CreateTableDslCliente As String = "CREATE TABLE DslCliente(
	                                                    rutCliente integer NOT NULL,
	                                                    razonSocial text NOT NULL,
	                                                    direccion text NOT NULL,
	                                                    comuna text NOT NULL,
	                                                    giro text NOT NULL,
	                                                    primary key (rutCliente)
                                                    );"
			Dim CreateTableDslCliePrecio As String = "create table DslCliePrecio (
	                                                    rutCliente integer not null,
	                                                    fechaCrea text not null,
	                                                    PrecioPublico integer not null,
	                                                    primary key (rutCliente, fechaCrea),
	                                                    foreign key (rutCliente) references DslCliente (rutCliente)
                                                    );"
			Dim CreateTableDslIE As String = "create table DslIE (	
	                                                fechaCrea text not null,
	                                                IEComBase real not null,
	                                                IEComVar real not null,
	                                                primary key (fechaCrea)
                                                );"
			Dim CreateTableUTM As String = "create table UTM (
	                                            mes text not null,
	                                            valor integer not null,
	                                            primary key(mes)
                                            );"
			Dim CreateTableDslCamion As String = "create table DslCamion (
	                                                    patente text not null,
	                                                    propietario text not null,
	                                                    domisicio text not null,
	                                                    fechaAdquisicion text not null,
	                                                    fechaInscripcion text not null,
	                                                    anio integer not null,
	                                                    marca text not null,
	                                                    modelo text not null,
	                                                    nroMotor text not null,
	                                                    nroChasis text not null,
	                                                    nroSerie text not null,
	                                                    nroVIN text not null,
	                                                    color text not null,
	                                                    primary key (patente)
                                                    );"
			Dim CreateTableDslDTE As String = "CREATE TABLE DslDTE(
	                                                tipoDTE integer NOT NULL,
	                                                folioDTE integer NOT NULL,
	                                                fechaEmision text NOT NULL,
	                                                rutCliente integer NOT NULL,
	                                                montoNeto integer NOT NULL,
	                                                montoEsp integer not null,
	                                                montoIVA integer NOT NULL,
	                                                montoTotal integer NOT NULL,
	                                                trackId text NULL,
	                                                patente text not null,
	                                                precio integer not null,
	                                                IEBase real not null,
	                                                IEVar real not null,
	                                                UTM integer not null,
	                                                fechaCrea text not null,
	                                                primary key(tipoDTE, folioDTE),
	                                                foreign key (rutCliente) references DslCliente (rutCliente),
	                                                foreign key (patente) references DslCamion (patente)
                                                );"
			Dim CreateTableDslMiter As String = "create table DslMiter (
	                                                tipoDTE integer NOT NULL,
	                                                folioDTE integer NOT NULL,
	                                                odometroInicial integer not null,
	                                                odometroFinal integer not null,
	                                                primary key(tipoDTE, folioDTE),
	                                                foreign key (tipoDTE, folioDTE) references DslDTE (tipoDTE, folioDTE)
                                                );"
			Dim CreateTableDslDTEDetalle As String = "CREATE TABLE DslDTEDetalle(
															tipoDTE integer NOT NULL,
															folioDTE integer NOT NULL,
															nroLinea integer NOT NULL,
															descripcionProducto text NOT NULL,
															cantidad real NOT NULL,
															precio real NOT NULL,
															undMedida text NOT NULL,
															tipoImpuesto integer not NULL default 0,
															afecto integer not NULL default 1,
															primary key(tipoDTE, folioDTE, nroLinea),
															foreign key (tipoDTE, folioDTE) references DslDTE (tipoDTE, folioDTE)
														);"
			Dim CreateTableDslCompras As String = "create table DslCompras (
														rutEmisor integer not null,
														folioFactura integer not null,
														RazonSocial text not null,
														fechaCompra text not null,
														patente text not null,
														totLtrDiesel integer not null,
														totLtrGasolina integer not null default 0,
														montoNeto integer not null,
														montoEsp integer not null,
														montoIVA integer not null,
														montoTotal integer not null,
														primary key (rutEmisor, folioFactura),
														foreign key (patente) references DslCamion (patente)
													);"
			Dim CreateTableParametros As String = "CREATE TABLE Parametros(
	                                                    IdParametro text NOT NULL,
	                                                    Valor text NOT NULL,
	                                                    primary key (IdParametro)
                                                    );"
#End Region
			'debo crear todoas las tablas y estructuras locales para el sistema

			If File.Exists(Stic.SQLite.BaseDatos) Then
				Exit Sub
			End If
			Dim Cn As New Stic.SQLite
			Try
				If Cn.AbrirBaseDatos Then
#Region "Creando las Tablas"
					Cn.SentenciaSQL = CreateTableConsumoFolio
					Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableDslCliente
					'Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableDslCliePrecio
					'Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableDslIE
					'Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableUTM
					'Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableDslCamion
					'Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableDslDTE
					'Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableDslMiter
					'Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableDslDTEDetalle
					'Cn.GuardarDatos()
					'Cn.SentenciaSQL = CreateTableDslCompras
					'Cn.GuardarDatos()
					Cn.SentenciaSQL = CreateTableParametros
					Cn.GuardarDatos()
#End Region
#Region "Insertando Parametros por Defecto"
					Cn.SentenciaSQL = "insert into Parametros values ('Patente','Adic.')"
					Cn.GuardarDatos()
#End Region
				End If
			Catch ex As Exception
				Throw
			Finally
				Cn.CerrarBaseDatos()
			End Try
		End Sub

	End Class
End Namespace
