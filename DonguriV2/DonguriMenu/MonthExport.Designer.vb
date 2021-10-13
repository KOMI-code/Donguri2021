<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthExport
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
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker
        Me.btnQuit = New System.Windows.Forms.Button
        Me.btnWrite = New System.Windows.Forms.Button
        Me.fbDlg = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'dtpMonth
        '
        Me.dtpMonth.CustomFormat = "yyyy 年 MM 月"
        Me.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonth.Location = New System.Drawing.Point(12, 12)
        Me.dtpMonth.Name = "dtpMonth"
        Me.dtpMonth.Size = New System.Drawing.Size(204, 26)
        Me.dtpMonth.TabIndex = 0
        '
        'btnQuit
        '
        Me.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnQuit.Location = New System.Drawing.Point(117, 44)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(99, 32)
        Me.btnQuit.TabIndex = 10
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnWrite
        '
        Me.btnWrite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnWrite.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnWrite.Location = New System.Drawing.Point(12, 44)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(99, 32)
        Me.btnWrite.TabIndex = 9
        Me.btnWrite.Text = "書出"
        Me.btnWrite.UseVisualStyleBackColor = True
        '
        'fbDlg
        '
        Me.fbDlg.Description = "フォルダを指定してください。"
        Me.fbDlg.ShowNewFolderButton = False
        '
        'MonthExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(224, 82)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnWrite)
        Me.Controls.Add(Me.dtpMonth)
        Me.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "MonthExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "スケジュール書出"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnWrite As System.Windows.Forms.Button
    Friend WithEvents fbDlg As System.Windows.Forms.FolderBrowserDialog
End Class
