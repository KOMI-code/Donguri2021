Public Class HelperSelect

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Me.Visible = False
        Dim dlg As New DonguriHelper.HelperReg
        dlg.Tag = DirectCast(cmbHelperSelect.SelectedItem, DonguriLib.LibClass.ComboItem).Id.ToString '選択された利用者のIDを設定する（新規の場合ID=0）
        dlg.ShowDialog(Me)
        dlg.Dispose()
        Me.Close()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub HelperSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPER", cn)
                'ヘルパー氏名取得
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全ヘルパー対象
                cmd.Parameters.Add("@IsAll", SqlDbType.Bit).Value = True '非稼働分も対象
                cmd.Parameters.Add("@Member", SqlDbType.Int).Value = 0 '単独／複合全て対象
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbHelperSelect.Items.Clear()
                Dim ci0 As New DonguriLib.LibClass.ComboItem
                ci0.Id = 0
                ci0.Value = "<< 新規 >>"
                cmbHelperSelect.Items.Add(ci0)
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Helper
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToHelperName
                    cmbHelperSelect.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
        cmbHelperSelect.SelectedIndex = 0
    End Sub
End Class