Public Class Update
    Public mId As Integer
    Public mDt As New ArrayList

    Private Sub Update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim I As Integer
        For I = 0 To mDt.Count - 1
            Me.Text &= mDt(I) & "　"
        Next I
        Call SetComboItem()
        Call SetSchedule(CDate(mDt(0)), True, True)
    End Sub

    Private Sub SetComboItem()
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_CODE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@CodeId", SqlDbType.Int).Value = 2 '業務情報
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Code
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToValue
                    cmbSchJob01.Items.Add(ci) : cmbSchJob02.Items.Add(ci) : cmbSchJob03.Items.Add(ci) : cmbSchJob04.Items.Add(ci) : cmbSchJob05.Items.Add(ci)
                    cmbSchJob06.Items.Add(ci) : cmbSchJob07.Items.Add(ci) : cmbSchJob08.Items.Add(ci) : cmbSchJob09.Items.Add(ci)
                    cmbRstJob01.Items.Add(ci) : cmbRstJob02.Items.Add(ci) : cmbRstJob03.Items.Add(ci) : cmbRstJob04.Items.Add(ci) : cmbRstJob05.Items.Add(ci)
                    cmbRstJob06.Items.Add(ci) : cmbRstJob07.Items.Add(ci) : cmbRstJob08.Items.Add(ci) : cmbRstJob09.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPER", cn)
                'ヘルパー氏名取得
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全ヘルパー対象
                cmd.Parameters.Add("@IsAll", SqlDbType.Bit).Value = False '非稼働分は除く
                cmd.Parameters.Add("@Member", SqlDbType.Int).Value = 0 '単独／複合全て対象
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Helper
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToId
                    ci.Value = db.ToHelperName
                    cmbSchHelper01.Items.Add(ci) : cmbSchHelper02.Items.Add(ci) : cmbSchHelper03.Items.Add(ci) : cmbSchHelper04.Items.Add(ci) : cmbSchHelper05.Items.Add(ci)
                    cmbSchHelper06.Items.Add(ci) : cmbSchHelper07.Items.Add(ci) : cmbSchHelper08.Items.Add(ci) : cmbSchHelper09.Items.Add(ci)
                    cmbRstHelper01.Items.Add(ci) : cmbRstHelper02.Items.Add(ci) : cmbRstHelper03.Items.Add(ci) : cmbRstHelper04.Items.Add(ci) : cmbRstHelper05.Items.Add(ci)
                    cmbRstHelper06.Items.Add(ci) : cmbRstHelper07.Items.Add(ci) : cmbRstHelper08.Items.Add(ci) : cmbRstHelper09.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            Using cmd As New SqlClient.SqlCommand("SP_SEL_VIEWNOTE", cn)
                '利用者表示上位内容
                cmd.CommandType = Data.CommandType.StoredProcedure
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Note
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToCnt
                    ci.Value = db.ToNote
                    cmbSchView01.Items.Add(ci) : cmbSchView02.Items.Add(ci) : cmbSchView03.Items.Add(ci) : cmbSchView04.Items.Add(ci) : cmbSchView05.Items.Add(ci)
                    cmbSchView06.Items.Add(ci) : cmbSchView07.Items.Add(ci) : cmbSchView08.Items.Add(ci) : cmbSchView09.Items.Add(ci)
                    cmbRstView01.Items.Add(ci) : cmbRstView02.Items.Add(ci) : cmbRstView03.Items.Add(ci) : cmbRstView04.Items.Add(ci) : cmbRstView05.Items.Add(ci)
                    cmbRstView06.Items.Add(ci) : cmbRstView07.Items.Add(ci) : cmbRstView08.Items.Add(ci) : cmbRstView09.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            Using cmd As New SqlClient.SqlCommand("SP_SEL_HIDENOTE", cn)
                '利用者非表示上位内容
                cmd.CommandType = Data.CommandType.StoredProcedure
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Note
                    db.SetReader(dr)
                    Dim ci As New DonguriLib.LibClass.ComboItem
                    ci.Id = db.ToCnt
                    ci.Value = db.ToNote
                    cmbSchHide01.Items.Add(ci) : cmbSchHide02.Items.Add(ci) : cmbSchHide03.Items.Add(ci) : cmbSchHide04.Items.Add(ci) : cmbSchHide05.Items.Add(ci)
                    cmbSchHide06.Items.Add(ci) : cmbSchHide07.Items.Add(ci) : cmbSchHide08.Items.Add(ci) : cmbSchHide09.Items.Add(ci)
                    cmbRstHide01.Items.Add(ci) : cmbRstHide02.Items.Add(ci) : cmbRstHide03.Items.Add(ci) : cmbRstHide04.Items.Add(ci) : cmbRstHide05.Items.Add(ci)
                    cmbRstHide06.Items.Add(ci) : cmbRstHide07.Items.Add(ci) : cmbRstHide08.Items.Add(ci) : cmbRstHide09.Items.Add(ci)
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
    End Sub

    Private Sub SetSchedule(ByVal dt As Date, ByVal isSch As Boolean, ByVal isRst As Boolean)
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_USERDAYSCHEDULE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = dt '対象日設定
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = 0 '予定/実績抽出
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = mId '利用者番号
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim si As Integer = 0
                Dim ri As Integer = 0
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    Dim ck As System.Windows.Forms.CheckBox
                    Dim tf As System.Windows.Forms.TextBox
                    Dim tt As System.Windows.Forms.TextBox
                    Dim cj As System.Windows.Forms.ComboBox
                    Dim ch As System.Windows.Forms.ComboBox
                    Dim cc As System.Windows.Forms.CheckBox
                    Dim cv As System.Windows.Forms.ComboBox
                    Dim cx As System.Windows.Forms.ComboBox
                    If (db.ToTypeId = 1) And (isSch) Then
                        si += 1
                        ck = grpSch.Controls("chkSchAtt" & si.ToString("D2"))
                        tf = grpSch.Controls("txtSchFrom" & si.ToString("D2"))
                        tt = grpSch.Controls("txtSchTo" & si.ToString("D2"))
                        cj = grpSch.Controls("cmbSchJob" & si.ToString("D2"))
                        ch = grpSch.Controls("cmbSchHelper" & si.ToString("D2"))
                        cc = grpSch.Controls("chkSchCancel" & si.ToString("D2"))
                        cv = grpSch.Controls("cmbSchView" & si.ToString("D2"))
                        cx = grpSch.Controls("cmbSchHide" & si.ToString("D2"))
                        ck.Checked = db.ToAttention
                        tf.Text = db.ToFromTime.ToString("HH:mm")
                        tt.Text = db.ToToTime.ToString("HH:mm")
                        If db.ToJobId = 0 Then cj.SelectedIndex = -1 Else cj.SelectedIndex = cj.FindString(db.ToJob)
                        If db.ToHelperName = "" Then ch.SelectedIndex = -1 Else ch.SelectedIndex = ch.FindString(db.ToHelperName)
                        cc.Checked = db.ToIsCancel
                        cv.Text = db.ToViewNote
                        cx.Text = db.ToHideNote
                    End If
                    If (db.ToTypeId = 2) And (isRst) Then
                        ri += 1
                        ck = grpRst.Controls("chkRstAtt" & ri.ToString("D2"))
                        tf = grpRst.Controls("txtRstFrom" & ri.ToString("D2"))
                        tt = grpRst.Controls("txtRstTo" & ri.ToString("D2"))
                        cj = grpRst.Controls("cmbRstJob" & ri.ToString("D2"))
                        ch = grpRst.Controls("cmbRstHelper" & ri.ToString("D2"))
                        cv = grpRst.Controls("cmbRstView" & ri.ToString("D2"))
                        cx = grpRst.Controls("cmbRstHide" & ri.ToString("D2"))
                        ck.Checked = db.ToAttention
                        tf.Text = db.ToFromTime.ToString("HH:mm")
                        tt.Text = db.ToToTime.ToString("HH:mm")
                        If db.ToJobId = 0 Then cj.SelectedIndex = -1 Else cj.SelectedIndex = cj.FindString(db.ToJob)
                        If db.ToHelperName = "" Then ch.SelectedIndex = -1 Else ch.SelectedIndex = ch.FindString(db.ToHelperName)
                        cv.Text = db.ToViewNote
                        cx.Text = db.ToHideNote
                    End If
                Loop
                dr.Close()
            End Using
        End Using
    End Sub

    Private Sub btnSchCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSchCopy.Click
        Dim rslt As Integer = MsgBox("現在の情報を破棄し、" & vbCrLf & _
                    "指定された [ " & dtpSchCopy.Text & " ] の内容で上書きします。" & vbCrLf & _
                    "よろしいですか？", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "上書確認")
        If rslt = MsgBoxResult.Yes Then
            Call ClrItem(True, False)
            Call SetSchedule(dtpSchCopy.Value, True, False)
        End If
    End Sub

    Private Sub btnToSchCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToSchCopy.Click
        Dim rslt As Integer = MsgBox("現在の情報を破棄し、" & vbCrLf & _
                    "[ 本日予定 ] の内容で上書きします。" & vbCrLf & _
                    "よろしいですか？", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "上書確認")
        If rslt = MsgBoxResult.Yes Then
            If Not chkSchCancel01.Checked Then
                chkRstAtt01.Checked = chkSchAtt01.Checked : txtRstFrom01.Text = txtSchFrom01.Text : txtRstTo01.Text = txtSchTo01.Text
                cmbRstJob01.SelectedIndex = cmbSchJob01.SelectedIndex : cmbRstHelper01.SelectedIndex = cmbSchHelper01.SelectedIndex
                cmbRstView01.Text = cmbSchView01.Text : cmbRstHide01.Text = cmbSchHide01.Text
            End If
            If Not chkSchCancel02.Checked Then
                chkRstAtt02.Checked = chkSchAtt02.Checked : txtRstFrom02.Text = txtSchFrom02.Text : txtRstTo02.Text = txtSchTo02.Text
                cmbRstJob02.SelectedIndex = cmbSchJob02.SelectedIndex : cmbRstHelper02.SelectedIndex = cmbSchHelper02.SelectedIndex
                cmbRstView02.Text = cmbSchView02.Text : cmbRstHide02.Text = cmbSchHide02.Text
            End If
            If Not chkSchCancel03.Checked Then
                chkRstAtt03.Checked = chkSchAtt03.Checked : txtRstFrom03.Text = txtSchFrom03.Text : txtRstTo03.Text = txtSchTo03.Text
                cmbRstJob03.SelectedIndex = cmbSchJob03.SelectedIndex : cmbRstHelper03.SelectedIndex = cmbSchHelper03.SelectedIndex
                cmbRstView03.Text = cmbSchView03.Text : cmbRstHide03.Text = cmbSchHide03.Text
            End If
            If Not chkSchCancel04.Checked Then
                chkRstAtt04.Checked = chkSchAtt04.Checked : txtRstFrom04.Text = txtSchFrom04.Text : txtRstTo04.Text = txtSchTo04.Text
                cmbRstJob04.SelectedIndex = cmbSchJob04.SelectedIndex : cmbRstHelper04.SelectedIndex = cmbSchHelper04.SelectedIndex
                cmbRstView04.Text = cmbSchView04.Text : cmbRstHide04.Text = cmbSchHide04.Text
            End If
            If Not chkSchCancel05.Checked Then
                chkRstAtt05.Checked = chkSchAtt05.Checked : txtRstFrom05.Text = txtSchFrom05.Text : txtRstTo05.Text = txtSchTo05.Text
                cmbRstJob05.SelectedIndex = cmbSchJob05.SelectedIndex : cmbRstHelper05.SelectedIndex = cmbSchHelper05.SelectedIndex
                cmbRstView05.Text = cmbSchView05.Text : cmbRstHide05.Text = cmbSchHide05.Text
            End If
            If Not chkSchCancel06.Checked Then
                chkRstAtt06.Checked = chkSchAtt06.Checked : txtRstFrom06.Text = txtSchFrom06.Text : txtRstTo06.Text = txtSchTo06.Text
                cmbRstJob06.SelectedIndex = cmbSchJob06.SelectedIndex : cmbRstHelper06.SelectedIndex = cmbSchHelper06.SelectedIndex
                cmbRstView06.Text = cmbSchView06.Text : cmbRstHide06.Text = cmbSchHide06.Text
            End If
            If Not chkSchCancel07.Checked Then
                chkRstAtt07.Checked = chkSchAtt07.Checked : txtRstFrom07.Text = txtSchFrom07.Text : txtRstTo07.Text = txtSchTo07.Text
                cmbRstJob07.SelectedIndex = cmbSchJob07.SelectedIndex : cmbRstHelper07.SelectedIndex = cmbSchHelper07.SelectedIndex
                cmbRstView07.Text = cmbSchView07.Text : cmbRstHide07.Text = cmbSchHide07.Text
            End If
            If Not chkSchCancel08.Checked Then
                chkRstAtt08.Checked = chkSchAtt08.Checked : txtRstFrom08.Text = txtSchFrom08.Text : txtRstTo08.Text = txtSchTo08.Text
                cmbRstJob08.SelectedIndex = cmbSchJob08.SelectedIndex : cmbRstHelper08.SelectedIndex = cmbSchHelper08.SelectedIndex
                cmbRstView08.Text = cmbSchView08.Text : cmbRstHide08.Text = cmbSchHide08.Text
            End If
            If Not chkSchCancel09.Checked Then
                chkRstAtt09.Checked = chkSchAtt09.Checked : txtRstFrom09.Text = txtSchFrom09.Text : txtRstTo09.Text = txtSchTo09.Text
                cmbRstJob09.SelectedIndex = cmbSchJob09.SelectedIndex : cmbRstHelper09.SelectedIndex = cmbSchHelper09.SelectedIndex
                cmbRstView09.Text = cmbSchView09.Text : cmbRstHide09.Text = cmbSchHide09.Text
            End If
        End If
    End Sub

    Private Sub btnRstCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRstCopy.Click
        Dim rslt As Integer = MsgBox("現在の情報を破棄し、" & vbCrLf & _
                    "指定された [ " & dtpRstCopy.Text & " ] の内容で上書きします。" & vbCrLf & _
                    "よろしいですか？", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "上書確認")
        If rslt = MsgBoxResult.Yes Then
            Call ClrItem(False, True)
            Call SetSchedule(dtpRstCopy.Value, False, True)
        End If
    End Sub

    Private Sub ClrItem(ByVal isSch As Boolean, ByVal isRst As Boolean)
        If isSch Then
            chkSchAtt01.Checked = False : chkSchAtt02.Checked = False : chkSchAtt03.Checked = False : chkSchAtt04.Checked = False : chkSchAtt05.Checked = False
            chkSchAtt06.Checked = False : chkSchAtt07.Checked = False : chkSchAtt08.Checked = False : chkSchAtt09.Checked = False
            chkSchCancel01.Checked = False : chkSchCancel02.Checked = False : chkSchCancel03.Checked = False : chkSchCancel04.Checked = False : chkSchCancel05.Checked = False
            chkSchCancel06.Checked = False : chkSchCancel07.Checked = False : chkSchCancel08.Checked = False : chkSchCancel09.Checked = False
            txtSchFrom01.Clear() : txtSchFrom02.Clear() : txtSchFrom03.Clear() : txtSchFrom04.Clear() : txtSchFrom05.Clear()
            txtSchFrom06.Clear() : txtSchFrom07.Clear() : txtSchFrom08.Clear() : txtSchFrom09.Clear()
            txtSchTo01.Clear() : txtSchTo02.Clear() : txtSchTo03.Clear() : txtSchTo04.Clear() : txtSchTo05.Clear()
            txtSchTo06.Clear() : txtSchTo07.Clear() : txtSchTo08.Clear() : txtSchTo09.Clear()
            cmbSchJob01.SelectedIndex = -1 : cmbSchJob02.SelectedIndex = -1 : cmbSchJob03.SelectedIndex = -1 : cmbSchJob04.SelectedIndex = -1 : cmbSchJob05.SelectedIndex = -1
            cmbSchJob06.SelectedIndex = -1 : cmbSchJob07.SelectedIndex = -1 : cmbSchJob08.SelectedIndex = -1 : cmbSchJob09.SelectedIndex = -1
            cmbSchHelper01.SelectedIndex = -1 : cmbSchHelper02.SelectedIndex = -1 : cmbSchHelper03.SelectedIndex = -1 : cmbSchHelper04.SelectedIndex = -1 : cmbSchHelper05.SelectedIndex = -1
            cmbSchHelper06.SelectedIndex = -1 : cmbSchHelper07.SelectedIndex = -1 : cmbSchHelper08.SelectedIndex = -1 : cmbSchHelper09.SelectedIndex = -1
            cmbSchView01.Text = "" : cmbSchView02.Text = "" : cmbSchView03.Text = "" : cmbSchView04.Text = "" : cmbSchView05.Text = ""
            cmbSchView06.Text = "" : cmbSchView07.Text = "" : cmbSchView08.Text = "" : cmbSchView09.Text = ""
            cmbSchHide01.Text = "" : cmbSchHide02.Text = "" : cmbSchHide03.Text = "" : cmbSchHide04.Text = "" : cmbSchHide05.Text = ""
            cmbSchHide06.Text = "" : cmbSchHide07.Text = "" : cmbSchHide08.Text = "" : cmbSchHide09.Text = ""
        End If

        If isRst Then
            chkRstAtt01.Checked = False : chkRstAtt02.Checked = False : chkRstAtt03.Checked = False : chkRstAtt04.Checked = False : chkRstAtt05.Checked = False
            chkRstAtt06.Checked = False : chkRstAtt07.Checked = False : chkRstAtt08.Checked = False : chkRstAtt09.Checked = False
            txtRstFrom01.Clear() : txtRstFrom02.Clear() : txtRstFrom03.Clear() : txtRstFrom04.Clear() : txtRstFrom05.Clear()
            txtRstFrom06.Clear() : txtRstFrom07.Clear() : txtRstFrom08.Clear() : txtRstFrom09.Clear()
            txtRstTo01.Clear() : txtRstTo02.Clear() : txtRstTo03.Clear() : txtRstTo04.Clear() : txtRstTo05.Clear()
            txtRstTo06.Clear() : txtRstTo07.Clear() : txtRstTo08.Clear() : txtRstTo09.Clear()
            cmbRstJob01.SelectedIndex = -1 : cmbRstJob02.SelectedIndex = -1 : cmbRstJob03.SelectedIndex = -1 : cmbRstJob04.SelectedIndex = -1 : cmbRstJob05.SelectedIndex = -1
            cmbRstJob06.SelectedIndex = -1 : cmbRstJob07.SelectedIndex = -1 : cmbRstJob08.SelectedIndex = -1 : cmbRstJob09.SelectedIndex = -1
            cmbRstHelper01.SelectedIndex = -1 : cmbRstHelper02.SelectedIndex = -1 : cmbRstHelper03.SelectedIndex = -1 : cmbRstHelper04.SelectedIndex = -1 : cmbRstHelper05.SelectedIndex = -1
            cmbRstHelper06.SelectedIndex = -1 : cmbRstHelper07.SelectedIndex = -1 : cmbRstHelper08.SelectedIndex = -1 : cmbRstHelper09.SelectedIndex = -1
            cmbRstView01.Text = "" : cmbRstView02.Text = "" : cmbRstView03.Text = "" : cmbRstView04.Text = "" : cmbRstView05.Text = ""
            cmbRstView06.Text = "" : cmbRstView07.Text = "" : cmbRstView08.Text = "" : cmbRstView09.Text = ""
            cmbRstHide01.Text = "" : cmbRstHide02.Text = "" : cmbRstHide03.Text = "" : cmbRstHide04.Text = "" : cmbRstHide05.Text = ""
            cmbRstHide06.Text = "" : cmbRstHide07.Text = "" : cmbRstHide08.Text = "" : cmbRstHide09.Text = ""
        End If
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtSchFrom01.KeyPress, txtSchFrom02.KeyPress, txtSchFrom03.KeyPress, txtSchFrom04.KeyPress, txtSchFrom05.KeyPress, _
                txtSchFrom06.KeyPress, txtSchFrom07.KeyPress, txtSchFrom08.KeyPress, txtSchFrom09.KeyPress, _
                txtRstFrom01.KeyPress, txtRstFrom02.KeyPress, txtRstFrom03.KeyPress, txtRstFrom04.KeyPress, txtRstFrom05.KeyPress, _
                txtRstFrom06.KeyPress, txtRstFrom07.KeyPress, txtRstFrom08.KeyPress, txtRstFrom09.KeyPress, _
                txtSchTo01.KeyPress, txtSchTo02.KeyPress, txtSchTo03.KeyPress, txtSchTo04.KeyPress, txtSchTo05.KeyPress, _
                txtSchTo06.KeyPress, txtSchTo07.KeyPress, txtSchTo08.KeyPress, txtSchTo09.KeyPress, _
                txtRstTo01.KeyPress, txtRstTo02.KeyPress, txtRstTo03.KeyPress, txtRstTo04.KeyPress, txtRstTo05.KeyPress, _
                txtRstTo06.KeyPress, txtRstTo07.KeyPress, txtRstTo08.KeyPress, txtRstTo09.KeyPress
        With DirectCast(sender, System.Windows.Forms.TextBox)
            Select Case e.KeyChar
                '数値のみ入力可能
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.D0) To Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.D9)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Delete)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Tab)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Back)
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                    SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
                Case Else
                    e.Handled = True
            End Select
        End With
    End Sub

    Private Sub txt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtSchFrom01.Leave, txtSchFrom02.Leave, txtSchFrom03.Leave, txtSchFrom04.Leave, txtSchFrom05.Leave, _
                txtSchFrom06.Leave, txtSchFrom07.Leave, txtSchFrom08.Leave, txtSchFrom09.Leave, _
                txtRstFrom01.Leave, txtRstFrom02.Leave, txtRstFrom03.Leave, txtRstFrom04.Leave, txtRstFrom05.Leave, _
                txtRstFrom06.Leave, txtRstFrom07.Leave, txtRstFrom08.Leave, txtRstFrom09.Leave, _
                txtSchTo01.Leave, txtSchTo02.Leave, txtSchTo03.Leave, txtSchTo04.Leave, txtSchTo05.Leave, _
                txtSchTo06.Leave, txtSchTo07.Leave, txtSchTo08.Leave, txtSchTo09.Leave, _
                txtRstTo01.Leave, txtRstTo02.Leave, txtRstTo03.Leave, txtRstTo04.Leave, txtRstTo05.Leave, _
                txtRstTo06.Leave, txtRstTo07.Leave, txtRstTo08.Leave, txtRstTo09.Leave

        Dim fr As Windows.Forms.TextBox = DirectCast(sender, System.Windows.Forms.TextBox)
        With fr
            If .Text = "" Then
                If fr.Name.Substring(6, 4) = "From" Then
                    Dim t1 As String = fr.Name.Substring(3, 3) 'Sch,Rst
                    Dim t2 As String = fr.Name.Substring(fr.Name.Length - 2, 2) 'No
                    Dim ck As Windows.Forms.CheckBox
                    Dim tf As Windows.Forms.TextBox
                    Dim cj As Windows.Forms.ComboBox
                    Dim ch As Windows.Forms.ComboBox
                    Dim cv As Windows.Forms.ComboBox
                    Dim ce As Windows.Forms.ComboBox
                    If t1 = "Sch" Then
                        ck = grpSch.Controls("chkSch" & "Att" & t2)
                        tf = grpSch.Controls("txtSch" & "To" & t2)
                        cj = grpSch.Controls("cmbSch" & "Job" & t2)
                        ch = grpSch.Controls("cmbSch" & "Helper" & t2)
                        cv = grpSch.Controls("cmbSch" & "View" & t2)
                        ce = grpSch.Controls("cmbSch" & "Hide" & t2)
                    Else
                        ck = grpRst.Controls("chkRst" & "Att" & t2)
                        tf = grpRst.Controls("txtRst" & "To" & t2)
                        cj = grpRst.Controls("cmbRst" & "Job" & t2)
                        ch = grpRst.Controls("cmbRst" & "Helper" & t2)
                        cv = grpRst.Controls("cmbRst" & "View" & t2)
                        ce = grpRst.Controls("cmbRst" & "Hide" & t2)
                    End If
                    If ck.Checked Or (tf.Text <> "") Or (cj.Text <> "") Or (ch.Text <> "") Or (cv.Text <> "") Or (ce.Text <> "") Then
                        Dim rslt As Integer = MsgBox("現在の行を削除しますか？", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "削除確認")
                        If rslt = MsgBoxResult.Yes Then
                            ck.Checked = False
                            tf.Text = ""
                            cj.SelectedIndex = -1
                            ch.SelectedIndex = -1
                            cv.Text = ""
                            ce.Text = ""
                        End If
                    End If
                End If
                Else
                    Select Case .Text.Length
                        Case 0 '空白は除外
                        Case 1 : .Text = "00:0" & .Text
                        Case 2 : .Text = "00:" & .Text
                        Case 3 : .Text = "0" & .Text.Substring(0, 1) & ":" & .Text.Substring(1)
                        Case 4 : .Text = .Text.Substring(0, 2) & ":" & .Text.Substring(2)
                    End Select
                    Dim dt As Date
                    If Date.TryParse(.Text, dt) Then
                    Else
                        MsgBox("時間を入力して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "不正入力")
                        .Focus()
                    End If
                End If
        End With
    End Sub

    Private Sub txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtSchFrom01.Enter, txtSchFrom02.Enter, txtSchFrom03.Enter, txtSchFrom04.Enter, txtSchFrom05.Enter, _
                txtSchFrom06.Enter, txtSchFrom07.Enter, txtSchFrom08.Enter, txtSchFrom09.Enter, _
                txtRstFrom01.Enter, txtRstFrom02.Enter, txtRstFrom03.Enter, txtRstFrom04.Enter, txtRstFrom05.Enter, _
                txtRstFrom06.Enter, txtRstFrom07.Enter, txtRstFrom08.Enter, txtRstFrom09.Enter, _
                txtSchTo01.Enter, txtSchTo02.Enter, txtSchTo03.Enter, txtSchTo04.Enter, txtSchTo05.Enter, _
                txtSchTo06.Enter, txtSchTo07.Enter, txtSchTo08.Enter, txtSchTo09.Enter, _
                txtRstTo01.Enter, txtRstTo02.Enter, txtRstTo03.Enter, txtRstTo04.Enter, txtRstTo05.Enter, _
                txtRstTo06.Enter, txtRstTo07.Enter, txtRstTo08.Enter, txtRstTo09.Enter

        With DirectCast(sender, System.Windows.Forms.TextBox)
            .Text = .Text.Replace(":", "") 'コロンを除去する
            .SelectAll() '数値全体を選択
        End With
    End Sub

    Private Sub cmbItemList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles cmbSchJob01.KeyPress, cmbSchJob02.KeyPress, cmbSchJob03.KeyPress, cmbSchJob04.KeyPress, cmbSchJob05.KeyPress, _
                    cmbSchJob06.KeyPress, cmbSchJob07.KeyPress, cmbSchJob08.KeyPress, cmbSchJob09.KeyPress, _
                    cmbSchHelper01.KeyPress, cmbSchHelper02.KeyPress, cmbSchHelper03.KeyPress, cmbSchHelper04.KeyPress, cmbSchHelper05.KeyPress, _
                    cmbSchHelper06.KeyPress, cmbSchHelper07.KeyPress, cmbSchHelper08.KeyPress, cmbSchHelper09.KeyPress, _
                    cmbRstJob01.KeyPress, cmbRstJob02.KeyPress, cmbRstJob03.KeyPress, cmbRstJob04.KeyPress, cmbRstJob05.KeyPress, _
                    cmbRstJob06.KeyPress, cmbRstJob07.KeyPress, cmbRstJob08.KeyPress, cmbRstJob09.KeyPress, _
                    cmbRstHelper01.KeyPress, cmbRstHelper02.KeyPress, cmbRstHelper03.KeyPress, cmbRstHelper04.KeyPress, cmbRstHelper05.KeyPress, _
                    cmbRstHelper06.KeyPress, cmbRstHelper07.KeyPress, cmbRstHelper08.KeyPress, cmbRstHelper09.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
        End Select
    End Sub

    Private Sub cmbItem_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles cmbSchView01.KeyPress, cmbSchView02.KeyPress, cmbSchView03.KeyPress, cmbSchView04.KeyPress, cmbSchView05.KeyPress, _
                    cmbSchView06.KeyPress, cmbSchView07.KeyPress, cmbSchView08.KeyPress, cmbSchView09.KeyPress, _
                    cmbSchHide01.KeyPress, cmbSchHide02.KeyPress, cmbSchHide03.KeyPress, cmbSchHide04.KeyPress, cmbSchHide05.KeyPress, _
                    cmbSchHide06.KeyPress, cmbSchHide07.KeyPress, cmbSchHide08.KeyPress, cmbSchHide09.KeyPress, _
                    cmbRstView01.KeyPress, cmbRstView02.KeyPress, cmbRstView03.KeyPress, cmbRstView04.KeyPress, cmbRstView05.KeyPress, _
                    cmbRstView06.KeyPress, cmbRstView07.KeyPress, cmbRstView08.KeyPress, cmbRstView09.KeyPress, _
                    cmbRstHide01.KeyPress, cmbRstHide02.KeyPress, cmbRstHide03.KeyPress, cmbRstHide04.KeyPress, cmbRstHide05.KeyPress, _
                    cmbRstHide06.KeyPress, cmbRstHide07.KeyPress, cmbRstHide08.KeyPress, cmbRstHide09.KeyPress
        With DirectCast(sender, System.Windows.Forms.ComboBox)
            Select Case e.KeyChar
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                    SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Escape)
                    .DropDownStyle = Windows.Forms.ComboBoxStyle.DropDown
                    If Not .DroppedDown Then .DroppedDown = True 'ドロップダウンを開く
                Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Down)
                    .DropDownStyle = Windows.Forms.ComboBoxStyle.DropDown
                    If Not .DroppedDown Then .DroppedDown = True 'ドロップダウンを開く
            End Select
        End With
    End Sub

    Private Sub cmbItem_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles cmbSchView01.Leave, cmbSchView02.Leave, cmbSchView03.Leave, cmbSchView04.Leave, cmbSchView05.Leave, _
                    cmbSchView06.Leave, cmbSchView07.Leave, cmbSchView08.Leave, cmbSchView09.Leave, _
                    cmbSchHide01.Leave, cmbSchHide02.Leave, cmbSchHide03.Leave, cmbSchHide04.Leave, cmbSchHide05.Leave, _
                    cmbSchHide06.Leave, cmbSchHide07.Leave, cmbSchHide08.Leave, cmbSchHide09.Leave, _
                    cmbRstView01.Leave, cmbRstView02.Leave, cmbRstView03.Leave, cmbRstView04.Leave, cmbRstView05.Leave, _
                    cmbRstView06.Leave, cmbRstView07.Leave, cmbRstView08.Leave, cmbRstView09.Leave, _
                    cmbRstHide01.Leave, cmbRstHide02.Leave, cmbRstHide03.Leave, cmbRstHide04.Leave, cmbRstHide05.Leave, _
                    cmbRstHide06.Leave, cmbRstHide07.Leave, cmbRstHide08.Leave, cmbRstHide09.Leave
        Dim cmb As Windows.Forms.ComboBox = DirectCast(sender, Windows.Forms.ComboBox)
        cmb.Text = cmb.Text.Replace("～", "-")
        cmb.Text = StrConv(sender.text, VbStrConv.Narrow).Trim
        sender.DropDownStyle = Windows.Forms.ComboBoxStyle.Simple

    End Sub

    Private Sub cmbItemList_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles cmbSchJob01.Enter, cmbSchJob02.Enter, cmbSchJob03.Enter, cmbSchJob04.Enter, cmbSchJob05.Enter, _
                    cmbSchJob06.Enter, cmbSchJob07.Enter, cmbSchJob08.Enter, cmbSchJob09.Enter, _
                    cmbSchHelper01.Enter, cmbSchHelper02.Enter, cmbSchHelper03.Enter, cmbSchHelper04.Enter, cmbSchHelper05.Enter, _
                    cmbSchHelper06.Enter, cmbSchHelper07.Enter, cmbSchHelper08.Enter, cmbSchHelper09.Enter, _
                    cmbRstJob01.Enter, cmbRstJob02.Enter, cmbRstJob03.Enter, cmbRstJob04.Enter, cmbRstJob05.Enter, _
                    cmbRstJob06.Enter, cmbRstJob07.Enter, cmbRstJob08.Enter, cmbRstJob09.Enter, _
                    cmbRstHelper01.Enter, cmbRstHelper02.Enter, cmbRstHelper03.Enter, cmbRstHelper04.Enter, cmbRstHelper05.Enter, _
                    cmbRstHelper06.Enter, cmbRstHelper07.Enter, cmbRstHelper08.Enter, cmbRstHelper09.Enter
        With DirectCast(sender, System.Windows.Forms.ComboBox)
            If Not .DroppedDown Then .DroppedDown = True
        End With
    End Sub

    Private Sub chkAtt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles chkSchAtt01.KeyPress, chkSchAtt02.KeyPress, chkSchAtt03.KeyPress, chkSchAtt04.KeyPress, chkSchAtt05.KeyPress, _
                    chkSchAtt06.KeyPress, chkSchAtt07.KeyPress, chkSchAtt08.KeyPress, chkSchAtt09.KeyPress, _
                    chkRstAtt01.KeyPress, chkRstAtt02.KeyPress, chkRstAtt03.KeyPress, chkRstAtt04.KeyPress, chkRstAtt05.KeyPress, _
                    chkRstAtt06.KeyPress, chkRstAtt07.KeyPress, chkRstAtt08.KeyPress, chkRstAtt09.KeyPress, _
                    chkSchCancel01.KeyPress, chkSchCancel02.KeyPress, chkSchCancel03.KeyPress, chkSchCancel04.KeyPress, chkSchCancel05.KeyPress, _
                    chkSchCancel06.KeyPress, chkSchCancel07.KeyPress, chkSchCancel08.KeyPress, chkSchCancel09.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Enter)
                SelectNextControl(sender, True, True, True, False) '次のコントロールへ移動
        End Select
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim ar As New ArrayList
        ar.Clear()
        Dim I As Integer
        For I = 1 To 9
            Dim ck As System.Windows.Forms.CheckBox = grpSch.Controls("chkSchAtt" & I.ToString("D2"))
            Dim tf As System.Windows.Forms.TextBox = grpSch.Controls("txtSchFrom" & I.ToString("D2"))
            Dim tt As System.Windows.Forms.TextBox = grpSch.Controls("txtSchTo" & I.ToString("D2"))
            Dim cj As System.Windows.Forms.ComboBox = grpSch.Controls("cmbSchJob" & I.ToString("D2"))
            Dim ch As System.Windows.Forms.ComboBox = grpSch.Controls("cmbSchHelper" & I.ToString("D2"))
            Dim cc As System.Windows.Forms.CheckBox = grpSch.Controls("chkSchCancel" & I.ToString("D2"))
            Dim cv As System.Windows.Forms.ComboBox = grpSch.Controls("cmbSchView" & I.ToString("D2"))
            Dim cx As System.Windows.Forms.ComboBox = grpSch.Controls("cmbSchHide" & I.ToString("D2"))

            If (ck.Checked) Or (tf.Text <> "") Or (tt.Text <> "") Or (cj.Text <> "") Or (ch.Text <> "") Or (cv.Text <> "") Or (cx.Text <> "") Then

                If (tf.Text = "") Then
                    MsgBox("開始時刻を設定して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
                    tf.Focus()
                    Exit Sub
                End If
                If (tt.Text = "") Then
                    MsgBox("終了時刻を設定して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
                    tt.Focus()
                    Exit Sub
                End If
                If (cj.Text = "") Then
                    MsgBox("業務内容設定して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
                    cj.Focus()
                    Exit Sub
                End If
                If (ch.Text = "") Then
                    MsgBox("担当ヘルパー設定して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
                    ch.Focus()
                    Exit Sub
                End If
                If (tf.Text = "") And (tt.Text = "") And (cj.Text = "") And (ch.Text = "") And (cv.Text = "") And (cx.Text = "") Then
                    'ck.Checkedのみは無効
                Else
                    Dim ix As Integer
                    For ix = 0 To mDt.Count - 1
                        Dim sch As New DonguriLib.LibClass.T_Schedule
                        sch.SetAttention(ck.Checked)
                        sch.SetUserId(mId)
                        If ch.Text = "" Then sch.SetHelperId(0) Else sch.SetHelperId(DirectCast(ch.SelectedItem, DonguriLib.LibClass.ComboItem).Id)
                        If cj.Text = "" Then sch.SetJobId(0) Else sch.SetJobId(DirectCast(cj.SelectedItem, DonguriLib.LibClass.ComboItem).Id)
                        sch.SetTypeId(1) '予定
                        Dim tp As Date
                        If Date.TryParse(mDt(ix), tp) Then
                            sch.SetTarget(tp)
                        Else
                            'ここにはこないはず
                            MsgBox("対象日[ " & mDt(ix) & " ]が不正です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力不正")
                            tf.Focus()
                            Exit Sub
                        End If
                        If Date.TryParse(mDt(ix) & " " & tf.Text, tp) Then
                            sch.SetFromTime(tp)
                        Else
                            'ここにはこないはず
                            MsgBox("開始時刻[ " & mDt(ix) & " " & tf.Text & " ]が不正です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力不正")
                            tf.Focus()
                            Exit Sub
                        End If
                        If Date.TryParse(mDt(ix) & " " & tt.Text, tp) Then
                            sch.SetToTime(tp)
                        Else
                            'ここにはこないはず
                            MsgBox("対象日[ " & mDt(ix) & " " & tt.Text & " ]が不正です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力不正")
                            tt.Focus()
                            Exit Sub
                        End If
                        '終了時刻が開始時刻より小さい場合、翌日とする
                        If sch.ToFromTime > sch.ToToTime Then sch.SetToTime(DateAdd(DateInterval.Day, 1, sch.ToToTime))
                        sch.SetIsCancel(cc.Checked)
                        sch.SetViewNote(cv.Text)
                        sch.SetHideNote(cx.Text)
                        ar.Add(sch)
                    Next ix
                End If
            End If
        Next I
        For I = 1 To 9
            Dim ck As System.Windows.Forms.CheckBox = grpRst.Controls("chkRstAtt" & I.ToString("D2"))
            Dim tf As System.Windows.Forms.TextBox = grpRst.Controls("txtRstFrom" & I.ToString("D2"))
            Dim tt As System.Windows.Forms.TextBox = grpRst.Controls("txtRstTo" & I.ToString("D2"))
            Dim cj As System.Windows.Forms.ComboBox = grpRst.Controls("cmbRstJob" & I.ToString("D2"))
            Dim ch As System.Windows.Forms.ComboBox = grpRst.Controls("cmbRstHelper" & I.ToString("D2"))
            Dim cv As System.Windows.Forms.ComboBox = grpRst.Controls("cmbRstView" & I.ToString("D2"))
            Dim cx As System.Windows.Forms.ComboBox = grpRst.Controls("cmbRstHide" & I.ToString("D2"))

            If (ck.Checked) Or (tf.Text <> "") Or (tt.Text <> "") Or (cj.Text <> "") Or (ch.Text <> "") Or (cv.Text <> "") Or (cx.Text <> "") Then

                If (tf.Text = "") Then
                    MsgBox("開始時刻を設定して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
                    tf.Focus()
                    Exit Sub
                End If
                If (tt.Text = "") Then
                    MsgBox("終了時刻を設定して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
                    tt.Focus()
                    Exit Sub
                End If
                If (cj.Text = "") Then
                    MsgBox("業務内容設定して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
                    cj.Focus()
                    Exit Sub
                End If
                If (ch.Text = "") Then
                    MsgBox("担当ヘルパー設定して下さい。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力未済")
                    ch.Focus()
                    Exit Sub
                End If
                If (tf.Text = "") And (tt.Text = "") And (cj.Text = "") And (ch.Text = "") And (cv.Text = "") And (cx.Text = "") Then
                    'ck.Checkedのみは無効
                Else
                    Dim ix As Integer
                    For ix = 0 To mDt.Count - 1
                        Dim sch As New DonguriLib.LibClass.T_Schedule
                        sch.SetAttention(ck.Checked)
                        sch.SetUserId(mId)
                        If ch.Text = "" Then sch.SetHelperId(0) Else sch.SetHelperId(DirectCast(ch.SelectedItem, DonguriLib.LibClass.ComboItem).Id)
                        If cj.Text = "" Then sch.SetJobId(0) Else sch.SetJobId(DirectCast(cj.SelectedItem, DonguriLib.LibClass.ComboItem).Id)
                        sch.SetTypeId(2) '実績
                        Dim tp As Date
                        If Date.TryParse(mDt(ix), tp) Then
                            sch.SetTarget(tp)
                        Else
                            'ここにはこないはず
                            MsgBox("対象日[ " & mDt(ix) & " ]が不正です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力不正")
                            tf.Focus()
                            Exit Sub
                        End If
                        If Date.TryParse(mDt(ix) & " " & tf.Text, tp) Then
                            sch.SetFromTime(tp)
                        Else
                            'ここにはこないはず
                            MsgBox("開始時刻[ " & mDt(ix) & " " & tf.Text & " ]が不正です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力不正")
                            tf.Focus()
                            Exit Sub
                        End If
                        If Date.TryParse(mDt(ix) & " " & tt.Text, tp) Then
                            sch.SetToTime(tp)
                        Else
                            'ここにはこないはず
                            MsgBox("対象日[ " & mDt(ix) & " " & tt.Text & " ]が不正です。", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "入力不正")
                            tt.Focus()
                            Exit Sub
                        End If
                        '終了時刻が開始時刻より小さい場合、翌日とする
                        If sch.ToFromTime > sch.ToToTime Then sch.SetToTime(DateAdd(DateInterval.Day, 1, sch.ToToTime))
                        sch.SetViewNote(cv.Text)
                        sch.SetHideNote(cx.Text)
                        ar.Add(sch)
                    Next ix
                End If
            End If
        Next I

        Dim st As String = " "
        For dx = 0 To mDt.Count - 1
            st &= mDt(dx) & " "
        Next dx
        Dim rslt As Integer = MsgBox("登録された内容を下記対象者及び対象日に対して上書きします。" & vbCrLf & _
                                      "よろしいですか？" & vbCrLf & _
                                      "対象者 = [ " & Me.Tag & " ]" & vbCrLf & _
                                      "対象日 = [" & st & "]", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "上書確認")
        If rslt = MsgBoxResult.Yes Then
            Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                cn.Open()
                For dtx = 0 To mDt.Count - 1
                    Using cmd As New SqlClient.SqlCommand("SP_DEL_SCHEDULE", cn)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = mDt(dtx) '対象日設定
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = mId '利用者番号
                        cmd.ExecuteNonQuery()
                    End Using
                Next dtx
                For itx = 0 To ar.Count - 1
                    Using cmd As New SqlClient.SqlCommand("SP_INS_SCHEDULE", cn)
                        cmd.CommandType = Data.CommandType.StoredProcedure
                        Dim sch As DonguriLib.LibClass.T_Schedule = DirectCast(ar(itx), DonguriLib.LibClass.T_Schedule)
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = sch.ToUserId '利用者番号
                        cmd.Parameters.Add("@HelperId", SqlDbType.Int).Value = sch.ToHelperId 'ヘルパー番号
                        cmd.Parameters.Add("@JobId", SqlDbType.Int).Value = sch.ToJobId '業務番号
                        cmd.Parameters.Add("@TypeId", SqlDbType.Int).Value = sch.ToTypeId '予定/実績
                        cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = sch.ToTarget '対象日
                        cmd.Parameters.Add("@FromTime", SqlDbType.DateTime).Value = sch.ToFromTime '開始時刻
                        cmd.Parameters.Add("@ToTime", SqlDbType.DateTime).Value = sch.ToToTime '終了時刻
                        cmd.Parameters.Add("@ViewNote", SqlDbType.VarChar, 50).Value = sch.ToViewNote '備考（利用者表示）
                        cmd.Parameters.Add("@HideNote", SqlDbType.VarChar, 50).Value = sch.ToHideNote '備考（利用者非表示）
                        cmd.Parameters.Add("@Attention", SqlDbType.Bit).Value = sch.ToAttention '注記
                        cmd.Parameters.Add("@IsCancel", SqlDbType.Bit).Value = sch.ToIsCancel '取り消し
                        cmd.ExecuteNonQuery()
                    End Using
                Next itx
                MsgBox("更新しました。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "更新完了")
                cn.Close()
            End Using
            Me.Close()
        End If
    End Sub

    Private Sub grpSch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpSch.Enter

    End Sub

End Class