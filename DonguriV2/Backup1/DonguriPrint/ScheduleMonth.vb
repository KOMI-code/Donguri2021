Public Class ScheduleMonth
    Public mIsUser As Boolean
    Private Const PDF_FL As String = "D:\DonguriV2\Data\SCHEDULEMONTH.PDF"
    Private Const TXT_FL As String = "D:\DonguriV2\Data\SCHEDULEMONTH.TXT"
    Private Const EBK_FL As String = "D:\DonguriV2\Data\SCHEDULEMONTH.XLSM"
    Private wb As System.Windows.Forms.WebBrowser = Nothing

    Private Sub ScheduleMonth_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Not (wb Is Nothing) Then wb.Dispose()
    End Sub

    Public Function SetHelperData() As Boolean
        Dim sw As New System.IO.StreamWriter(TXT_FL, False, System.Text.Encoding.GetEncoding("shift_jis"))
        Dim xId As Integer = 0
        Dim row As Integer = 1
        Dim col As Integer = 0
        Dim xDt As Date = Nothing
        Dim fDt As Date = Nothing
        Dim bHr As Boolean = False
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPERMONTHSCHEDULE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = CDate(dtpMonth.Value.ToString("yyyy/MM/01")) '対象月設定
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = 1 '予定抽出
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全件対象
                cmd.Parameters.Add("@St", SqlDbType.VarChar, 50).Value = "[SHelperId],[Target],[FromTime],[TypeId]"
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                bHr = dr.HasRows
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    Dim st As String = ""
                    If xId <> db.ToSHelperId Then
                        If xId <> 0 Then sw.WriteLine("X0009") 'コピー指示
                        sw.WriteLine("X0001") '初期化指示
                        sw.WriteLine("H0001" & "ヘルパー名") '対象者
                        sw.WriteLine("H0003" & db.ToSHelperName) '対象者名
                        sw.WriteLine("H0005" & db.ToTarget.ToString("yyyy/MM/01")) '対象月
                        fDt = CDate(dtpMonth.Value.ToString("yyyy/MM/01")) '日曜日取得
                        fDt = fDt.AddDays(-1 * fDt.DayOfWeek) '日曜日取得
                        sw.WriteLine("H0007" & fDt.ToString("yyyy/MM/dd")) '開始年月日
                        xId = db.ToSHelperId
                        row = 1
                        col = DateDiff(DateInterval.Day, fDt, db.ToTarget) + 1
                    End If
                    If xDt <> db.ToTarget Then
                        row = 1
                        col = DateDiff(DateInterval.Day, fDt, db.ToTarget) + 1
                        xDt = db.ToTarget
                    End If
                    st = StrConv(db.ToJobTime, VbStrConv.Wide)
                    If db.ToMember > 1 Then st &= " (*)"
                    sw.WriteLine("D" & col.ToString("D2") & row.ToString("D2") & st) '業務時間
                    row += 1
                    If chkJob.Checked Then st = db.ToJob & Space(8 - System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(db.ToJob)) Else st = "        "
                    st &= " "
                    If chkHelper.Checked Then st &= db.ToUserName
                    If st.Trim <> "" Then
                        sw.WriteLine("D" & col.ToString("D2") & row.ToString("D2") & st) '業務内容 ヘルパー名
                        row += 1
                    End If
                    If chkNote.Checked Then
                        Dim arx As ArrayList = db.ToViewArray(28, 0)
                        For I As Integer = 0 To arx.Count - 1
                            sw.WriteLine("D" & col.ToString("D2") & row.ToString("D2") & arx(I).ToString) '備考
                            row += 1
                        Next I
                    End If
                Loop
                dr.Close()
                sw.WriteLine("X9000") 'PDF作成
                sw.Close()
            End Using
            cn.Close()
        End Using
        Return bHr
    End Function

    Public Function SetUserData() As Boolean
        Dim sw As New System.IO.StreamWriter(TXT_FL, False, System.Text.Encoding.GetEncoding("shift_jis"))
        Dim xId As Integer = 0
        Dim row As Integer = 1
        Dim col As Integer = 0
        Dim xDt As Date = Nothing
        Dim fDt As Date = Nothing
        Dim bHr As Boolean = False
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_USERMONTHSCHEDULE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = CDate(dtpMonth.Value.ToString("yyyy/MM/01")) '対象月設定
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = 1 '予定抽出
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全件対象
                cmd.Parameters.Add("@St", SqlDbType.VarChar, 50).Value = "[UserId],[Target],[FromTime],[TypeId]"
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                bHr = dr.HasRows
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    Dim st As String = ""
                    If xId <> db.ToUserId Then
                        If xId <> 0 Then sw.WriteLine("X0009") 'コピー指示
                        sw.WriteLine("X0001") '初期化指示
                        sw.WriteLine("H0001" & "利用者名") '対象者
                        sw.WriteLine("H0003" & db.ToUserName) '対象者名
                        sw.WriteLine("H0005" & db.ToTarget.ToString("yyyy/MM/01")) '対象月
                        fDt = CDate(dtpMonth.Value.ToString("yyyy/MM/01")) '日曜日取得
                        fDt = fDt.AddDays(-1 * fDt.DayOfWeek) '日曜日取得
                        sw.WriteLine("H0007" & fDt.ToString("yyyy/MM/dd")) '開始年月日
                        xId = db.ToUserId
                        row = 1
                        col = DateDiff(DateInterval.Day, fDt, db.ToTarget) + 1
                    End If
                    If xDt <> db.ToTarget Then
                        row = 1
                        col = DateDiff(DateInterval.Day, fDt, db.ToTarget) + 1
                        xDt = db.ToTarget
                    End If

                    st = StrConv(db.ToJobTime, VbStrConv.Wide)
                    If db.ToMember > 1 Then st &= " (*)"
                    sw.WriteLine("D" & col.ToString("D2") & row.ToString("D2") & st) '業務時間
                    row += 1
                    If chkJob.Checked Then st = db.ToJob & Space(8 - System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(db.ToJob)) Else st = "        "
                    st &= " "
                    If chkHelper.Checked Then st &= db.ToHelperName
                    If st.Trim <> "" Then
                        sw.WriteLine("D" & col.ToString("D2") & row.ToString("D2") & st) '業務内容 ヘルパー名
                        row += 1
                    End If
                    If chkNote.Checked Then
                        Dim arx As ArrayList = db.ToViewArray(28, 0)
                        For I As Integer = 0 To arx.Count - 1
                            sw.WriteLine("D" & col.ToString("D2") & row.ToString("D2") & arx(I).ToString) '備考
                            row += 1
                        Next I
                    End If
                Loop
                dr.Close()
                sw.WriteLine("X9000") 'PDF作成
                sw.Close()
            End Using
            cn.Close()
        End Using
        Return bHr
    End Function

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
        If mIsUser Then
            If SetUserData() Then
                Call GetList()
            Else
                MsgBox("指定された年月の情報はありません", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "対象なし")
            End If
        Else
            If SetHelperData() Then
                Call GetList()
            Else
                MsgBox("指定された年月の情報はありません", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "対象なし")
            End If
        End If
        Me.Enabled = True
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub ScheduleMonth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If mIsUser Then
            chkHelper.Text = "ヘルパー名"
        Else
            chkHelper.Text = "利用者名"
        End If
    End Sub
End Class