Public Class ErrorCheck
    Private Sub ErrorCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Tag <> "" Then
            dtpMonth.Value = CDate(Me.Tag)
            lstAnser.Items.Clear()
            If chkSchedule() = 0 Then Me.Close()
        End If
    End Sub

    Public Function chkSchedule() As Integer
        Dim suCnt As Integer = 0
        Dim ruCnt As Integer = 0
        Dim shCnt As Integer = 0
        Dim rhCnt As Integer = 0
        Dim upCnt As Integer = 0
        suCnt = chkUserSchedule(1) '利用者情報の確認（予定）
        ruCnt = chkUserSchedule(2) '利用者情報の確認（実績）
        shCnt = chkHelperSchedule(1) 'ヘルパー情報の確認（予定）
        rhCnt = chkHelperSchedule(2) 'ヘルパー情報の確認（実績）
        Dim st As String = "対象月 = " & dtpMonth.Value.ToString("yyyy 年 MM 月") & vbCrLf & vbCrLf
        st &= "重複確認【 予定 】 利用者 = " & Space(3 - suCnt.ToString.Length) & suCnt.ToString & " 件  ,  ヘルパー = " & Space(3 - shCnt.ToString.Length) & shCnt.ToString & " 件  " & vbCrLf
        st &= "重複確認【 実績 】 利用者 = " & Space(3 - ruCnt.ToString.Length) & ruCnt.ToString & " 件  ,  ヘルパー = " & Space(3 - rhCnt.ToString.Length) & rhCnt.ToString & " 件  " & vbCrLf
        st &= vbCrLf

        Dim aru As ArrayList = GetUserMonthList(dtpMonth.Value)
        For I As Integer = 0 To aru.Count - 1
            Dim arx As ArrayList = chkUpper(dtpMonth.Value, DirectCast(aru(I), Integer))
            For J As Integer = 0 To arx.Count - 1
                st &= arx(J).ToString & vbCrLf
                lstAnser.Items.Add(arx(J).ToString)
                upCnt += 1
            Next J
        Next I
        Dim dCnt As Integer = suCnt + ruCnt + shCnt + rhCnt
        If dCnt = 0 Then
            If upCnt = 0 Then
                MsgBox(st & "重複及び上限オーバーはありませんでした。", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "登録確認")
            Else
                MsgBox(st & upCnt.ToString & " 件の上限オーバーがあります。確認してください。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "登録確認")
            End If
        Else
            If upCnt = 0 Then
                MsgBox(st & dCnt.ToString & " 件の重複があります。確認してください。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "登録確認")
            Else
                st &= dCnt.ToString & " 件の重複があります。確認してください。"
                MsgBox(st & upCnt.ToString & " 件の上限オーバーがあります。確認してください。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "登録確認")
            End If
        End If
        Return (dCnt + upCnt)
    End Function

    Public Function chkUserSchedule(ByVal readType As Integer) As Integer
        Dim ErrCnt As Integer = 0
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_USERMONTHSCHEDULE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = CDate(dtpMonth.Value.ToString("yyyy/MM/01")) '対象月設定
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = readType
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全件対象
                cmd.Parameters.Add("@St", SqlDbType.VarChar, 50).Value = "[UserId],[Target],[FromTime],[TypeId]"
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim dbx As New DonguriLib.LibClass.T_Schedule
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    If (db.ToUserId = dbx.ToUserId) And (dbx.ToToTime > db.ToFromTime) Then
                        Dim st As String = ""
                        st = dbx.ToType & " " & dbx.ToUserName & " " & db.ToTarget.ToString("yyyy/MM/dd") & " " & dbx.ToJobTime & " " & dbx.ToJob & " " & dbx.ToHelperName & " と"
                        lstAnser.Items.Add(st)
                        st = db.ToType & " " & db.ToUserName & " " & db.ToTarget.ToString("yyyy/MM/dd") & " " & db.ToJobTime & " " & db.ToJob & " " & db.ToHelperName & " に 重複があります。"
                        lstAnser.Items.Add(st)
                        lstAnser.Items.Add(" ")
                        ErrCnt += 1
                    End If
                    dbx = db
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
        Return ErrCnt
    End Function

    Public Function chkHelperSchedule(ByVal readType As Integer) As Integer
        Dim ErrCnt As Integer = 0
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_HELPERMONTHSCHEDULE", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = CDate(dtpMonth.Value.ToString("yyyy/MM/01")) '対象月設定
                cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = readType
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 0 '全件対象
                cmd.Parameters.Add("@St", SqlDbType.VarChar, 50).Value = "[SHelperId],[Target],[FromTime],[TypeId]"
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Dim dbx As New DonguriLib.LibClass.T_Schedule
                Do While dr.Read()
                    Dim db As New DonguriLib.LibClass.T_Schedule
                    db.SetReader(dr)
                    If (db.ToSHelperId = dbx.ToSHelperId) And (dbx.ToToTime > db.ToFromTime) Then
                        Dim st As String = ""
                        st = dbx.ToType & " " & dbx.ToHelperName & " " & db.ToTarget.ToString("yyyy/MM/dd") & " " & dbx.ToJobTime & " " & dbx.ToJob & " " & dbx.ToUserName & " と"
                        lstAnser.Items.Add(st)
                        st = db.ToType & " " & db.ToHelperName & " " & db.ToTarget.ToString("yyyy/MM/dd") & " " & db.ToJobTime & " " & db.ToJob & " " & db.ToUserName & " に 重複があります。"
                        lstAnser.Items.Add(st)
                        lstAnser.Items.Add(" ")
                        ErrCnt += 1
                    End If
                    dbx = db
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
        Return ErrCnt
    End Function

    Public Function chkUpper(ByVal dt As Date, ByVal id As Integer) As ArrayList
        Dim db As New DonguriLib.LibClass.T_Schedule
        db.SetAccountTime(dt, id, True)
        Dim ar As New ArrayList
        If db.ToSaSinSch > db.ToSoSinUpp Then ar.Add(db.ToAccUserName & " 請求稼働予定時間 身体 上限オーバー (" & db.ToSaSinSch.ToString("N2") & "/" & db.ToSoSinUpp.ToString("N2") & ")")
        If db.ToSaSinRst > db.ToSoSinUpp Then ar.Add(db.ToAccUserName & " 請求稼働実績時間 身体 上限オーバー (" & db.ToSaSinRst.ToString("N2") & "/" & db.ToSoSinUpp.ToString("N2") & ")")
        If db.ToSoSinSch > db.ToSoSinUpp Then ar.Add(db.ToAccUserName & " 実績稼働予定時間 身体 上限オーバー (" & db.ToSoSinSch.ToString("N2") & "/" & db.ToSoSinUpp.ToString("N2") & ")")
        If db.ToSoSinRst > db.ToSoSinUpp Then ar.Add(db.ToAccUserName & " 実績稼働実績時間 身体 上限オーバー (" & db.ToSoSinRst.ToString("N2") & "/" & db.ToSoSinUpp.ToString("N2") & ")")
        If db.ToSaKajSch > db.ToSoKajUpp Then ar.Add(db.ToAccUserName & " 請求稼働予定時間 家事 上限オーバー (" & db.ToSaKajSch.ToString("N2") & "/" & db.ToSoKajUpp.ToString("N2") & ")")
        If db.ToSaKajRst > db.ToSoKajUpp Then ar.Add(db.ToAccUserName & " 請求稼働実績時間 家事 上限オーバー (" & db.ToSaKajRst.ToString("N2") & "/" & db.ToSoKajUpp.ToString("N2") & ")")
        If db.ToSoKajSch > db.ToSoKajUpp Then ar.Add(db.ToAccUserName & " 実績稼働予定時間 家事 上限オーバー (" & db.ToSaKajSch.ToString("N2") & "/" & db.ToSoKajUpp.ToString("N2") & ")")
        If db.ToSoKajRst > db.ToSoKajUpp Then ar.Add(db.ToAccUserName & " 実績稼働実績時間 家事 上限オーバー (" & db.ToSaKajRst.ToString("N2") & "/" & db.ToSoKajUpp.ToString("N2") & ")")
        If db.ToSaIdoSch > db.ToSoIdoUpp Then ar.Add(db.ToAccUserName & " 請求稼働予定時間 移動 上限オーバー (" & db.ToSaIdoSch.ToString("N2") & "/" & db.ToSoIdoUpp.ToString("N2") & ")")
        If db.ToSaIdoRst > db.ToSoIdoUpp Then ar.Add(db.ToAccUserName & " 請求稼働実績時間 移動 上限オーバー (" & db.ToSaIdoRst.ToString("N2") & "/" & db.ToSoIdoUpp.ToString("N2") & ")")
        If db.ToSoIdoSch > db.ToSoIdoUpp Then ar.Add(db.ToAccUserName & " 実績稼働予定時間 移動 上限オーバー (" & db.ToSaIdoSch.ToString("N2") & "/" & db.ToSoIdoUpp.ToString("N2") & ")")
        If db.ToSoIdoRst > db.ToSoIdoUpp Then ar.Add(db.ToAccUserName & " 実績稼働実績時間 移動 上限オーバー (" & db.ToSaIdoRst.ToString("N2") & "/" & db.ToSoIdoUpp.ToString("N2") & ")")
        Return ar
    End Function

    Public Function GetUserMonthList(ByVal Target As Date) As ArrayList
        Dim ar As New ArrayList
        Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand("SP_SEL_USERMONTHLIST", cn)
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = Target
                Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                Do While dr.Read()
                    ar.Add(DirectCast(dr("UserId"), Integer))
                Loop
                dr.Close()
            End Using
            cn.Close()
        End Using
        Return ar
    End Function

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        lstAnser.Items.Clear()
        If chkSchedule() = 0 Then Me.Close()
    End Sub
End Class