<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmitirFactura
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.nroFolio = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRecepGiro = New System.Windows.Forms.TextBox()
        Me.txtRecepCiudad = New System.Windows.Forms.TextBox()
        Me.txtRecepComuna = New System.Windows.Forms.TextBox()
        Me.txtRecepDireccion = New System.Windows.Forms.TextBox()
        Me.txtRecepRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtRecepRut = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BtnGenerarFactura = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtVtaIVA = New System.Windows.Forms.TextBox()
        Me.txtVtaNeto = New System.Windows.Forms.TextBox()
        Me.txtVtaTotal = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtVtaEsp = New System.Windows.Forms.TextBox()
        Me.txtVtaLitros = New System.Windows.Forms.TextBox()
        Me.txtVtaPrecioNeto = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUTM = New System.Windows.Forms.TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.txtPrecioCliente = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtIEComVar = New System.Windows.Forms.TextBox()
        Me.txtIEComBase = New System.Windows.Forms.TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nroFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtFecha)
        Me.GroupBox2.Controls.Add(Me.nroFolio)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtRecepGiro)
        Me.GroupBox2.Controls.Add(Me.txtRecepCiudad)
        Me.GroupBox2.Controls.Add(Me.txtRecepComuna)
        Me.GroupBox2.Controls.Add(Me.txtRecepDireccion)
        Me.GroupBox2.Controls.Add(Me.txtRecepRazonSocial)
        Me.GroupBox2.Controls.Add(Me.txtRecepRut)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(721, 130)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Cliente"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(480, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Fecha"
        '
        'txtFecha
        '
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(556, 45)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(159, 20)
        Me.txtFecha.TabIndex = 6
        '
        'nroFolio
        '
        Me.nroFolio.Enabled = False
        Me.nroFolio.Location = New System.Drawing.Point(616, 20)
        Me.nroFolio.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nroFolio.Name = "nroFolio"
        Me.nroFolio.ReadOnly = True
        Me.nroFolio.Size = New System.Drawing.Size(99, 20)
        Me.nroFolio.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(581, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Folio"
        '
        'txtRecepGiro
        '
        Me.txtRecepGiro.Location = New System.Drawing.Point(82, 97)
        Me.txtRecepGiro.MaxLength = 250
        Me.txtRecepGiro.Name = "txtRecepGiro"
        Me.txtRecepGiro.Size = New System.Drawing.Size(392, 20)
        Me.txtRecepGiro.TabIndex = 5
        Me.txtRecepGiro.Text = "f"
        '
        'txtRecepCiudad
        '
        Me.txtRecepCiudad.Location = New System.Drawing.Point(556, 97)
        Me.txtRecepCiudad.MaxLength = 100
        Me.txtRecepCiudad.Name = "txtRecepCiudad"
        Me.txtRecepCiudad.Size = New System.Drawing.Size(159, 20)
        Me.txtRecepCiudad.TabIndex = 8
        Me.txtRecepCiudad.Text = "f"
        '
        'txtRecepComuna
        '
        Me.txtRecepComuna.Location = New System.Drawing.Point(556, 71)
        Me.txtRecepComuna.MaxLength = 100
        Me.txtRecepComuna.Name = "txtRecepComuna"
        Me.txtRecepComuna.Size = New System.Drawing.Size(159, 20)
        Me.txtRecepComuna.TabIndex = 7
        Me.txtRecepComuna.Text = "f"
        '
        'txtRecepDireccion
        '
        Me.txtRecepDireccion.Location = New System.Drawing.Point(82, 71)
        Me.txtRecepDireccion.MaxLength = 250
        Me.txtRecepDireccion.Name = "txtRecepDireccion"
        Me.txtRecepDireccion.Size = New System.Drawing.Size(392, 20)
        Me.txtRecepDireccion.TabIndex = 4
        Me.txtRecepDireccion.Text = "f"
        '
        'txtRecepRazonSocial
        '
        Me.txtRecepRazonSocial.Location = New System.Drawing.Point(82, 45)
        Me.txtRecepRazonSocial.MaxLength = 250
        Me.txtRecepRazonSocial.Name = "txtRecepRazonSocial"
        Me.txtRecepRazonSocial.Size = New System.Drawing.Size(392, 20)
        Me.txtRecepRazonSocial.TabIndex = 3
        Me.txtRecepRazonSocial.Text = "f"
        '
        'txtRecepRut
        '
        Me.txtRecepRut.Location = New System.Drawing.Point(82, 19)
        Me.txtRecepRut.Name = "txtRecepRut"
        Me.txtRecepRut.Size = New System.Drawing.Size(95, 20)
        Me.txtRecepRut.TabIndex = 2
        Me.txtRecepRut.Text = "f"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Giro"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(480, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Ciudad"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(480, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Comuna"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "Direccion"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Razon Social"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Rut"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.BtnGenerarFactura)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 321)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(721, 51)
        Me.GroupBox5.TabIndex = 49
        Me.GroupBox5.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(291, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 28)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'BtnGenerarFactura
        '
        Me.BtnGenerarFactura.Location = New System.Drawing.Point(6, 19)
        Me.BtnGenerarFactura.Name = "BtnGenerarFactura"
        Me.BtnGenerarFactura.Size = New System.Drawing.Size(156, 26)
        Me.BtnGenerarFactura.TabIndex = 14
        Me.BtnGenerarFactura.Text = "Generar Factura"
        Me.BtnGenerarFactura.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(638, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 26)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Cerrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtVtaIVA)
        Me.GroupBox3.Controls.Add(Me.txtVtaNeto)
        Me.GroupBox3.Controls.Add(Me.txtVtaTotal)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.txtVtaEsp)
        Me.GroupBox3.Controls.Add(Me.txtVtaLitros)
        Me.GroupBox3.Controls.Add(Me.txtVtaPrecioNeto)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 222)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(721, 93)
        Me.GroupBox3.TabIndex = 48
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Producto Diesel"
        '
        'txtVtaIVA
        '
        Me.txtVtaIVA.Enabled = False
        Me.txtVtaIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVtaIVA.Location = New System.Drawing.Point(418, 48)
        Me.txtVtaIVA.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVtaIVA.Name = "txtVtaIVA"
        Me.txtVtaIVA.ReadOnly = True
        Me.txtVtaIVA.Size = New System.Drawing.Size(95, 26)
        Me.txtVtaIVA.TabIndex = 33
        Me.txtVtaIVA.Text = "99.999.999"
        Me.txtVtaIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVtaNeto
        '
        Me.txtVtaNeto.Enabled = False
        Me.txtVtaNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVtaNeto.Location = New System.Drawing.Point(319, 48)
        Me.txtVtaNeto.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVtaNeto.Name = "txtVtaNeto"
        Me.txtVtaNeto.ReadOnly = True
        Me.txtVtaNeto.Size = New System.Drawing.Size(95, 26)
        Me.txtVtaNeto.TabIndex = 32
        Me.txtVtaNeto.Text = "99.999.999"
        Me.txtVtaNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVtaTotal
        '
        Me.txtVtaTotal.Enabled = False
        Me.txtVtaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVtaTotal.Location = New System.Drawing.Point(616, 48)
        Me.txtVtaTotal.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVtaTotal.Name = "txtVtaTotal"
        Me.txtVtaTotal.ReadOnly = True
        Me.txtVtaTotal.Size = New System.Drawing.Size(95, 26)
        Me.txtVtaTotal.TabIndex = 31
        Me.txtVtaTotal.Text = "99.999.999"
        Me.txtVtaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(315, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(47, 20)
        Me.Label23.TabIndex = 30
        Me.Label23.Text = "Neto"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(612, 27)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 20)
        Me.Label24.TabIndex = 29
        Me.Label24.Text = "Total"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(513, 27)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(92, 20)
        Me.Label25.TabIndex = 28
        Me.Label25.Text = "Especifico"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(414, 26)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(54, 20)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "I.V.A."
        '
        'txtVtaEsp
        '
        Me.txtVtaEsp.Enabled = False
        Me.txtVtaEsp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVtaEsp.Location = New System.Drawing.Point(517, 48)
        Me.txtVtaEsp.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVtaEsp.Name = "txtVtaEsp"
        Me.txtVtaEsp.ReadOnly = True
        Me.txtVtaEsp.Size = New System.Drawing.Size(95, 26)
        Me.txtVtaEsp.TabIndex = 26
        Me.txtVtaEsp.Text = "99.999.999"
        Me.txtVtaEsp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVtaLitros
        '
        Me.txtVtaLitros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVtaLitros.Location = New System.Drawing.Point(65, 48)
        Me.txtVtaLitros.Name = "txtVtaLitros"
        Me.txtVtaLitros.Size = New System.Drawing.Size(87, 26)
        Me.txtVtaLitros.TabIndex = 12
        Me.txtVtaLitros.Text = "285.8595"
        Me.txtVtaLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVtaPrecioNeto
        '
        Me.txtVtaPrecioNeto.Enabled = False
        Me.txtVtaPrecioNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVtaPrecioNeto.Location = New System.Drawing.Point(170, 48)
        Me.txtVtaPrecioNeto.Name = "txtVtaPrecioNeto"
        Me.txtVtaPrecioNeto.ReadOnly = True
        Me.txtVtaPrecioNeto.Size = New System.Drawing.Size(87, 26)
        Me.txtVtaPrecioNeto.TabIndex = 24
        Me.txtVtaPrecioNeto.Text = "285.8595"
        Me.txtVtaPrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(166, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(91, 20)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Precio Neto"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(61, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 20)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Litros"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel4)
        Me.GroupBox1.Controls.Add(Me.txtUTM)
        Me.GroupBox1.Controls.Add(Me.LinkLabel3)
        Me.GroupBox1.Controls.Add(Me.LinkLabel2)
        Me.GroupBox1.Controls.Add(Me.txtPrecioCliente)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtIEComVar)
        Me.GroupBox1.Controls.Add(Me.txtIEComBase)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(721, 68)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Indicadores Precio Diesel"
        '
        'txtUTM
        '
        Me.txtUTM.Location = New System.Drawing.Point(469, 31)
        Me.txtUTM.Name = "txtUTM"
        Me.txtUTM.Size = New System.Drawing.Size(62, 20)
        Me.txtUTM.TabIndex = 10
        Me.txtUTM.Text = "99.555"
        Me.txtUTM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(424, 34)
        Me.LinkLabel3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(40, 13)
        Me.LinkLabel3.TabIndex = 33
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "U.T.M."
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(274, 34)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(78, 13)
        Me.LinkLabel2.TabIndex = 33
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Comp. Variable"
        '
        'txtPrecioCliente
        '
        Me.txtPrecioCliente.Location = New System.Drawing.Point(581, 31)
        Me.txtPrecioCliente.Name = "txtPrecioCliente"
        Me.txtPrecioCliente.Size = New System.Drawing.Size(62, 20)
        Me.txtPrecioCliente.TabIndex = 11
        Me.txtPrecioCliente.Text = "99.555"
        Me.txtPrecioCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(136, 34)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(64, 13)
        Me.LinkLabel1.TabIndex = 32
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Comp. Base"
        '
        'txtIEComVar
        '
        Me.txtIEComVar.Location = New System.Drawing.Point(357, 31)
        Me.txtIEComVar.Name = "txtIEComVar"
        Me.txtIEComVar.Size = New System.Drawing.Size(62, 20)
        Me.txtIEComVar.TabIndex = 9
        Me.txtIEComVar.Text = "2.7595"
        Me.txtIEComVar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIEComBase
        '
        Me.txtIEComBase.Location = New System.Drawing.Point(205, 31)
        Me.txtIEComBase.Name = "txtIEComBase"
        Me.txtIEComBase.ReadOnly = True
        Me.txtIEComBase.Size = New System.Drawing.Size(62, 20)
        Me.txtIEComBase.TabIndex = 55
        Me.txtIEComBase.Text = "sdsd"
        Me.txtIEComBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(536, 34)
        Me.LinkLabel4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(37, 13)
        Me.LinkLabel4.TabIndex = 34
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Precio"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(183, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(114, 20)
        Me.Button3.TabIndex = 63
        Me.Button3.Text = "Cargas Clientes [F1]"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmEmitirFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 379)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmEmitirFactura"
        Me.Text = "frmEmitirFactura"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nroFolio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFecha As DateTimePicker
    Friend WithEvents nroFolio As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents txtRecepGiro As TextBox
    Friend WithEvents txtRecepCiudad As TextBox
    Friend WithEvents txtRecepComuna As TextBox
    Friend WithEvents txtRecepDireccion As TextBox
    Friend WithEvents txtRecepRazonSocial As TextBox
    Friend WithEvents txtRecepRut As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents BtnGenerarFactura As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtVtaIVA As TextBox
    Friend WithEvents txtVtaNeto As TextBox
    Friend WithEvents txtVtaTotal As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtVtaEsp As TextBox
    Friend WithEvents txtVtaLitros As TextBox
    Friend WithEvents txtVtaPrecioNeto As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtUTM As TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents txtPrecioCliente As TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtIEComVar As TextBox
    Friend WithEvents txtIEComBase As TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Button3 As Button
End Class
