Public Class JobTimeMonth

    Public mIsUser As Boolean
    'Private Const PDF_FL As String = "D:\DonguriV2\Data\JOBTIMEMONTH.PDF"
    Private Const XLS_FL As String = "D:\DonguriV2\Excel\" ' & yyyymm.xls
    Private Const TXT_FL As String = "D:\DonguriV2\Data\JOBTIMEMONTH.TXT"
    Private Const EBK_FL As String = "D:\DonguriV2\Data\JOBTIMEMONTH.XLSM"
    Private wb As System.Windows.Forms.WebBrowser = Nothing

    Public Function SetHelper(ByVal fl As String) As Boolean
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
                Dim rt As String = Me.Tag
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = CInt(rt.Substring(1)) '抽出
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全件対象
                cmd.Parameters.Add("@St", SqlDbType.VarChar, 50).Value = DirectCast(cmbSort.SelectedItem, DonguriLib.LibClass.SortItem).Key
                sw.WriteLine("X9999HELPER") '
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                bHr = dr.HasRows
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    Dim st As String = ""
                    If xId <> db.ToSHelperId Then
                        sw.WriteLine("X0009" & db.ToSHelperName) 'コピー指示
                        If Me.Tag = "H1" Then
                            sw.WriteLine("H0001" & "ヘルパー稼働予定表") 'タイトル
                        Else
                            sw.WriteLine("H0001" & "ヘルパー稼働実績表") 'タイトル
                        End If
                        sw.WriteLine("H0003" & db.ToSHelperName) '対象者名
                        sw.WriteLine("H0005" & db.ToTarget.ToString("yyyy/MM") & "月分") '対象月
                        xId = db.ToSHelperId
                    End If
                    sw.WriteLine("D0100" & db.ToTarget.ToString("dd")) '日付
                    sw.WriteLine("D0200" & db.ToTarget.ToString("ddd")) '曜日

                    sw.WriteLine("D0300" & db.ToUserName) '利用者名
                    sw.WriteLine("D0400" & db.ToJob) '内容
                    sw.WriteLine("D0500" & db.ToFromTime.ToString("HH:mm")) '実績時間－開始
                    sw.WriteLine("D0600" & db.ToToTime.ToString("HH:mm")) '実績時間－終了
                    Dim dt As Decimal = db.ToDiffTime * db.ToAccountMag  '実績時間－時間
                    sw.WriteLine("D0700" & dt.ToString("N2")) '実績時間－時間

                    Dim arx As ArrayList = db.ToDivItem
                    For I As Integer = 0 To arx.Count - 1
                        sw.WriteLine("D0800" & DirectCast(arx(I), DonguriLib.LibClass.DivItem).FromTime.ToString("HH:mm")) '算出時間－開始
                        sw.WriteLine("D0900" & DirectCast(arx(I), DonguriLib.LibClass.DivItem).ToTime.ToString("HH:mm")) '算出時間－終了
                        sw.WriteLine("D1000" & DirectCast(arx(I), DonguriLib.LibClass.DivItem).DiffTime.ToString("N2")) '算出時間－時間
                        sw.WriteLine("D1100" & DirectCast(arx(I), DonguriLib.LibClass.DivItem).Type1.ToString) '適用－区分１
                        sw.WriteLine("D1200" & DirectCast(arx(I), DonguriLib.LibClass.DivItem).Pay1) '適用－金額１
                        If db.ToAccountMag = 0 Then sw.WriteLine("D1700" & db.ToAccount) '備考
                        If db.ToIsCancel Then sw.WriteLine("X7999") '取り消し線
                        sw.WriteLine("X8000") '改行
                    Next I
                    sw.WriteLine("X8100") '上線
                Loop
                sw.WriteLine("X9000" & fl) 'XLS作成
                sw.Close()
                dr.Close()
            End Using
            cn.Close()
        End Using
        Return bHr
    End Function

    Public Function SetUser(ByVal fl As String) As Boolean
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
                Dim rt As String = Me.Tag
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = CInt(rt.Substring(1)) '抽出
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@St", SqlDbType.VarChar, 50).Value = DirectCast(cmbSort.SelectedItem, DonguriLib.LibClass.SortItem).Key
                sw.WriteLine("X9999USER") '
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                bHr = dr.HasRows
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    Dim st As String = ""
                    If xId <> db.ToUserId Then
                        sw.WriteLine("X0009" & db.ToUserName) 'コピー指示
                        If Me.Tag = "U1" Then
                            sw.WriteLine("H0001" & "利用者稼働予定表") 'タイトル
                        Else
                            sw.WriteLine("H0001" & "利用者稼働実績表") 'タイトル
                        End If
                        sw.WriteLine("H0003" & db.ToUserName) '対象者名
                        sw.WriteLine("H0005" & db.ToTarget.ToString("yyyy/MM") & "月分") '対象月
                        xId = db.ToUserId
                    End If
                    sw.WriteLine("D0100" & db.ToTarget.ToString("dd")) '日付
                    sw.WriteLine("D0200" & db.ToTarget.ToString("ddd")) '曜日

                    sw.WriteLine("D0300" & db.ToSHelperName) 'ヘルパー名
                    sw.WriteLine("D0400" & db.ToJob) '内容
                    sw.WriteLine("D0500" & db.ToFromTime.ToString("HH:mm")) '実績時間－開始
                    sw.WriteLine("D0600" & db.ToToTime.ToString("HH:mm")) '実績時間－終了
                    Dim dt As Decimal = db.ToDiffTime * db.ToAccountMag  '実績時間－時間
                    sw.WriteLine("D0700" & dt.ToString("N2")) '実績時間－時間
                    If db.ToAccountMag = 0 Then sw.WriteLine("D1700" & db.ToAccount) '備考
                    If db.ToIsCancel Then sw.WriteLine("X7999") '取り消し線
                    sw.WriteLine("X8000") '改行
                    sw.WriteLine("X8100") '上線
                Loop
                dr.Close()
                sw.WriteLine("X9000" & fl) 'XLS作成
                sw.Close()
            End Using
            cn.Close()
        End Using
        Return bHr
    End Function

    Private Sub GetList(ByVal fl As String)
        If Dir(fl) <> "" Then My.Computer.FileSystem.DeleteFile(fl)
        Dim ex As New Microsoft.Office.Interop.Excel.Application
        ex.Visible = False
        Dim bks As Microsoft.Office.Interop.Excel.Workbooks = ex.Workbooks
        Dim bk As Microsoft.Office.Interop.Excel.Workbook = bks.Open(EBK_FL)
        For I As Integer = 0 To 600
            System.Threading.Thread.Sleep(200)
            If Dir(fl, FileAttribute.Normal) <> "" Then Exit For
        Next I
        If Dir(fl, FileAttribute.Normal) <> "" Then
            MsgBox("稼働表は" & vbCrLf & fl & vbCrLf & "に作成されました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "帳票作成完了")
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
        Dim xlFl As String = XLS_FL & Me.Tag & dtpMonth.Value.ToString("yyyyMM") & ".xlsx" 'XLS作成
        Select Case Me.Tag
            Case "U1"
                xlFl = XLS_FL & "利用者稼働予定表" & dtpMonth.Value.ToString("yyyyMM") & ".xlsx"
                If SetUser(xlFl) Then
                    Call GetList(xlFl)
                Else
                    MsgBox("指定された年月の情報はありません", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "対象なし")
                End If
            Case "U2"
                xlFl = XLS_FL & "利用者稼働実績表" & dtpMonth.Value.ToString("yyyyMM") & ".xlsx"
                If SetUser(xlFl) Then
                    Call GetList(xlFl)
                Else
                    MsgBox("指定された年月の情報はありません", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "対象なし")
                End If
            Case "H1"
                xlFl = XLS_FL & "ヘルパー稼働予定表" & dtpMonth.Value.ToString("yyyyMM") & ".xlsx"
                If SetHelper(xlFl) Then
                    Call GetList(xlFl)
                Else
                    MsgBox("指定された年月の情報はありません", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "対象なし")
                End If
            Case "H2"
                xlFl = XLS_FL & "ヘルパー稼働実績表" & dtpMonth.Value.ToString("yyyyMM") & ".xlsx"
                If SetHelper(xlFl) Then
                    Call GetList(xlFl)
                Else
                    MsgBox("指定された年月の情報はありません", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "対象なし")
                End If
        End Select
        Me.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub JobTimeMonth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Me.Tag = "U1") Or (Me.Tag = "U2") Then
            cmbSort.Items.Clear()
            Dim it1 As New DonguriLib.LibClass.SortItem
            it1.Value = "業務内容,日付,ヘルパー"
            it1.Key = "[UserId],[JobId],[FromTime],[SHelperId],[TypeId]"
            cmbSort.Items.Add(it1)
            Dim it2 As New DonguriLib.LibClass.SortItem
            it2.Value = "日付,業務内容,ヘルパー"
            it2.Key = "[UserId],[FromTime],[JobId],[SHelperId],[TypeId]"
            cmbSort.Items.Add(it2)
        Else
            cmbSort.Items.Clear()
            Dim it1 As New DonguriLib.LibClass.SortItem
            it1.Value = "利用者,業務内容,日付"
            it1.Key = "[SHelperId],[UserId],[JobId],[FromTime],[TypeId]"
            cmbSort.Items.Add(it1)
            Dim it2 As New DonguriLib.LibClass.SortItem
            it2.Value = "日付,業務内容,利用者"
            it2.Key = "[SHelperId],[FromTime],[JobId],[UserId],[TypeId]"
            cmbSort.Items.Add(it2)
        End If
        cmbSort.SelectedIndex = 0
    End Sub
End Class