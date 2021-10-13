<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserReg
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserReg))
        Me.btnQuit = New System.Windows.Forms.Button
        Me.Sin = New System.Windows.Forms.ColumnHeader
        Me.FromDate = New System.Windows.Forms.ColumnHeader
        Me.dummy = New System.Windows.Forms.ColumnHeader
        Me.txtFromDate = New System.Windows.Forms.TextBox
        Me.lstUpper = New System.Windows.Forms.ListView
        Me.Kaj = New System.Windows.Forms.ColumnHeader
        Me.Ido = New System.Windows.Forms.ColumnHeader
        Me.Tsu = New System.Windows.Forms.ColumnHeader
        Me.txtIdo = New System.Windows.Forms.TextBox
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.txtKaj = New System.Windows.Forms.TextBox
        Me.txtSin = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTsu = New System.Windows.Forms.TextBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.txtBirthday = New System.Windows.Forms.TextBox
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFamilyName = New System.Windows.Forms.TextBox
        Me.cmbSex = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnQuit
        '
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnQuit.Location = New System.Drawing.Point(481, 461)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(108, 32)
        Me.btnQuit.TabIndex = 1
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'Sin
        '
        Me.Sin.Text = "身体"
        Me.Sin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Sin.Width = 80
        '
        'FromDate
        '
        Me.FromDate.Text = "適用開始日"
        Me.FromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FromDate.Width = 200
        '
        'dummy
        '
        Me.dummy.Text = ""
        Me.dummy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.dummy.Width = 0
        '
        'txtFromDate
        '
        Me.txtFromDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFromDate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtFromDate.Location = New System.Drawing.Point(6, 267)
        Me.txtFromDate.Name = "txtFromDate"
        Me.txtFromDate.Size = New System.Drawing.Size(119, 26)
        Me.txtFromDate.TabIndex = 0
        Me.txtFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstUpper
        '
        Me.lstUpper.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.dummy, Me.FromDate, Me.Sin, Me.Kaj, Me.Ido, Me.Tsu})
        Me.lstUpper.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstUpper.FullRowSelect = True
        Me.lstUpper.GridLines = True
        Me.lstUpper.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstUpper.Location = New System.Drawing.Point(6, 25)
        Me.lstUpper.MultiSelect = False
        Me.lstUpper.Name = "lstUpper"
        Me.lstUpper.Size = New System.Drawing.Size(558, 229)
        Me.lstUpper.TabIndex = 6
        Me.lstUpper.TabStop = False
        Me.lstUpper.UseCompatibleStateImageBehavior = False
        Me.lstUpper.View = System.Windows.Forms.View.Details
        '
        'Kaj
        '
        Me.Kaj.Text = "家事"
        Me.Kaj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Kaj.Width = 80
        '
        'Ido
        '
        Me.Ido.Text = "移動"
        Me.Ido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Ido.Width = 80
        '
        'Tsu
        '
        Me.Tsu.Text = "通院"
        Me.Tsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Tsu.Width = 80
        '
        'txtIdo
        '
        Me.txtIdo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtIdo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtIdo.Location = New System.Drawing.Point(278, 267)
        Me.txtIdo.Name = "txtIdo"
        Me.txtIdo.Size = New System.Drawing.Size(69, 26)
        Me.txtIdo.TabIndex = 3
        Me.txtIdo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnUpdate
        '
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnUpdate.Location = New System.Drawing.Point(367, 461)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(108, 32)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "登録"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtKaj
        '
        Me.txtKaj.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtKaj.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtKaj.Location = New System.Drawing.Point(205, 267)
        Me.txtKaj.Name = "txtKaj"
        Me.txtKaj.Size = New System.Drawing.Size(67, 26)
        Me.txtKaj.TabIndex = 2
        Me.txtKaj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSin
        '
        Me.txtSin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSin.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtSin.Location = New System.Drawing.Point(131, 267)
        Me.txtSin.Name = "txtSin"
        Me.txtSin.Size = New System.Drawing.Size(68, 26)
        Me.txtSin.TabIndex = 1
        Me.txtSin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTsu)
        Me.GroupBox2.Controls.Add(Me.txtFromDate)
        Me.GroupBox2.Controls.Add(Me.lstUpper)
        Me.GroupBox2.Controls.Add(Me.txtIdo)
        Me.GroupBox2.Controls.Add(Me.txtKaj)
        Me.GroupBox2.Controls.Add(Me.txtSin)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.btnDelete)
        Me.GroupBox2.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(577, 308)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "上限情報"
        '
        'txtTsu
        '
        Me.txtTsu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTsu.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtTsu.Location = New System.Drawing.Point(353, 267)
        Me.txtTsu.Name = "txtTsu"
        Me.txtTsu.Size = New System.Drawing.Size(69, 26)
        Me.txtTsu.TabIndex = 4
        Me.txtTsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAdd
        '
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.Location = New System.Drawing.Point(498, 264)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(66, 32)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Location = New System.Drawing.Point(429, 264)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 32)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtBirthday
        '
        Me.txtBirthday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtBirthday.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtBirthday.Location = New System.Drawing.Point(110, 90)
        Me.txtBirthday.Name = "txtBirthday"
        Me.txtBirthday.Size = New System.Drawing.Size(224, 26)
        Me.txtBirthday.TabIndex = 4
        Me.txtBirthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbStatus
        '
        Me.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"対象", "非対象"})
        Me.cmbStatus.Location = New System.Drawing.Point(429, 57)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(89, 27)
        Me.cmbStatus.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(336, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 19)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "状態"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "生年月日"
        '
        'txtFamilyName
        '
        Me.txtFamilyName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFamilyName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtFamilyName.Location = New System.Drawing.Point(110, 25)
        Me.txtFamilyName.MaxLength = 20
        Me.txtFamilyName.Name = "txtFamilyName"
        Me.txtFamilyName.Size = New System.Drawing.Size(224, 26)
        Me.txtFamilyName.TabIndex = 0
        '
        'cmbSex
        '
        Me.cmbSex.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSex.FormattingEnabled = True
        Me.cmbSex.Items.AddRange(New Object() {"男性", "女性"})
        Me.cmbSex.Location = New System.Drawing.Point(110, 57)
        Me.cmbSex.Name = "cmbSex"
        Me.cmbSex.Size = New System.Drawing.Size(89, 27)
        Me.cmbSex.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "姓名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "性別"
        '
        'txtFirstName
        '
        Me.txtFirstName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFirstName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtFirstName.Location = New System.Drawing.Point(340, 25)
        Me.txtFirstName.MaxLength = 20
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(224, 26)
        Me.txtFirstName.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBirthday)
        Me.GroupBox1.Controls.Add(Me.cmbStatus)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFamilyName)
        Me.GroupBox1.Controls.Add(Me.cmbSex)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(577, 129)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "利用者情報"
        '
        'UserReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 500)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("HG教科書体", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "UserReg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "利用者登録"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents Sin As System.Windows.Forms.ColumnHeader
    Friend WithEvents FromDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents dummy As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtFromDate As System.Windows.Forms.TextBox
    Friend WithEvents lstUpper As System.Windows.Forms.ListView
    Friend WithEvents Kaj As System.Windows.Forms.ColumnHeader
    Friend WithEvents Ido As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIdo As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents txtKaj As System.Windows.Forms.TextBox
    Friend WithEvents txtSin As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtBirthday As System.Windows.Forms.TextBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFamilyName As System.Windows.Forms.TextBox
    Friend WithEvents cmbSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Tsu As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTsu As System.Windows.Forms.TextBox
End Class
