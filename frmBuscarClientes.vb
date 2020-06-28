Public Class frmBuscarClientes
    Private FrmFact As frmEmitirFactura = Nothing
    Private Sub Inicio(Optional ByVal NombreFrmPadre As String = "")
        Try
            Me.Width = 1098
            Dim V As New clsVistas
            DataGridView1.DataSource = V.VistaEntregas
            DataGridView1.RowHeadersVisible = False
            DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.Columns(0).Visible = False
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.AllowUserToResizeColumns = True
            DataGridView1.ReadOnly = True
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Inicio()
    End Sub
    Public Sub New(Frm As frmEmitirFactura)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'Inicio(Frm.Name)
        FrmFact = Frm
    End Sub

    Private Sub frmBuscarClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyValue
            Case Keys.Escape : Me.Close()
        End Select
    End Sub

    Private Sub frmBuscarClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Try
            FrmFact.txtRecepRut.Text = DataGridView1.CurrentRow.Cells(1).Value
            FrmFact.txtVtaLitros.Text = DataGridView1.CurrentRow.Cells(8).Value.Replace(".", "")
            Me.Close()
        Catch ex As Exception
            Err(ex.Message, True)
        End Try
    End Sub
End Class