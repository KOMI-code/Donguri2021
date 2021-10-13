<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScheduleDay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScheduleDay))
        Me.btnQuit = New System.Windows.Forms.Button
        Me.btnCreate = New System.Windows.Forms.Button
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.pnlView = New System.Windows.Forms.Panel
        Me.chkA3 = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'btnQuit
        '
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnQuit.Location = New System.Drawing.Point(1148, 698)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(114, 37)
        Me.btnQuit.TabIndex = 40
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreate.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnCreate.Location = New System.Drawing.Point(204, 8)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(108, 26)
        Me.btnCreate.TabIndex = 39
        Me.btnCreate.Text = "表示"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpDate.CustomFormat = "yyyy 年 MM 月"
        Me.dtpDate.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.dtpDate.Location = New System.Drawing.Point(12, 8)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(186, 26)
        Me.dtpDate.TabIndex = 38
        '
        'pnlView
        '
        Me.pnlView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlView.Location = New System.Drawing.Point(12, 40)
        Me.pnlView.Name = "pnlView"
        Me.pnlView.Size = New System.Drawing.Size(1250, 652)
        Me.pnlView.TabIndex = 37
        '
        'chkA3
        '
        Me.chkA3.AutoSize = True
        Me.chkA3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkA3.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.chkA3.Location = New System.Drawing.Point(328, 11)
        Me.chkA3.Name = "chkA3"
        Me.chkA3.Size = New System.Drawing.Size(88, 23)
        Me.chkA3.TabIndex = 41
        Me.chkA3.Text = "A3出力"
        Me.chkA3.UseVisualStyleBackColor = True
        '
        'ScheduleDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1274, 741)
        Me.Controls.Add(Me.chkA3)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.pnlView)
        Me.Font = New System.Drawing.Font("HG教科書体", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "ScheduleDay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "日次予定表"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlView As System.Windows.Forms.Panel
    Friend WithEvents chkA3 As System.Windows.Forms.CheckBox
End Class
