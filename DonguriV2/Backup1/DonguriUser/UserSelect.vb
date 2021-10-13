Public Class UserSelect
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Me.Visible = False
        Dim dlg As New DonguriUser.UserReg
        dlg.Tag = DirectCast(cmbUserSelect.SelectedItem, DonguriLib.LibClass.ComboItem).Id.ToString '選択された利用者のIDを設定する（新規の場合ID=0）
        dlg.ShowDialog(Me)
        dlg.Dispose()
        Me.Close()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub UserSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_USER", cn)
                '利用者氏名取得
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全利用者対象
                cmd.Parameters.Add("@IsAll", SqlDbType.Bit).Value = True '非稼働分も対象
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbUserSelect.Items.Clear()
                Dim ci0 As New DonguriLib.LibClass.ComboItem
                ci0.Id = 0
                ci0.Value = "<< 新規 >>"
                cmbUserSelect.Items.Add(ci0)
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_User
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToUserName
                    cmbUserSelect.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
        cmbUserSelect.SelectedIndex = 0
        cmbUserSelect.Focus()
    End Sub
End Class