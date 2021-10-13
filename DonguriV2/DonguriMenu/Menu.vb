Public Class Menu
    Private Sub button_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnHelperBaseM.MouseMove, btnUserBaseM.MouseMove, btnHelperBaseD.MouseMove, btnSchedule.MouseMove, btnBackup.MouseMove, btnRestore.MouseMove, btnErrcheck.MouseMove, btnRstJobTimeHM.MouseMove, btnPay.MouseMove, btnUserBaseD.MouseMove, btnUser.MouseMove, btnHelper.MouseMove, btnCalendar.MouseMove
        sender.forecolor = Color.Red
    End Sub

    Private Sub button_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelperBaseM.MouseLeave, btnUserBaseM.MouseLeave, btnHelperBaseD.MouseLeave, btnSchedule.MouseLeave, btnBackup.MouseLeave, btnRestore.MouseLeave, btnErrcheck.MouseLeave, btnRstJobTimeHM.MouseLeave, btnPay.MouseLeave, btnUserBaseD.MouseLeave, btnUser.MouseLeave, btnHelper.MouseLeave, btnCalendar.MouseLeave
        sender.forecolor = Color.Blue
    End Sub

    Private Sub btnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUser.Click
        Dim dlg As New DonguriUser.UserSelect
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnHelper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelper.Click
        Dim dlg As New DonguriHelper.HelperSelect
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnUserBaseD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserBaseD.Click
        Dim dlg As New DonguriPrint.ScheduleDay
        dlg.Text = sender.text
        dlg.mIsUser = True
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnHelperBaseD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelperBaseD.Click
        Dim dlg As New DonguriPrint.ScheduleDay
        dlg.Text = sender.text
        dlg.mIsUser = False
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnUserBaseM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserBaseM.Click
        Dim dlg As New DonguriPrint.ScheduleMonth
        dlg.Text = sender.text
        dlg.mIsUser = True
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnHelperBaseM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelperBaseM.Click
        Dim dlg As New DonguriPrint.ScheduleMonth
        dlg.Text = sender.text
        dlg.mIsUser = False
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalendar.Click
        Dim dlg As New DonguriCalendar.Calendar
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSchedule.Click
        Me.Visible = False
        Dim dlg As New DonguriSchedule.Schedule
        dlg.ShowDialog(Me)
        dlg.Dispose()
        Me.Visible = True
    End Sub

    Private Sub btnErrcheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnErrcheck.Click
        Me.Visible = False
        Dim dlg As New DonguriSchedule.ErrorCheck
        dlg.Tag = "" '対象年月日指定
        dlg.ShowDialog(Me)
        dlg.Dispose()
        Me.Visible = True
    End Sub

    Private Sub btnPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPay.Click
        Dim dlg As New DonguriPay.PaySelect
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnSchJobTimeHM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSchJobTimeHM.Click
        Dim dlg As New DonguriPrint.JobTimeMonth
        dlg.Text = btnSchJobTimeHM.Text
        dlg.Tag = "H1"
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnRstJobTimeHM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRstJobTimeHM.Click
        Dim dlg As New DonguriPrint.JobTimeMonth
        dlg.Text = btnRstJobTimeHM.Text
        dlg.Tag = "H2"
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
        Me.Enabled = False
        If Dir("D:\DonguriV2\Data\Master.txt", FileAttribute.Normal) = "" Then
            'スレーブモード（スケジュール書出）
            Dim dlg As New DonguriMenu.MonthExport
            dlg.ShowDialog(Me)
            dlg.Dispose()
        Else
            'マスターモード（バックアップ）
            If fbDlg.ShowDialog(Me) = DialogResult.OK Then
                Call ExecBackUp(True, fbDlg.SelectedPath & "\DB" & Now.ToString("yyyyMMddHHmmss") & ".bak")
            End If
        End If
        Me.Enabled = True
    End Sub

    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click
        If Dir("D:\DonguriV2\Data\Master.txt", FileAttribute.Normal) = "" Then
            'スレーブモード（データベースの復元）
            ofDlg.Title = "バックアップファイルを選択してください"
            ofDlg.FilterIndex = 1
            If ofDlg.ShowDialog() = DialogResult.OK Then
                Call ExecSlaveRestore(True, ofDlg.FileName)
            End If
        Else
            ofDlg.Title = "スケジュールファイルを選択してください"
            ofDlg.FilterIndex = 2
            If ofDlg.ShowDialog() = DialogResult.OK Then
                'マスターモード（スケジュール取り込み）
                Dim cntIn As Integer = 0
                Dim cntUp As Integer = 0
                Dim cntIs As Integer = 0
                Dim cntSk As Integer = 0
                Dim mn As String = ofDlg.SafeFileName.Substring(3, 4) & "/" & ofDlg.SafeFileName.Substring(7, 2) '年月
                Dim rslt As Integer = MsgBox("対象年月 = [" & mn & "] の取り込みを開始します。" & vbCrLf & "よろしいですか？", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "取込確認")
                If rslt = MsgBoxResult.Yes Then
                    Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                        cn.Open()
                        Using ps As New Microsoft.VisualBasic.FileIO.TextFieldParser(ofDlg.FileName, System.Text.Encoding.GetEncoding("Shift_JIS"))
                            ps.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
                            ps.SetDelimiters(",") ' 区切り文字はコンマ
                            ps.HasFieldsEnclosedInQuotes = True
                            ps.TrimWhiteSpace = True
                            Do While Not ps.EndOfData
                                Dim row As String() = ps.ReadFields() ' 1行読み込み
                                cntIn += 1
                                Dim bRow As Boolean
                                Dim vn As String = ""
                                Dim hn As String = ""
                                Dim at As Boolean = False
                                Dim ic As Boolean = False
                                Using cmd As New SqlClient.SqlCommand("SP_SEL_IMPORTSCHEDULE", cn)
                                    cmd.CommandType = Data.CommandType.StoredProcedure
                                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = CInt(row(0)) '利用者名
                                    cmd.Parameters.Add("@HelperId", SqlDbType.Int).Value = CInt(row(1)) 'ヘルパー名
                                    cmd.Parameters.Add("@JobId", SqlDbType.Int).Value = CInt(row(2)) '業務内容
                                    cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = CInt(row(3)) '予定/実績
                                    cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = CDate(row(4)) '対象日
                                    cmd.Parameters.Add("@FromTime", SqlDbType.DateTime).Value = CDate(row(5)) '開始時刻
                                    cmd.Parameters.Add("@ToTime", SqlDbType.DateTime).Value = CDate(row(6)) '終了時刻
                                    Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                                    bRow = dr.HasRows
                                    If dr.Read() Then
                                        If dr("ViewNote") Is DBNull.Value Then vn = "" Else vn = dr("ViewNote").ToString.Trim
                                        If dr("HideNote") Is DBNull.Value Then hn = "" Else hn = dr("HideNote").ToString.Trim
                                        If dr("Attention") Is DBNull.Value Then at = False Else at = DirectCast(dr("Attention"), Boolean)
                                        If dr("IsCancel") Is DBNull.Value Then ic = False Else ic = DirectCast(dr("IsCancel"), Boolean)
                                    End If
                                    dr.Close()
                                End Using
                                If bRow Then
                                    If (vn = row(7)) And (hn = row(8)) And (at = CBool(row(9))) And (ic = CBool(row(10))) Then
                                        cntSk += 1
                                    Else
                                        '既存備考がある場合既存分を優先とする
                                        If (vn <> "") Then row(7) = vn
                                        If (hn <> "") Then row(8) = hn
                                        If at Or (row(9).ToUpper = "TRUE") Then row(9) = "True" 'どちらか True なら True
                                        If ic Or (row(10).ToUpper = "TRUE") Then row(10) = "True" 'どちらか True なら True
                                        Using cmd As New SqlClient.SqlCommand("SP_UPD_IMPORTSCHEDULE", cn)
                                            cmd.CommandType = Data.CommandType.StoredProcedure
                                            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = CInt(row(0)) '利用者名
                                            cmd.Parameters.Add("@HelperId", SqlDbType.Int).Value = CInt(row(1)) 'ヘルパー名
                                            cmd.Parameters.Add("@JobId", SqlDbType.Int).Value = CInt(row(2)) '業務内容
                                            cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = CInt(row(3)) '予定/実績
                                            cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = CDate(row(4)) '対象日
                                            cmd.Parameters.Add("@FromTime", SqlDbType.DateTime).Value = CDate(row(5)) '開始時刻
                                            cmd.Parameters.Add("@ToTime", SqlDbType.DateTime).Value = CDate(row(6)) '終了時刻
                                            cmd.Parameters.Add("@ViewNote", SqlDbType.VarChar, 100).Value = row(7) '備考
                                            cmd.Parameters.Add("@HideNote", SqlDbType.VarChar, 100).Value = row(8) '備考
                                            cmd.Parameters.Add("@Attention", SqlDbType.Bit).Value = row(9) '注記
                                            cmd.Parameters.Add("@IsCancel", SqlDbType.Bit).Value = row(10) '取消線
                                            cmd.ExecuteNonQuery()
                                            cntUp += 1
                                        End Using
                                    End If
                                Else
                                    Using cmd As New SqlClient.SqlCommand("SP_INS_IMPORTSCHEDULE", cn)
                                        cmd.CommandType = Data.CommandType.StoredProcedure
                                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = CInt(row(0)) '利用者名
                                        cmd.Parameters.Add("@HelperId", SqlDbType.Int).Value = CInt(row(1)) 'ヘルパー名
                                        cmd.Parameters.Add("@JobId", SqlDbType.Int).Value = CInt(row(2)) '業務内容
                                        cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = CInt(row(3)) '予定/実績
                                        cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = CDate(row(4)) '対象日
                                        cmd.Parameters.Add("@FromTime", SqlDbType.DateTime).Value = CDate(row(5)) '開始時刻
                                        cmd.Parameters.Add("@ToTime", SqlDbType.DateTime).Value = CDate(row(6)) '終了時刻
                                        cmd.Parameters.Add("@ViewNote", SqlDbType.VarChar, 100).Value = row(7) '備考
                                        cmd.Parameters.Add("@HideNote", SqlDbType.VarChar, 100).Value = row(8) '備考
                                        cmd.Parameters.Add("@Attention", SqlDbType.Bit).Value = row(9) '注記
                                        cmd.Parameters.Add("@IsCancel", SqlDbType.Bit).Value = row(10) '取消線
                                        cmd.ExecuteNonQuery()
                                        cntIs += 1
                                    End Using
                                End If
                            Loop
                        End Using
                        cn.Close()
                    End Using
                End If
                Dim mg As String = "入力件数　= " & cntIn & "件" & vbCrLf
                mg &= "更新件数　= " & cntUp & "件" & vbCrLf
                mg &= "新規件数　= " & cntIs & "件" & vbCrLf
                mg &= "既存件数　= " & cntSk & "件" & vbCrLf
                mg &= "にて登録されました。"
                MsgBox(mg, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "登録完了")
            End If
        End If
    End Sub

    Private Sub ExecBackUp(ByVal msg As Boolean, ByVal fl As String)
        Me.Enabled = False
        Try
            'サーバへの接続情報を設定
            Dim sv As New Server
            sv.ConnectionContext.ServerInstance = "localhost\SQLEXPRESS"
            sv.ConnectionContext.LoginSecure = True
            'バックアップの動作を決める
            Dim bk As New Backup
            bk.Action = BackupActionType.Database
            'バックアップ対象のデータベースを指定
            bk.Database = "D:\DonguriV2\Data\Donguri_Data.mdf"
            '完全バックアップにする
            'IncrementalプロパティをTrueにすると増分バックアップになる
            bk.Incremental = False
            bk.Initialize = True
            bk.LogTruncation = BackupTruncateLogType.Truncate
            'バックアップ先の指定
            Dim dv As New BackupDeviceItem(fl, DeviceType.File)
            bk.Devices.Add(dv)
            bk.PercentCompleteNotification = 10
            'バックアップの実行
            bk.SqlBackup(sv)
            If msg Then MsgBox("バックアップファイルが" & vbCrLf & fl & vbCrLf & "に作成されました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "バックアップ完了")
        Catch ex As Exception
            If msg Then MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "バックアップ失敗")
        End Try
        Me.Enabled = True
    End Sub

    Private Sub ExecSlaveRestore(ByVal msg As Boolean, ByVal fl As String)
        Me.Enabled = False
        Try
            Dim sv As New Server 'サーバへの接続情報を設定
            sv.ConnectionContext.ServerInstance = "localhost\SQLEXPRESS"
            sv.ConnectionContext.LoginSecure = True
            '復元に利用するバックアップを指定
            Dim rs As New Restore
            rs.Devices.AddDevice(fl, DeviceType.File)
            Dim er As String = ""
            If rs.SqlVerify(sv, er) = False Then
                MsgBox(er, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ＤＢ破損")
                Exit Sub
            End If
            rs.Database = "D:\DonguriV2\Data\Donguri_Data.mdf"
            rs.ReplaceDatabase = True
            rs.PercentCompleteNotification = 10
            rs.SqlRestore(sv)
            If msg Then MsgBox("取込が完了しました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "完了通知")
        Catch ex As Exception
            If msg Then MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "異常終了")
        End Try
        Me.Enabled = True
    End Sub



    Private Sub btnSchJobTimeUM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSchJobTimeUM.Click
        Dim dlg As New DonguriPrint.JobTimeMonth
        dlg.Text = btnSchJobTimeUM.Text
        dlg.Tag = "U1"
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub btnRstJobTimeUM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRstJobTimeUM.Click
        Dim dlg As New DonguriPrint.JobTimeMonth
        dlg.Text = btnRstJobTimeUM.Text
        dlg.Tag = "U2"
        dlg.ShowDialog(Me)
        dlg.Dispose()
    End Sub

    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Dir("D:\DonguriV2\Data\Master.txt", FileAttribute.Normal) = "" Then
            btnUser.Enabled = False
            btnHelper.Enabled = False
            btnCalendar.Enabled = False
            btnPay.Enabled = False
            btnBackup.Text = "スケジュール出力"
            btnRestore.Text = "データベース取込"
        Else
            btnBackup.Text = "データベース書出"
            btnRestore.Text = "スケジュール読込"
        End If
    End Sub

    Private Sub btnQuit_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuit.Disposed
        Dim dl As String = Now.AddDays(-7).ToString("yyyyMMdd")
        Dim fn As String = Dir("D:\DonguriV2\Backup\DB????????.bak")
        Do While (fn <> "")
            '1週間前のバックアップを削除する
            If fn.Substring(2, 8) < dl Then My.Computer.FileSystem.DeleteFile("D:\DonguriV2\Backup\" & fn)
            fn = Dir()
        Loop
        Call ExecBackUp(False, "D:\DonguriV2\Backup\DB" & Now.ToString("yyyyMMdd") & ".bak")
    End Sub
End Class
