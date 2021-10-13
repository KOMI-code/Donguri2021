Public Class MonthExport

    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click
        Me.Enabled = False
        If fbDlg.ShowDialog(Me) = DialogResult.OK Then
            Dim fl As String = fbDlg.SelectedPath & "\SCH" & dtpMonth.Value.ToString("yyyyMM") & ".csv"
            Dim sw As New System.IO.StreamWriter(fl, False, System.Text.Encoding.GetEncoding("shift_jis"))
            Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                cn.Open()
                Using cmd As New SqlClient.SqlCommand("SP_SEL_USERMONTHSCHEDULE", cn)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = dtpMonth.Value
                    cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = 0 '予定/実績抽出
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全利用者
                    cmd.Parameters.Add("@St", SqlDbType.VarChar, 50).Value = "[UserId],[Target],[FromTime],[TypeId]"
                    Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read()
                        Dim db As New DonguriLib.LibClass.T_Schedule
                        db.SetReader(dr)
                        sw.WriteLine(db.ToScheduleCSV)
                    Loop
                    dr.Close()
                End Using
                cn.Close()
            End Using
            sw.Close()
            MsgBox(dtpMonth.Value.ToString("yyyy年MM月") & "分スケジュールが" & vbCrLf & fl & vbCrLf & "に作成されました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "バックアップ完了")
        End If
        Me.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub
End Class