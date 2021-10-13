Public Class UserReg

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub


    Private Sub UserReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetCombo()
        Dim Id As Integer = 0
        If Integer.TryParse(Me.Tag, Id) Then
            If Id <> 0 Then 'Id=0は新規作成の為、すべて空白にて表示
                Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                    cn.Open()
                    '利用者情報取得
                    Using cmd As New SqlClient.SqlCommand("SP_SEL_USER", cn)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id '対象利用者
                        cmd.Parameters.Add("@IsAll", SqlDbType.Bit).Value = True '非稼働分も対象
                        Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                        If dr.HasRows Then
                            dr.Read()
                            Dim db As New DonguriLib.LibClass.T_User
                            db.SetReader(dr)
                            txtFamilyName.Text = db.ToFamilyName
                            txtFirstName.Text = db.ToFirstName
                            If db.ToBirthday = Date.MinValue Then txtBirthday.Text = "" Else txtBirthday.Text = db.ToBirthday.ToString("yyyy/MM/dd")
                            cmbSex.SelectedIndex = cmbSex.FindString(db.ToSex)
                            cmbStatus.SelectedIndex = cmbStatus.FindString(db.ToStatus)
                        End If
                        dr.Close()
                    End Using
                    '利用者上限情報取得
                    Using cmd As New SqlClient.SqlCommand("SP_SEL_USERUPPER", cn)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id '対象利用者
                        Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                        Do While dr.Read()
                            Dim db As New DonguriLib.LibClass.T_UserUpper
                            db.SetReader(dr)
                            Dim fd As String
                            If db.ToFromDate = Date.MinValue Then fd = "" Else fd = db.ToFromDate.ToString("yyyy/MM/dd")
                            Dim it() As String = {"", fd, db.ToSin.ToString("N2"), db.ToKaj.ToString("N2"), db.ToIdo.ToString("N2"), db.ToTsu.ToString("N2")}
                            lstUpper.Items.Add(New Windows.Forms.ListViewItem(it))
                        Loop
                        dr.Close()
                    End Using
                    cn.Close()
                End Using
            End If
        End If
        txtFromDate.Text = ""
        txtSin.Text = ""
        txtKaj.Text = ""
        txtIdo.Text = ""
        txtTsu.Text = ""
    End Sub

    Private Sub SetCombo()
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_CODE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@CodeId", SqlDbType.Int).Value = 3 '性別情報
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbSex.Items.Clear()
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Code
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToValue
                    cmbSex.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            cmbSex.SelectedIndex = 0
            Using cmd As New SqlClient.SqlCommand("SP_SEL_CODE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@CodeId", SqlDbType.Int).Value = 4 '状態情報
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbStatus.Items.Clear()
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Code
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToValue
                    cmbStatus.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            cn.Close()
            cmbStatus.SelectedIndex = 0
        End Using
    End Sub

    Private Sub lstUpper_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstUpper.ItemSelectionChanged
        If lstUpper.SelectedItems.Count <> 0 Then '行が選択されている場合のみ実行
            Dim it As System.Windows.Forms.ListViewItem = lstUpper.SelectedItems(0)
            txtFromDate.Text = it.SubItems(1).Text
            txtSin.Text = it.SubItems(2).Text
            txtKaj.Text = it.SubItems(3).Text
            txtIdo.Text = it.SubItems(4).Text
            txtTsu.Text = it.SubItems(5).Text
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '指定された行を削除する
        If lstUpper.SelectedItems.Count <> 0 Then '行が選択されている場合のみ実行
            lstUpper.Items.Remove(lstUpper.SelectedItems(0))
            txtFromDate.Text = ""
            txtSin.Text = ""
            txtKaj.Text = ""
            txtIdo.Text = ""
            txtTsu.Text = ""
        End If
    End Sub

    Private Sub txtFromDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFromDate.Validating
        If txtFromDate.Text.Trim <> "" Then
            If Not IsDate(txtFromDate.Text) Then e.Cancel = True
        End If
    End Sub

    Private Sub txtSin_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSin.Validating
        If txtSin.Text.Trim <> "" Then
            Dim dc As Decimal
            If Decimal.TryParse(txtSin.Text, dc) Then
                txtSin.Text = dc.ToString("N2")
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtKaj_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtKaj.Validating
        If txtKaj.Text.Trim <> "" Then
            Dim dc As Decimal
            If Decimal.TryParse(txtKaj.Text, dc) Then
                txtKaj.Text = dc.ToString("N2")
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtBirthday_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBirthday.Validating
        If txtBirthday.Text.Trim <> "" Then
            Dim dt As Date
            If Date.TryParse(txtBirthday.Text, dt) Then
                txtBirthday.Text = dt.ToString("yyyy/MM/dd")
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtIdo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIdo.Validating
        If txtIdo.Text.Trim <> "" Then
            Dim dc As Decimal
            If Decimal.TryParse(txtIdo.Text, dc) Then
                txtIdo.Text = dc.ToString("N2")
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtTsu_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTsu.Validating
        If txtTsu.Text.Trim <> "" Then
            Dim dc As Decimal
            If Decimal.TryParse(txtTsu.Text, dc) Then
                txtTsu.Text = dc.ToString("N2")
            Else
                e.Cancel = True
            End If
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
        If (txtFromDate.Text.Trim = "") And (txtSin.Text.Trim = "") And (txtKaj.Text.Trim = "") And (txtIdo.Text.Trim = "") Then Exit Sub

        If txtFromDate.Text.Trim = "" Then
            MsgBox("適用開始日を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            txtFromDate.Focus()
            Exit Sub
        End If
        If txtSin.Text.Trim = "" Then
            MsgBox("身体上限時間を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            txtSin.Focus()
            Exit Sub
        End If
        If txtKaj.Text.Trim = "" Then
            MsgBox("家事上限時間を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            txtKaj.Focus()
            Exit Sub
        End If
        If txtIdo.Text.Trim = "" Then
            MsgBox("移動上限時間を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            txtIdo.Focus()
            Exit Sub
        End If
        If txtTsu.Text.Trim = "" Then
            MsgBox("通院上限時間を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            txtTsu.Focus()
            Exit Sub
        End If

        For I As Integer = 0 To lstUpper.Items.Count - 1
            Dim it As System.Windows.Forms.ListViewItem = lstUpper.Items(I)
            If txtFromDate.Text = it.SubItems(1).Text Then
                Dim rslt As Integer = MsgBox("指定された適用開始日は既に登録されています。" & vbCrLf & "上書きしますか？", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "上書確認")
                If rslt = MsgBoxResult.Yes Then
                    it.SubItems(2).Text = txtSin.Text
                    it.SubItems(3).Text = txtKaj.Text
                    it.SubItems(4).Text = txtIdo.Text
                    it.SubItems(5).Text = txtTsu.Text
                End If
                Exit Sub
            End If
        Next I
        Dim itm() As String = {"", txtFromDate.Text, txtSin.Text, txtKaj.Text, txtIdo.Text, txtTsu.Text}
        lstUpper.Items.Add(New Windows.Forms.ListViewItem(itm))
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtFamilyName.Text.Trim = "" Then
            MsgBox("姓が未入力です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "未入力")
            txtFamilyName.Focus()
            Exit Sub
        End If
        If txtFirstName.Text.Trim = "" Then
            MsgBox("名が未入力です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "未入力")
            txtFirstName.Focus()
            Exit Sub
        End If
        If txtBirthday.Text.Trim = "" Then
            MsgBox("誕生日が未入力です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "未入力")
            txtBirthday.Focus()
            Exit Sub
        End If
        If lstUpper.Items.Count = 0 Then
            MsgBox("上限情報が未入力です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "未入力")
            txtFromDate.Focus()
            Exit Sub
        End If

        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Dim setId As Integer = 0 '新規登録時の利用者番号
            Using cmd As New SqlClient.SqlCommand("SP_UPD_USER", cn)
                '利用者基本情報設定
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = CInt(Me.Tag) '利用者番号
                cmd.Parameters.Add("@FamilyName", SqlDbType.VarChar, 20).Value = txtFamilyName.Text '姓 
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = txtFirstName.Text '名
                cmd.Parameters.Add("@SecondName", SqlDbType.VarChar, 20).Value = "" '未使用名
                cmd.Parameters.Add("@ThirdName", SqlDbType.VarChar, 20).Value = "" '未使用名
                Dim dt As Date
                If Date.TryParse(txtBirthday.Text, dt) Then
                    cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = dt '誕生日
                Else
                    cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = DBNull.Value   '誕生日
                End If
                cmd.Parameters.Add("@SexId", SqlDbType.Int).Value = DirectCast(cmbSex.SelectedItem, DonguriLib.LibClass.ComboItem).Id  '性別
                cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = DirectCast(cmbStatus.SelectedItem, DonguriLib.LibClass.ComboItem).Id  '状態
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                dr.Read()
                setId = DirectCast(dr("Id"), Integer)
                dr.Close()
            End Using
            Using cmd As New SqlClient.SqlCommand("SP_DEL_USERUPPER", cn)
                '利用者上限情報削除
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = setId '利用者番号
                cmd.ExecuteNonQuery()
            End Using
            For I As Integer = 0 To lstUpper.Items.Count - 1
                Using cmd As New SqlClient.SqlCommand("SP_INS_USERUPPER", cn)
                    '利用者上限情報設定
                    Dim it As System.Windows.Forms.ListViewItem = lstUpper.Items(I)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = setId '利用者番号
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = CDate(it.SubItems(1).Text) '適用開始日
                    cmd.Parameters.Add("@Sin", SqlDbType.Decimal).Value = CDec(it.SubItems(2).Text) '身体上限 
                    cmd.Parameters.Add("@Kaj", SqlDbType.Decimal).Value = CDec(it.SubItems(3).Text) '家事上限 
                    cmd.Parameters.Add("@Ido", SqlDbType.Decimal).Value = CDec(it.SubItems(4).Text) '移動上限 
                    cmd.Parameters.Add("@Tsu", SqlDbType.Decimal).Value = CDec(it.SubItems(5).Text) '通院上限 
                    cmd.ExecuteNonQuery()
                End Using
            Next I
            cn.Close()
        End Using
        MsgBox("登録しました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "登録完了")
        Me.Close()
    End Sub

    Private Sub txtYmd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromDate.KeyPress, txtBirthday.KeyPress
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

    Private Sub txtNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSin.KeyPress, txtKaj.KeyPress, txtIdo.KeyPress, txtTsu.KeyPress
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

    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFamilyName.KeyPress, txtFirstName.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
        End Select
    End Sub

    Private Sub txtYmd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBirthday.Leave, txtFromDate.Leave

    End Sub

    Private Sub txtWide_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFamilyName.Leave, txtFirstName.Leave
        sender.text = StrConv(sender.text, VbStrConv.Wide)
    End Sub

    Private Sub UserReg_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFamilyName.Focus()
    End Sub

    Private Sub cmb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSex.KeyPress, cmbStatus.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
        End Select
    End Sub

End Class