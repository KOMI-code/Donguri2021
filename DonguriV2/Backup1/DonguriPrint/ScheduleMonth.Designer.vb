<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScheduleMonth
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScheduleMonth))
        Me.btnCreate = New System.Windows.Forms.Button
        Me.btnQuit = New System.Windows.Forms.Button
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker
        Me.chkNote = New System.Windows.Forms.CheckBox
        Me.pnlView = New System.Windows.Forms.Panel
        Me.chkJob = New System.Windows.Forms.CheckBox
        Me.chkHelper = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreate.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnCreate.Location = New System.Drawing.Point(539, 4)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(108, 26)
        Me.btnCreate.TabIndex = 33
        Me.btnCreate.Text = "表示"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnQuit.Location = New System.Drawing.Point(1149, 697)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(114, 37)
        Me.btnQuit.TabIndex = 28
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'dtpMonth
        '
        Me.dtpMonth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpMonth.CustomFormat = "yyyy 年 MM 月"
        Me.dtpMonth.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonth.Location = New System.Drawing.Point(12, 5)
        Me.dtpMonth.Name = "dtpMonth"
        Me.dtpMonth.Size = New System.Drawing.Size(174, 26)
        Me.dtpMonth.TabIndex = 29
        '
        'chkNote
        '
        Me.chkNote.AutoSize = True
        Me.chkNote.Checked = True
        Me.chkNote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkNote.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.chkNote.Location = New System.Drawing.Point(446, 7)
        Me.chkNote.Name = "chkNote"
        Me.chkNote.Size = New System.Drawing.Size(68, 23)
        Me.chkNote.TabIndex = 32
        Me.chkNote.Text = "備考"
        Me.chkNote.UseVisualStyleBackColor = True
        '
        'pnlView
        '
        Me.pnlView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlView.Location = New System.Drawing.Point(13, 37)
        Me.pnlView.Name = "pnlView"
        Me.pnlView.Size = New System.Drawing.Size(1250, 652)
        Me.pnlView.TabIndex = 27
        '
        'chkJob
        '
        Me.chkJob.AutoSize = True
        Me.chkJob.Checked = True
        Me.chkJob.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkJob.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkJob.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.chkJob.Location = New System.Drawing.Point(198, 7)
        Me.chkJob.Name = "chkJob"
        Me.chkJob.Size = New System.Drawing.Size(108, 23)
        Me.chkJob.TabIndex = 30
        Me.chkJob.Text = "業務内容"
        Me.chkJob.UseVisualStyleBackColor = True
        '
        'chkHelper
        '
        Me.chkHelper.AutoSize = True
        Me.chkHelper.Checked = True
        Me.chkHelper.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHelper.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkHelper.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.chkHelper.Location = New System.Drawing.Point(312, 7)
        Me.chkHelper.Name = "chkHelper"
        Me.chkHelper.Size = New System.Drawing.Size(128, 23)
        Me.chkHelper.TabIndex = 31
        Me.chkHelper.Text = "ヘルパー名"
        Me.chkHelper.UseVisualStyleBackColor = True
        '
        'ScheduleMonth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1274, 741)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.dtpMonth)
        Me.Controls.Add(Me.chkNote)
        Me.Controls.Add(Me.pnlView)
        Me.Controls.Add(Me.chkJob)
        Me.Controls.Add(Me.chkHelper)
        Me.Font = New System.Drawing.Font("HG教科書体", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "ScheduleMonth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "月次予定表"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkNote As System.Windows.Forms.CheckBox
    Friend WithEvents pnlView As System.Windows.Forms.Panel
    Friend WithEvents chkJob As System.Windows.Forms.CheckBox
    Friend WithEvents chkHelper As System.Windows.Forms.CheckBox
End Class
