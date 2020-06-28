<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.EmitirFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolicitarFoliosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmitirFacturaToolStripMenuItem, Me.SolicitarFoliosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(817, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EmitirFacturaToolStripMenuItem
        '
        Me.EmitirFacturaToolStripMenuItem.Name = "EmitirFacturaToolStripMenuItem"
        Me.EmitirFacturaToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.EmitirFacturaToolStripMenuItem.Text = "Emitir Factura"
        '
        'SolicitarFoliosToolStripMenuItem
        '
        Me.SolicitarFoliosToolStripMenuItem.Name = "SolicitarFoliosToolStripMenuItem"
        Me.SolicitarFoliosToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.SolicitarFoliosToolStripMenuItem.Text = "Solicitar Folios"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 477)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VGR - Camion [Adic]"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents EmitirFacturaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SolicitarFoliosToolStripMenuItem As ToolStripMenuItem
End Class
