Public Class ScheduleDay
    Public mIsUser As Boolean
    Private Const PDF_FL As String = "D:\DonguriV2\Data\SCHEDULEDAY.PDF"
    Private Const TXT_FL As String = "D:\DonguriV2\Data\SCHEDULEDAY.TXT"
    Private Const EBK_FL As String = "D:\DonguriV2\Data\SCHEDULEDAY.XLSM"
    Private wb As System.Windows.Forms.WebBrowser = Nothing

    Private Sub frmHelperSchDay_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Not (wb Is Nothing) Then wb.Dispose()
    End Sub

    Public Sub SetHelperData()
        Dim sw As New System.IO.StreamWriter(TXT_FL, False, System.Text.Encoding.GetEncoding("shift_jis"))
        Dim xId As Integer = 0
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPERDAYSCHEDULE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = dtpDate.Value '対象月設定
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = 1 '予定抽出
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全件対象
                cmd.Parameters.Add("@St", SqlDbType.Int).Value = 1 'ヘルパー順
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If xId = 0 Then
                    sw.WriteLine("H0001" & StrConv(dtpDate.Value.ToString("yyyy/MM/dd(ddd)"), VbStrConv.Wide)) '対象日
                    sw.WriteLine("H0002ヘルパー名") '基準者
                    sw.WriteLine("H0003利用者名") '対象者
                End If
                If Not dr.HasRows Then sw.WriteLine("H0009") '該当なし
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    Dim st As String = ""
                    If xId <> db.ToSHelperId Then
                        If xId <> 0 Then sw.WriteLine("X0009") '上線指示（全体）
                        xId = db.ToSHelperId
                        sw.WriteLine("D0100" & db.ToSHelperName) 'ヘルパー名
                    End If
                    sw.WriteLine("D0200" & StrConv(db.ToJobTime, VbStrConv.Wide)) '業務時間
                    sw.WriteLine("D0300" & db.ToUserName) '利用者名
                    sw.WriteLine("D0400" & db.ToSinMark) '身体
                    sw.WriteLine("D0500" & db.ToKajMark) '家事
                    sw.WriteLine("D0600" & db.ToIdoMark) '移動
                    sw.WriteLine("D0700" & db.ToTsuMark) '通院
                    sw.WriteLine("D0800" & db.ToEtcMark) 'その他
                    Dim arx As ArrayList = db.ToNoteArray(48, 0)
                    For I As Integer = 0 To arx.Count - 1
                        If arx(I).ToString.Trim <> "" Then
                            sw.WriteLine("D0900" & arx(I).ToString) '備考
                            If I <> (arx.Count - 1) Then
                                If db.ToIsCancel Then sw.WriteLine("X7999") '取消線
                                sw.WriteLine("X0005") '改行
                            End If
                        End If
                    Next I
                    sw.WriteLine("X0008") '下線指示（部分）
                    If db.ToIsCancel Then sw.WriteLine("X7999") '取消線
                    sw.WriteLine("X0005") '改行
                Loop
                dr.Close()
                If chkA3.Checked Then
                    sw.WriteLine("X8000A3") 'A3出力
                Else
                    sw.WriteLine("X8000A4") 'A4出力
                End If
                sw.WriteLine("X9000") 'PDF作成
                sw.Close()
            End Using
            cn.Close()
        End Using
    End Sub

    Public Sub SetUserData()
        Dim sw As New System.IO.StreamWriter(TXT_FL, False, System.Text.Encoding.GetEncoding("shift_jis"))
        Dim xId As Integer = 0
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_USERDAYSCHEDULE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = dtpDate.Value '対象月設定
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = 1 '予定抽出
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全件対象
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                If xId = 0 Then
                    sw.WriteLine("H0001" & StrConv(dtpDate.Value.ToString("yyyy/MM/dd(ddd)"), VbStrConv.Wide)) '対象日
                    sw.WriteLine("H0002利用者名") '基準者
                    sw.WriteLine("H0003ヘルパー名") '対象者
                End If
                If Not dr.HasRows Then sw.WriteLine("H0009") '該当なし
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    Dim st As String = ""
                    If xId <> db.ToUserId Then
                        If xId <> 0 Then sw.WriteLine("X0009") '上線指示（全体）
                        xId = db.ToUserId
                        sw.WriteLine("D0100" & db.ToUserName) '利用者名
                    End If
                    sw.WriteLine("D0200" & StrConv(db.ToJobTime, VbStrConv.Wide)) '業務時間
                    sw.WriteLine("D0300" & db.ToHelperName) 'ヘルパー名
                    sw.WriteLine("D0400" & db.ToSinMark) '身体
                    sw.WriteLine("D0500" & db.ToKajMark) '家事
                    sw.WriteLine("D0600" & db.ToIdoMark) '移動
                    sw.WriteLine("D0700" & db.ToTsuMark) '通院
                    sw.WriteLine("D0800" & db.ToEtcMark) 'その他
                    Dim arx As ArrayList = db.ToNoteArray(48, 0)
                    For I As Integer = 0 To arx.Count - 1
                        If arx(I).ToString.Trim <> "" Then
                            sw.WriteLine("D0900" & arx(I).ToString) '備考
                            If I <> (arx.Count - 1) Then
                                If db.ToIsCancel Then sw.WriteLine("X7999") '取消線
                                sw.WriteLine("X0005") '改行
                            End If
                        End If
                    Next I
                    sw.WriteLine("X0008") '下線指示（部分）
                    If db.ToIsCancel Then sw.WriteLine("X7999") '取消線
                    sw.WriteLine("X0005") '改行
                Loop
                dr.Close()
                If chkA3.Checked Then
                    sw.WriteLine("X8000A3") 'A3出力
                Else
                    sw.WriteLine("X8000A4") 'A4出力
                End If

                sw.WriteLine("X9000") 'PDF作成
                sw.Close()
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub GetList()
        If Not (wb Is Nothing) Then wb.Dispose()
        If wb Is Nothing Then
            wb = New System.Windows.Forms.WebBrowser
            wb.Dock = Windows.Forms.DockStyle.Fill
        Else
            wb = New System.Windows.Forms.WebBrowser
            wb.Dock = Windows.Forms.DockStyle.Fill
        End If
        wb.Navigate("about:blank")
        System.Threading.Thread.Sleep(200)

        If Dir(PDF_FL, FileAttribute.Normal) <> "" Then My.Computer.FileSystem.DeleteFile(PDF_FL)
        Dim ex As New Microsoft.Office.Interop.Excel.Application
        ex.Visible = False
        Dim bks As Microsoft.Office.Interop.Excel.Workbooks = ex.Workbooks
        Dim bk As Microsoft.Office.Interop.Excel.Workbook = bks.Open(EBK_FL)
        For I As Integer = 0 To 600
            System.Threading.Thread.Sleep(100)
            If Dir(PDF_FL, FileAttribute.Normal) <> "" Then Exit For
        Next I
        If Dir(PDF_FL, FileAttribute.Normal) <> "" Then
            wb.Navigate(PDF_FL)
            pnlView.Controls.Add(wb)
        Else
            MsgBox("帳票の作成に失敗しました。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "帳票作成失敗")
        End If
        ex.DisplayAlerts = False
        bk.Close()
        bks.Close()
        ex.DisplayAlerts = True
        ex.Quit()
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(bk)
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(bks)
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(ex)
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Me.Enabled = False
        If mIsUser Then SetUserData() Else SetHelperData()
        Call GetList()
        Me.Enabled = True
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub ScheduleDay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDate.Value = dtpDate.Value.AddDays(1)
    End Sub
End Class