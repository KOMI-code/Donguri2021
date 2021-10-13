<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorCheck))
        Me.btnCheck = New System.Windows.Forms.Button
        Me.btnQuit = New System.Windows.Forms.Button
        Me.lstAnser = New System.Windows.Forms.ListBox
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'btnCheck
        '
        Me.btnCheck.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnCheck.Location = New System.Drawing.Point(192, 12)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(114, 26)
        Me.btnCheck.TabIndex = 21
        Me.btnCheck.Text = "確認"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.btnQuit.Location = New System.Drawing.Point(750, 472)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(114, 30)
        Me.btnQuit.TabIndex = 20
        Me.btnQuit.Text = "閉じる"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'lstAnser
        '
        Me.lstAnser.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.lstAnser.FormattingEnabled = True
        Me.lstAnser.ItemHeight = 19
        Me.lstAnser.Location = New System.Drawing.Point(12, 44)
        Me.lstAnser.Name = "lstAnser"
        Me.lstAnser.Size = New System.Drawing.Size(852, 422)
        Me.lstAnser.TabIndex = 19
        '
        'dtpMonth
        '
        Me.dtpMonth.CustomFormat = "yyyy 年 MM 月"
        Me.dtpMonth.Font = New System.Drawing.Font("HGｺﾞｼｯｸM", 14.25!)
        Me.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonth.Location = New System.Drawing.Point(12, 12)
        Me.dtpMonth.Name = "dtpMonth"
        Me.dtpMonth.Size = New System.Drawing.Size(174, 26)
        Me.dtpMonth.TabIndex = 18
        '
        'ErrorCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 510)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.lstAnser)
        Me.Controls.Add(Me.dtpMonth)
        Me.Font = New System.Drawing.Font("HG教科書体", 14.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "ErrorCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "登録確認"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents lstAnser As System.Windows.Forms.ListBox
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
End Class
