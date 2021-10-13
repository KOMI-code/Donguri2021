Public Class Calendar

    Private aCal As New ArrayList

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub Calendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetCombo()
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_CALENDAR", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dim db As New DonguriLib.LibClass.T_Calendar
                    db.SetReader(dr)
                    Dim itx() As String = {"", db.ToTarget.ToString("yyyy/MM/dd"), db.ToItem, db.ToNote, db.ToType, db.ToTypeId}
                    lstCalendar.Items.Add(New Windows.Forms.ListViewItem(itx))
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
        aCal.Clear()
        cmbHoliday.SelectedIndex = 0
    End Sub

    Private Sub SetCombo()
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_CODE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@CodeId", SqlDbType.Int).Value = 6 '平日／休日情報
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbHoliday.Items.Clear()
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Code
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToValue
                    cmbHoliday.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub lstCalendar_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstCalendar.ItemSelectionChanged
        If lstCalendar.SelectedItems.Count <> 0 Then '行が選択されている場合のみ実行
            Dim it As System.Windows.Forms.ListViewItem = lstCalendar.SelectedItems(0)
            txtTarget.Text = it.SubItems(1).Text
            txtItem.Text = it.SubItems(2).Text
            txtNote.Text = it.SubItems(3).Text
            cmbHoliday.SelectedIndex = cmbHoliday.FindString(it.SubItems(4).Text)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '指定された行を削除する
        If lstCalendar.SelectedItems.Count <> 0 Then '行が選択されている場合のみ実行
            Dim it As System.Windows.Forms.ListViewItem = lstCalendar.SelectedItems(0)
            Dim cl As New DonguriLib.LibClass.T_Calendar
            cl.SetListItem(lstCalendar.SelectedItems(0), "DELETE")
            aCal.Add(cl)
            lstCalendar.Items.Remove(lstCalendar.SelectedItems(0))
            txtTarget.Text = ""
            txtItem.Text = ""
            txtNote.Text = ""
            cmbHoliday.SelectedIndex = 0
            MsgBox("表より削除しました。" & vbCrLf & "実際の更新は「登録」で行われます。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "確認")
        End If
    End Sub

    Private Function IsDate(ByRef value As String) As Boolean
        IsDate = False
        Dim rslt As Date
        If Date.TryParse(value.Trim, rslt) Then
            value = rslt.ToString("yyyy/MM/dd")
            IsDate = True
        Else
            MsgBox("日付を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力エラー")
        End If
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        '全て空白なら対象外とする
        If (txtTarget.Text.Trim = "") And (txtItem.Text.Trim = "") And (txtNote.Text.Trim = "") Then Exit Sub

        If txtTarget.Text.Trim = "" Then
            MsgBox("対象日を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            txtTarget.Focus()
            Exit Sub
        End If
        If txtItem.Text.Trim = "" Then
            MsgBox("名称を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            txtItem.Focus()
            Exit Sub
        End If
        Dim I As Integer
        For I = 0 To lstCalendar.Items.Count - 1
            Dim it As System.Windows.Forms.ListViewItem = lstCalendar.Items(I)
            If txtTarget.Text.Trim = it.SubItems(1).Text Then
                Dim rslt As Integer = MsgBox("指定された日付は既に登録されています。" & vbCrLf & "上書きしますか？", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "上書確認")
                If rslt = MsgBoxResult.Yes Then
                    Dim clu As New DonguriLib.LibClass.T_Calendar
                    clu.SetSqlType("UPDATE")
                    clu.SetTarget(CDate(txtTarget.Text))
                    clu.SetItem(txtItem.Text)
                    clu.SetNote(txtNote.Text)
                    clu.SetType(DirectCast(cmbHoliday.SelectedItem, DonguriLib.LibClass.ComboItem).Value)
                    clu.SetTypeId(DirectCast(cmbHoliday.SelectedItem, DonguriLib.LibClass.ComboItem).Id)
                    aCal.Add(clu)
                    it.SubItems(2).Text = txtItem.Text
                    it.SubItems(3).Text = txtNote.Text
                    it.SubItems(4).Text = DirectCast(cmbHoliday.SelectedItem, DonguriLib.LibClass.ComboItem).Value
                    it.SubItems(5).Text = DirectCast(cmbHoliday.SelectedItem, DonguriLib.LibClass.ComboItem).Id
                End If
                Exit Sub
            End If
        Next I
        '
        Dim cl As New DonguriLib.LibClass.T_Calendar
        cl.SetSqlType("ADD")
        cl.SetTarget(CDate(txtTarget.Text))
        cl.SetItem(txtItem.Text)
        cl.SetNote(txtNote.Text)
        cl.SetType(DirectCast(cmbHoliday.SelectedItem, DonguriLib.LibClass.ComboItem).Value)
        cl.SetTypeId(DirectCast(cmbHoliday.SelectedItem, DonguriLib.LibClass.ComboItem).Id)
        aCal.Add(cl)
        Dim itm() As String = {"", _
                               txtTarget.Text, _
                               txtItem.Text, _
                               txtNote.Text, _
                               DirectCast(cmbHoliday.SelectedItem, DonguriLib.LibClass.ComboItem).Value, _
                               DirectCast(cmbHoliday.SelectedItem, DonguriLib.LibClass.ComboItem).Id}
        lstCalendar.Items.Add(New Windows.Forms.ListViewItem(itm))
        MsgBox("表に追加しました。" & vbCrLf & "実際の更新は「登録」で行われます。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "確認")
    End Sub

    Private Sub txtTarget_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTarget.Validating
        If txtTarget.Text <> "" Then
            Dim rslt As Date
            If Date.TryParse(txtTarget.Text, rslt) Then
                txtTarget.Text = rslt.ToString("yyyy/MM/dd")
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If aCal.Count = 0 Then
            MsgBox("登録対象がありません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "登録不可")
            Exit Sub
        End If
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Dim I As Integer
            For I = 0 To aCal.Count - 1
                Dim cl As DonguriLib.LibClass.T_Calendar = aCal(I)
                If cl.ToSqlType = "ADD" Then
                    Using cmd As New SqlClient.SqlCommand("SP_INS_CALENDAR", cn)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = cl.ToTarget '対象日
                        cmd.Parameters.Add("@Item", SqlDbType.VarChar, 10).Value = cl.ToItem '名称 
                        cmd.Parameters.Add("@Note", SqlDbType.VarChar, 10).Value = cl.ToNote '備考
                        cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = cl.ToTypeId '休日/通常
                        cmd.ExecuteNonQuery()
                    End Using
                ElseIf cl.ToSqlType = "UPDATE" Then
                    Using cmd As New SqlClient.SqlCommand("SP_UPD_CALENDAR", cn)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = cl.ToTarget '対象日
                        cmd.Parameters.Add("@Item", SqlDbType.VarChar, 10).Value = cl.ToItem '名称 
                        cmd.Parameters.Add("@Note", SqlDbType.VarChar, 10).Value = cl.ToNote '備考
                        cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = cl.ToTypeId '休日/通常
                        cmd.ExecuteNonQuery()
                    End Using
                ElseIf cl.ToSqlType = "DELETE" Then
                    Using cmd As New SqlClient.SqlCommand("SP_DEL_CALENDAR", cn)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = cl.ToTarget '対象日
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            Next I
            cn.Close()
        End Using
        MsgBox("登録しました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "登録完了")
        aCal.Clear()
        Me.Close()
    End Sub

    Private Sub frmCalendar_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If aCal.Count <> 0 Then
            Dim rslt As Integer = MsgBox("未登録情報があります。" & vbCrLf & "破棄して終了しますか？", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "破棄確認")
            If rslt <> MsgBoxResult.Yes Then e.Cancel = True
        End If
    End Sub


    Private Sub txtYmd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With DirectCast(sender, System.Windows.Forms.TextBox)
            Select Case e.KeyChar
                '数値のみ入力可能
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.D0) To Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.D9)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Delete)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Tab)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Help) 'なぜか "/" 対応
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Back)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                    SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
                Case Else
                    e.Handled = True
            End Select
        End With
    End Sub

    Private Sub txtNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        With DirectCast(sender, System.Windows.Forms.TextBox)
            Select Case e.KeyChar
                '数値のみ入力可能
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.D0) To Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.D9)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Delete) 'なぜか "."
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Back)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                    SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
                Case Else
                    e.Handled = True
            End Select
        End With
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNote.KeyPress, txtItem.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
        End Select
    End Sub

    Private Sub txtYmd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTarget.Leave
        If sender.text = "" Then Exit Sub
        Dim dt As Date
        If Date.TryParse(sender.Text, dt) Then
            sender.text = dt.ToString("yyyy/MM/dd")
        Else
            MsgBox("日付を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "不正入力")
        End If
    End Sub

    Private Sub txtWide_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.Leave, txtItem.Leave
        sender.text = StrConv(sender.text, VbStrConv.Wide)
    End Sub

    Private Sub Calendar_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtTarget.Focus()
    End Sub

    Private Sub cmb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbHoliday.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
        End Select
    End Sub
End Class