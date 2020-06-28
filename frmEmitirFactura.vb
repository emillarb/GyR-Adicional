Public Class frmEmitirFactura
#Region "Factura"
    Private Sub AgregaItem(Dte As GenerarDTE)
        Try
            Dim CantidadLitros As Integer = Val(txtVtaLitros.Text)
            Dim PrecioNeto As Integer = Val(txtVtaPrecioNeto.Text)
            'validaciones
            ' If txtProducto.Text.Trim.Length = 0 Then Throw New System.Exception("El nombre del producto no puede quedar vacio")
            If CantidadLitros < 1 Then Err(Mensajes.Errores.ErrVtaCantidad)
            If PrecioNeto < 1 Then Err(Mensajes.Errores.ErrVtaPrecio)
            Dim SubTotal As Integer = CantidadLitros * PrecioNeto
            Dim MontoDescuento As Integer = 0 ' nroMontoDescuento.Value
            If SubTotal < MontoDescuento Then Err(Mensajes.Errores.ErrVtaDescuento)



            Dim Item As New Millar.Stic.ItemDTE
            Item.Nombre = "Petroleo Diesel"
            Item.Cantidad = CantidadLitros
            Item.Afecto = True
            Item.Precio = PrecioNeto ' .PrecioNetoDiesel '+ (clsPrecioDiesel.IEBase + clsPrecioDiesel.IEVariable) '/ 1.19) ' clsPrecioDiesel.PrecioPublicoDiesel - (clsPrecioDiesel.IEBase + clsPrecioDiesel.IEVariable)   'CInt(nroPrecio.Value) ' tengo el preoblema que el precio del diese es en decimal
            Item.Descuento = Val(MontoDescuento)

            Item.UnidadMedida = "Ltr"  ' checkUnidad.Checked ? "Kg." : String.Empty;
            Item.TipoImpuesto = ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.ImpuestoEspecificoDiesel

            Dte.AddItemDTE(Item)
            'Items.Add(Item)
            'dgvProductos.DataSource = Nothing
            'dgvProductos.DataSource = Dte.ListaItems




            'nroCantidad.Value = 1
            'nroPrecio.Value = Nothing

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub EmitirFactura()
        Try
            Dim Dte As New GenerarDTE
            Dte.Folio = nroFolio.Value  'nroFolio.Value
            Dte.TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica
            Dim Folio As Integer = Dte.Folio, TipoDTE As Integer = Dte.TipoDTE
            Dim FechaEmision As DateTime = txtFecha.Value ' CDate("2020-01-27 15:28:49") ' Now
            Dte.FechaEmision = FechaEmision

            Dte.ReceptorRut = txtRecepRut.Text ' "66666666-6"
            Dte.ReceptorRazonSocial = txtRecepRazonSocial.Text ' "Razon Social de Cliente"
            Dte.ReceptorDireccion = txtRecepDireccion.Text ' "Dirección de cliente"
            Dte.ReceptorComuna = txtRecepComuna.Text '"Comuna de cliente"
            Dte.ReceptorCiudad = txtRecepCiudad.Text ' "Ciudad de cliente"
            Dte.ReceptorGiro = txtRecepGiro.Text '"Giro de cliente"

            Dte.FormaPago = ChileSystems.DTE.Engine.Enum.FormaPago.FormaPagoEnum.Credito
            '#Region "Referencias"
            '            'tengo que rebisar bien este metodo para poder automatizar, por que es un metodo estatico y manual
            '            If Dte.UsaReferencia Then
            '                '_Referencias(dte)
            '                Dte.Referencia = Referencia.lstRef.Last
            '            End If
            '#End Region
            AgregaItem(Dte)
            Dte.MontoIEDiesel = Val(txtVtaEsp.Text.Replace(".", "").Replace(",", ""))
            Dte.IEBase = CalculaIE(Val(txtUTM.Text), CDbl(txtIEComBase.Text))
            Dte.IEVariable = CalculaIE(Val(txtUTM.Text), CDbl(txtIEComVar.Text))
            Dte.PrecioPublico = Val(txtPrecioCliente.Text)
            Dte.IEComBase = CDbl(txtIEComBase.Text)
            Dte.IEComVariable = CDbl(txtIEComVar.Text)
            Dte.UTM = Val(txtUTM.Text)
            'Dte.OdoMiterMin = Val(txtOdoMiterMin.Text)
            'Dte.OdoMiterMax = Val(txtOdoMiterMax.Text)

            Dim RutaXML As String = Dte.GenerarDTE()

            Dim Msg As String = ""
            Dim TrackId As String = ""
            If Not IsNothing(Dte.RespuestaEnvioDTE) Then
                'MsgBox("TrackId de Envio: " & Dte.RespuestaEnvioDTE.TrackId)
                Msg = "TrackId de Envio: " & Dte.RespuestaEnvioDTE.TrackId
                TrackId = Dte.RespuestaEnvioDTE.TrackId

            End If

            'Almacenar la Factura en la Base de datos, inclullendo el TrackId
            'MsgBox("Termino" & vbNewLine & vbNewLine & Dte.PathDte & vbNewLine & Msg)
            'Dim Clie As New clsCliente
            'If Not Clie.ClienteExiste(txtRecepRut.Text) Then
            '    Clie.Crear(ObtenerRutDinDigitoVerificador(txtRecepRut.Text), txtRecepRazonSocial.Text, txtRecepDireccion.Text, txtRecepComuna.Text, txtRecepCiudad.Text, txtRecepGiro.Text)
            'End If
            'Dim Fact As New clsFactura
            'Fact.GuardarFacturaEmitida(Dte.TipoDTE, nroFolio.Value, FechaEmision, ObtenerRutDinDigitoVerificador(txtRecepRut.Text), Dte.MontoNeto, Dte.MontoIVA, Dte.MontoTotal)

            'dgvProductos.DataSource = Nothing
            'dgvProductos.DataSource = Dte.ListaItems
            'MsgBox("Termino")
            'termino de genrar la factura electronica
            Inicio()
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
    Private Sub CalculoFacturas()
        txtVtaNeto.Text = Val(txtVtaLitros.Text) * Val(txtVtaPrecioNeto.Text)
        txtVtaIVA.Text = Val(txtVtaNeto.Text) * 0.19 'el IVa deberia estar en el archivo de configuraciones
        txtVtaEsp.Text = IIf(Val(txtVtaNeto.Text) = 0, 0, MontoIE(Val(txtVtaLitros.Text), Val(txtIEComBase.Text.Replace(",", ".")), Val(txtIEComVar.Text.Replace(",", ".")), Val(txtUTM.Text)))
        txtVtaTotal.Text = (Val(txtVtaNeto.Text) + Val(txtVtaIVA.Text) + Val(txtVtaEsp.Text)).ToString("N0")
        txtVtaNeto.Text = Val(txtVtaNeto.Text).ToString("N0")
        txtVtaIVA.Text = Val(txtVtaIVA.Text).ToString("N0")
        txtVtaEsp.Text = Val(txtVtaEsp.Text).ToString("N0")

    End Sub
    Private Sub CalculoTotales(MontoItemNeto As Integer, MontoItemEsp As Integer)
        Try
            txtVtaNeto.Text = Val(txtVtaLitros.Text) * Val(txtVtaPrecioNeto.Text)
            txtVtaIVA.Text = Val(txtVtaNeto.Text) * 0.19 'el IVa deberia estar en el archivo de configuraciones
            txtVtaEsp.Text = IIf(Val(txtVtaNeto.Text) = 0, 0, MontoIE(Val(txtVtaLitros.Text), Val(txtIEComBase.Text.Replace(",", ".")), Val(txtIEComVar.Text.Replace(",", ".")), Val(txtUTM.Text)))
            txtVtaTotal.Text = (Val(txtVtaNeto.Text) + Val(txtVtaIVA.Text) + Val(txtVtaEsp.Text)).ToString("N0")
            txtVtaNeto.Text = Val(txtVtaNeto.Text).ToString("N0")
            txtVtaIVA.Text = Val(txtVtaIVA.Text).ToString("N0")
            txtVtaEsp.Text = Val(txtVtaEsp.Text).ToString("N0")
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub
    Private Sub MostrarDatosCliente(Optional ByVal IncluirRutCliente As Boolean = False)
        Try
            Dim Cliente As New clsCliente
            Dim R As clsCliente.dtCliente = Cliente.MostrarCliente(txtRecepRut.Text)
            txtRecepRazonSocial.Text = R.RazonSocial
            txtRecepDireccion.Text = R.Direccion
            txtRecepGiro.Text = R.Giro
            txtRecepComuna.Text = R.Comuna
            txtRecepCiudad.Text = R.Ciudad
            If IncluirRutCliente Then txtRecepRut.Text = R.RutCliente
            txtPrecioCliente.Text = clsCliente.Precio(R.IdCliente)
            'Dim Facturacion As New clsFacturacionMensual
            Dim Neto As Integer = 0, Esp As Integer = 0
            'ItemsFactura = Facturacion.ListaGuiasAFacturar(R.IdCliente, Neto, Esp)
            'DGV_Items.DataSource = Nothing
            'DGV_Items.DataSource = ItemsFactura
            CalculoTotales(Neto, Esp)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub Inicio()
        'Grupo 1
        txtFecha.Value = Now
        txtRecepRut.Text = ""
        txtRecepRazonSocial.Text = ""
        txtRecepDireccion.Text = ""
        txtRecepGiro.Text = ""
        txtRecepComuna.Text = ""
        txtRecepCiudad.Text = ""
        nroFolio.Value = clsFolio.NroProximaFactura
        'Grupo 2
        txtIEComBase.Text = clsIndicadores.IEComponenteBase
        txtIEComVar.Text = clsIndicadores.IEComponenteVariable
        txtUTM.Text = clsIndicadores.UTMActual
        txtPrecioCliente.Text = ""
        'Grupo 3
        txtVtaLitros.Text = ""
        txtVtaPrecioNeto.Text = ""
        txtVtaNeto.Text = ""
        txtVtaIVA.Text = ""
        txtVtaEsp.Text = ""
        txtVtaTotal.Text = ""



        If nroFolio.Value = 0 Then
            Err(Mensajes.Errores.sinFoliosDisponibles.Replace("·tipoDTE·", "Factura Electronica").Replace("(·Folio·)", ""))
        End If

    End Sub

    Private Sub frmEmitirFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim LinkMepco As String = "http://www.sii.cl/valores_y_fechas/mepco/mepco|año|.htm".Replace("|año|", Format(Now, "yyyy"))
            Dim LinkUTM As String = "http://www.sii.cl/valores_y_fechas/utm/utm|año|.htm".Replace("|año|", Format(Now, "yyyy"))
            Dim LinkPrecio As String = "http://www.bencinaenlinea.cl/web2/buscador.php?region=10"
            LinkLabel1.Links.Add(0, LinkLabel1.Text.Length, LinkMepco)
            LinkLabel2.Links.Add(0, LinkLabel2.Text.Length, LinkMepco)
            LinkLabel3.Links.Add(0, LinkLabel3.Text.Length, LinkUTM)
            LinkLabel4.Links.Add(0, LinkLabel4.Text.Length, LinkPrecio)
            Inicio()
        Catch ex As Exception
            BtnGenerarFactura.Enabled = False
            Err(ex.Message, True)
        Finally
            txtRecepRut.Focus()
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub txtRecepRut_Leave(sender As Object, e As EventArgs) Handles txtRecepRut.Leave
        Try
            txtRecepRut.Text = txtRecepRut.Text.ToUpper
            If txtRecepRut.Text.Trim.Length = 0 Then Exit Sub
            If dllFunciones.Erik.ValidaRut(txtRecepRut.Text) Then
                MostrarDatosCliente()
            Else
                Err(Mensajes.Errores.RutInvalido)
            End If
        Catch ex As Exception
            Err(ex.Message, True)
        End Try
    End Sub

    Private Sub txtIEComVar_Leave(sender As Object, e As EventArgs) Handles txtIEComVar.Leave
        txtIEComVar.Text = CDbl(Val(txtIEComVar.Text.Replace(",", ".")))
        If txtIEComVar.Text > 10 Then
            MsgBox(Mensajes.Advertencias.IEVarAlto, MsgBoxStyle.Exclamation, App.Nombre)
        End If
    End Sub

    Private Sub txtPrecioCliente_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioCliente.TextChanged
        txtVtaPrecioNeto.Text = PrecioNeto(Val(txtPrecioCliente.Text), Val(txtIEComBase.Text.Replace(",", ".")), Val(txtIEComVar.Text.Replace(",", ".")), Val(txtUTM.Text))
    End Sub

    Private Sub txtUTM_TextChanged(sender As Object, e As EventArgs) Handles txtUTM.TextChanged
        txtVtaPrecioNeto.Text = PrecioNeto(Val(txtPrecioCliente.Text), Val(txtIEComBase.Text.Replace(",", ".")), Val(txtIEComVar.Text.Replace(",", ".")), Val(txtUTM.Text))
    End Sub

    Private Sub txtIEComVar_TextChanged(sender As Object, e As EventArgs) Handles txtIEComVar.TextChanged
        txtVtaPrecioNeto.Text = PrecioNeto(Val(txtPrecioCliente.Text), Val(txtIEComBase.Text.Replace(",", ".")), Val(txtIEComVar.Text.Replace(",", ".")), Val(txtUTM.Text))
    End Sub

    Private Sub txtVtaPrecioNeto_TextChanged(sender As Object, e As EventArgs) Handles txtVtaPrecioNeto.TextChanged
        CalculoFacturas()
    End Sub

    Private Sub txtVtaLitros_TextChanged(sender As Object, e As EventArgs) Handles txtVtaLitros.TextChanged
        CalculoFacturas()
    End Sub

    Private Sub BtnGenerarFactura_Click(sender As Object, e As EventArgs) Handles BtnGenerarFactura.Click
        Dim FechaDoc As DateTime = Now
        Dim FolioFact As Integer = 0
        Dim LtrVta As Integer = 0
        Dim OdoInicial As Int64 = 0
        Dim OdoFinal As Int64 = 0
        Try
            If Val(txtVtaLitros.Text.Replace(".", "").Replace(",", "")) = 0 _
                Or Val(txtVtaPrecioNeto.Text.Replace(".", "").Replace(",", "")) = 0 _
                Or Val(txtVtaNeto.Text.Replace(".", "").Replace(",", "")) = 0 _
                Or Val(txtVtaIVA.Text.Replace(".", "").Replace(",", "")) = 0 _
                Or Val(txtVtaEsp.Text.Replace(".", "").Replace(",", "")) = 0 _
                Or Val(txtVtaTotal.Text.Replace(".", "").Replace(",", "")) = 0 Then
                Throw New System.Exception(Mensajes.Errores.TotalesRequeridos)
            End If

            'If DiferenciaListros(lblDiferenciaListros.Text, txtVtaLitros.Text) Then Exit Sub
            Dim Cliente As New clsCliente
            If dllFunciones.Erik.ValidaRut(txtRecepRut.Text) Then
                If Cliente.GuardarCliente(txtRecepRut.Text, txtRecepRazonSocial.Text, txtRecepGiro.Text, txtRecepDireccion.Text, txtRecepComuna.Text, txtRecepCiudad.Text) Then
                    clsCliente.GuardarPrecio(IdRut(txtRecepRut.Text), txtPrecioCliente.Text)
                    MostrarDatosCliente(True)
                    If txtPrecioCliente.Text = 0 Then Throw New System.Exception(Mensajes.Errores.ErrPrecio)
                    clsIndicadores.GuardarIE(txtIEComBase.Text, txtIEComVar.Text)
                    Dim UTM As Integer = clsIndicadores.UTMActual
                    If UTM = 0 Then clsIndicadores.GuardarUTM(txtUTM.Text)
                    txtUTM.Text = clsIndicadores.UTMActual
                    If txtUTM.Text = 0 Then Throw New System.Exception(Mensajes.Errores.ErrUTM)

                    'FechaDoc = Now
                    'FolioFact = nroFolio.Value
                    'LtrVta = txtVtaLitros.Text
                    'OdoInicial = txtOdoMiterMin.Text
                    'OdoFinal = txtOdoMiterMax.Text

                    EmitirFactura()

                End If
            Else
                Err(Mensajes.Errores.RutInvalido)
            End If

        Catch ex As Exception
            Err(ex.Message, True)
        End Try
    End Sub

    Private Sub frmEmitirFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmEmitirFactura_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtRecepRut.Focus()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub txtPrecioCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtVtaLitros.Focus()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim F As New frmBuscarClientes(Me)
            F.ShowDialog()
            If txtRecepRut.Text.Trim.Length > 0 Then
                MostrarDatosCliente()
                txtVtaLitros.Focus()
            End If

        Catch ex As Exception
            Err(ex.Message, True)
        End Try
    End Sub

    Private Sub frmEmitirFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case Keys.F1 : Button3.PerformClick()

        End Select
    End Sub
End Class