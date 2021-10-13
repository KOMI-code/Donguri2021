Public Class HelperReg

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub HelperReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetCombo()
        Dim Id As Integer = 0
        Dim bId As Integer = 0
        If Integer.TryParse(Me.Tag, Id) Then
            If Id <> 0 Then 'Id=0は新規作成の為、すべて空白にて表示
                Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                    cn.Open()
                    Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPER", cn)
                        'ヘルパー基本情報取得
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id '指定された利用者情報取得
                        cmd.Parameters.Add("@IsAll", SqlDbType.Bit).Value = True '非稼働分を含む
                        cmd.Parameters.Add("@Member", SqlDbType.Int).Value = 0 '単独／複合のみ
                        Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                        dr.Read()
                        Dim db As New DonguriLib.LibClass.T_Helper
                        db.SetReader(dr)
                        bId = db.ToId
                        txtFamilyName.Text = db.ToFamilyName
                        txtFirstName.Text = db.ToFirstName
                        txtSecondName.Text = db.ToSecondName
                        txtThirdName.Text = db.ToThirdName
                        txtBirthday.Text = db.ToBirthday.ToString("yyyy/MM/dd")
                        cmbSex.SelectedIndex = cmbSex.FindString(db.ToSex)
                        cmbStatus.SelectedIndex = cmbStatus.FindString(db.ToStatus)
                        dr.Close()
                    End Using
                    'ヘルパー従属情報取得
                    Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPERSLAVE", cn)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id '指定されたヘルパー情報取得
                        Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                        Do While dr.Read()
                            Dim db As New DonguriLib.LibClass.T_HelperSlave
                            db.SetReader(dr)
                            Dim it() As String = {db.ToSlaveId, db.ToHelperName, db.ToAccount, db.ToAccountMag}
                            lstSlave.Items.Add(New Windows.Forms.ListViewItem(it))
                        Loop
                        dr.Close()
                    End Using
                End Using
            End If
        End If
        cmbSlave.SelectedIndex = -1
        cmbAccount.SelectedIndex = -1
    End Sub

    Private Sub SetCombo()
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_CODE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@CodeId", SqlDbType.Int).Value = 1 '課金情報
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbAccount.Items.Clear()
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Code
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToValue
                    cmbAccount.Items.Add(ci)
                Loop
                dr.Close()
            End Using
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
                cmbSex.SelectedIndex = 0
            End Using
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
                cmbStatus.SelectedIndex = 0
            End Using
            Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPER", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全ヘルパー対象
                cmd.Parameters.Add("@IsAll", SqlDbType.Bit).Value = False '稼働分のみ
                cmd.Parameters.Add("@Member", SqlDbType.Int).Value = 1 '単独のみ
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                cmbSlave.Items.Clear()
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Helper
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToHelperName
                    cmbSlave.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub lstSlave_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstSlave.ItemSelectionChanged
        If lstSlave.SelectedItems.Count <> 0 Then '行が選択されている場合のみ実行
            Dim it As System.Windows.Forms.ListViewItem = lstSlave.SelectedItems(0)
            cmbSlave.SelectedIndex = cmbSlave.FindString(it.SubItems(1).Text)
            cmbAccount.SelectedIndex = cmbAccount.FindString(it.SubItems(2).Text)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '指定された行を削除する
        If lstSlave.SelectedItems.Count <> 0 Then '行が選択されている場合のみ実行
            lstSlave.Items.Remove(lstSlave.SelectedItems(0))
            cmbSlave.SelectedIndex = -1
            cmbAccount.SelectedIndex = -1
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
        If (cmbSlave.Text = "") And (cmbAccount.Text = "") Then Exit Sub

        If cmbSlave.Text = "" Then
            MsgBox("ヘルパーを選択して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            cmbSlave.Focus()
            Exit Sub
        End If
        If cmbAccount.Text = "" Then
            MsgBox("課金情報を選択して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
            cmbAccount.Focus()
            Exit Sub
        End If

        For I As Integer = 0 To lstSlave.Items.Count - 1
            Dim it As System.Windows.Forms.ListViewItem = lstSlave.Items(I)
            If cmbSlave.Text = it.SubItems(1).Text Then
                Dim rslt As Integer = MsgBox("指定されたヘルパーは既に登録されています。" & vbCrLf & "上書きしますか？", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "上書確認")
                If rslt = MsgBoxResult.Yes Then
                    it.SubItems(0).Text = DirectCast(cmbSlave.SelectedItem, DonguriLib.LibClass.ComboItem).Id
                    it.SubItems(1).Text = DirectCast(cmbSlave.SelectedItem, DonguriLib.LibClass.ComboItem).Value
                    it.SubItems(2).Text = DirectCast(cmbAccount.SelectedItem, DonguriLib.LibClass.ComboItem).Value
                    it.SubItems(3).Text = DirectCast(cmbAccount.SelectedItem, DonguriLib.LibClass.ComboItem).Id
                End If
                Exit Sub
            End If
        Next I
        Dim itm() As String = {DirectCast(cmbSlave.SelectedItem, DonguriLib.LibClass.ComboItem).Id, _
                               DirectCast(cmbSlave.SelectedItem, DonguriLib.LibClass.ComboItem).Value, _
                               DirectCast(cmbAccount.SelectedItem, DonguriLib.LibClass.ComboItem).Value, _
                               DirectCast(cmbAccount.SelectedItem, DonguriLib.LibClass.ComboItem).Id}
        lstSlave.Items.Add(New Windows.Forms.ListViewItem(itm))
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtFamilyName.Text = "" Then
            MsgBox("名称が未入力です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "未入力")
            txtFamilyName.Focus()
            Exit Sub
        End If
        If lstSlave.Items.Count <= 0 Then '単独ヘルパーのみチェック
            If txtFirstName.Text = "" Then
                MsgBox("名称が未入力です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "未入力")
                txtFirstName.Focus()
                Exit Sub
            End If
        End If
        If lstSlave.Items.Count <= 0 Then '単独ヘルパーのみチェック
            If txtBirthday.Text = "" Then
                MsgBox("誕生日が未入力です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "未入力")
                txtBirthday.Focus()
                Exit Sub
            End If
        End If
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Dim setId As Integer = 0
            Using cmd As New SqlClient.SqlCommand("SP_UPD_HELPER", cn)
                'ヘルパー情報設定
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = CInt(Me.Tag) 'ヘルパー番号
                cmd.Parameters.Add("@FamilyName", SqlDbType.VarChar, 10).Value = txtFamilyName.Text '名称 
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 10).Value = txtFirstName.Text '名称
                cmd.Parameters.Add("@SecondName", SqlDbType.VarChar, 10).Value = txtSecondName.Text '名称
                cmd.Parameters.Add("@ThirdName", SqlDbType.VarChar, 10).Value = txtThirdName.Text '名称
                Dim dt As Date
                If Date.TryParse(txtBirthday.Text, dt) Then
                    cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = dt '誕生日
                Else
                    cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = DBNull.Value   '誕生日
                End If
                cmd.Parameters.Add("@SexId", SqlDbType.Int).Value = DirectCast(cmbSex.SelectedItem, DonguriLib.LibClass.ComboItem).Id '性別
                If lstSlave.Items.Count <= 0 Then
                    cmd.Parameters.Add("@Member", SqlDbType.Int).Value = 1 '従属数
                Else
                    cmd.Parameters.Add("@Member", SqlDbType.Int).Value = lstSlave.Items.Count '従属数
                End If
                cmd.Parameters.Add("@StatusId", SqlDbType.Int).Value = DirectCast(cmbStatus.SelectedItem, DonguriLib.LibClass.ComboItem).Id '状態
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                dr.Read()
                setId = DirectCast(dr("Id"), Integer)
                dr.Close()
            End Using
            Using cmd As New SqlClient.SqlCommand("SP_DEL_HELPERSLAVE", cn)
                'ヘルパー従属情報削除
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = setId 'ヘルパー番号
                cmd.ExecuteNonQuery()
            End Using
            '基準ヘルパー情報設定
            If lstSlave.Items.Count <= 0 Then
                Using cmd As New SqlClient.SqlCommand("SP_INS_HELPERSLAVE", cn)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = setId '基準ヘルパー 
                    cmd.Parameters.Add("@SlaveId", SqlDbType.Int).Value = setId '基準ヘルパー 
                    cmd.Parameters.Add("@AccountMag", SqlDbType.Int).Value = 1 '課金あり
                    cmd.ExecuteNonQuery()
                End Using
            Else
                For I As Integer = 0 To lstSlave.Items.Count - 1
                    Using cmd As New SqlClient.SqlCommand("SP_INS_HELPERSLAVE", cn)
                        'ヘルパー従属情報設定
                        Dim it As System.Windows.Forms.ListViewItem = lstSlave.Items(I)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = setId '基準ヘルパー 
                        cmd.Parameters.Add("@SlaveId", SqlDbType.Int).Value = CInt(it.SubItems(0).Text) '従属ヘルパー 
                        cmd.Parameters.Add("@AccountMag", SqlDbType.Int).Value = CInt(it.SubItems(3).Text) '課金情報
                        cmd.ExecuteNonQuery()
                    End Using
                Next I
                cn.Close()
            End If
        End Using
        MsgBox("登録しました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "登録完了")
        Me.Close()
    End Sub

    Private Sub txtYmd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBirthday.KeyPress
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

    Private Sub txtName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFamilyName.KeyPress, txtFirstName.KeyPress, txtSecondName.KeyPress, txtThirdName.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
        End Select
    End Sub

    Private Sub txtYmd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBirthday.Leave

    End Sub

    Private Sub txtWide_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFamilyName.Leave, txtFirstName.Leave, txtSecondName.Leave, txtThirdName.Leave
        sender.text = StrConv(sender.text, VbStrConv.Wide)
    End Sub

    Private Sub HelperReg_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFamilyName.Focus()
    End Sub

    Private Sub cmb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSex.KeyPress, cmbStatus.KeyPress, cmbSlave.KeyPress, cmbAccount.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
        End Select
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class