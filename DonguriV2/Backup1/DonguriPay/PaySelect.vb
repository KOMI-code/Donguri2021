Public Class PaySelect

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Me.Visible = False
        Dim dlg As New DonguriPay.PayReg
        dlg.Tag = cmbPaySelect.Text
        dlg.ShowDialog(Me)
        dlg.Dispose()
        Me.Close()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub PaySelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_PAYFROMDATE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbPaySelect.Items.Clear()
                cmbPaySelect.Items.Add("<< 新規 >>")
                Do While dr.Read()
                    cmbPaySelect.Items.Add(DirectCast(dr("FromDate"), Date).ToString("yyyy/MM/dd"))
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
        cmbPaySelect.SelectedIndex = 0
    End Sub
End Class