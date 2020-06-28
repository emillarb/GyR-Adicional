Public Class frmSolicitarFolios
    Private Sub Mostrar()
        Try
            If IsNumeric(cmbDtes.SelectedValue.ToString) Then
                'Dim F As New clsFolio
                Dim Resp As tdFolio = clsFolio.MostrarFolios(cmbDtes.SelectedValue.ToString)
                If Not IsNothing(Resp) Then
                    txtFecha.Text = IIf(Resp.fecha = #1/1/0001 00:00:00#, "S/D", Format(Resp.fecha, "dd-MM-yyyy HH:mm"))
                    txtRangoDesde.Text = IIf(Resp.rDesde = 0, "S/D", Resp.rDesde)
                    txtRangoHasta.Text = IIf(Resp.rHasta = 0, "S/D", Resp.rHasta)
                End If
            End If
        Catch ex As Exception
            txtFecha.Text = ""
            txtRangoDesde.Text = ""
            txtRangoHasta.Text = ""
            Err(ex.Message, True)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If IsNumeric(cmbDtes.SelectedValue.ToString) Then
                Dim F As New clsFolio
                F.SolicitarFolios(cmbDtes.SelectedValue.ToString)
                MsgBox(Mensajes.Correctos.SolicitudFoliosOK, MsgBoxStyle.Information, App.Nombre)
                Mostrar()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, App.Nombre)
        End Try
    End Sub

    Private Sub frmSolicitarFolios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbDtes.DataSource = DTEs()
            cmbDtes.DisplayMember = "DTE"
            cmbDtes.ValueMember = "id"
            Mostrar()
        Catch ex As Exception
            Err(ex.Message, True)
        End Try
    End Sub

    Private Sub cmbDtes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDtes.SelectedIndexChanged
        Mostrar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class