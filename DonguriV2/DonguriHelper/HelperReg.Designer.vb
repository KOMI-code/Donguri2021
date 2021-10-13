<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelperReg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelperReg))
        Me.cmbAccount = New System.Windows.Forms.ComboBox
        Me.txtThirdName = New System.Windows.Forms.TextBox
        Me.txtBirthday = New System.Windows.Forms.TextBox
        Me.cmbSlave = New System.Windows.Forms.ComboBox
        Me.SlaveId = New System.Windows.Forms.ColumnHeader
        Me.lstSlave = New System.Windows.Forms.ListView
        Me.SlaveName = New System.Windows.Forms.ColumnHeader
        Me.Account = New System.Windows.Forms.ColumnHeader
        Me.AccountMag = New System.Windows.Forms.ColumnHeader
        Me.btnQuit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.txtSecondName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFamilyName = New System.Windows.Forms.TextBox
        Me.cmbSex = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbAccount
        '
        Me.cmbAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccount.FormattingEnabled = True
        Me.cmbAccount.Items.AddRange(New Object() {"課金なし", "課金あり"})
        Me.cmbAccount.Location = New System.Drawing.Point(250, 263)
        Me.cmbAccount.Name = "cmbAccount"
        Me.cmbAccount.Size = New System.Drawing.Size(137, 27)
        Me.cmbAccount.TabIndex = 1
        '
        'txtThirdName
        '
        Me.txtThirdName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtThirdName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtThirdName.Location = New System.Drawing.Point(342, 59)
        Me.txtThirdName.MaxLength = 20
        Me.txtThirdName.Name = "txtThirdName"
        Me.txtThirdName.Size = New System.Drawing.Size(224, 26)
        Me.txtThirdName.TabIndex = 3
        '
        'txtBirthday
        '
        Me.txtBirthday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtBirthday.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtBirthday.Location = New System.Drawing.Point(112, 124)
        Me.txtBirthday.Name = "txtBirthday"
        Me.txtBirthday.Size = New System.Drawing.Size(224, 26)
        Me.txtBirthday.TabIndex = 6
        Me.txtBirthday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbSlave
        '
        Me.cmbSlave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbSlave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSlave.FormattingEnabled = True
        Me.cmbSlave.Location = New System.Drawing.Point(6, 263)
        Me.cmbSlave.Name = "cmbSlave"
        Me.cmbSlave.Size = New System.Drawing.Size(231, 27)
        Me.cmbSlave.TabIndex = 0
        '
        'SlaveId
        '
        Me.SlaveId.Text = ""
        Me.SlaveId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SlaveId.Width = 0
        '
        'lstSlave
        '
        Me.lstSlave.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SlaveId, Me.SlaveName, Me.Account, Me.AccountMag})
        Me.lstSlave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstSlave.FullRowSelect = True
        Me.lstSlave.GridLines = True
        Me.lstSlave.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstSlave.Location = New System.Drawing.Point(6, 25)
        Me.lstSlave.MultiSelect = False
        Me.lstSlave.Name = "lstSlave"
        Me.lstSlave.Size = New System.Drawing.Size(560, 229)
        Me.lstSlave.TabIndex = 6
        Me.lstSlave.TabStop = False
        Me.lstSlave.UseCompatibleStateImageBehavior = False
        Me.lstSlave.View = System.Windows.Forms.View.Details
        '
        'SlaveName
        '
        Me.SlaveName.Text = "従属者"
        Me.SlaveName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SlaveName.Width = 325
        '
        'Account
        '
        Me.Account.Text = "課金情報"
        Me.Account.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Account.Width = 200
        '
        'AccountMag
        '
        Me.AccountMag.Width = 0
        '
        'btnQuit
        '
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnQuit.Location = New System.Drawing.Point(483, 489)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(108, 32)
        Me.btnQuit.TabIndex = 1
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.Location = New System.Drawing.Point(486, 260)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 32)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(369, 489)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(108, 32)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "登録"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Location = New System.Drawing.Point(400, 260)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 32)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbAccount)
        Me.GroupBox2.Controls.Add(Me.cmbSlave)
        Me.GroupBox2.Controls.Add(Me.lstSlave)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.btnDelete)
        Me.GroupBox2.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 183)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(579, 300)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "従属情報"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(338, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 19)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "状態"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtThirdName)
        Me.GroupBox1.Controls.Add(Me.txtBirthday)
        Me.GroupBox1.Controls.Add(Me.cmbStatus)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtSecondName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFamilyName)
        Me.GroupBox1.Controls.Add(Me.cmbSex)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(579, 165)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ヘルパー情報"
        '
        'cmbStatus
        '
        Me.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"対象", "非対象"})
        Me.cmbStatus.Location = New System.Drawing.Point(407, 91)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(89, 27)
        Me.cmbStatus.TabIndex = 5
        '
        'txtSecondName
        '
        Me.txtSecondName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtSecondName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtSecondName.Location = New System.Drawing.Point(112, 59)
        Me.txtSecondName.MaxLength = 20
        Me.txtSecondName.Name = "txtSecondName"
        Me.txtSecondName.Size = New System.Drawing.Size(224, 26)
        Me.txtSecondName.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "生年月日"
        '
        'txtFamilyName
        '
        Me.txtFamilyName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFamilyName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtFamilyName.Location = New System.Drawing.Point(112, 27)
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
        Me.cmbSex.Location = New System.Drawing.Point(112, 91)
        Me.cmbSex.Name = "cmbSex"
        Me.cmbSex.Size = New System.Drawing.Size(89, 27)
        Me.cmbSex.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "姓名"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "性別"
        '
        'txtFirstName
        '
        Me.txtFirstName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtFirstName.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtFirstName.Location = New System.Drawing.Point(342, 27)
        Me.txtFirstName.MaxLength = 20
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(224, 26)
        Me.txtFirstName.TabIndex = 1
        '
        'HelperReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 529)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("HG教科書体", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "HelperReg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ヘルパー登録"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbAccount As System.Windows.Forms.ComboBox
    Friend WithEvents txtThirdName As System.Windows.Forms.TextBox
    Friend WithEvents txtBirthday As System.Windows.Forms.TextBox
    Friend WithEvents cmbSlave As System.Windows.Forms.ComboBox
    Friend WithEvents SlaveId As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstSlave As System.Windows.Forms.ListView
    Friend WithEvents SlaveName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Account As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtSecondName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFamilyName As System.Windows.Forms.TextBox
    Friend WithEvents cmbSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents AccountMag As System.Windows.Forms.ColumnHeader
End Class
