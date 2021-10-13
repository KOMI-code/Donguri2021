Public Class Schedule

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub Schedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoUser.Checked = True '初期値 
        txtMonth.Text = Now.ToString("yyyy年MM月") '初期値 
        txtMonth.Tag = Now.ToString("yyyy/MM")
        Call SetCalendar()
        Call GetSchedule()
    End Sub

    Private Sub GetUser()
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_USER", cn)
                '利用者氏名取得
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全利用者対象
                cmd.Parameters.Add("@IsAll", SqlDbType.Bit).Value = False '稼働分のみ
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbName.Items.Clear()
                Dim ci0 As New DonguriLib.LibClass.ComboItem
                ci0.Id = 0
                ci0.Value = "<< 全利用者 >>"
                cmbName.Items.Add(ci0)
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_User
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToUserName
                    cmbName.Items.Add(ci)
                Loop
                dr.Close()
                cmbName.SelectedIndex = 0
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub GetHelper()
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPER", cn)
                'ヘルパー氏名取得
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全ヘルパー対象
                cmd.Parameters.Add("@IsAll", SqlDbType.Bit).Value = False '稼働分のみ
                cmd.Parameters.Add("@Member", SqlDbType.Int).Value = 1 '単独対象
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbName.Items.Clear()
                Dim ci0 As New DonguriLib.LibClass.ComboItem
                ci0.Id = 0
                ci0.Value = "<< 全ヘルパー >>"
                cmbName.Items.Add(ci0)
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Helper
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToHelperName
                    cmbName.Items.Add(ci)
                Loop
                dr.Close()
                cmbName.SelectedIndex = 0
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub GetSchedule()
        If txtMonth.Text = "" Then Exit Sub
        If cmbName.SelectedIndex = -1 Then Exit Sub

        For I As Integer = 1 To 37
            DirectCast(Me.Controls("grpSch" & I.ToString("D2")).Controls(0), System.Windows.Forms.ListBox).Items.Clear()
        Next I

        Dim st As String = ""
        If rdoUser.Checked Then st = "SP_SEL_USERMONTHSCHEDULE" Else st = "SP_SEL_HELPERMONTHSCHEDULE"
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand(st, cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = CDate(txtMonth.Text & "01日") '対象月初日設定
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = 0 '予定/実績抽出
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id '利用者番号
                cmd.Parameters.Add("@St", SqlDbType.VarChar, 50).Value = "[Target],[FromTime],[TypeId]"
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim I As Integer = 1
                Do While dr.Read()
                    Do While Me.Controls("grpSch" & I.ToString("D2")).Tag <> DirectCast(dr("Target"), Date).ToString("yyyy/MM/dd")
                        I += 1
                    Loop
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    If (db.ToTypeId = 1 And chkSch.Checked) Or (db.ToTypeId = 2 And chkRst.Checked) Then
                        If DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id = 0 Then
                            Dim arx As ArrayList = db.ToArrayLineDual(23, 3, rdoUser.Checked)
                            For J As Integer = 0 To arx.Count - 1
                                DirectCast(Me.Controls("grpSch" & I.ToString("D2")).Controls(0), System.Windows.Forms.ListBox).Items.Add(arx(J))
                            Next J
                        Else
                            Dim arx As ArrayList = db.ToArrayLine(23, 3, rdoUser.Checked)
                            For J As Integer = 0 To arx.Count - 1
                                DirectCast(Me.Controls("grpSch" & I.ToString("D2")).Controls(0), System.Windows.Forms.ListBox).Items.Add(arx(J))
                            Next J
                        End If
                    End If
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
        'If rdoUser.Checked Then 
        Call SetAccountTime()
    End Sub

    Private Sub rdo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHelper.CheckedChanged, rdoUser.CheckedChanged
        If rdoUser.Checked Then
            Call GetUser()
        Else
            Call GetHelper()
        End If
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim dt As Date
        dt = DateAdd(DateInterval.Month, -1, CDate(txtMonth.Text & "01日"))
        txtMonth.Text = dt.ToString("yyyy年MM月")
        txtMonth.Tag = dt.ToString("yyyy/MM")
        Call SetCalendar()
        Call GetSchedule()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim dt As Date
        dt = DateAdd(DateInterval.Month, 1, CDate(txtMonth.Text & "01日"))
        txtMonth.Text = dt.ToString("yyyy年MM月")
        txtMonth.Tag = dt.ToString("yyyy/MM")
        Call SetCalendar()
        Call GetSchedule()
    End Sub

    Private Sub SetCalendar()
        Dim nDay As Date = CDate(txtMonth.Text & "01日") '対象月初日設定
        Dim wk As Integer = CDate(txtMonth.Text & "01日").DayOfWeek '対象月初日曜日取得
        Dim fDay As Date = DateAdd(DateInterval.Day, wk * -1, nDay) '第一日曜日付取得
        Dim wDay As Date = fDay '作業用
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Dim I As Integer
            For I = 1 To 37
                Me.Controls("grpSch" & I.ToString("D2")).Text = wDay.ToString("dd")
                Me.Controls("grpSch" & I.ToString("D2")).Tag = wDay.ToString("yyyy/MM/dd")
                Me.Controls("grpSch" & I.ToString("D2")).Controls(0).Tag = wDay.ToString("yyyy/MM/dd")
                If wDay.ToString("yyyyMM") = nDay.ToString("yyyyMM") Then
                    Me.Controls("grpSch" & I.ToString("D2")).Controls(0).Visible = True '対象月のリストボックスは可視にする
                Else
                    Me.Controls("grpSch" & I.ToString("D2")).Controls(0).Visible = False '対象月以外のリストボックスは非可視にする
                End If
                Using cmd As New SqlClient.SqlCommand("SP_SEL_DAYNOTE", cn)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = wDay
                    Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    Dim it As String = ""
                    Dim its As String = ""
                    Dim hd As Boolean = False
                    Do While dr.Read
                        Dim db As New DonguriLib.LibClass.T_DayNote
                        db.SetReader(dr)
                        it &= db.ToNote & ","
                        its &= db.ToNoteShort & ","
                        If db.ToTypeId = 2 Then hd = True
                    Loop
                    If it <> "" Then it = "(" & it.Substring(0, it.Length - 1) & ")"
                    it = it.Replace(" ", "")
                    If its <> "" Then its = "(" & its.Substring(0, its.Length - 1) & ")"
                    its = its.Replace(" ", "")
                    If wDay.DayOfWeek = DayOfWeek.Sunday Then hd = True
                    If wDay.DayOfWeek = DayOfWeek.Saturday Then hd = True

                    If hd Then '休日の場合、赤文字
                        Me.Controls("grpSch" & I.ToString("D2")).ForeColor = Drawing.Color.Red
                    Else '平日の場合、黒文字
                        Me.Controls("grpSch" & I.ToString("D2")).ForeColor = Drawing.Color.Black
                    End If
                    If System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(it) > 20 Then
                        Me.Controls("grpSch" & I.ToString("D2")).Text &= its
                    Else
                        Me.Controls("grpSch" & I.ToString("D2")).Text &= it
                    End If
                    dr.Close()
                End Using
                wDay = DateAdd(DateInterval.Day, 1, wDay)
            Next I
            cn.Close()
        End Using

    End Sub

    Private Sub SetAccountTime()
        Dim db As New DonguriLib.LibClass.T_Schedule
        db.SetAccountTime(CDate(txtMonth.Text & "01日"), DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id, rdoUser.Checked)
        '背景色設定（初期設定）
        txtSchSSin.BackColor = Drawing.Color.White : txtSchSKaj.BackColor = Drawing.Color.White : txtSchSIdo.BackColor = Drawing.Color.White : txtSchSTsu.BackColor = Drawing.Color.White
        txtRstSSin.BackColor = Drawing.Color.White : txtRstSKaj.BackColor = Drawing.Color.White : txtRstSIdo.BackColor = Drawing.Color.White : txtRstSTsu.BackColor = Drawing.Color.White
        txtUppSSin.BackColor = Drawing.Color.White : txtUppSKaj.BackColor = Drawing.Color.White : txtUppSIdo.BackColor = Drawing.Color.White : txtUppSTsu.BackColor = Drawing.Color.White
        txtSchKSin.BackColor = Drawing.Color.White : txtSchKKaj.BackColor = Drawing.Color.White : txtSchKIdo.BackColor = Drawing.Color.White
        txtRstKSin.BackColor = Drawing.Color.White : txtRstKKaj.BackColor = Drawing.Color.White : txtRstKIdo.BackColor = Drawing.Color.White
        txtUppKSin.BackColor = Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
        txtUppKKaj.BackColor = Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
        txtUppKIdo.BackColor = Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
        txtSchEtc.BackColor = Drawing.Color.White : txtRstEtc.BackColor = Drawing.Color.White
        txtUppEtc.BackColor = Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
        '実稼働時間
        txtSchSSin.Text = db.ToSoSinSch.ToString("N2") : txtSchSKaj.Text = db.ToSoKajSch.ToString("N2") : txtSchSIdo.Text = db.ToSoIdoSch.ToString("N2") : txtSchSTsu.Text = db.ToSotsuSch.ToString("N2")
        txtRstSSin.Text = db.ToSoSinRst.ToString("N2") : txtRstSKaj.Text = db.ToSoKajRst.ToString("N2") : txtRstSIdo.Text = db.ToSoIdoRst.ToString("N2") : txtRstSTsu.Text = db.ToSotsuRst.ToString("N2")
        txtSchKSin.Text = db.ToKoSinSch.ToString("N2") : txtSchKKaj.Text = db.ToKoKajSch.ToString("N2") : txtSchKIdo.Text = db.ToKoIdoSch.ToString("N2")
        txtRstKSin.Text = db.ToKoSinRst.ToString("N2") : txtRstKKaj.Text = db.ToKoKajRst.ToString("N2") : txtRstKIdo.Text = db.ToKoIdoRst.ToString("N2")
        txtSchEtc.Text = db.ToEoEtcSch.ToString("N2") : txtRstEtc.Text = db.ToEoEtcRst.ToString("N2")
        '請求稼働時間
        txtSchSSin.Tag = db.ToSaSinSch.ToString("N2") : txtSchSKaj.Tag = db.ToSaKajSch.ToString("N2") : txtSchSIdo.Tag = db.ToSaIdoSch.ToString("N2") : txtSchSTsu.Tag = db.ToSatsuSch.ToString("N2")
        txtRstSSin.Tag = db.ToSaSinRst.ToString("N2") : txtRstSKaj.Tag = db.ToSaKajRst.ToString("N2") : txtRstSIdo.Tag = db.ToSaIdoRst.ToString("N2") : txtRstSTsu.Tag = db.ToSatsuRst.ToString("N2")
        txtSchKSin.Tag = db.ToKaSinSch.ToString("N2") : txtSchKKaj.Tag = db.ToKaKajSch.ToString("N2") : txtSchKIdo.Tag = db.ToKaIdoSch.ToString("N2")
        txtRstKSin.Tag = db.ToKaSinRst.ToString("N2") : txtRstKKaj.Tag = db.ToKaKajRst.ToString("N2") : txtRstKIdo.Tag = db.ToKaIdoRst.ToString("N2")
        txtSchEtc.Tag = db.ToEaEtcSch.ToString("N2") : txtRstEtc.Tag = db.ToEaEtcRst.ToString("N2")
        If rdoUser.Checked And (DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id <> 0) Then
            txtUppSSin.Text = db.ToSoSinUpp.ToString("N2") : txtUppSKaj.Text = db.ToSoKajUpp.ToString("N2") : txtUppSIdo.Text = db.ToSoIdoUpp.ToString("N2") : txtUppSTsu.Text = db.ToSoTsuUpp.ToString("N2")
            If db.ToSaSinSch > db.ToSoSinUpp Then txtSchSSin.BackColor = Drawing.Color.Yellow '請求稼働予定時間 身体 上限オーバー
            If db.ToSaSinRst > db.ToSoSinUpp Then txtRstSSin.BackColor = Drawing.Color.Yellow '請求稼働実績時間 身体 上限オーバー
            If db.ToSoSinSch > db.ToSoSinUpp Then txtSchSSin.BackColor = Drawing.Color.Red '実稼働予定時間 身体 上限オーバー
            If db.ToSoSinRst > db.ToSoSinUpp Then txtRstSSin.BackColor = Drawing.Color.Red '実稼働実績時間 身体 上限オーバー
            If db.ToSaKajSch > db.ToSoKajUpp Then txtSchSKaj.BackColor = Drawing.Color.Yellow '請求稼働予定時間 家事 上限オーバー
            If db.ToSaKajRst > db.ToSoKajUpp Then txtRstSKaj.BackColor = Drawing.Color.Yellow '請求稼働実績時間 家事 上限オーバー
            If db.ToSoKajSch > db.ToSoKajUpp Then txtSchSKaj.BackColor = Drawing.Color.Red '実稼働予定時間 家事 上限オーバー
            If db.ToSoKajRst > db.ToSoKajUpp Then txtRstSKaj.BackColor = Drawing.Color.Red '実稼働実績時間 家事 上限オーバー
            If db.ToSaIdoSch > db.ToSoIdoUpp Then txtSchSIdo.BackColor = Drawing.Color.Yellow '請求稼働予定時間 移動 上限オーバー
            If db.ToSaIdoRst > db.ToSoIdoUpp Then txtRstSIdo.BackColor = Drawing.Color.Yellow '請求稼働実績時間 移動 上限オーバー
            If db.ToSoIdoSch > db.ToSoIdoUpp Then txtSchSIdo.BackColor = Drawing.Color.Red '実稼働予定時間 移動 上限オーバー
            If db.ToSoIdoRst > db.ToSoIdoUpp Then txtRstSIdo.BackColor = Drawing.Color.Red '実稼働実績時間 移動 上限オーバー
            If db.ToSatsuSch > db.ToSotsuUpp Then txtSchSTsu.BackColor = Drawing.Color.Yellow '請求稼働予定時間 移動 上限オーバー
            If db.ToSatsuRst > db.ToSotsuUpp Then txtRstSTsu.BackColor = Drawing.Color.Yellow '請求稼働実績時間 移動 上限オーバー
            If db.ToSotsuSch > db.ToSotsuUpp Then txtSchSTsu.BackColor = Drawing.Color.Red '実稼働予定時間 移動 上限オーバー
            If db.ToSotsuRst > db.ToSotsuUpp Then txtRstSTsu.BackColor = Drawing.Color.Red '実稼働実績時間 移動 上限オーバー
        Else
            txtUppSSin.Text = "" : txtUppSKaj.Text = "" : txtUppSIdo.Text = "" : txtUppSTsu.Text = ""
            txtUppSSin.BackColor = Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
            txtUppSKaj.BackColor = Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
            txtUppSIdo.BackColor = Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
            txtUppSTsu.BackColor = Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
        End If
    End Sub

    Private Sub lstSch_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstSch01.DrawItem, lstSch07.DrawItem, lstSch06.DrawItem, lstSch05.DrawItem, lstSch04.DrawItem, lstSch03.DrawItem, lstSch02.DrawItem, lstSch37.DrawItem, lstSch36.DrawItem, lstSch35.DrawItem, lstSch34.DrawItem, lstSch33.DrawItem, lstSch32.DrawItem, lstSch31.DrawItem, lstSch30.DrawItem, lstSch29.DrawItem, lstSch28.DrawItem, lstSch27.DrawItem, lstSch26.DrawItem, lstSch25.DrawItem, lstSch24.DrawItem, lstSch23.DrawItem, lstSch22.DrawItem, lstSch21.DrawItem, lstSch20.DrawItem, lstSch19.DrawItem, lstSch18.DrawItem, lstSch17.DrawItem, lstSch16.DrawItem, lstSch15.DrawItem, lstSch14.DrawItem, lstSch13.DrawItem, lstSch12.DrawItem, lstSch11.DrawItem, lstSch10.DrawItem, lstSch09.DrawItem, lstSch08.DrawItem, lstToolTip.DrawItem
        If e.Index > -1 Then
            Dim lst As Windows.Forms.ListBox = sender
            Dim br As Drawing.Brush = Nothing
            Dim fn As Drawing.Font = e.Font
            If DirectCast(lst.Items(e.Index), DonguriLib.LibClass.LineItem).IsCancel Then
                fn = New Drawing.Font(e.Font, Drawing.FontStyle.Strikeout)
            End If
            If DirectCast(lst.Items(e.Index), DonguriLib.LibClass.LineItem).Attention Then
                br = New Drawing.SolidBrush(Drawing.Color.Red)
            Else
                br = New Drawing.SolidBrush(Drawing.Color.Black)
            End If
            e.DrawBackground()
            e.Graphics.DrawString(lst.Items(e.Index).ToString(), fn, br, e.Bounds, Drawing.StringFormat.GenericDefault)
        End If
    End Sub

    Private Sub cmbName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbName.SelectedIndexChanged
        Call GetSchedule()
    End Sub

    Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSch.CheckedChanged, chkRst.CheckedChanged
        Call GetSchedule()
    End Sub

    Private Sub lst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles lstSch01.Click, lstSch02.Click, lstSch03.Click, lstSch04.Click, lstSch05.Click, lstSch06.Click, lstSch07.Click, _
                lstSch08.Click, lstSch09.Click, lstSch10.Click, lstSch11.Click, lstSch12.Click, lstSch13.Click, lstSch14.Click, _
                lstSch15.Click, lstSch16.Click, lstSch17.Click, lstSch18.Click, lstSch19.Click, lstSch20.Click, lstSch21.Click, _
                lstSch22.Click, lstSch23.Click, lstSch24.Click, lstSch25.Click, lstSch26.Click, lstSch27.Click, lstSch28.Click, _
                lstSch29.Click, lstSch30.Click, lstSch31.Click, lstSch32.Click, lstSch33.Click, lstSch34.Click, lstSch35.Click, _
                lstSch36.Click, lstSch37.Click
        If rdoUser.Checked And (DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id <> 0) Then
            Dim dlg As New DonguriSchedule.Update
            dlg.mId = DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id '利用者番号
            dlg.Text &= "　（　" & DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Value & "　様　）　" '利用者名
            dlg.Tag = DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Value & "　様" '利用者名
            dlg.mDt.Clear()
            dlg.mDt.Add(sender.tag)
            dlg.ShowDialog(Me)
            dlg.Dispose()
            Call GetSchedule()
        End If
    End Sub

    Private Sub btnWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSun.Click, btnWed.Click, btnTue.Click, btnThu.Click, btnSat.Click, btnFri.Click, btnMon.Click
        If rdoUser.Checked And (DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id <> 0) Then
            Me.Enabled = False
            Dim dlg As New DonguriSchedule.Update
            dlg.mId = DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id '利用者番号
            dlg.Text &= "　（　" & DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Value & "　様　）　" '利用者名
            dlg.Tag = DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Value & "　様" '利用者名
            dlg.mDt.Clear()
            Dim st As Integer = CInt(sender.tag)
            Dim I As Integer
            For I = st To 37 Step 7
                Dim mt As String = Me.Controls("grpSch" & I.ToString("D2")).Tag
                If txtMonth.Tag = mt.Substring(0, 7) Then
                    dlg.mDt.Add(mt)
                End If
            Next I
            dlg.ShowDialog(Me)
            dlg.Dispose()
            Call GetSchedule()
            Me.Enabled = True
        End If
    End Sub

    Private Sub lstSch_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles lstSch01.MouseHover, lstSch02.MouseHover, lstSch03.MouseHover, lstSch04.MouseHover, lstSch05.MouseHover, lstSch06.MouseHover, lstSch07.MouseHover, _
                    lstSch08.MouseHover, lstSch09.MouseHover, lstSch10.MouseHover, lstSch11.MouseHover, lstSch12.MouseHover, lstSch13.MouseHover, lstSch14.MouseHover, _
                    lstSch15.MouseHover, lstSch16.MouseHover, lstSch17.MouseHover, lstSch18.MouseHover, lstSch19.MouseHover, lstSch20.MouseHover, lstSch21.MouseHover, _
                    lstSch22.MouseHover, lstSch23.MouseHover, lstSch24.MouseHover, lstSch25.MouseHover, lstSch26.MouseHover, lstSch27.MouseHover, lstSch28.MouseHover, _
                    lstSch29.MouseHover, lstSch30.MouseHover, lstSch31.MouseHover, lstSch32.MouseHover, lstSch33.MouseHover, lstSch34.MouseHover, lstSch35.MouseHover, _
                    lstSch36.MouseHover, lstSch37.MouseHover
        Dim lst As Windows.Forms.ListBox = DirectCast(sender, Windows.Forms.ListBox)
        lstToolTip.Items.Clear()
        Dim ymd As New DonguriLib.LibClass.LineItem
        ymd.Attention = False
        ymd.LineString = lst.Tag
        lstToolTip.Items.Add(ymd)
        For I As Integer = 0 To lst.Items.Count - 1
            lstToolTip.Items.Add(lst.Items(I))
        Next I

        Dim p As Drawing.Point = Windows.Forms.Cursor.Position

        With lstToolTip
            .Height = (.Items.Count + 1) * .ItemHeight
            '            If p.Y > 400 Then
            '.Top = .Top - (.Height / 2)
            'Else
            '.Top = p.Y
            'End If
            If p.X > 600 Then
                .Left = p.X - .Width - 10
            Else
                .Left = p.X + 10
            End If
            .Top = p.Y - (.Height / 2)
            If (.Top + .Height) > 760 Then .Top = 760 - .Height

            If .Top < 5 Then .Top = 5
            .Visible = True
        End With
    End Sub

    Private Sub lstSch01_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles lstSch01.MouseLeave, lstSch02.MouseLeave, lstSch03.MouseLeave, lstSch04.MouseLeave, lstSch05.MouseLeave, lstSch06.MouseLeave, lstSch07.MouseLeave, _
                    lstSch08.MouseLeave, lstSch09.MouseLeave, lstSch10.MouseLeave, lstSch11.MouseLeave, lstSch12.MouseLeave, lstSch13.MouseLeave, lstSch14.MouseLeave, _
                    lstSch15.MouseLeave, lstSch16.MouseLeave, lstSch17.MouseLeave, lstSch18.MouseLeave, lstSch19.MouseLeave, lstSch20.MouseLeave, lstSch21.MouseLeave, _
                    lstSch22.MouseLeave, lstSch23.MouseLeave, lstSch24.MouseLeave, lstSch25.MouseLeave, lstSch26.MouseLeave, lstSch27.MouseLeave, lstSch28.MouseLeave, _
                    lstSch29.MouseLeave, lstSch30.MouseLeave, lstSch31.MouseLeave, lstSch32.MouseLeave, lstSch33.MouseLeave, lstSch34.MouseLeave, lstSch35.MouseLeave, _
                    lstSch36.MouseLeave, lstSch37.MouseLeave
        lstToolTip.Visible = False
    End Sub

    Private Sub btnDupChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDupChk.Click
        Me.Enabled = False
        Dim dlg As New ErrorCheck
        dlg.Tag = txtMonth.Text & "01日"
        dlg.ShowDialog(Me)
        dlg.Dispose()
        Me.Enabled = True
    End Sub

    Private Sub txtTime_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSchSSin.MouseHover, txtUppSSin.MouseHover, txtUppSKaj.MouseHover, txtUppSIdo.MouseHover, txtUppKSin.MouseHover, txtUppKKaj.MouseHover, txtUppKIdo.MouseHover, txtUppEtc.MouseHover, txtSchSKaj.MouseHover, txtSchSIdo.MouseHover, txtSchKSin.MouseHover, txtSchKKaj.MouseHover, txtSchKIdo.MouseHover, txtSchEtc.MouseHover, txtRstSSin.MouseHover, txtRstSKaj.MouseHover, txtRstSIdo.MouseHover, txtRstKSin.MouseHover, txtRstKKaj.MouseHover, txtRstKIdo.MouseHover, txtRstEtc.MouseHover
        Dim txt As Windows.Forms.TextBox = DirectCast(sender, Windows.Forms.TextBox)
        lstToolTip.Items.Clear()
        Dim st1 As String = "" : Dim st2 As String = "" : Dim st3 As String = ""
        Select Case txt.Name
            Case "txtSchSSin", "txtRstSSin", "txtUppSSin"
                st1 = "支－身体　予定 = " & txtSchSSin.Text & " ( " & txtSchSSin.Tag & " )   "
                st2 = "          実績 = " & txtRstSSin.Text & " ( " & txtRstSSin.Tag & " )   "
                If rdoUser.Checked And (DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id <> 0) Then
                    st3 = "          上限 = " & txtUppSSin.Text
                End If
            Case "txtSchSKaj", "txtRstSKaj", "txtUppSKaj"
                st1 = "支－家事　予定 = " & txtSchSKaj.Text & " ( " & txtSchSKaj.Tag & " )   "
                st2 = "          実績 = " & txtRstSKaj.Text & " ( " & txtRstSKaj.Tag & " )   "
                If rdoUser.Checked And (DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id <> 0) Then
                    st3 = "          上限 = " & txtUppSKaj.Text
                End If
            Case "txtSchSIdo", "txtRstSIdo", "txtUppSIdo"
                st1 = "支－移動　予定 = " & txtSchSIdo.Text & " ( " & txtSchSIdo.Tag & " )   "
                st2 = "          実績 = " & txtRstSIdo.Text & " ( " & txtRstSIdo.Tag & " )   "
                If rdoUser.Checked And (DirectCast(cmbName.SelectedItem, DonguriLib.LibClass.ComboItem).Id <> 0) Then
                    st3 = "          上限 = " & txtUppSIdo.Text
                End If
            Case "txtSchKSin", "txtRstKSin", "txtUppKSin"
                st1 &= "介－身体　予定 = " & txtSchKSin.Text & " ( " & txtSchKSin.Tag & " )   "
                st2 = "          実績 = " & txtRstKSin.Text & " ( " & txtRstKSin.Tag & " )   "
            Case "txtSchKKaj", "txtRstKKaj", "txtUppKKaj"
                st1 = "介－家事　予定 = " & txtSchKKaj.Text & " ( " & txtSchKKaj.Tag & " )   "
                st2 = "          実績 = " & txtRstKKaj.Text & " ( " & txtRstKKaj.Tag & " )   "
            Case "txtSchKIdo", "txtRstKIdo", "txtUppKIdo"
                st1 = "介－移動　予定 = " & txtSchKIdo.Text & " ( " & txtSchKIdo.Tag & " )   "
                st2 = "          実績 = " & txtRstKIdo.Text & " ( " & txtRstKIdo.Tag & " )   "
            Case "txtSchEtc", "txtRstEtc", "txtUppEtc"
                st1 = "その他  　予定 = " & txtSchEtc.Text & " ( " & txtSchEtc.Tag & " )   "
                st2 = "          実績 = " & txtRstEtc.Text & " ( " & txtRstEtc.Tag & " )   "
        End Select
        Dim it1 As New DonguriLib.LibClass.LineItem
        it1.LineString = st1
        it1.Attention = False
        lstToolTip.Items.Add(it1)
        Dim it2 As New DonguriLib.LibClass.LineItem
        it2.LineString = st2
        it2.Attention = False
        lstToolTip.Items.Add(it2)
        If st3 <> "" Then
            Dim it3 As New DonguriLib.LibClass.LineItem
            it3.LineString = st3
            it3.Attention = False
            lstToolTip.Items.Add(it3)
        End If
        With lstToolTip
            .Top = 540
            .Left = 500
            .Height = (.Items.Count + 1) * .ItemHeight
            .Visible = True
        End With
    End Sub

    Private Sub txtTime_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUppSSin.MouseLeave, txtUppSKaj.MouseLeave, txtUppSIdo.MouseLeave, txtUppKSin.MouseLeave, txtUppKKaj.MouseLeave, txtUppKIdo.MouseLeave, txtUppEtc.MouseLeave, txtSchSSin.MouseLeave, txtSchSKaj.MouseLeave, txtSchSIdo.MouseLeave, txtSchKSin.MouseLeave, txtSchKKaj.MouseLeave, txtSchKIdo.MouseLeave, txtSchEtc.MouseLeave, txtRstSSin.MouseLeave, txtRstSKaj.MouseLeave, txtRstSIdo.MouseLeave, txtRstKSin.MouseLeave, txtRstKKaj.MouseLeave, txtRstKIdo.MouseLeave, txtRstEtc.MouseLeave
        lstToolTip.Visible = False
    End Sub

    Private Sub lstSch02_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSch02.SelectedIndexChanged

    End Sub
End Class