<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calendar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calendar))
        Me.Type = New System.Windows.Forms.ColumnHeader
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbHoliday = New System.Windows.Forms.ComboBox
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.txtItem = New System.Windows.Forms.TextBox
        Me.txtTarget = New System.Windows.Forms.TextBox
        Me.lstCalendar = New System.Windows.Forms.ListView
        Me.Dummy = New System.Windows.Forms.ColumnHeader
        Me.TargetDate = New System.Windows.Forms.ColumnHeader
        Me.Item = New System.Windows.Forms.ColumnHeader
        Me.Note = New System.Windows.Forms.ColumnHeader
        Me.TypeId = New System.Windows.Forms.ColumnHeader
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnQuit = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Type
        '
        Me.Type.Text = "区分"
        Me.Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Type.Width = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbHoliday)
        Me.GroupBox2.Controls.Add(Me.txtNote)
        Me.GroupBox2.Controls.Add(Me.txtItem)
        Me.GroupBox2.Controls.Add(Me.txtTarget)
        Me.GroupBox2.Controls.Add(Me.lstCalendar)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.btnDelete)
        Me.GroupBox2.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(773, 506)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "カレンダー情報"
        '
        'cmbHoliday
        '
        Me.cmbHoliday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHoliday.FormattingEnabled = True
        Me.cmbHoliday.Items.AddRange(New Object() {"休日", "通常"})
        Me.cmbHoliday.Location = New System.Drawing.Point(484, 472)
        Me.cmbHoliday.Name = "cmbHoliday"
        Me.cmbHoliday.Size = New System.Drawing.Size(106, 27)
        Me.cmbHoliday.TabIndex = 3
        '
        'txtNote
        '
        Me.txtNote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtNote.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtNote.Location = New System.Drawing.Point(314, 472)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(164, 26)
        Me.txtNote.TabIndex = 2
        Me.txtNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtItem
        '
        Me.txtItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtItem.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtItem.Location = New System.Drawing.Point(160, 473)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(148, 26)
        Me.txtItem.TabIndex = 1
        Me.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTarget
        '
        Me.txtTarget.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTarget.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtTarget.Location = New System.Drawing.Point(6, 474)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(148, 26)
        Me.txtTarget.TabIndex = 0
        Me.txtTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstCalendar
        '
        Me.lstCalendar.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Dummy, Me.TargetDate, Me.Item, Me.Note, Me.Type, Me.TypeId})
        Me.lstCalendar.FullRowSelect = True
        Me.lstCalendar.GridLines = True
        Me.lstCalendar.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstCalendar.Location = New System.Drawing.Point(6, 25)
        Me.lstCalendar.MultiSelect = False
        Me.lstCalendar.Name = "lstCalendar"
        Me.lstCalendar.Size = New System.Drawing.Size(756, 437)
        Me.lstCalendar.TabIndex = 6
        Me.lstCalendar.TabStop = False
        Me.lstCalendar.UseCompatibleStateImageBehavior = False
        Me.lstCalendar.View = System.Windows.Forms.View.Details
        '
        'Dummy
        '
        Me.Dummy.Text = ""
        Me.Dummy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dummy.Width = 0
        '
        'TargetDate
        '
        Me.TargetDate.Text = "日付"
        Me.TargetDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TargetDate.Width = 150
        '
        'Item
        '
        Me.Item.Text = "名称"
        Me.Item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Item.Width = 200
        '
        'Note
        '
        Me.Note.Text = "備考"
        Me.Note.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Note.Width = 250
        '
        'TypeId
        '
        Me.TypeId.Width = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(682, 468)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 32)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(596, 468)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 32)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnQuit.Location = New System.Drawing.Point(677, 524)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(108, 32)
        Me.btnQuit.TabIndex = 1
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnUpdate.Location = New System.Drawing.Point(563, 524)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(108, 32)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "登録"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 563)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnUpdate)
        Me.Font = New System.Drawing.Font("HG教科書体", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "Calendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "カレンダー登録"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Type As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbHoliday As System.Windows.Forms.ComboBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents txtTarget As System.Windows.Forms.TextBox
    Friend WithEvents lstCalendar As System.Windows.Forms.ListView
    Friend WithEvents Dummy As System.Windows.Forms.ColumnHeader
    Friend WithEvents TargetDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents Item As System.Windows.Forms.ColumnHeader
    Friend WithEvents Note As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents TypeId As System.Windows.Forms.ColumnHeader
End Class
