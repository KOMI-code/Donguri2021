Public Class LibClass
    '接続文字列
    Public Const _Cn = "Data Source=localhost\SQLEXPRESS;AttachDbFilename=D:\DonguriV2\Data\Donguri_Data.mdf;Integrated Security=True"

    Public Class SortItem
        Public Value As String
        Public Key As String
        Public Overrides Function ToString() As String
            Return Value
        End Function
    End Class

    Public Class ComboItem
        Public Id As Integer
        Public Value As String
        Public Overrides Function ToString() As String
            Return Value
        End Function
    End Class

    Public Class LineItem
        Public LineString As String
        Public Attention As Boolean
        Public IsCancel As Boolean
        Public Overrides Function ToString() As String
            Return LineString
        End Function
    End Class

    Public Class DivItem
        Public FromTime As Date
        Public ToTime As Date
        Public DiffTime As Decimal
        Public Type1 As String
        Public Pay1 As Integer
        Public Type2 As String
        Public Pay2 As Integer
        Public Note As String
    End Class

    Public Class T_User
        Private Id As Integer
        Private FamilyName As String
        Private FirstName As String
        Private SecondName As String
        Private ThirdName As String
        Private Birthday As Date
        Private SexId As Integer
        Private StatusId As Integer
        Private Sex As String
        Private Status As String

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("Id") Is DBNull.Value Then Id = 0 Else Id = DirectCast(dr("Id"), Integer)
            If dr("FamilyName") Is DBNull.Value Then FamilyName = "" Else FamilyName = dr("FamilyName").ToString.Trim
            If dr("FirstName") Is DBNull.Value Then FirstName = "" Else FirstName = dr("FirstName").ToString.Trim
            If dr("SecondName") Is DBNull.Value Then SecondName = "" Else SecondName = dr("SecondName").ToString.Trim
            If dr("ThirdName") Is DBNull.Value Then ThirdName = "" Else ThirdName = dr("ThirdName").ToString.Trim
            If dr("Birthday") Is DBNull.Value Then Birthday = Date.MinValue Else Birthday = DirectCast(dr("Birthday"), Date)
            If dr("SexId") Is DBNull.Value Then SexId = 0 Else SexId = DirectCast(dr("SexId"), Integer)
            If dr("StatusId") Is DBNull.Value Then StatusId = 0 Else StatusId = DirectCast(dr("StatusId"), Integer)
            If dr("Sex") Is DBNull.Value Then Sex = "" Else Sex = dr("Sex").ToString.Trim
            If dr("Status") Is DBNull.Value Then Status = "" Else Status = dr("Status").ToString.Trim
        End Sub

        Public Function ToId() As Integer
            Return Id
        End Function
        Public Function ToFamilyName() As String
            Return FamilyName
        End Function
        Public Function ToFirstName() As String
            Return FirstName
        End Function
        Public Function ToSecondName() As String
            Return SecondName
        End Function
        Public Function ToThirdName() As String
            Return ThirdName
        End Function
        Public Function ToUserName() As String
            Dim nm As String = FamilyName & " " & FirstName
            Return nm
        End Function
        Public Function ToBirthday() As Date
            Return Birthday
        End Function
        Public Function ToSexId() As Integer
            Return SexId
        End Function
        Public Function ToStatusId() As Integer
            Return StatusId
        End Function
        Public Function ToSex() As String
            Return Sex
        End Function
        Public Function ToStatus() As String
            Return Status
        End Function
    End Class

    Public Class T_UserUpper
        Private Id As Integer
        Private FromDate As Date
        Private Sin As Decimal
        Private Kaj As Decimal
        Private Ido As Decimal
        Private Tsu As Decimal

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("Id") Is DBNull.Value Then Id = 0 Else Id = DirectCast(dr("Id"), Integer)
            If dr("FromDate") Is DBNull.Value Then FromDate = Date.MinValue Else FromDate = DirectCast(dr("FromDate"), Date)
            If dr("Sin") Is DBNull.Value Then Sin = 0D Else Sin = DirectCast(dr("Sin"), Decimal)
            If dr("Kaj") Is DBNull.Value Then Kaj = 0D Else Kaj = DirectCast(dr("Kaj"), Decimal)
            If dr("Ido") Is DBNull.Value Then Ido = 0D Else Ido = DirectCast(dr("Ido"), Decimal)
            If dr("Tsu") Is DBNull.Value Then Tsu = 0D Else Tsu = DirectCast(dr("Tsu"), Decimal)
        End Sub

        Public Function ToId() As Integer
            Return Id
        End Function

        Public Function ToFromDate() As Date
            Return FromDate
        End Function

        Public Function ToSin() As Decimal
            Return Sin
        End Function

        Public Function ToKaj() As Decimal
            Return Kaj
        End Function

        Public Function ToIdo() As Decimal
            Return Ido
        End Function

        Public Function ToTsu() As Decimal
            Return Tsu
        End Function
    End Class

    Public Class T_Code
        Private Id As Integer
        Private Value As String

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("Id") Is DBNull.Value Then Id = 0 Else Id = DirectCast(dr("Id"), Integer)
            If dr("Value") Is DBNull.Value Then Value = "" Else Value = dr("Value").ToString.Trim
        End Sub

        Public Function ToId() As Integer
            Return Id
        End Function
        Public Function ToValue() As String
            Return Value
        End Function
    End Class

    Public Class T_Helper
        Private Id As Integer
        Private FamilyName As String
        Private FirstName As String
        Private SecondName As String
        Private ThirdName As String
        Private Birthday As Date
        Private SexId As Integer
        Private StatusId As Integer
        Private Sex As String
        Private Status As String
        Private Member As Integer

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("Id") Is DBNull.Value Then Id = 0 Else Id = DirectCast(dr("Id"), Integer)
            If dr("FamilyName") Is DBNull.Value Then FamilyName = "" Else FamilyName = dr("FamilyName").ToString.Trim
            If dr("FirstName") Is DBNull.Value Then FirstName = "" Else FirstName = dr("FirstName").ToString.Trim
            If dr("SecondName") Is DBNull.Value Then SecondName = "" Else SecondName = dr("SecondName").ToString.Trim
            If dr("ThirdName") Is DBNull.Value Then ThirdName = "" Else ThirdName = dr("ThirdName").ToString.Trim
            If dr("Birthday") Is DBNull.Value Then Birthday = Date.MinValue Else Birthday = DirectCast(dr("Birthday"), Date)
            If dr("SexId") Is DBNull.Value Then SexId = 0 Else SexId = DirectCast(dr("SexId"), Integer)
            If dr("StatusId") Is DBNull.Value Then StatusId = 0 Else StatusId = DirectCast(dr("StatusId"), Integer)
            If dr("Sex") Is DBNull.Value Then Sex = "" Else Sex = dr("Sex").ToString.Trim
            If dr("Status") Is DBNull.Value Then Status = "" Else Status = dr("Status").ToString.Trim
            If dr("Member") Is DBNull.Value Then Member = 0 Else Member = DirectCast(dr("Member"), Integer)
        End Sub

        Public Function ToId() As Integer
            Return Id
        End Function
        Public Function ToFamilyName() As String
            Return FamilyName
        End Function
        Public Function ToFirstName() As String
            Return FirstName
        End Function
        Public Function ToSecondName() As String
            Return SecondName
        End Function
        Public Function ToThirdName() As String
            Return ThirdName
        End Function
        Public Function ToHelperName() As String
            Dim nm As String = ""
            If Member < 2 Then
                nm = FamilyName & " " & FirstName
            Else
                If FamilyName <> "" Then nm = FamilyName
                If nm <> "" Then
                    If FirstName <> "" Then nm &= "・" & FirstName
                Else
                    If FirstName <> "" Then nm = FirstName
                End If
                If nm <> "" Then
                    If SecondName <> "" Then nm &= "・" & SecondName
                Else
                    If SecondName <> "" Then nm = SecondName
                End If
                If nm <> "" Then
                    If ThirdName <> "" Then nm &= "・" & ThirdName
                Else
                    If ThirdName <> "" Then nm = ThirdName
                End If
            End If
            Return nm
        End Function
        Public Function ToBirthday() As Date
            Return Birthday
        End Function
        Public Function ToSexId() As Integer
            Return SexId
        End Function
        Public Function ToStatusId() As Integer
            Return StatusId
        End Function
        Public Function ToSex() As String
            Return Sex
        End Function
        Public Function ToStatus() As String
            Return Status
        End Function
        Public Function ToMember() As Integer
            Return Member
        End Function
    End Class

    Public Class T_HelperSlave
        Private Id As Integer
        Private SlaveId As Integer
        Private AccountMag As Integer
        Private FamilyName As String
        Private FirstName As String
        Private SecondName As String
        Private ThirdName As String
        Private StatusId As Integer
        Private Account As String
        Private Status As String

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("Id") Is DBNull.Value Then Id = 0 Else Id = DirectCast(dr("Id"), Integer)
            If dr("SlaveId") Is DBNull.Value Then SlaveId = 0 Else SlaveId = DirectCast(dr("SlaveId"), Integer)
            If dr("AccountMag") Is DBNull.Value Then AccountMag = 0 Else AccountMag = DirectCast(dr("AccountMag"), Integer)
            If dr("FamilyName") Is DBNull.Value Then FamilyName = "" Else FamilyName = dr("FamilyName").ToString.Trim
            If dr("FirstName") Is DBNull.Value Then FirstName = "" Else FirstName = dr("FirstName").ToString.Trim
            If dr("SecondName") Is DBNull.Value Then SecondName = "" Else SecondName = dr("SecondName").ToString.Trim
            If dr("ThirdName") Is DBNull.Value Then ThirdName = "" Else ThirdName = dr("ThirdName").ToString.Trim
            If dr("StatusId") Is DBNull.Value Then StatusId = 0 Else StatusId = DirectCast(dr("StatusId"), Integer)
            If dr("Account") Is DBNull.Value Then Account = "" Else Account = dr("Account").ToString.Trim
            If dr("Status") Is DBNull.Value Then Status = "" Else Status = dr("Status").ToString.Trim
        End Sub

        Public Function ToId() As Integer
            Return Id
        End Function

        Public Function ToSlaveId() As Integer
            Return SlaveId
        End Function

        Public Function ToAccountMag() As Integer
            Return AccountMag
        End Function

        Public Function ToFamilyName() As String
            Return FamilyName
        End Function
        Public Function ToFirstName() As String
            Return FirstName
        End Function
        Public Function ToSecondName() As String
            Return SecondName
        End Function
        Public Function ToThirdName() As String
            Return ThirdName
        End Function
        Public Function ToHelperName() As String
            'Slaveは単独者のみの為
            Dim nm As String = FamilyName & " " & FirstName
            Return nm
        End Function
        Public Function ToStatusId() As Integer
            Return StatusId
        End Function
        Public Function ToAccount() As String
            Return Account
        End Function
        Public Function ToStatus() As String
            Return Status
        End Function
    End Class

    Public Class T_Calendar
        Private Target As Date
        Private Item As String
        Private Note As String
        Private TypeId As Integer
        Private Type As String
        Private SqlType As String

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("Target") Is DBNull.Value Then Target = Date.MinValue Else Target = DirectCast(dr("Target"), Date)
            If dr("Item") Is DBNull.Value Then Item = "" Else Item = dr("Item").ToString
            If dr("Note") Is DBNull.Value Then Note = "" Else Note = dr("Note").ToString
            If dr("TypeId") Is DBNull.Value Then TypeId = 0 Else TypeId = DirectCast(dr("TypeId"), Integer)
            If dr("Type") Is DBNull.Value Then Type = "" Else Type = dr("Type").ToString
        End Sub

        Public Sub SetListItem(ByVal it As System.Windows.Forms.ListViewItem, ByVal st As String)
            SqlType = st
            Target = it.SubItems(1).Text
            Item = it.SubItems(2).Text
            Note = it.SubItems(3).Text
            Type = it.SubItems(4).Text
            TypeId = it.SubItems(5).Text
        End Sub

        Public Function ToTarget() As Date
            Return Target
        End Function

        Public Function ToItem() As String
            Return Item
        End Function

        Public Function ToNote() As String
            Return Note
        End Function

        Public Function ToTypeId() As Integer
            Return TypeId
        End Function

        Public Function ToType() As String
            Return Type
        End Function

        Public Sub SetTarget(ByVal value As Date)
            Target = value
        End Sub

        Public Sub SetItem(ByVal value As String)
            Item = value
        End Sub

        Public Sub SetNote(ByVal value As String)
            Note = value
        End Sub

        Public Sub SetTypeId(ByVal value As Integer)
            TypeId = value
        End Sub

        Public Sub SetType(ByVal value As String)
            Type = value
        End Sub

        Public Sub SetSqlType(ByVal value As String)
            SqlType = value
        End Sub

        Public Function ToSqlType() As String
            Return SqlType
        End Function
    End Class

    Public Class T_DayNote
        Private FamilyName As String
        Private FirstName As String
        Private SecondName As String
        Private ThirdName As String
        Private TypeId As Integer
        Private Type As String

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("FamilyName") Is DBNull.Value Then FamilyName = "" Else FamilyName = dr("FamilyName").ToString.Trim
            If dr("FirstName") Is DBNull.Value Then FirstName = "" Else FirstName = dr("FirstName").ToString.Trim
            If dr("SecondName") Is DBNull.Value Then SecondName = "" Else SecondName = dr("SecondName").ToString.Trim
            If dr("ThirdName") Is DBNull.Value Then ThirdName = "" Else ThirdName = dr("ThirdName").ToString.Trim
            If dr("TypeId") Is DBNull.Value Then TypeId = 0 Else TypeId = DirectCast(dr("TypeId"), Integer)
            If dr("Type") Is DBNull.Value Then Type = "" Else Type = dr("Type").ToString.Trim
        End Sub

        Public Function ToFamilyName() As String
            Return FamilyName
        End Function
        Public Function ToFirstName() As String
            Return FirstName
        End Function
        Public Function ToSecondName() As String
            Return SecondName
        End Function
        Public Function ToThirdName() As String
            Return ThirdName
        End Function
        Public Function ToNote() As String
            Dim st As String = FamilyName & " " & FirstName & " " & SecondName & " " & ThirdName
            Return st
        End Function
        Public Function ToNoteShort() As String
            Dim st As String = FamilyName
            Return st
        End Function
        Public Function ToTypeId() As Integer
            Return TypeId
        End Function
        Public Function ToType() As String
            Return Type
        End Function
    End Class

    Public Class T_Schedule
        Private UserId As Integer
        Private UserFamilyName As String
        Private UserFirstName As String
        Private UserSecondName As String
        Private UserThirdName As String
        Private UserBirthday As Date
        Private UserSexId As Integer
        Private UserSex As String
        Private UserStatusId As Integer
        Private UserStatus As String
        Private HelperId As Integer
        Private HelperFamilyName As String
        Private HelperFirstName As String
        Private HelperSecondName As String
        Private HelperThirdName As String
        Private HelperBirthday As Date
        Private HelperSexId As Integer
        Private HelperSex As String
        Private HelperStatusId As Integer
        Private HelperStatus As String
        Private Member As Integer
        Private SHelperId As Integer
        Private SHelperFamilyName As String
        Private SHelperFirstName As String
        Private SHelperSecondName As String
        Private SHelperThirdName As String
        Private AccountMag As Integer
        Private Account As String
        Private JobId As Integer
        Private Job As String
        Private TypeId As Integer
        Private Type As String
        Private Target As Date
        Private FromTime As Date
        Private ToTime As Date
        Private ViewNote As String
        Private HideNote As String
        Private Attention As Boolean
        Private IsCancel As Boolean
        '以下はSetAccountTime実行時有効
        Private SaSinSch As Decimal = 0D
        Private SaSinRst As Decimal = 0D
        Private SaKajSch As Decimal = 0D
        Private SaKajRst As Decimal = 0D
        Private SaIdoSch As Decimal = 0D
        Private SaIdoRst As Decimal = 0D
        Private SaTsuSch As Decimal = 0D
        Private SaTsuRst As Decimal = 0D
        Private SoSinSch As Decimal = 0D
        Private SoSinRst As Decimal = 0D
        Private SoSinUpp As Decimal = 0D
        Private SoKajSch As Decimal = 0D
        Private SoKajRst As Decimal = 0D
        Private SoKajUpp As Decimal = 0D
        Private SoIdoSch As Decimal = 0D
        Private SoIdoRst As Decimal = 0D
        Private SoIdoUpp As Decimal = 0D
        Private SoTsuSch As Decimal = 0D
        Private SoTsuRst As Decimal = 0D
        Private SoTsuUpp As Decimal = 0D
        Private KaSinSch As Decimal = 0D
        Private KaSinRst As Decimal = 0D
        Private KaKajSch As Decimal = 0D
        Private KaKajRst As Decimal = 0D
        Private KaIdoSch As Decimal = 0D
        Private KaIdoRst As Decimal = 0D
        Private KoSinSch As Decimal = 0D
        Private KoSinRst As Decimal = 0D
        Private KoKajSch As Decimal = 0D
        Private KoKajRst As Decimal = 0D
        Private KoIdoSch As Decimal = 0D
        Private KoIdoRst As Decimal = 0D
        Private EaEtcSch As Decimal = 0D
        Private EaEtcRst As Decimal = 0D
        Private EoEtcSch As Decimal = 0D
        Private EoEtcRst As Decimal = 0D
        Private AccUserName As String
        '
        Public Overrides Function ToString() As String
            Return ""
        End Function

        Public Sub SetAttention(ByVal value As Boolean)
            Attention = value
        End Sub

        Public Sub SetIsCancel(ByVal value As Boolean)
            IsCancel = value
        End Sub

        Public Sub SetUserId(ByVal value As Integer)
            UserId = value
        End Sub

        Public Sub SetHelperId(ByVal value As Integer)
            HelperId = value
        End Sub

        Public Sub SetJobId(ByVal value As Integer)
            JobId = value
        End Sub

        Public Sub SetTypeId(ByVal value As Integer)
            TypeId = value
        End Sub

        Public Sub SetTarget(ByVal value As Date)
            Target = value
        End Sub

        Public Sub SetFromTime(ByVal value As Date)
            FromTime = value
        End Sub

        Public Sub SetToTime(ByVal value As Date)
            ToTime = value
        End Sub

        Public Sub SetViewNote(ByVal value As String)
            ViewNote = value
        End Sub

        Public Sub SetHideNote(ByVal value As String)
            HideNote = value
        End Sub

        Public Function ToUserId() As Integer
            Return UserId
        End Function

        Public Function ToUserFamilyName() As String
            Return UserFamilyName
        End Function

        Public Function ToUserFirstName() As String
            Return UserFirstName
        End Function

        Public Function ToUserBirthday() As Date
            Return UserBirthday
        End Function

        Public Function ToUserSexId() As Integer
            Return UserSexId
        End Function

        Public Function ToUserSex() As String
            Return UserSex
        End Function

        Public Function ToUserStatusId() As Integer
            Return UserStatusId
        End Function

        Public Function ToUserStatus() As String
            Return UserStatus
        End Function

        Public Function ToHelperId() As Integer
            Return HelperId
        End Function

        Public Function ToHelperFamilyName() As String
            Return HelperFamilyName
        End Function

        Public Function ToHelperFirstName() As String
            Return HelperFirstName
        End Function

        Public Function ToHelperSecondName() As String
            Return HelperSecondName
        End Function

        Public Function ToHelperThirdName() As String
            Return HelperThirdName
        End Function

        Public Function ToHelperBirthday() As Date
            Return HelperBirthday
        End Function

        Public Function ToHelperSexId() As Integer
            Return HelperSexId
        End Function

        Public Function ToHelperSex() As String
            Return HelperSex
        End Function

        Public Function ToHelperStatusId() As Integer
            Return HelperStatusId
        End Function

        Public Function ToHelperStatus() As String
            Return HelperStatus
        End Function

        Public Function ToUserName() As String
            Dim nm As String = UserFamilyName
            If UserFirstName <> "" Then nm &= " " & UserFirstName
            Return nm
        End Function

        Public Function ToHelperName() As String
            Dim nm As String = ""
            If Member < 2 Then
                nm = HelperFamilyName
                If HelperFirstName <> "" Then nm &= " " & HelperFirstName
            Else
                nm = HelperFamilyName
                If HelperFirstName <> "" Then nm &= "・" & HelperFirstName
                If HelperSecondName <> "" Then nm &= "・" & HelperSecondName
                If HelperThirdName <> "" Then nm &= "・" & HelperThirdName
            End If
            Return nm
        End Function

        Public Function ToSHelperId() As Integer
            Return SHelperId
        End Function

        Public Function ToMember() As Integer
            Return Member
        End Function

        Public Function ToSHelperName() As String
            Dim nm As String = ""
            nm = SHelperFamilyName
            If SHelperFirstName <> "" Then nm &= " " & SHelperFirstName
            If SHelperSecondName <> "" Then nm &= " " & SHelperSecondName
            If SHelperThirdName <> "" Then nm &= " " & SHelperThirdName
            Return nm
        End Function

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("UserId") Is DBNull.Value Then UserId = 0 Else UserId = DirectCast(dr("UserId"), Integer)
            If dr("UserFamilyName") Is DBNull.Value Then UserFamilyName = "" Else UserFamilyName = dr("UserFamilyName").ToString.Trim
            If dr("UserFirstName") Is DBNull.Value Then UserFirstName = "" Else UserFirstName = dr("UserFirstName").ToString.Trim
            If dr("UserSecondName") Is DBNull.Value Then UserSecondName = "" Else UserSecondName = dr("UserSecondName").ToString.Trim
            If dr("UserThirdName") Is DBNull.Value Then UserThirdName = "" Else UserThirdName = dr("UserThirdName").ToString.Trim
            If dr("HelperId") Is DBNull.Value Then HelperId = 0 Else HelperId = DirectCast(dr("HelperId"), Integer)
            If dr("HelperFamilyName") Is DBNull.Value Then HelperFamilyName = "" Else HelperFamilyName = dr("HelperFamilyName").ToString.Trim
            If dr("HelperFirstName") Is DBNull.Value Then HelperFirstName = "" Else HelperFirstName = dr("HelperFirstName").ToString.Trim
            If dr("HelperSecondName") Is DBNull.Value Then HelperSecondName = "" Else HelperSecondName = dr("HelperSecondName").ToString.Trim
            If dr("HelperThirdName") Is DBNull.Value Then HelperThirdName = "" Else HelperThirdName = dr("HelperThirdName").ToString.Trim
            If dr("Member") Is DBNull.Value Then Member = 0 Else Member = DirectCast(dr("Member"), Integer)
            If dr("SHelperId") Is DBNull.Value Then SHelperId = 0 Else SHelperId = DirectCast(dr("SHelperId"), Integer)
            If dr("SHelperFamilyName") Is DBNull.Value Then SHelperFamilyName = "" Else SHelperFamilyName = dr("SHelperFamilyName").ToString.Trim
            If dr("SHelperFirstName") Is DBNull.Value Then SHelperFirstName = "" Else SHelperFirstName = dr("SHelperFirstName").ToString.Trim
            If dr("SHelperSecondName") Is DBNull.Value Then SHelperSecondName = "" Else SHelperSecondName = dr("SHelperSecondName").ToString.Trim
            If dr("SHelperThirdName") Is DBNull.Value Then SHelperThirdName = "" Else SHelperThirdName = dr("SHelperThirdName").ToString.Trim
            If dr("AccountMag") Is DBNull.Value Then AccountMag = 0 Else AccountMag = DirectCast(dr("AccountMag"), Integer)
            If dr("Account") Is DBNull.Value Then Account = "" Else Account = dr("Account").ToString.Trim
            If dr("JobId") Is DBNull.Value Then JobId = 0 Else JobId = DirectCast(dr("JobId"), Integer)
            If dr("Job") Is DBNull.Value Then Job = "" Else Job = dr("Job").ToString.Trim
            If dr("TypeId") Is DBNull.Value Then TypeId = 0 Else TypeId = DirectCast(dr("TypeId"), Integer)
            If dr("Type") Is DBNull.Value Then Type = "" Else Type = dr("Type").ToString.Trim
            If dr("Target") Is DBNull.Value Then Target = Date.MinValue Else Target = DirectCast(dr("Target"), Date)
            If dr("FromTime") Is DBNull.Value Then FromTime = Date.MinValue Else FromTime = DirectCast(dr("FromTime"), Date)
            If dr("ToTime") Is DBNull.Value Then ToTime = Date.MinValue Else ToTime = DirectCast(dr("ToTime"), Date)
            If dr("ViewNote") Is DBNull.Value Then ViewNote = "" Else ViewNote = dr("ViewNote").ToString.Trim
            If dr("HideNote") Is DBNull.Value Then HideNote = "" Else HideNote = dr("HideNote").ToString.Trim
            If dr("Attention") Is DBNull.Value Then Attention = False Else Attention = DirectCast(dr("Attention"), Boolean)
            If dr("IsCancel") Is DBNull.Value Then IsCancel = False Else IsCancel = DirectCast(dr("IsCancel"), Boolean)
        End Sub

        Public Function ToScheduleCSV() As String
            Dim st As New System.Text.StringBuilder
            st.Append(ToUserId.ToString & ",")
            st.Append(ToHelperId.ToString & ",")
            st.Append(ToJobId.ToString & ",")
            st.Append(ToTypeId.ToString & ",")
            st.Append(Chr(34) & ToTarget.ToString("yyyy/MM/dd") & Chr(34) & ",")
            st.Append(Chr(34) & ToFromTime.ToString("yyyy/MM/dd HH:mm:ss") & Chr(34) & ",")
            st.Append(Chr(34) & ToToTime.ToString("yyyy/MM/dd HH:mm:ss") & Chr(34) & ",")
            st.Append(Chr(34) & ToViewNote.ToString & Chr(34) & ",")
            st.Append(Chr(34) & ToHideNote.ToString & Chr(34) & ",")
            st.Append(ToAttention() & ",")
            st.Append(ToIsCancel())
            Return st.ToString
        End Function

        Public Function ToAccountMag() As Integer
            Return AccountMag
        End Function

        Public Function ToAccount() As String
            Return Account
        End Function

        Public Function ToJobId() As Integer
            Return JobId
        End Function

        Public Function ToJob() As String
            Return Job
        End Function

        Public Function ToTypeId() As Integer
            Return TypeId
        End Function

        Public Function ToType() As String
            Return Type
        End Function

        Public Function ToTarget() As Date
            Return Target
        End Function

        Public Function ToFromTime() As Date
            Return FromTime
        End Function

        Public Function ToToTime() As Date
            Return ToTime
        End Function

        Public Function ToDiffTime() As Decimal
            Dim dt As Long = DateDiff(DateInterval.Minute, FromTime, ToTime)
            Return CDec(dt / 60)
        End Function

        Public Function ToDivItem() As ArrayList
            Dim ar As New ArrayList
            Dim ft As Integer = CInt(FromTime.ToString("HH")) * 60 + CInt(FromTime.ToString("mm"))
            Dim tt As Integer = DateDiff(DateInterval.Minute, FromTime, ToTime)
            Dim mt As Integer = 0 '最大時間(Min)
            Dim st As Integer = 0 '開始時間(Min)
            Dim et As Integer = 0 '終了時間(Min)

            st = ft
            Select Case st
                Case 0 To 359 ' 0:00 - 5:59 深夜
                    mt = 360 - ft '最大時間(Min)算出
                    If tt > mt Then et = mt Else et = tt
                    ar.Add(GetPay(st, et, "深夜"))
                    st = 360
                    et = tt - mt
                    tt = et
                Case 360 To 479 ' 6:00 - 7:59 夜・早
                    mt = 480 - ft '最大時間(Min)算出
                    If tt > mt Then et = mt Else et = tt
                    ar.Add(GetPay(st, et, "夜早"))
                    st = 480
                    et = tt - mt
                    tt = et
                Case 480 To 1079 ' 8:00 - 17:59 日中
                    mt = 1080 - ft '最大時間(Min)算出
                    If tt > mt Then et = mt Else et = tt
                    ar.Add(GetPay(st, et, "日中"))
                    st = 1080
                    et = tt - mt
                    tt = et
                Case 1080 To 1319 ' 18:00 - 21:59 夜・早
                    mt = 1320 - ft '最大時間(Min)算出
                    If tt > mt Then et = mt Else et = tt
                    ar.Add(GetPay(st, et, "夜早"))
                    st = 1320
                    et = tt - mt
                    tt = et
                Case 1320 To 1439 ' 22:00 - 23:59 深夜
                    mt = 1440 - ft '最大時間(Min)算出
                    If tt > mt Then et = mt Else et = tt
                    ar.Add(GetPay(st, et, "深夜"))
                    st = 0
                    et = tt - mt
                    tt = et
            End Select
            If et > 0 Then
                Select Case st
                    Case 0 To 359 ' 0:00 - 5:59 深夜
                        mt = 360 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "深夜"))
                        st = 360
                        et = tt - mt
                        tt = et
                    Case 360 To 479 ' 6:00 - 7:59 夜・早
                        mt = 480 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "夜早"))
                        st = 480
                        et = tt - mt
                        tt = et
                    Case 480 To 1079 ' 8:00 - 17:59 日中
                        mt = 1080 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "日中"))
                        st = 1080
                        et = tt - mt
                        tt = et
                    Case 1080 To 1319 ' 18:00 - 21:59 夜・早
                        mt = 1320 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "夜早"))
                        st = 1320
                        et = tt - mt
                        tt = et
                    Case 1320 To 1439 ' 22:00 - 23:59 深夜
                        mt = 1440 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "深夜"))
                        st = 0
                        et = tt - mt
                        tt = et
                End Select
            End If
            If et > 0 Then
                Select Case st
                    Case 0 To 359 ' 0:00 - 5:59 深夜
                        mt = 360 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "深夜"))
                        st = 360
                        et = tt - mt
                        tt = et
                    Case 360 To 479 ' 6:00 - 7:59 夜・早
                        mt = 480 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "夜早"))
                        st = 480
                        et = tt - mt
                        tt = et
                    Case 480 To 1079 ' 8:00 - 17:59 日中
                        mt = 1080 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "日中"))
                        st = 1080
                        et = tt - mt
                        tt = et
                    Case 1080 To 1319 ' 18:00 - 21:59 夜・早
                        mt = 1320 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "夜早"))
                        st = 1320
                        et = tt - mt
                        tt = et
                    Case 1320 To 1439 ' 22:00 - 23:59 深夜
                        mt = 1440 - ft '最大時間(Min)算出
                        If tt > mt Then et = mt Else et = tt
                        ar.Add(GetPay(st, et, "深夜"))
                        st = 0
                        et = tt - mt
                        tt = et
                End Select
            End If
            Return ar
        End Function

        Private Function GetSinPayTable(ByVal dt As Date, ByVal ix As Integer) As Integer
            Dim db As New DonguriLib.LibClass.T_PayTable
            Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                cn.Open()
                Using cmd As New SqlClient.SqlCommand("SP_SEL_PAYREAD", cn)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dt
                    Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    dr.Read()
                    db.SetReader(dr)
                    dr.Close()
                End Using
                cn.Close()
            End Using
            Return CInt(db.ToSinArray(ix))
        End Function

        Private Function GetKajPayTable(ByVal dt As Date, ByVal ix As Integer) As Decimal
            Dim db As New DonguriLib.LibClass.T_PayTable
            Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                cn.Open()
                Using cmd As New SqlClient.SqlCommand("SP_SEL_PAYREAD", cn)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dt
                    Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    dr.Read()
                    db.SetReader(dr)
                    dr.Close()
                End Using
                cn.Close()
            End Using
            Return db.ToKajArray(ix)
        End Function

        Private Function GetIdoPayTable(ByVal dt As Date, ByVal ix As Integer) As Decimal
            Dim db As New DonguriLib.LibClass.T_PayTable
            Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                cn.Open()
                Using cmd As New SqlClient.SqlCommand("SP_SEL_PAYREAD", cn)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dt
                    Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    dr.Read()
                    db.SetReader(dr)
                    dr.Close()
                End Using
                cn.Close()
            End Using
            Return db.ToIdoArray(ix)
        End Function

        Private Function GetPay(ByVal st As Integer, ByVal et As Integer, ByVal tp As String) As DivItem
            Dim it As New DivItem
            it.FromTime = Target.AddMinutes(st)
            it.ToTime = it.FromTime.AddMinutes(et)
            Dim ts As Decimal = et \ 60D
            Dim ta As Decimal = et Mod 60D
            Select Case ta
                Case 0D To 14D : ts += 0D
                Case 15D To 44D : ts += 0.5D
                Case 45D To 59D : ts += 1D
            End Select
            it.DiffTime = ts
            it.Type1 = tp
            Dim ix As Integer = (et \ 30) - 1
            If (et Mod 30) >= 15 Then ix += 1
            Select Case tp
                'Case "日中" : ix += 0
                Case "夜早" : ix += 20
                Case "深夜" : ix += 28
            End Select
            If ix >= 0 Then
                Select Case JobId
                    Case 1, 4, 51
                        it.Pay1 = GetSinPayTable(Target, ix) * AccountMag
                    Case 2, 52
                        it.Pay1 = GetKajPayTable(Target, ix) * AccountMag
                    Case 3, 53
                        it.Pay1 = GetIdoPayTable(Target, ix) * AccountMag
                End Select
                If AccountMag = 0 Then it.Note = Account '課金なし文言
            End If
            Return it
        End Function

        Public Function ToJobTime() As String
            Dim nm As String = ""
            If FromTime = Date.MinValue Then
                If ToTime = Date.MinValue Then
                    nm = "           " '時刻未設定は空白表示
                Else
                    nm = "     -" & ToTime.ToString("HH:mm") '時刻未設定は空白表示
                End If
            Else
                nm = FromTime.ToString("HH:mm") & "-" & ToTime.ToString("HH:mm")
            End If
            Return nm
        End Function

        Public Function ToOpeTime() As Decimal
            Dim tm As Decimal = CDec(DateDiff(DateInterval.Minute, ToFromTime, ToToTime))
            Return tm / 60D
        End Function

        Public Function ToAppTime() As Decimal
            Dim tm As Decimal = CDec(DateDiff(DateInterval.Minute, ToFromTime, ToToTime))
            Dim ts As Decimal = tm \ 60D
            Dim ta As Decimal = tm Mod 60D
            Select Case ta
                Case 0D To 14D : ts += 0D
                Case 15D To 44D : ts += 0.5D
                Case 45D To 59D : ts += 1D
            End Select
            Return ts
        End Function

        Public Function ToSinMark() As String
            Dim nm As String
            Select Case JobId
                Case 1 : nm = "○"
                Case 51 : nm = "●"
                Case Else : nm = "  "
            End Select
            Return nm
        End Function

        Public Function ToKajMark() As String
            Dim nm As String
            Select Case JobId
                Case 2 : nm = "○"
                Case 52 : nm = "●"
                Case Else : nm = "  "
            End Select
            Return nm
        End Function

        Public Function ToTsuMark() As String
            Dim nm As String
            Select Case JobId
                Case 4 : nm = "○"
                Case Else : nm = "  "
            End Select
            Return nm
        End Function

        Public Function ToIdoMark() As String
            Dim nm As String
            Select Case JobId
                Case 3 : nm = "○"
                Case 53 : nm = "●"
                Case Else : nm = "  "
            End Select
            Return nm
        End Function

        Public Function ToEtcMark() As String
            Dim nm As String
            Select Case JobId
                Case 1, 2, 3, 4 : nm = "  "
                Case 51, 52, 53 : nm = "  "
                Case Else : nm = "○"
            End Select
            Return nm
        End Function

        Public Function ToViewNote() As String
            Return ViewNote
        End Function

        Public Function ToViewArray(ByVal mx As Integer, ByVal blk As Integer) As ArrayList
            Dim nm As String = ViewNote
            Return DivItem(nm, mx, blk)
        End Function

        Public Function ToHideNote() As String
            Return HideNote
        End Function

        Public Function ToHideArray(ByVal mx As Integer, ByVal blk As Integer) As ArrayList
            Dim nm As String = HideNote
            Return DivItem(nm, mx, blk)
        End Function

        Public Function ToAttention() As Boolean
            Return Attention
        End Function

        Public Function ToIsCancel() As Boolean
            Return IsCancel
        End Function

        Public Function ToNoteArray(ByVal mx As Integer, ByVal blk As Integer) As ArrayList
            Dim nm As String = ViewNote
            If HideNote <> "" Then nm &= "（" & HideNote & "）"
            Return DivItem(nm, mx, blk)
        End Function

        Public Function ToArrayLine(ByVal mx As Integer, ByVal blk As Integer, ByVal IsUser As Boolean) As ArrayList
            Dim ar As New ArrayList
            Dim it1 As New LineItem
            it1.LineString = ToType.Substring(0, 1) & " " & ToJobTime() & " " & ToJob().Substring(0, 3) & " "
            If IsUser Then it1.LineString &= ToHelperName.Replace(" ", "") Else it1.LineString &= ToUserName.Replace(" ", "")
            it1.Attention = ToAttention()
            it1.IsCancel = ToIsCancel()
            ar.Add(it1)
            Dim arx1 As ArrayList = ToViewArray(mx, 3)
            For I As Integer = 0 To arx1.Count - 1
                Dim itx As New LineItem
                itx.LineString = arx1(I)
                itx.Attention = ToAttention()
                itx.IsCancel = ToIsCancel()
                ar.Add(itx)
            Next I
            Dim arx2 As ArrayList = ToHideArray(mx, 3)
            For I As Integer = 0 To arx2.Count - 1
                Dim itx As New LineItem
                itx.LineString = arx2(I)
                itx.Attention = ToAttention()
                itx.IsCancel = ToIsCancel()
                ar.Add(itx)
            Next I
            Return ar
        End Function

        Public Function ToArrayLineDual(ByVal mx As Integer, ByVal blk As Integer, ByVal IsUser As Boolean) As ArrayList
            Dim ar As New ArrayList
            Dim it1 As New LineItem
            it1.LineString = ToType.Substring(0, 1) & " " & ToJobTime() & " " & ToJob().Substring(0, 3) & " "
            If IsUser Then
                it1.LineString &= ToUserName.Replace(" ", "") & " " & ToHelperName.Replace(" ", "")
            Else
                If Member < 2 Then
                    it1.LineString &= ToHelperName.Replace(" ", "") & " " & ToUserName.Replace(" ", "")
                Else
                    it1.LineString &= ToSHelperName.Replace(" ", "") & "（" & ToHelperName.Replace(" ", "") & "） " & ToUserName.Replace(" ", "")
                End If
            End If
            it1.Attention = ToAttention()
            it1.IsCancel = ToIsCancel()
            ar.Add(it1)
            Dim arx1 As ArrayList = ToViewArray(mx, 3)
            For I As Integer = 0 To arx1.Count - 1
                Dim itx As New LineItem
                itx.LineString = arx1(I)
                itx.Attention = ToAttention()
                itx.IsCancel = ToIsCancel()
                ar.Add(itx)
            Next I
            Dim arx2 As ArrayList = ToHideArray(mx, 3)
            For I As Integer = 0 To arx2.Count - 1
                Dim itx As New LineItem
                itx.LineString = arx2(I)
                itx.Attention = ToAttention()
                itx.IsCancel = ToIsCancel()
                ar.Add(itx)
            Next I
            Return ar
        End Function


        Public Sub SetAccountTime(ByVal dt As Date, ByVal id As Integer, ByVal IsUser As Boolean)
            Dim fDt As Date = CDate(dt.ToString("yyyy/MM/01")) '月初日
            Dim nDt As Date = fDt.AddMonths(1) '翌月初日
            Dim lDt As Date = nDt.AddDays(-1) '月末日

            Using cn As New SqlClient.SqlConnection(DonguriLib.LibClass._Cn)
                cn.Open()
                Using cmd As New SqlClient.SqlCommand("SP_SEL_MONTHACCOUNT", cn)
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = fDt '対象月初日設定
                    cmd.Parameters.Add("@ReadType", SqlDbType.Int).Value = 0 '予定/実績
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id '利用者番号
                    cmd.Parameters.Add("@IsUser", SqlDbType.Bit).Value = IsUser '利用者
                    Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                    Dim dbx As New DonguriLib.LibClass.T_Schedule

                    Do While dr.Read()
                        Dim db As New DonguriLib.LibClass.T_Schedule
                        db.SetReader(dr)
                        AccUserName = db.ToUserName
                        Select Case db.ToJobId
                            Case 1 '支援－身体
                                If db.ToTypeId = 1 Then
                                    SoSinSch += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    SaSinSch += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                ElseIf db.ToTypeId = 2 Then
                                    SoSinRst += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    SaSinRst += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                End If
                            Case 2 '支援－家事
                                If db.ToTypeId = 1 Then
                                    SoKajSch += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    SaKajSch += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                ElseIf db.ToTypeId = 2 Then
                                    SoKajRst += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    SaKajRst += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                End If
                            Case 3 '支援－移動
                                If db.ToTypeId = 1 Then
                                    SoIdoSch += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    SaIdoSch += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                ElseIf db.ToTypeId = 2 Then
                                    SoIdoRst += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    SaIdoRst += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                End If
                            Case 4 '支援－通院
                                If db.ToTypeId = 1 Then
                                    SoTsuSch += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    SaTsuSch += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                ElseIf db.ToTypeId = 2 Then
                                    SoTsuRst += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    SaTsuRst += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                End If
                            Case 51 '介護－身体
                                If db.ToTypeId = 1 Then
                                    KoSinSch += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    KaSinSch += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                ElseIf db.ToTypeId = 2 Then
                                    KoSinRst += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    KaSinRst += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                End If
                            Case 52 '介護－家事
                                If db.ToTypeId = 1 Then
                                    KoKajSch += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    KaKajSch += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                ElseIf db.ToTypeId = 2 Then
                                    KoKajRst += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    KaKajRst += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                End If
                            Case 53 '介護－移動
                                If db.ToTypeId = 1 Then
                                    KoIdoSch += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    KaIdoSch += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                ElseIf db.ToTypeId = 2 Then
                                    KoIdoRst += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    KaIdoRst += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                End If
                            Case Else 'その他
                                If db.ToTypeId = 1 Then
                                    EoEtcSch += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    EaEtcSch += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                ElseIf db.ToTypeId = 2 Then
                                    EoEtcRst += db.ToOpeTime * CDec(db.ToAccountMag) '実稼働時間
                                    EaEtcRst += db.ToAppTime * CDec(db.ToAccountMag) '請求稼働時間
                                End If
                        End Select
                    Loop
                    dr.Close()
                End Using
                If IsUser Then
                    If id <> 0 Then
                        Using cmd As New SqlClient.SqlCommand("SP_SEL_USERUPPERTARGET", cn)
                            cmd.CommandType = Data.CommandType.StoredProcedure
                            cmd.Parameters.Add("@Target", SqlDbType.DateTime).Value = lDt '当月末日
                            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id '利用者番号
                            Dim dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                            dr.Read()
                            SoSinUpp = DirectCast(dr("Sin"), Decimal)
                            SoKajUpp = DirectCast(dr("Kaj"), Decimal)
                            SoIdoUpp = DirectCast(dr("Ido"), Decimal)
                            SoTsuUpp = DirectCast(dr("Tsu"), Decimal)
                            dr.Close()
                        End Using
                    End If
                End If
                cn.Close()
            End Using
        End Sub

        Public Function ToSaSinSch() As Decimal
            Return SaSinSch
        End Function
        Public Function ToSaSinRst() As Decimal
            Return SaSinRst
        End Function
        Public Function ToSaKajSch() As Decimal
            Return SaKajSch
        End Function
        Public Function ToSaKajRst() As Decimal
            Return SaKajRst
        End Function
        Public Function ToSaIdoSch() As Decimal
            Return SaIdoSch
        End Function
        Public Function ToSaIdoRst() As Decimal
            Return SaIdoRst
        End Function
        Public Function ToSaTsuSch() As Decimal
            Return SaTsuSch
        End Function
        Public Function ToSaTsuRst() As Decimal
            Return SaTsuRst
        End Function
        Public Function ToSoSinSch() As Decimal
            Return SoSinSch
        End Function
        Public Function ToSoSinRst() As Decimal
            Return SoSinRst
        End Function
        Public Function ToSoSinUpp() As Decimal
            Return SoSinUpp
        End Function
        Public Function ToSoKajSch() As Decimal
            Return SoKajSch
        End Function
        Public Function ToSoKajRst() As Decimal
            Return SoKajRst
        End Function
        Public Function ToSoKajUpp() As Decimal
            Return SoKajUpp
        End Function
        Public Function ToSoIdoSch() As Decimal
            Return SoIdoSch
        End Function
        Public Function ToSoIdoRst() As Decimal
            Return SoIdoRst
        End Function
        Public Function ToSoIdoUpp() As Decimal
            Return SoIdoUpp
        End Function
        Public Function ToSoTsuSch() As Decimal
            Return SoTsuSch
        End Function
        Public Function ToSoTsuRst() As Decimal
            Return SoTsuRst
        End Function
        Public Function ToSoTsuUpp() As Decimal
            Return SoTsuUpp
        End Function
        Public Function ToKaSinSch() As Decimal
            Return KaSinSch
        End Function
        Public Function ToKaSinRst() As Decimal
            Return KaSinRst
        End Function
        Public Function ToKaKajSch() As Decimal
            Return KaKajSch
        End Function
        Public Function ToKaKajRst() As Decimal
            Return KaKajRst
        End Function
        Public Function ToKaIdoSch() As Decimal
            Return KaIdoSch
        End Function
        Public Function ToKaIdoRst() As Decimal
            Return KaIdoRst
        End Function
        Public Function ToKoSinSch() As Decimal
            Return KoSinSch
        End Function
        Public Function ToKoSinRst() As Decimal
            Return KoSinRst
        End Function
        Public Function ToKoKajSch() As Decimal
            Return KoKajSch
        End Function
        Public Function ToKoKajRst() As Decimal
            Return KoKajRst
        End Function
        Public Function ToKoIdoSch() As Decimal
            Return KoIdoSch
        End Function
        Public Function ToKoIdoRst() As Decimal
            Return KoIdoRst
        End Function
        Public Function ToEaEtcSch() As Decimal
            Return EaEtcSch
        End Function
        Public Function ToEaEtcRst() As Decimal
            Return EaEtcRst
        End Function
        Public Function ToEoEtcSch() As Decimal
            Return EoEtcSch
        End Function
        Public Function ToEoEtcRst() As Decimal
            Return EoEtcRst
        End Function
        Public Function ToAccUserName() As String
            Return AccUserName
        End Function


        '入力された文字列を指定バイト数にて分割して出力する
        Private Function DivItem(ByVal st As String, ByVal mx As Integer, ByVal blk As Integer) As ArrayList
            Dim it As New ArrayList
            Dim list As String = ""
            Dim cnt As Integer = 0
            Dim byt As Integer
            Dim note As String = st.Replace("～", "-").Trim
            note = StrConv(note, VbStrConv.Narrow)
            it.Clear()
            For i As Integer = 0 To note.Length - 1
                byt = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(note.Substring(i, 1))
                If (cnt + byt) > mx Then
                    it.Add(Space(blk) & list)
                    list = note.Substring(i, 1)
                    cnt = byt
                Else
                    list &= note.Substring(i, 1)
                    cnt += byt
                End If
            Next i
            If list <> "" Then it.Add(Space(blk) & list)
            Return it
        End Function
    End Class

    Public Class T_Note
        Private Cnt As Integer
        Private Note As String

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("Cnt") Is DBNull.Value Then Cnt = 0 Else Cnt = DirectCast(dr("Cnt"), Integer)
            If dr("Note") Is DBNull.Value Then Note = "" Else Note = dr("Note").ToString.Trim
        End Sub

        Public Function ToCnt() As Integer
            Return Cnt
        End Function
        Public Function ToNote() As String
            Return Note
        End Function
    End Class

    Public Class T_PayTable
        Private FromDate As Date
        Private Sa005 As Integer
        Private Sa010 As Integer
        Private Sa015 As Integer
        Private Sa020 As Integer
        Private Sa025 As Integer
        Private Sa030 As Integer
        Private Sa035 As Integer
        Private Sa040 As Integer
        Private Sa045 As Integer
        Private Sa050 As Integer
        Private Sa055 As Integer
        Private Sa060 As Integer
        Private Sa065 As Integer
        Private Sa070 As Integer
        Private Sa075 As Integer
        Private Sa080 As Integer
        Private Sa085 As Integer
        Private Sa090 As Integer
        Private Sa095 As Integer
        Private Sa100 As Integer
        Private Sb005 As Integer
        Private Sb010 As Integer
        Private Sb015 As Integer
        Private Sb020 As Integer
        Private Sb025 As Integer
        Private Sb030 As Integer
        Private Sb035 As Integer
        Private Sb040 As Integer
        Private Sc005 As Integer
        Private Sc010 As Integer
        Private Sc015 As Integer
        Private Sc020 As Integer
        Private Sc025 As Integer
        Private Sc030 As Integer
        Private Sc035 As Integer
        Private Sc040 As Integer
        Private Sc045 As Integer
        Private Sc050 As Integer
        Private Sc055 As Integer
        Private Sc060 As Integer
        Private Sc065 As Integer
        Private Sc070 As Integer
        Private Sc075 As Integer
        Private Sc080 As Integer
        Private Ka005 As Integer
        Private Ka010 As Integer
        Private Ka015 As Integer
        Private Ka020 As Integer
        Private Ka025 As Integer
        Private Ka030 As Integer
        Private Ka035 As Integer
        Private Ka040 As Integer
        Private Ka045 As Integer
        Private Ka050 As Integer
        Private Ka055 As Integer
        Private Ka060 As Integer
        Private Ka065 As Integer
        Private Ka070 As Integer
        Private Ka075 As Integer
        Private Ka080 As Integer
        Private Ka085 As Integer
        Private Ka090 As Integer
        Private Ka095 As Integer
        Private Ka100 As Integer
        Private Kb005 As Integer
        Private Kb010 As Integer
        Private Kb015 As Integer
        Private Kb020 As Integer
        Private Kb025 As Integer
        Private Kb030 As Integer
        Private Kb035 As Integer
        Private Kb040 As Integer
        Private Kc005 As Integer
        Private Kc010 As Integer
        Private Kc015 As Integer
        Private Kc020 As Integer
        Private Kc025 As Integer
        Private Kc030 As Integer
        Private Kc035 As Integer
        Private Kc040 As Integer
        Private Kc045 As Integer
        Private Kc050 As Integer
        Private Kc055 As Integer
        Private Kc060 As Integer
        Private Kc065 As Integer
        Private Kc070 As Integer
        Private Kc075 As Integer
        Private Kc080 As Integer
        Private Ia005 As Integer
        Private Ia010 As Integer
        Private Ia015 As Integer
        Private Ia020 As Integer
        Private Ia025 As Integer
        Private Ia030 As Integer
        Private Ia035 As Integer
        Private Ia040 As Integer
        Private Ia045 As Integer
        Private Ia050 As Integer
        Private Ia055 As Integer
        Private Ia060 As Integer
        Private Ia065 As Integer
        Private Ia070 As Integer
        Private Ia075 As Integer
        Private Ia080 As Integer
        Private Ia085 As Integer
        Private Ia090 As Integer
        Private Ia095 As Integer
        Private Ia100 As Integer
        Private Ib005 As Integer
        Private Ib010 As Integer
        Private Ib015 As Integer
        Private Ib020 As Integer
        Private Ib025 As Integer
        Private Ib030 As Integer
        Private Ib035 As Integer
        Private Ib040 As Integer
        Private Ic005 As Integer
        Private Ic010 As Integer
        Private Ic015 As Integer
        Private Ic020 As Integer
        Private Ic025 As Integer
        Private Ic030 As Integer
        Private Ic035 As Integer
        Private Ic040 As Integer
        Private Ic045 As Integer
        Private Ic050 As Integer
        Private Ic055 As Integer
        Private Ic060 As Integer
        Private Ic065 As Integer
        Private Ic070 As Integer
        Private Ic075 As Integer
        Private Ic080 As Integer

        Public Sub SetReader(ByVal dr As SqlClient.SqlDataReader)
            If dr("FromDate") Is DBNull.Value Then FromDate = Date.MinValue Else FromDate = DirectCast(dr("FromDate"), Date)
            If dr("SA005") Is DBNull.Value Then Sa005 = 0 Else Sa005 = DirectCast(dr("SA005"), Integer)
            If dr("SA010") Is DBNull.Value Then Sa010 = 0 Else Sa010 = DirectCast(dr("SA010"), Integer)
            If dr("SA015") Is DBNull.Value Then Sa015 = 0 Else Sa015 = DirectCast(dr("SA015"), Integer)
            If dr("SA020") Is DBNull.Value Then Sa020 = 0 Else Sa020 = DirectCast(dr("SA020"), Integer)
            If dr("SA025") Is DBNull.Value Then Sa025 = 0 Else Sa025 = DirectCast(dr("SA025"), Integer)
            If dr("SA030") Is DBNull.Value Then Sa030 = 0 Else Sa030 = DirectCast(dr("SA030"), Integer)
            If dr("SA035") Is DBNull.Value Then Sa035 = 0 Else Sa035 = DirectCast(dr("SA035"), Integer)
            If dr("SA040") Is DBNull.Value Then Sa040 = 0 Else Sa040 = DirectCast(dr("SA040"), Integer)
            If dr("SA045") Is DBNull.Value Then Sa045 = 0 Else Sa045 = DirectCast(dr("SA045"), Integer)
            If dr("SA050") Is DBNull.Value Then Sa050 = 0 Else Sa050 = DirectCast(dr("SA050"), Integer)
            If dr("SA055") Is DBNull.Value Then Sa055 = 0 Else Sa055 = DirectCast(dr("SA055"), Integer)
            If dr("SA060") Is DBNull.Value Then Sa060 = 0 Else Sa060 = DirectCast(dr("SA060"), Integer)
            If dr("SA065") Is DBNull.Value Then Sa065 = 0 Else Sa065 = DirectCast(dr("SA065"), Integer)
            If dr("SA070") Is DBNull.Value Then Sa070 = 0 Else Sa070 = DirectCast(dr("SA070"), Integer)
            If dr("SA075") Is DBNull.Value Then Sa075 = 0 Else Sa075 = DirectCast(dr("SA075"), Integer)
            If dr("SA080") Is DBNull.Value Then Sa080 = 0 Else Sa080 = DirectCast(dr("SA080"), Integer)
            If dr("SA085") Is DBNull.Value Then Sa085 = 0 Else Sa085 = DirectCast(dr("SA085"), Integer)
            If dr("SA090") Is DBNull.Value Then Sa090 = 0 Else Sa090 = DirectCast(dr("SA090"), Integer)
            If dr("SA095") Is DBNull.Value Then Sa095 = 0 Else Sa095 = DirectCast(dr("SA095"), Integer)
            If dr("SA100") Is DBNull.Value Then Sa100 = 0 Else Sa100 = DirectCast(dr("SA100"), Integer)
            If dr("SB005") Is DBNull.Value Then Sb005 = 0 Else Sb005 = DirectCast(dr("SB005"), Integer)
            If dr("SB010") Is DBNull.Value Then Sb010 = 0 Else Sb010 = DirectCast(dr("SB010"), Integer)
            If dr("SB015") Is DBNull.Value Then Sb015 = 0 Else Sb015 = DirectCast(dr("SB015"), Integer)
            If dr("SB020") Is DBNull.Value Then Sb020 = 0 Else Sb020 = DirectCast(dr("SB020"), Integer)
            If dr("SB025") Is DBNull.Value Then Sb025 = 0 Else Sb025 = DirectCast(dr("SB025"), Integer)
            If dr("SB030") Is DBNull.Value Then Sb030 = 0 Else Sb030 = DirectCast(dr("SB030"), Integer)
            If dr("SB035") Is DBNull.Value Then Sb035 = 0 Else Sb035 = DirectCast(dr("SB035"), Integer)
            If dr("SB040") Is DBNull.Value Then Sb040 = 0 Else Sb040 = DirectCast(dr("SB040"), Integer)
            If dr("SC005") Is DBNull.Value Then Sc005 = 0 Else Sc005 = DirectCast(dr("SC005"), Integer)
            If dr("SC010") Is DBNull.Value Then Sc010 = 0 Else Sc010 = DirectCast(dr("SC010"), Integer)
            If dr("SC015") Is DBNull.Value Then Sc015 = 0 Else Sc015 = DirectCast(dr("SC015"), Integer)
            If dr("SC020") Is DBNull.Value Then Sc020 = 0 Else Sc020 = DirectCast(dr("SC020"), Integer)
            If dr("SC025") Is DBNull.Value Then Sc025 = 0 Else Sc025 = DirectCast(dr("SC025"), Integer)
            If dr("SC030") Is DBNull.Value Then Sc030 = 0 Else Sc030 = DirectCast(dr("SC030"), Integer)
            If dr("SC035") Is DBNull.Value Then Sc035 = 0 Else Sc035 = DirectCast(dr("SC035"), Integer)
            If dr("SC040") Is DBNull.Value Then Sc040 = 0 Else Sc040 = DirectCast(dr("SC040"), Integer)
            If dr("SC045") Is DBNull.Value Then Sc045 = 0 Else Sc045 = DirectCast(dr("SC045"), Integer)
            If dr("SC050") Is DBNull.Value Then Sc050 = 0 Else Sc050 = DirectCast(dr("SC050"), Integer)
            If dr("SC055") Is DBNull.Value Then Sc055 = 0 Else Sc055 = DirectCast(dr("SC055"), Integer)
            If dr("SC060") Is DBNull.Value Then Sc060 = 0 Else Sc060 = DirectCast(dr("SC060"), Integer)
            If dr("SC065") Is DBNull.Value Then Sc065 = 0 Else Sc065 = DirectCast(dr("SC065"), Integer)
            If dr("SC070") Is DBNull.Value Then Sc070 = 0 Else Sc070 = DirectCast(dr("SC070"), Integer)
            If dr("SC075") Is DBNull.Value Then Sc075 = 0 Else Sc075 = DirectCast(dr("SC075"), Integer)
            If dr("SC080") Is DBNull.Value Then Sc080 = 0 Else Sc080 = DirectCast(dr("SC080"), Integer)
            If dr("KA005") Is DBNull.Value Then Ka005 = 0 Else Ka005 = DirectCast(dr("KA005"), Integer)
            If dr("KA010") Is DBNull.Value Then Ka010 = 0 Else Ka010 = DirectCast(dr("KA010"), Integer)
            If dr("KA015") Is DBNull.Value Then Ka015 = 0 Else Ka015 = DirectCast(dr("KA015"), Integer)
            If dr("KA020") Is DBNull.Value Then Ka020 = 0 Else Ka020 = DirectCast(dr("KA020"), Integer)
            If dr("KA025") Is DBNull.Value Then Ka025 = 0 Else Ka025 = DirectCast(dr("KA025"), Integer)
            If dr("KA030") Is DBNull.Value Then Ka030 = 0 Else Ka030 = DirectCast(dr("KA030"), Integer)
            If dr("KA035") Is DBNull.Value Then Ka035 = 0 Else Ka035 = DirectCast(dr("KA035"), Integer)
            If dr("KA040") Is DBNull.Value Then Ka040 = 0 Else Ka040 = DirectCast(dr("KA040"), Integer)
            If dr("KA045") Is DBNull.Value Then Ka045 = 0 Else Ka045 = DirectCast(dr("KA045"), Integer)
            If dr("KA050") Is DBNull.Value Then Ka050 = 0 Else Ka050 = DirectCast(dr("KA050"), Integer)
            If dr("KA055") Is DBNull.Value Then Ka055 = 0 Else Ka055 = DirectCast(dr("KA055"), Integer)
            If dr("KA060") Is DBNull.Value Then Ka060 = 0 Else Ka060 = DirectCast(dr("KA060"), Integer)
            If dr("KA065") Is DBNull.Value Then Ka065 = 0 Else Ka065 = DirectCast(dr("KA065"), Integer)
            If dr("KA070") Is DBNull.Value Then Ka070 = 0 Else Ka070 = DirectCast(dr("KA070"), Integer)
            If dr("KA075") Is DBNull.Value Then Ka075 = 0 Else Ka075 = DirectCast(dr("KA075"), Integer)
            If dr("KA080") Is DBNull.Value Then Ka080 = 0 Else Ka080 = DirectCast(dr("KA080"), Integer)
            If dr("KA085") Is DBNull.Value Then Ka085 = 0 Else Ka085 = DirectCast(dr("KA085"), Integer)
            If dr("KA090") Is DBNull.Value Then Ka090 = 0 Else Ka090 = DirectCast(dr("KA090"), Integer)
            If dr("KA095") Is DBNull.Value Then Ka095 = 0 Else Ka095 = DirectCast(dr("KA095"), Integer)
            If dr("KA100") Is DBNull.Value Then Ka100 = 0 Else Ka100 = DirectCast(dr("KA100"), Integer)
            If dr("KB005") Is DBNull.Value Then Kb005 = 0 Else Kb005 = DirectCast(dr("KB005"), Integer)
            If dr("KB010") Is DBNull.Value Then Kb010 = 0 Else Kb010 = DirectCast(dr("KB010"), Integer)
            If dr("KB015") Is DBNull.Value Then Kb015 = 0 Else Kb015 = DirectCast(dr("KB015"), Integer)
            If dr("KB020") Is DBNull.Value Then Kb020 = 0 Else Kb020 = DirectCast(dr("KB020"), Integer)
            If dr("KB025") Is DBNull.Value Then Kb025 = 0 Else Kb025 = DirectCast(dr("KB025"), Integer)
            If dr("KB030") Is DBNull.Value Then Kb030 = 0 Else Kb030 = DirectCast(dr("KB030"), Integer)
            If dr("KB035") Is DBNull.Value Then Kb035 = 0 Else Kb035 = DirectCast(dr("KB035"), Integer)
            If dr("KB040") Is DBNull.Value Then Kb040 = 0 Else Kb040 = DirectCast(dr("KB040"), Integer)
            If dr("KC005") Is DBNull.Value Then Kc005 = 0 Else Kc005 = DirectCast(dr("KC005"), Integer)
            If dr("KC010") Is DBNull.Value Then Kc010 = 0 Else Kc010 = DirectCast(dr("KC010"), Integer)
            If dr("KC015") Is DBNull.Value Then Kc015 = 0 Else Kc015 = DirectCast(dr("KC015"), Integer)
            If dr("KC020") Is DBNull.Value Then Kc020 = 0 Else Kc020 = DirectCast(dr("KC020"), Integer)
            If dr("KC025") Is DBNull.Value Then Kc025 = 0 Else Kc025 = DirectCast(dr("KC025"), Integer)
            If dr("KC030") Is DBNull.Value Then Kc030 = 0 Else Kc030 = DirectCast(dr("KC030"), Integer)
            If dr("KC035") Is DBNull.Value Then Kc035 = 0 Else Kc035 = DirectCast(dr("KC035"), Integer)
            If dr("KC040") Is DBNull.Value Then Kc040 = 0 Else Kc040 = DirectCast(dr("KC040"), Integer)
            If dr("KC045") Is DBNull.Value Then Kc045 = 0 Else Kc045 = DirectCast(dr("KC045"), Integer)
            If dr("KC050") Is DBNull.Value Then Kc050 = 0 Else Kc050 = DirectCast(dr("KC050"), Integer)
            If dr("KC055") Is DBNull.Value Then Kc055 = 0 Else Kc055 = DirectCast(dr("KC055"), Integer)
            If dr("KC060") Is DBNull.Value Then Kc060 = 0 Else Kc060 = DirectCast(dr("KC060"), Integer)
            If dr("KC065") Is DBNull.Value Then Kc065 = 0 Else Kc065 = DirectCast(dr("KC065"), Integer)
            If dr("KC070") Is DBNull.Value Then Kc070 = 0 Else Kc070 = DirectCast(dr("KC070"), Integer)
            If dr("KC075") Is DBNull.Value Then Kc075 = 0 Else Kc075 = DirectCast(dr("KC075"), Integer)
            If dr("KC080") Is DBNull.Value Then Kc080 = 0 Else Kc080 = DirectCast(dr("KC080"), Integer)
            If dr("IA005") Is DBNull.Value Then Ia005 = 0 Else Ia005 = DirectCast(dr("IA005"), Integer)
            If dr("IA010") Is DBNull.Value Then Ia010 = 0 Else Ia010 = DirectCast(dr("IA010"), Integer)
            If dr("IA015") Is DBNull.Value Then Ia015 = 0 Else Ia015 = DirectCast(dr("IA015"), Integer)
            If dr("IA020") Is DBNull.Value Then Ia020 = 0 Else Ia020 = DirectCast(dr("IA020"), Integer)
            If dr("IA025") Is DBNull.Value Then Ia025 = 0 Else Ia025 = DirectCast(dr("IA025"), Integer)
            If dr("IA030") Is DBNull.Value Then Ia030 = 0 Else Ia030 = DirectCast(dr("IA030"), Integer)
            If dr("IA035") Is DBNull.Value Then Ia035 = 0 Else Ia035 = DirectCast(dr("IA035"), Integer)
            If dr("IA040") Is DBNull.Value Then Ia040 = 0 Else Ia040 = DirectCast(dr("IA040"), Integer)
            If dr("IA045") Is DBNull.Value Then Ia045 = 0 Else Ia045 = DirectCast(dr("IA045"), Integer)
            If dr("IA050") Is DBNull.Value Then Ia050 = 0 Else Ia050 = DirectCast(dr("IA050"), Integer)
            If dr("IA055") Is DBNull.Value Then Ia055 = 0 Else Ia055 = DirectCast(dr("IA055"), Integer)
            If dr("IA060") Is DBNull.Value Then Ia060 = 0 Else Ia060 = DirectCast(dr("IA060"), Integer)
            If dr("IA065") Is DBNull.Value Then Ia065 = 0 Else Ia065 = DirectCast(dr("IA065"), Integer)
            If dr("IA070") Is DBNull.Value Then Ia070 = 0 Else Ia070 = DirectCast(dr("IA070"), Integer)
            If dr("IA075") Is DBNull.Value Then Ia075 = 0 Else Ia075 = DirectCast(dr("IA075"), Integer)
            If dr("IA080") Is DBNull.Value Then Ia080 = 0 Else Ia080 = DirectCast(dr("IA080"), Integer)
            If dr("IA085") Is DBNull.Value Then Ia085 = 0 Else Ia085 = DirectCast(dr("IA085"), Integer)
            If dr("IA090") Is DBNull.Value Then Ia090 = 0 Else Ia090 = DirectCast(dr("IA090"), Integer)
            If dr("IA095") Is DBNull.Value Then Ia095 = 0 Else Ia095 = DirectCast(dr("IA095"), Integer)
            If dr("IA100") Is DBNull.Value Then Ia100 = 0 Else Ia100 = DirectCast(dr("IA100"), Integer)
            If dr("IB005") Is DBNull.Value Then Ib005 = 0 Else Ib005 = DirectCast(dr("IB005"), Integer)
            If dr("IB010") Is DBNull.Value Then Ib010 = 0 Else Ib010 = DirectCast(dr("IB010"), Integer)
            If dr("IB015") Is DBNull.Value Then Ib015 = 0 Else Ib015 = DirectCast(dr("IB015"), Integer)
            If dr("IB020") Is DBNull.Value Then Ib020 = 0 Else Ib020 = DirectCast(dr("IB020"), Integer)
            If dr("IB025") Is DBNull.Value Then Ib025 = 0 Else Ib025 = DirectCast(dr("IB025"), Integer)
            If dr("IB030") Is DBNull.Value Then Ib030 = 0 Else Ib030 = DirectCast(dr("IB030"), Integer)
            If dr("IB035") Is DBNull.Value Then Ib035 = 0 Else Ib035 = DirectCast(dr("IB035"), Integer)
            If dr("IB040") Is DBNull.Value Then Ib040 = 0 Else Ib040 = DirectCast(dr("IB040"), Integer)
            If dr("IC005") Is DBNull.Value Then Ic005 = 0 Else Ic005 = DirectCast(dr("IC005"), Integer)
            If dr("IC010") Is DBNull.Value Then Ic010 = 0 Else Ic010 = DirectCast(dr("IC010"), Integer)
            If dr("IC015") Is DBNull.Value Then Ic015 = 0 Else Ic015 = DirectCast(dr("IC015"), Integer)
            If dr("IC020") Is DBNull.Value Then Ic020 = 0 Else Ic020 = DirectCast(dr("IC020"), Integer)
            If dr("IC025") Is DBNull.Value Then Ic025 = 0 Else Ic025 = DirectCast(dr("IC025"), Integer)
            If dr("IC030") Is DBNull.Value Then Ic030 = 0 Else Ic030 = DirectCast(dr("IC030"), Integer)
            If dr("IC035") Is DBNull.Value Then Ic035 = 0 Else Ic035 = DirectCast(dr("IC035"), Integer)
            If dr("IC040") Is DBNull.Value Then Ic040 = 0 Else Ic040 = DirectCast(dr("IC040"), Integer)
            If dr("IC045") Is DBNull.Value Then Ic045 = 0 Else Ic045 = DirectCast(dr("IC045"), Integer)
            If dr("IC050") Is DBNull.Value Then Ic050 = 0 Else Ic050 = DirectCast(dr("IC050"), Integer)
            If dr("IC055") Is DBNull.Value Then Ic055 = 0 Else Ic055 = DirectCast(dr("IC055"), Integer)
            If dr("IC060") Is DBNull.Value Then Ic060 = 0 Else Ic060 = DirectCast(dr("IC060"), Integer)
            If dr("IC065") Is DBNull.Value Then Ic065 = 0 Else Ic065 = DirectCast(dr("IC065"), Integer)
            If dr("IC070") Is DBNull.Value Then Ic070 = 0 Else Ic070 = DirectCast(dr("IC070"), Integer)
            If dr("IC075") Is DBNull.Value Then Ic075 = 0 Else Ic075 = DirectCast(dr("IC075"), Integer)
            If dr("IC080") Is DBNull.Value Then Ic080 = 0 Else Ic080 = DirectCast(dr("IC080"), Integer)
        End Sub

        Public Function ToFromDate() As Date
            Return FromDate
        End Function
        Public Function ToSa005() As Integer
            Return Sa005
        End Function
        Public Function ToSa010() As Integer
            Return Sa010
        End Function
        Public Function ToSa015() As Integer
            Return Sa015
        End Function
        Public Function ToSa020() As Integer
            Return Sa020
        End Function
        Public Function ToSa025() As Integer
            Return Sa025
        End Function
        Public Function ToSa030() As Integer
            Return Sa030
        End Function
        Public Function ToSa035() As Integer
            Return Sa035
        End Function
        Public Function ToSa040() As Integer
            Return Sa040
        End Function
        Public Function ToSa045() As Integer
            Return Sa045
        End Function
        Public Function ToSa050() As Integer
            Return Sa050
        End Function
        Public Function ToSa055() As Integer
            Return Sa055
        End Function
        Public Function ToSa060() As Integer
            Return Sa060
        End Function
        Public Function ToSa065() As Integer
            Return Sa065
        End Function
        Public Function ToSa070() As Integer
            Return Sa070
        End Function
        Public Function ToSa075() As Integer
            Return Sa075
        End Function
        Public Function ToSa080() As Integer
            Return Sa080
        End Function
        Public Function ToSa085() As Integer
            Return Sa085
        End Function
        Public Function ToSa090() As Integer
            Return Sa090
        End Function
        Public Function ToSa095() As Integer
            Return Sa095
        End Function
        Public Function ToSa100() As Integer
            Return Sa100
        End Function
        Public Function Tosb005() As Integer
            Return Sb005
        End Function
        Public Function Tosb010() As Integer
            Return Sb010
        End Function
        Public Function Tosb015() As Integer
            Return Sb015
        End Function
        Public Function Tosb020() As Integer
            Return Sb020
        End Function
        Public Function Tosb025() As Integer
            Return Sb025
        End Function
        Public Function Tosb030() As Integer
            Return Sb030
        End Function
        Public Function Tosb035() As Integer
            Return Sb035
        End Function
        Public Function Tosb040() As Integer
            Return Sb040
        End Function
        Public Function Tosc005() As Integer
            Return Sc005
        End Function
        Public Function Tosc010() As Integer
            Return Sc010
        End Function
        Public Function Tosc015() As Integer
            Return Sc015
        End Function
        Public Function Tosc020() As Integer
            Return Sc020
        End Function
        Public Function Tosc025() As Integer
            Return Sc025
        End Function
        Public Function Tosc030() As Integer
            Return Sc030
        End Function
        Public Function Tosc035() As Integer
            Return Sc035
        End Function
        Public Function Tosc040() As Integer
            Return Sc040
        End Function
        Public Function Tosc045() As Integer
            Return Sc045
        End Function
        Public Function Tosc050() As Integer
            Return Sc050
        End Function
        Public Function Tosc055() As Integer
            Return Sc055
        End Function
        Public Function Tosc060() As Integer
            Return Sc060
        End Function
        Public Function Tosc065() As Integer
            Return Sc065
        End Function
        Public Function Tosc070() As Integer
            Return Sc070
        End Function
        Public Function Tosc075() As Integer
            Return Sc075
        End Function
        Public Function Tosc080() As Integer
            Return Sc080
        End Function
        Public Function ToKa005() As Integer
            Return Ka005
        End Function
        Public Function ToKa010() As Integer
            Return Ka010
        End Function
        Public Function ToKa015() As Integer
            Return Ka015
        End Function
        Public Function ToKa020() As Integer
            Return Ka020
        End Function
        Public Function ToKa025() As Integer
            Return Ka025
        End Function
        Public Function ToKa030() As Integer
            Return Ka030
        End Function
        Public Function ToKa035() As Integer
            Return Ka035
        End Function
        Public Function ToKa040() As Integer
            Return Ka040
        End Function
        Public Function ToKa045() As Integer
            Return Ka045
        End Function
        Public Function ToKa050() As Integer
            Return Ka050
        End Function
        Public Function ToKa055() As Integer
            Return Ka055
        End Function
        Public Function ToKa060() As Integer
            Return Ka060
        End Function
        Public Function ToKa065() As Integer
            Return Ka065
        End Function
        Public Function ToKa070() As Integer
            Return Ka070
        End Function
        Public Function ToKa075() As Integer
            Return Ka075
        End Function
        Public Function ToKa080() As Integer
            Return Ka080
        End Function
        Public Function ToKa085() As Integer
            Return Ka085
        End Function
        Public Function ToKa090() As Integer
            Return Ka090
        End Function
        Public Function ToKa095() As Integer
            Return Ka095
        End Function
        Public Function ToKa100() As Integer
            Return Ka100
        End Function
        Public Function ToKb005() As Integer
            Return Kb005
        End Function
        Public Function ToKb010() As Integer
            Return Kb010
        End Function
        Public Function ToKb015() As Integer
            Return Kb015
        End Function
        Public Function ToKb020() As Integer
            Return Kb020
        End Function
        Public Function ToKb025() As Integer
            Return Kb025
        End Function
        Public Function ToKb030() As Integer
            Return Kb030
        End Function
        Public Function ToKb035() As Integer
            Return Kb035
        End Function
        Public Function ToKb040() As Integer
            Return Kb040
        End Function
        Public Function ToKc005() As Integer
            Return Kc005
        End Function
        Public Function ToKc010() As Integer
            Return Kc010
        End Function
        Public Function ToKc015() As Integer
            Return Kc015
        End Function
        Public Function ToKc020() As Integer
            Return Kc020
        End Function
        Public Function ToKc025() As Integer
            Return Kc025
        End Function
        Public Function ToKc030() As Integer
            Return Kc030
        End Function
        Public Function ToKc035() As Integer
            Return Kc035
        End Function
        Public Function ToKc040() As Integer
            Return Kc040
        End Function
        Public Function ToKc045() As Integer
            Return Kc045
        End Function
        Public Function ToKc050() As Integer
            Return Kc050
        End Function
        Public Function ToKc055() As Integer
            Return Kc055
        End Function
        Public Function ToKc060() As Integer
            Return Kc060
        End Function
        Public Function ToKc065() As Integer
            Return Kc065
        End Function
        Public Function ToKc070() As Integer
            Return Kc070
        End Function
        Public Function ToKc075() As Integer
            Return Kc075
        End Function
        Public Function ToKc080() As Integer
            Return Kc080
        End Function
        Public Function ToIa005() As Integer
            Return Ia005
        End Function
        Public Function ToIa010() As Integer
            Return Ia010
        End Function
        Public Function ToIa015() As Integer
            Return Ia015
        End Function
        Public Function ToIa020() As Integer
            Return Ia020
        End Function
        Public Function ToIa025() As Integer
            Return Ia025
        End Function
        Public Function ToIa030() As Integer
            Return Ia030
        End Function
        Public Function ToIa035() As Integer
            Return Ia035
        End Function
        Public Function ToIa040() As Integer
            Return Ia040
        End Function
        Public Function ToIa045() As Integer
            Return Ia045
        End Function
        Public Function ToIa050() As Integer
            Return Ia050
        End Function
        Public Function ToIa055() As Integer
            Return Ia055
        End Function
        Public Function ToIa060() As Integer
            Return Ia060
        End Function
        Public Function ToIa065() As Integer
            Return Ia065
        End Function
        Public Function ToIa070() As Integer
            Return Ia070
        End Function
        Public Function ToIa075() As Integer
            Return Ia075
        End Function
        Public Function ToIa080() As Integer
            Return Ia080
        End Function
        Public Function ToIa085() As Integer
            Return Ia085
        End Function
        Public Function ToIa090() As Integer
            Return Ia090
        End Function
        Public Function ToIa095() As Integer
            Return Ia095
        End Function
        Public Function ToIa100() As Integer
            Return Ia100
        End Function
        Public Function ToIb005() As Integer
            Return Ib005
        End Function
        Public Function ToIb010() As Integer
            Return Ib010
        End Function
        Public Function ToIb015() As Integer
            Return Ib015
        End Function
        Public Function ToIb020() As Integer
            Return Ib020
        End Function
        Public Function ToIb025() As Integer
            Return Ib025
        End Function
        Public Function ToIb030() As Integer
            Return Ib030
        End Function
        Public Function ToIb035() As Integer
            Return Ib035
        End Function
        Public Function ToIb040() As Integer
            Return Ib040
        End Function
        Public Function ToIc005() As Integer
            Return Ic005
        End Function
        Public Function ToIc010() As Integer
            Return Ic010
        End Function
        Public Function ToIc015() As Integer
            Return Ic015
        End Function
        Public Function ToIc020() As Integer
            Return Ic020
        End Function
        Public Function ToIc025() As Integer
            Return Ic025
        End Function
        Public Function ToIc030() As Integer
            Return Ic030
        End Function
        Public Function ToIc035() As Integer
            Return Ic035
        End Function
        Public Function ToIc040() As Integer
            Return Ic040
        End Function
        Public Function ToIc045() As Integer
            Return Ic045
        End Function
        Public Function ToIc050() As Integer
            Return Ic050
        End Function
        Public Function ToIc055() As Integer
            Return Ic055
        End Function
        Public Function ToIc060() As Integer
            Return Ic060
        End Function
        Public Function ToIc065() As Integer
            Return Ic065
        End Function
        Public Function ToIc070() As Integer
            Return Ic070
        End Function
        Public Function ToIc075() As Integer
            Return Ic075
        End Function
        Public Function ToIc080() As Integer
            Return Ic080
        End Function
        Public Function ToSinArray() As Decimal()
            Dim dc(43) As Decimal
            dc(0) = Sa005 : dc(1) = Sa010 : dc(2) = Sa015 : dc(3) = Sa020 : dc(4) = Sa025 : dc(5) = Sa030 : dc(6) = Sa035 : dc(7) = Sa040
            dc(8) = Sa045 : dc(9) = Sa050 : dc(10) = Sa055 : dc(11) = Sa060 : dc(12) = Sa065 : dc(13) = Sa070 : dc(14) = Sa075 : dc(15) = Sa080
            dc(16) = Sa085 : dc(17) = Sa090 : dc(18) = Sa095 : dc(19) = Sa100
            dc(20) = Sb005 : dc(21) = Sb010 : dc(22) = Sb015 : dc(23) = Sb020 : dc(24) = Sb025 : dc(25) = Sb030 : dc(26) = Sb035 : dc(27) = Sb040
            dc(28) = Sc005 : dc(29) = Sc010 : dc(30) = Sc015 : dc(31) = Sc020 : dc(32) = Sc025 : dc(33) = Sc030 : dc(34) = Sc035 : dc(35) = Sc040
            dc(36) = Sc045 : dc(37) = Sc050 : dc(38) = Sc055 : dc(39) = Sc060 : dc(40) = Sc065 : dc(41) = Sc070 : dc(42) = Sc075 : dc(43) = Sc080
            Return dc
        End Function
        Public Function ToKajArray() As Decimal()
            Dim dc(43) As Decimal
            dc(0) = Ka005 : dc(1) = Ka010 : dc(2) = Ka015 : dc(3) = Ka020 : dc(4) = Ka025 : dc(5) = Ka030 : dc(6) = Ka035 : dc(7) = Ka040
            dc(8) = Ka045 : dc(9) = Ka050 : dc(10) = Ka055 : dc(11) = Ka060 : dc(12) = Ka065 : dc(13) = Ka070 : dc(14) = Ka075 : dc(15) = Ka080
            dc(16) = Ka085 : dc(17) = Ka090 : dc(18) = Ka095 : dc(19) = Ka100
            dc(20) = Kb005 : dc(21) = Kb010 : dc(22) = Kb015 : dc(23) = Kb020 : dc(24) = Kb025 : dc(25) = Kb030 : dc(26) = Kb035 : dc(27) = Kb040
            dc(28) = Kc005 : dc(29) = Kc010 : dc(30) = Kc015 : dc(31) = Kc020 : dc(32) = Kc025 : dc(33) = Kc030 : dc(34) = Kc035 : dc(35) = Kc040
            dc(36) = Kc045 : dc(37) = Kc050 : dc(38) = Kc055 : dc(39) = Kc060 : dc(40) = Kc065 : dc(41) = Kc070 : dc(42) = Kc075 : dc(43) = Kc080
            Return dc
        End Function
        Public Function ToIdoArray() As Decimal()
            Dim dc(43) As Decimal
            dc(0) = Ia005 : dc(1) = Ia010 : dc(2) = Ia015 : dc(3) = Ia020 : dc(4) = Ia025 : dc(5) = Ia030 : dc(6) = Ia035 : dc(7) = Ia040
            dc(8) = Ia045 : dc(9) = Ia050 : dc(10) = Ia055 : dc(11) = Ia060 : dc(12) = Ia065 : dc(13) = Ia070 : dc(14) = Ia075 : dc(15) = Ia080
            dc(16) = Ia085 : dc(17) = Ia090 : dc(18) = Ia095 : dc(19) = Ia100
            dc(20) = Ib005 : dc(21) = Ib010 : dc(22) = Ib015 : dc(23) = Ib020 : dc(24) = Ib025 : dc(25) = Ib030 : dc(26) = Ib035 : dc(27) = Ib040
            dc(28) = Ic005 : dc(29) = Ic010 : dc(30) = Ic015 : dc(31) = Ic020 : dc(32) = Ic025 : dc(33) = Ic030 : dc(34) = Ic035 : dc(35) = Ic040
            dc(36) = Ic045 : dc(37) = Ic050 : dc(38) = Ic055 : dc(39) = Ic060 : dc(40) = Ic065 : dc(41) = Ic070 : dc(42) = Ic075 : dc(43) = Ic080
            Return dc
        End Function
    End Class

End Class
