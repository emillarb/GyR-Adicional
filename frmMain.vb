Public Class frmMain
    Private Sub EmitirFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmitirFacturaToolStripMenuItem.Click
        frmEmitirFactura.MdiParent = Me
        frmEmitirFactura.Show()
        frmEmitirFactura.BringToFront()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Config As New Stic.Config
        Stic.Config.LeerArchivoConf()
        Me.Text &= " | " & Stic.Config.Nombre
        Config.CrearBaseDatosSQLite()
        'MsgBox(Patente)
    End Sub

    Private Sub SolicitarFoliosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolicitarFoliosToolStripMenuItem.Click
        frmSolicitarFolios.MdiParent = Me
        frmSolicitarFolios.Show()
        frmSolicitarFolios.BringToFront()
    End Sub
End Class
